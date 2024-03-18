using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Explorer.API.Controllers.Author
{

    [Route("api/administration/tourequipment")]
    public class TourEquipmentController : BaseApiController
    {
        private readonly HttpClient _httpClient;

        public TourEquipmentController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<ActionResult> AddEquipmentToTour([FromBody] TourEquipmentDto tourEquipment)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:8000/equipmentTours", tourEquipment);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            return Ok();
        }

        [HttpGet("{tourId:int}")]
        public async Task<ActionResult> GetTourEquipment(long tourId)
        {
            var response = await _httpClient.GetAsync($"http://localhost:8000/equipmentTours/{tourId}");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            var content = await response.Content.ReadAsStringAsync();
            var tourEquipment = JsonSerializer.Deserialize<List<TourEquipmentDto>>(content);

            return Ok(tourEquipment);
        }


        [HttpDelete("{tourId:int}/{equipmentId:int}")]
        public async Task<ActionResult> RemoveEquipmentFromTour(long tourId, long equipmentId)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:8000/equipmentTours/{tourId}/{equipmentId}");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            return Ok();
        }
    }
}
