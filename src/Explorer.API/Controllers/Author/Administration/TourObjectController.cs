using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.UseCases.Administration;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Explorer.API.Controllers.Author.Administration
{

    [Route("api/administration/object")]
    public class ObjectController : BaseApiController
    {
        private readonly ITourObjectService _objectService;

        public ObjectController(ITourObjectService objectService, HttpClient httpClient)
        {
            _objectService = objectService;
            _httpClient = httpClient;

        }

        private readonly HttpClient _httpClient;


        [HttpGet]
        public async Task<ActionResult<List<TourObjectDto>>> GetAll()
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://tours:8000/");

            try
            {
                var response = await httpClient.GetAsync("objects");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Result<List<TourObjectDto>> accounts = JsonConvert.DeserializeObject<List<TourObjectDto>>(content);
                    return CreateResponse(accounts);
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Failed to retrieve accounts from the other app.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while communicating with the other app: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TourObjectDto>> CreateAsync([FromBody] TourObjectDto tourObject)
        {
			var response = await _httpClient.PostAsJsonAsync("http://tours:8000/objects", tourObject);

			if (!response.IsSuccessStatusCode)
			{
				return StatusCode((int)response.StatusCode);
			}

			return Ok();
		}

        [HttpPut("{id:int}")]
        public ActionResult<TourObjectDto> Update([FromBody] TourObjectDto tourObject)
        {
            var result = _objectService.Update(tourObject);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _objectService.Delete(id);
            return CreateResponse(result);
        }

		[HttpGet("{id:int}")]

		public ActionResult<TourObjectDto> GetById(int id)
		{
			var result = _objectService.Get(id);
			return CreateResponse(result);
		}
	}
}
