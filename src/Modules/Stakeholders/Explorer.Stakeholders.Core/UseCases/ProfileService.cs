using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases;

public class ProfileService : BaseService<UserProfileDto, Person>, IProfileService
{
    private readonly ICrudRepository<Person> _personRepository;
    private readonly IUserRepository _userRepository;
    public ProfileService(IUserRepository userRepository, ICrudRepository<Person> personRepository, IMapper mapper) : base(mapper) {
        
        _personRepository = personRepository;
        _userRepository = userRepository;
    }

    public Result<UserProfileDto> Get(int userId)
    {
        try
        {
            // Use the _personRepository to fetch the Person entity by userId.
            var person = _personRepository.Get(_userRepository.GetPersonId(userId));

            if (person == null)
            {
                return Result.Fail("User profile not found");
            }

            // Map the Person entity to UserProfileDto.
            var userProfileDto = MapToDto(person);
            return Result.Ok(userProfileDto);
        }
        catch (Exception ex)
        {
            // Handle any exceptions or errors that occur during the data retrieval process.
            return Result.Fail("Error occurred while fetching the user profile: " + ex.Message);
        }
    }

	

	public Result<UserProfileDto> Update(UserProfileDto userProfile)
    {
        try
        {
            var result = _personRepository.Update(MapToDomain(userProfile));
            return MapToDto(result);
        }
        catch (KeyNotFoundException e)
        {
            return Result.Fail(FailureCode.NotFound).WithError(e.Message);
        }
        catch (ArgumentException e)
        {
            return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
        }
    }
}
