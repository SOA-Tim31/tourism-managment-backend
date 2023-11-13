﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    internal class TourRepository : ITourRepository
	{
		private readonly DbSet<Tour> _tours;
		private readonly ToursContext _context;

		public TourRepository(ToursContext context)
		{
			 _context = context;
			 _tours = _context.Set<Tour>();
		}
		

		public PagedResult<Tour> GetByUserId(int userId, int page, int pageSize)
		{
			var tours= _tours.Include(t => t.TourPoints).Where(t=>t.GuideId == userId).GetPagedById(page, pageSize);
			return tours.Result;
		}

        public Tour GetById(int tourId)
		{
            var tour = _tours.Include(t => t.TourPoints).Where(t => t.Id == tourId).FirstOrDefault();

            return tour;
        }

        public Result DeleteAgreggate(int tourId)
		{
			var tourToDelete = _tours.Where(t => t.Id == tourId).Include(t => t.TourPoints).FirstOrDefault();
			if(tourToDelete != null)
			{
				_context.RemoveRange(tourToDelete.TourPoints);
				_context.Remove(tourToDelete);

				_context.SaveChanges();
				return Result.Ok();
			}

			return Result.Fail("Tour not found");
		}
	}
}
