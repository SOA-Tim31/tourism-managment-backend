using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.TourExecutionsDTO;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.TourExecuting
{
    public interface ITourExecutionService
    {
       public Result<TourExecutionDto> GetById(int tourExecutionId);
       public void UpdatePosition(int tourExecutionId, double longitude, double latitude);
        public void CompleteTourPoint(int tourExecutionId, int tourPointId);
       public Result<TourExecutionDto> GetByUser(int userId);
        public void UpdateStatus(int tourExecutionId, string status);

       public bool IsFinished(int tourExecutionId);
        public Result<TourExecutionDto> Create(int userId, int tourId, double longitude, double latitude);
        public Result<PagedResult<TourExecutionDto>> GetAll(int page, int pageSize);
        public Result<PagedResult<TourPointExecutionDto>> GetPointsByExecution(int executionId);
        public List<TourExecutionDto> GetExecutionsByUser(int userId);

        public bool IsTourStarted(int tourId);
        public bool IsTourFinished(int tourId);

        public List<TourExecutionDto> GetAllExecutionsByTour(int tourId);
    }
}
