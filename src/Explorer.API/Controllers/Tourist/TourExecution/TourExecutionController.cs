using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.TourExecutionsDTO;
using Explorer.Tours.API.Public.TourExecuting;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.TourExecutions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

namespace Explorer.API.Controllers.Tourist.TourExecution
{
	//[Authorize(Policy = "touristPolicy")]
	[Route("api/tourExecution")]
	public class TourExecutionController : BaseApiController
	{
		private readonly ITourExecutionService _tourExecutionService;

		public TourExecutionController(ITourExecutionService service)
		{
			_tourExecutionService = service;
		}

		[HttpGet("{tourExecutionId:int}")]
		public ActionResult<PagedResult<TourExecutionDto>> GetById(int tourExecutionId)
		{
			var result = _tourExecutionService.GetById(tourExecutionId);
			return CreateResponse(result);
		}

		[HttpGet("user/{userId:int}")]
		public ActionResult<PagedResult<TourExecutionDto>> GetByUser(int userId)
		{
			var result = _tourExecutionService.GetByUser(userId);
			return CreateResponse(result);
		}

		[HttpPut("{tourExecutionId}/update-position/{longitude}/{latitude}")]
		public IActionResult UpdatePosition(int tourExecutionId, double longitude, double latitude)
		{
			try
			{
				_tourExecutionService.UpdatePosition(tourExecutionId, longitude, latitude);
				_tourExecutionService.IsFinished(tourExecutionId);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest($"Error updating position: {ex.Message}");
			}
		}

		[HttpPut("{tourExecutionId}/update-status/{status}")]
		public IActionResult UpdateStatus(int tourExecutionId, string status)
		{
			try
			{
				_tourExecutionService.UpdateStatus(tourExecutionId, status);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest($"Error updating status: {ex.Message}");
			}
		}


		[HttpPost("{tourExecutionId}/complete/{tourPointId}")]
		public IActionResult CompleteTourPoint(int tourExecutionId, int tourPointId)
		{
			try
			{
				_tourExecutionService.CompleteTourPoint(tourExecutionId, tourPointId);

				return Ok();
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex);
				return StatusCode(500, "An error occurred while completing the tour point.");
			}
		}
		[HttpPost("create/{userId:int}/{tourId:int}")]
		public ActionResult<TourExecutionDto> CreateTourExecution(int userId, int tourId)
		{
			try
			{
				var result = _tourExecutionService.Create(userId, tourId, 0, 0);
				return CreateResponse(result);

				//return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest($"Error creating TourExecution: {ex.Message}");
			}
		}


		//dodato zbog TourRating
		[HttpGet("allExecutions")]
		public ActionResult<PagedResult<TourExecutionDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
		{
			var result = _tourExecutionService.GetAll(page, pageSize);
			return CreateResponse(result);
		}

		[HttpGet("getPoints/{executionId:int}")]
		public ActionResult<PagedResult<TourPointExecutionDto>> GetPointsByExecution(int executionId)
		{
			var result = _tourExecutionService.GetPointsByExecution(executionId);
			return CreateResponse(result);
		}
	}
}