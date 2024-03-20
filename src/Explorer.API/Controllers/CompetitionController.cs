using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.UseCases.Authoring;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Explorer.API.Controllers
{
	[Route("api/competition")]
	public class CompetitionController : BaseApiController
	{
		private readonly ICompetitionService _competitionService;
		private readonly HttpClient _httpClient;

		public CompetitionController(ICompetitionService competitionService, HttpClient httpClient)
		{
			_competitionService = competitionService;
			_httpClient = httpClient;
		}



		[HttpPost]
		public async Task<ActionResult<CompetitionDto>> Create([FromBody] CompetitionDto competition)
		{
			var response = await _httpClient.PostAsJsonAsync("http://localhost:8000/competitions", competition);

			if (!response.IsSuccessStatusCode)
			{
				return StatusCode((int)response.StatusCode);
			}

			return Ok();

			
		}

		


		[HttpGet("allCompetitions")]
		public async  Task<ActionResult<PagedResult<CompetitionDto>>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
		{
			var apiUrl = $"http://localhost:8000/competitions";
			var response = await _httpClient.GetAsync(apiUrl);

			if (!response.IsSuccessStatusCode)
			{
				return StatusCode((int)response.StatusCode);
			}

			var responseBody = await response.Content.ReadAsStringAsync();
			var competitions = JsonConvert.DeserializeObject<List<CompetitionDto>>(responseBody);
			Result<PagedResult<CompetitionDto>> pagedResult = new PagedResult<CompetitionDto>(competitions, competitions.Count);


			return CreateResponse(pagedResult);

		}



		[HttpGet("getAllCompetitionAuthorId/{id}")]
        public ActionResult<PagedResult<CompetitionDto>> GetAllCompetitionAuthorId(int id, [FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _competitionService.GetAllCompetitionAuthorId(page, pageSize, id);
            return CreateResponse(result);
        }
    }
}
