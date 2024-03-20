using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain.TourBundle;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Administration
{
    public class TourBundleService : CrudService<TourBundleDto, TourBundle>, ITourBundleService
    {
        private readonly ITourService _tourService;
        private readonly ICrudRepository<TourBundle> _respository;
        public TourBundleService(ICrudRepository<TourBundle> repository, IMapper mapper, ITourService tourService) : base(repository, mapper) {
            this._tourService = tourService;
            this._respository = repository;
        }

        public Result<PagedResult<TourDTO>> GetToursByBundle(List<int> tourIds)
        {
            List<TourDTO> tours = new List<TourDTO>();

            foreach (int tourId in tourIds)
            {
                var tourResult = this._tourService.GetTourByTourId(tourId);

                if (tourResult.IsSuccess)
                {
                    tours.Add(tourResult.Value);
                }
            }

            var filteredPagedResult = new PagedResult<TourDTO>(tours, tours.Count());

            return Result.Ok(filteredPagedResult);
        }


        public Result<PagedResult<TourBundleDto>> GetPublishedBundles(int page, int pageSize)
        {
            var allTourBundles =  _respository.GetPaged(page, pageSize);

            var filteredPublishedTourBundles = allTourBundles.Results.Where(tourBundle => tourBundle.Status.ToString() == "Published" );

            var filteredPagedResult = new PagedResult<TourBundle>(filteredPublishedTourBundles.ToList(), filteredPublishedTourBundles.Count());

            
            return MapToDto(filteredPagedResult);
        }

    }
}
