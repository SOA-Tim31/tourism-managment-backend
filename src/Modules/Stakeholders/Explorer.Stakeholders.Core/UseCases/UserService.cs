﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class UserService : CrudService<UserDto, User>, IUserService
    {
        public UserService(ICrudRepository<User> crudRepository, IMapper mapper) : base(crudRepository, mapper) {}

        public Result<PagedResult<UserDto>> GetAll()
        {
            return GetPaged(0, 0);
        }
    }
}
