using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Explorer.API.Controllers;

[Route("api/users")]
public class AuthenticationController : BaseApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    

    [HttpPost]
    public ActionResult<AuthenticationTokensDto> RegisterTourist([FromBody] AccountRegistrationDto account)
    {
        var result = _authenticationService.RegisterTourist(account);

        
        
		return CreateResponse(result);
    }

    [HttpPost("login")]
	public ActionResult<AuthenticationTokensDto> Login([FromBody] CredentialsDto credentials)
	{
		var result = _authenticationService.Login(credentials);
		return CreateResponse(result);
	}
	public class PasswordResetRequestDto
    {
        public string Email { get; set; }
    }

    [HttpPost("request")]
    public ActionResult<string> RequestPasswordReset([FromBody] PasswordResetRequestDto request)
    {
        var result = _authenticationService.RequestPasswordReset(request.Email);
        return CreateResponse(result);
    }

    [HttpPost("reset")]
    public ActionResult<string> ResetPassword([FromBody] PasswordResetDto request)
    {
        var result = _authenticationService.ResetPassword(request);
        return CreateResponse(result);
    }
}