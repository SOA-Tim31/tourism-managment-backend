using System.Net.Http;
using System.Text;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Explorer.API.Controllers.Tourist.EncounterExecution
{
    //[Authorize(Policy = "touristPolicy")]
    [Route("api/encounterExecution")]
    public class EncounterExecutionController : BaseApiController
    {
        private readonly IEncounterExecutionService _encounterExecutionService;
        private readonly ISocialEncounterService _socialEncounterService;
        private readonly IHiddenLocationEncounterService _hiddenLocationEncounterService;
        private readonly HttpClient _httpClient;

        public EncounterExecutionController(IEncounterExecutionService service, ISocialEncounterService socialEncounterService, IHiddenLocationEncounterService hiddenLocationEncounterService)
        {
            _encounterExecutionService = service;
            _socialEncounterService = socialEncounterService;
            _hiddenLocationEncounterService = hiddenLocationEncounterService;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://encounters:8083")
            };
        }

        /*[HttpGet]
        public ActionResult<PagedResult<EncounterExecutionDto>> GePaged([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _encounterExecutionService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }*/

        [HttpGet]
        public async Task<ActionResult<List<EncounterExecutionDto>>> GetAllEncounterExecutionsDto()
        {
            try
            {
                // Assuming you have an HttpClient configured already
                using HttpResponseMessage response = await _httpClient.GetAsync("getEncounterExecutions");

                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var encounterDtos = JsonConvert.DeserializeObject<List<EncounterExecutionDto>>(jsonResponse);

                return Ok(encounterDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving encounters: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<EncounterExecutionDto>> Create([FromBody] EncounterExecutionDto encounterExecution)
        {
            try
            {


                var json = System.Text.Json.JsonSerializer.Serialize(encounterExecution);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using HttpResponseMessage response = await _httpClient.PostAsync("/createEncounterExecution", content);

                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                return Ok(jsonResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating execution: {ex.Message}");
            }
        }
        [HttpPut("{id:int}")]
        public ActionResult<EncounterExecutionDto> Update([FromBody] EncounterExecutionDto encounterExecution)
        {
            var result = _encounterExecutionService.Update(encounterExecution);
            return CreateResponse(result);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _encounterExecutionService.Delete(id);
            return CreateResponse(result);
        }

        [HttpGet("checkSocialEncounter/{encounterId:int}")]
        public PagedResult<EncounterExecutionDto> CheckSocialEncounter(int encounterId)
        {
            _socialEncounterService.CheckSocialEncounter(encounterId);

            List<EncounterExecutionDto> result = new List<EncounterExecutionDto>();
            result = _encounterExecutionService.GetAllExecutionsByEncounter(encounterId);

            return new PagedResult<EncounterExecutionDto>(result, result.Count);
        }

        [HttpGet("getActive/{userId:int}")]
        public async Task<ActionResult<EncounterExecutionDto>> GetActiveByUser([FromRoute] int userId)
        {
            try
            {
                // Send a GET request to the backend API to fetch the tour by user ID
                HttpResponseMessage response = await _httpClient.GetAsync($"activeEncounterByUserId/{userId}");

                // Ensure a successful response
                response.EnsureSuccessStatusCode();

                // Read the response content as a string
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into a single TourCreationDto object
                var encounterExecutionDto = JsonConvert.DeserializeObject<EncounterExecutionDto>(jsonResponse);

                // Return the TourCreationDto object as ActionResult
                return Ok(encounterExecutionDto);
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error with the error message if an exception occurs
                return StatusCode(500, $"An error occurred while retrieving encounter creation data: {ex.Message}");
            }
        }

        [HttpGet("checkHidden/{executionId:int}/{encounterId:int}")]
        public ActionResult<bool> GetBooleanValue(int executionId, int encounterId)
        {
            var result = _hiddenLocationEncounterService.CheckHiddenLocationEncounter(executionId, encounterId);

            return Ok(result);
        }

        [HttpGet("completeExecution/{userId:int}")]
        public async Task<ActionResult<EncounterExecutionDto>> CompleteExecution(int userId)
        {
            try
            {
                // Make HTTP request to Go backend to complete encounter execution
                using (HttpResponseMessage response = await _httpClient.GetAsync($"completeExecution/{userId}"))
                {
                    response.EnsureSuccessStatusCode();

                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var encounterExecutionDto = JsonConvert.DeserializeObject<EncounterExecutionDto>(jsonResponse);

                    return Ok(encounterExecutionDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while completing encounter execution: {ex.Message}");
            }
        }


    }
}