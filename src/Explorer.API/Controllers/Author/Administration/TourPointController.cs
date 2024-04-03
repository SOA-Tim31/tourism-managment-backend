using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.UseCases.Administration;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Explorer.API.Controllers.Author.Administration
{

   // [Authorize(Policy = "authorAndAdminPolicy")]

    [Route("api/administration/tourPoint")] 
    public class TourPointController : BaseApiController
    {
        private readonly ITourPointService _tourPointService;

        private readonly HttpClient _httpClient;

        public TourPointController(ITourPointService tourPointService, HttpClient httpClient)
        {
            _tourPointService = tourPointService;
            _httpClient = httpClient;
        }
        [Authorize(Policy = "authorPolicy")]
        [HttpGet]
        public ActionResult<PagedResult<TourPointDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tourPointService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

	

		[HttpPost]
       
        public async Task<ActionResult<PagedResult<TourPointDto>>> Create([FromBody] TourPointDto tourPoint)
        {
         

			var response = await _httpClient.PostAsJsonAsync("http://tours:8000/tourPoints", tourPoint);

			if (!response.IsSuccessStatusCode)
			{
				return StatusCode((int)response.StatusCode);
			}

			return Ok();
		}


        [Authorize(Policy = "authorPolicy")]
        [HttpPut("{id:int}")]
        public ActionResult<TourPointDto> Update([FromBody] TourPointDto tourPoint)
        {
            var result = _tourPointService.Update(tourPoint);
            return CreateResponse(result);
        }

        [Authorize(Policy = "authorPolicy")]
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _tourPointService.Delete(id);
            return CreateResponse(result);
        }

        
        [HttpGet("{tourId:int}")]

		public async Task<ActionResult<List<TourPointDto>>> GetTourPointsByTourId(int tourId)
		{
			var result = _tourPointService.GetTourPointsByTourId(tourId);
			return CreateResponse(result);
		}



		

		[HttpGet("getById/{id:int}")]
        public ActionResult<TourPointDto> GetTourPointById(int id)
        {
            var result = _tourPointService.Get(id);
            return CreateResponse(Result.Ok(result));
        }

    }
}
