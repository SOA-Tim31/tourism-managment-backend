using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using Explorer.Stakeholders.API.Dtos;

namespace Explorer.Stakeholders.API.Public;

public interface IProfileService
{
    Result<UserProfileDto> Get(int userId);
    Result<UserProfileDto> Update(UserProfileDto userProfile);

   
}
