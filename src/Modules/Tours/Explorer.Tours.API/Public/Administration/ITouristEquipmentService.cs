﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Administration
{
    public interface ITouristEquipmentService
    {

        Result<PagedResult<TouristEquipmentDto>> GetPaged(int page, int pageSize);
        Result<TouristEquipmentDto> Update(TouristEquipmentDto touristEquipment);
        Result<TouristEquipmentDto> Create(TouristEquipmentDto touristEquipment);
        Result Delete(int touristEquipmentDtoId);

    }
}
