using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.UseCases.Administration;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace Explorer.API.Controllers.Tourist
{
    
    [Route("api/tourist/tourReview")]
    public class TourReviewController : BaseApiController
    {
        private readonly HttpClient _httpClient;

        public TourReviewController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<ActionResult<TourReviewDto>> CreateAsync([FromBody] TourReviewDto tourReviewDto) {

            var response = await _httpClient.PostAsJsonAsync("http://localhost:8000/reviews", tourReviewDto);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult<List<TourReviewDto>>> GetAll()
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:8000/");

            try
            {
                var response = await httpClient.GetAsync("reviews");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Result<List<TourReviewDto>> accounts = JsonConvert.DeserializeObject<List<TourReviewDto>>(content);
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
        //[HttpPut("{id:int}")]
        //public ActionResult<TourReviewDto> Update([FromBody] TourReviewDto tourReviewDto)
        //{
        //    var result = _tourReviewService.Update(tourReviewDto);
        //    return CreateResponse(result);
        //}

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:8000/reviews/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            return Ok();
        }
    }

    }
