using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;

namespace Explorer.Stakeholders.Core.UseCases;

public class AuthenticationService : IAuthenticationService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IPasswordResetRepository _passwordResetRepository;
	private readonly HttpClient _httpClient;

	public AuthenticationService(IUserRepository userRepository, IPersonRepository personRepository, ITokenGenerator tokenGenerator, IPasswordResetRepository passwordResetRepository, HttpClient httpClient)
    {
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
        _personRepository = personRepository;
        _passwordResetRepository = passwordResetRepository;
        _httpClient = httpClient;
    }

    public Result<AuthenticationTokensDto> Login(CredentialsDto credentials)
    {
        var user = _userRepository.GetActiveByName(credentials.Username);
        if (user == null || !VerifyPassword(credentials.Password, user.Password)) return Result.Fail(FailureCode.NotFound);

        long personId;
        try
        {
            personId = _userRepository.GetPersonId(user.Id);
        }
        catch (KeyNotFoundException)
        {
            personId = 0;
        }
        return _tokenGenerator.GenerateAccessToken(user, personId);
    }

    public Result<AuthenticationTokensDto> RegisterTourist(AccountRegistrationDto account)
    {
        if(_userRepository.Exists(account.Username)) return Result.Fail(FailureCode.NonUniqueUsername);
        if(_personRepository.Exists(account.Email)) return Result.Fail("Email already in use");

        try
        {
            string verificationToken = GenerateUniqueVerificationToken();
            var user = _userRepository.Create(new User(account.Username, SetPassword(account.Password), UserRole.Tourist, false, verificationToken));
            var person = _personRepository.Create(new Person(user.Id, account.Name, account.Surname, account.Email, "", "", ""));

            GraphUser graphUser = new GraphUser(user.Id, user.Username);
		   _httpClient.PostAsJsonAsync("http://followers:89/user", graphUser);

			var emailSender = new EmailSenderService();
            emailSender.SendVerificationEmail(person.Email, verificationToken);

            return _tokenGenerator.GenerateAccessToken(user, person.Id);
        }
        catch (ArgumentException e)
        {
            return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            // There is a subtle issue here. Can you find it?
        }
    }

    public Result<string> RequestPasswordReset(string mail)
    {
        var person = _personRepository.GetByEmail(mail);
        if (person == null) return Result.Fail("Email not found");
        var user = _userRepository.Get(person.UserId);
        if (user == null) return Result.Fail("User not found");

        var token = Guid.NewGuid().ToString();
        var resetEntry = new PasswordReset(user.Id, token, DateTime.UtcNow.AddMinutes(15));

        var oldResetEntry = _passwordResetRepository.GetByUserId(user.Id);
        if (oldResetEntry != null)
        {
            _passwordResetRepository.Delete(oldResetEntry);
        }

        _passwordResetRepository.Create(resetEntry);

        var emailSender = new EmailSenderService();
        emailSender.SendPasswordResetEmail(person.Email, token);

        return Result.Ok("Request sent");
    }

    public Result<string> ResetPassword(PasswordResetDto request)
    {
        var resetEntry = _passwordResetRepository.ValidateToken(request.Token);
        if (resetEntry == null) return Result.Fail("Invalid or expired token");

        var user = _userRepository.Get(resetEntry.UserId);
        if (user == null) return Result.Fail("User not found");
        user.Password = SetPassword(request.Password);
        var savedUser = _userRepository.Update(user);

        _passwordResetRepository.Delete(resetEntry);

        return Result.Ok("Password reset");
    }

    private string SetPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Password cannot be empty");

        string PasswordHash;

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            PasswordHash = Convert.ToBase64String(hashedBytes);
        }

        return PasswordHash;
    }

    private bool VerifyPassword(string enteredPassword, string userPassword)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));

            string enteredPasswordHash = Convert.ToBase64String(hashedBytes);

            return enteredPasswordHash == userPassword;
        }
    }

    private string GenerateUniqueVerificationToken()
    {
        byte[] tokenBytes = new byte[32];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(tokenBytes);
        }

        string verificationToken = BitConverter.ToString(tokenBytes).Replace("-", "").ToLower();

        return verificationToken;
    }
}