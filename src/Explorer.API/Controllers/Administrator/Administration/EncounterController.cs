using Explorer.Blog.API.Dtos;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.UseCases;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Explorer.API.Controllers.Administrator.Administration;

//[Authorize(Policy = "administratorPolicy")]
[Route("api/encounters")]
public class EncounterController : BaseApiController
{
    private readonly IEncounterService _encounterService;
    private readonly IHiddenLocationEncounterService _hiddenLocationEncounterService;
    private readonly ILogger<EncounterController> _logger;

    private readonly ISocialEncounterService _socialEncounterService;
    private readonly HttpClient _httpClient;
    public EncounterController(IEncounterService encounterService, ISocialEncounterService socialEncounterService, IHiddenLocationEncounterService hiddenLocationEncounterService, ILogger<EncounterController> logger)
    {
        _logger = logger;
        _encounterService = encounterService;
        _socialEncounterService = socialEncounterService;
        _hiddenLocationEncounterService = hiddenLocationEncounterService;
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://encounters:8083")
        };
    }

    /*[HttpGet]
    
    public ActionResult<PagedResult<EncounterDto>> GetAllEncounters([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _encounterService.GetPaged(page, pageSize);
        return CreateResponse(result);
    }*/

    [HttpGet]
    public async Task<ActionResult<List<EncounterDto>>> GetAllEncounterDto()
    {
        try
        {
            // Assuming you have an HttpClient configured already
            using HttpResponseMessage response = await _httpClient.GetAsync("getEncounters");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var encounterDtos = JsonConvert.DeserializeObject<List<EncounterDto>>(jsonResponse);

            return Ok(encounterDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while retrieving encounters: {ex.Message}");
        }
    }


    [HttpGet("social")]
    public ActionResult<PagedResult<SocialEncounterDto>> GetAllSocialEncounters([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _socialEncounterService.GetPaged(page, pageSize);
        return CreateResponse(result);
    }

    [HttpGet("hiddenLocation")]
    public ActionResult<PagedResult<HiddenLocationEncounterDto>> GetAllHiddenLocationEncounters([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _hiddenLocationEncounterService.GetPaged(page, pageSize);
        return CreateResponse(result);
    }
    [HttpPost]
    public async Task<ActionResult<EncounterDto>> Create([FromBody] EncounterDto encounter)
    {
        try
        {
            _logger.LogInformation("STA SE DESAVA");
            _logger.LogInformation(encounter.ToString());
            _logger.LogInformation("=================================");
            var json = System.Text.Json.JsonSerializer.Serialize(encounter);

            _logger.LogInformation(json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await _httpClient.PostAsync("/createEncounter", content);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            return Ok(jsonResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred while creating tour: {ex.Message}");
        }
    }
    [HttpPost("hiddenLocation")]
    public ActionResult<HiddenLocationEncounterDto> Create([FromBody] WholeHiddenLocationEncounterDto wholeEncounter)
    {
        EncounterDto encounterDto = new EncounterDto();
        encounterDto.Name = wholeEncounter.Name;
        encounterDto.Description = wholeEncounter.Description;
        encounterDto.XpPoints = wholeEncounter.XpPoints;
        encounterDto.Status = wholeEncounter.Status;
        encounterDto.Type = wholeEncounter.Type;
        encounterDto.Longitude = wholeEncounter.Longitude;
        encounterDto.Latitude = wholeEncounter.Latitude;
        encounterDto.ShouldBeApproved = wholeEncounter.ShouldBeApproved;
        var baseEncounter = _encounterService.Create(encounterDto);
        if (!baseEncounter.IsSuccess)
        {
            return StatusCode((int)HttpStatusCode.BadRequest, baseEncounter);
        }

        HiddenLocationEncounterDto hiddenLocationEncounterDto = new HiddenLocationEncounterDto();
        hiddenLocationEncounterDto.EncounterId = long.Parse(baseEncounter.Value.Id);
        hiddenLocationEncounterDto.ImageLatitude = wholeEncounter.ImageLatitude;
        hiddenLocationEncounterDto.ImageLongitude = wholeEncounter.ImageLongitude;
        hiddenLocationEncounterDto.ImageURL = wholeEncounter.ImageURL;
        hiddenLocationEncounterDto.DistanceTreshold = wholeEncounter.DistanceTreshold;

        var result = _hiddenLocationEncounterService.Create(hiddenLocationEncounterDto);
        if (!result.IsSuccess)
        {
            return StatusCode((int)HttpStatusCode.BadRequest, result);
        }

        var wholeHiddenLocationEncounterDto = new WholeHiddenLocationEncounterDto();
        wholeHiddenLocationEncounterDto.EncounterId = long.Parse(baseEncounter.Value.Id);
        wholeHiddenLocationEncounterDto.Name = wholeEncounter.Name;
        wholeHiddenLocationEncounterDto.Description = wholeEncounter.Description;
        wholeHiddenLocationEncounterDto.XpPoints = wholeEncounter.XpPoints;
        wholeHiddenLocationEncounterDto.Status = wholeEncounter.Status;
        wholeHiddenLocationEncounterDto.Type = wholeEncounter.Type;
        wholeHiddenLocationEncounterDto.Latitude = wholeEncounter.Latitude;
        wholeHiddenLocationEncounterDto.Longitude = wholeEncounter.Longitude;
        wholeHiddenLocationEncounterDto.Id = result.Value.Id;
        wholeHiddenLocationEncounterDto.ImageURL = wholeEncounter.ImageURL;
        wholeHiddenLocationEncounterDto.ImageLatitude = wholeEncounter.ImageLatitude;
        wholeHiddenLocationEncounterDto.ImageLongitude = wholeEncounter.ImageLongitude;
        wholeHiddenLocationEncounterDto.DistanceTreshold = wholeEncounter.DistanceTreshold;
        wholeHiddenLocationEncounterDto.ShouldBeApproved = wholeEncounter.ShouldBeApproved;
        return StatusCode((int)HttpStatusCode.Created, wholeHiddenLocationEncounterDto);

    }
    [HttpPost("social")]
    public ActionResult<WholeSocialEncounterDto> Create([FromBody] WholeSocialEncounterDto socialEncounter)
    {
        EncounterDto encounterDto = new EncounterDto();
        encounterDto.Name = socialEncounter.Name;
        encounterDto.Description = socialEncounter.Description;
        encounterDto.XpPoints = socialEncounter.XpPoints;
        encounterDto.Status = socialEncounter.Status;
        encounterDto.Type = socialEncounter.Type;
        encounterDto.Longitude = socialEncounter.Longitude;
        encounterDto.Latitude = socialEncounter.Latitude;
        encounterDto.ShouldBeApproved = socialEncounter.ShouldBeApproved;
        var baseEncounter = _encounterService.Create(encounterDto);
        if (!baseEncounter.IsSuccess)
        {
            return StatusCode((int)HttpStatusCode.BadRequest, baseEncounter);
        }
        SocialEncounterDto socialEncounterDto = new SocialEncounterDto();
        socialEncounterDto.EncounterId = long.Parse(baseEncounter.Value.Id);
        socialEncounterDto.TouristsRequiredForCompletion = socialEncounter.TouristsRequiredForCompletion;
        socialEncounterDto.DistanceTreshold = socialEncounter.DistanceTreshold;
        socialEncounterDto.TouristIDs = socialEncounter.TouristIDs;
        var result = _socialEncounterService.Create(socialEncounterDto);
        if (!result.IsSuccess)
        {
            return StatusCode((int)HttpStatusCode.BadRequest, result);
        }

        var wholeSocialEncounterDto = new WholeSocialEncounterDto();
        wholeSocialEncounterDto.EncounterId = long.Parse(baseEncounter.Value.Id);
        wholeSocialEncounterDto.Name = socialEncounter.Name;
        wholeSocialEncounterDto.Description = socialEncounter.Description;
        wholeSocialEncounterDto.XpPoints = socialEncounter.XpPoints;
        wholeSocialEncounterDto.Status = socialEncounter.Status;
        wholeSocialEncounterDto.Type = socialEncounter.Type;
        wholeSocialEncounterDto.Latitude = socialEncounter.Latitude;
        wholeSocialEncounterDto.Longitude = socialEncounter.Longitude;
        wholeSocialEncounterDto.Id = result.Value.Id;
        wholeSocialEncounterDto.TouristsRequiredForCompletion = socialEncounter.TouristsRequiredForCompletion;
        wholeSocialEncounterDto.DistanceTreshold = socialEncounter.DistanceTreshold;
        wholeSocialEncounterDto.TouristIDs = socialEncounter.TouristIDs;
        wholeSocialEncounterDto.ShouldBeApproved = socialEncounter.ShouldBeApproved;

        return StatusCode((int)HttpStatusCode.Created, wholeSocialEncounterDto);
    }
    [HttpPut]
    public ActionResult<EncounterDto> Update([FromBody] EncounterDto encounter)
    {

        var result = _encounterService.Update(encounter);
        return CreateResponse(result);
    }
    [HttpPut("hiddenLocation")]
    public ActionResult<HiddenLocationEncounterDto> Update([FromBody] WholeHiddenLocationEncounterDto wholeEncounter)
    {
        EncounterDto encounterDto = new EncounterDto();
        encounterDto.Id = wholeEncounter.EncounterId.ToString();
        encounterDto.Name = wholeEncounter.Name;
        encounterDto.Description = wholeEncounter.Description;
        encounterDto.XpPoints = wholeEncounter.XpPoints;
        encounterDto.Status = wholeEncounter.Status;
        encounterDto.Type = wholeEncounter.Type;
        encounterDto.Longitude = wholeEncounter.Longitude;
        encounterDto.Latitude = wholeEncounter.Latitude;
        encounterDto.ShouldBeApproved = wholeEncounter.ShouldBeApproved;
        var baseEncounter = _encounterService.Update(encounterDto);
        if (!baseEncounter.IsSuccess)
        {
            return StatusCode((int)HttpStatusCode.BadRequest, baseEncounter);
        }

        HiddenLocationEncounterDto hiddenLocationEncounterDto = new HiddenLocationEncounterDto();
        hiddenLocationEncounterDto.Id = wholeEncounter.Id;
        hiddenLocationEncounterDto.EncounterId = long.Parse(baseEncounter.Value.Id);
        hiddenLocationEncounterDto.ImageLatitude = wholeEncounter.ImageLatitude;
        hiddenLocationEncounterDto.ImageLongitude = wholeEncounter.ImageLongitude;
        hiddenLocationEncounterDto.ImageURL = wholeEncounter.ImageURL;
        hiddenLocationEncounterDto.DistanceTreshold = wholeEncounter.DistanceTreshold;

        var result = _hiddenLocationEncounterService.Update(hiddenLocationEncounterDto);
        if (!result.IsSuccess)
        {
            return StatusCode((int)HttpStatusCode.BadRequest, result);
        }
        var wholeHiddenLocationEncounterDto = new WholeHiddenLocationEncounterDto();
        wholeHiddenLocationEncounterDto.EncounterId = long.Parse(baseEncounter.Value.Id);
        wholeHiddenLocationEncounterDto.Name = wholeEncounter.Name;
        wholeHiddenLocationEncounterDto.Description = wholeEncounter.Description;
        wholeHiddenLocationEncounterDto.XpPoints = wholeEncounter.XpPoints;
        wholeHiddenLocationEncounterDto.Status = wholeEncounter.Status;
        wholeHiddenLocationEncounterDto.Type = wholeEncounter.Type;
        wholeHiddenLocationEncounterDto.Latitude = wholeEncounter.Latitude;
        wholeHiddenLocationEncounterDto.Longitude = wholeEncounter.Longitude;
        wholeHiddenLocationEncounterDto.Id = result.Value.Id;
        wholeHiddenLocationEncounterDto.ImageURL = wholeEncounter.ImageURL;
        wholeHiddenLocationEncounterDto.ImageLatitude = wholeEncounter.ImageLatitude;
        wholeHiddenLocationEncounterDto.ImageLongitude = wholeEncounter.ImageLongitude;
        wholeHiddenLocationEncounterDto.DistanceTreshold = wholeEncounter.DistanceTreshold;
        wholeHiddenLocationEncounterDto.ShouldBeApproved = wholeEncounter.ShouldBeApproved;

        return StatusCode((int)HttpStatusCode.NoContent, wholeHiddenLocationEncounterDto);
    }

    [HttpPut("social")]
    public ActionResult<WholeSocialEncounterDto> Update([FromBody] WholeSocialEncounterDto socialEncounter)
    {
        EncounterDto encounterDto = new EncounterDto();
        encounterDto.Id = socialEncounter.EncounterId.ToString();
        encounterDto.Name = socialEncounter.Name;
        encounterDto.Description = socialEncounter.Description;
        encounterDto.XpPoints = socialEncounter.XpPoints;
        encounterDto.Status = socialEncounter.Status;
        encounterDto.Type = socialEncounter.Type;
        encounterDto.Longitude = socialEncounter.Longitude;
        encounterDto.Latitude = socialEncounter.Latitude;
        encounterDto.ShouldBeApproved = socialEncounter.ShouldBeApproved;
        var baseEncounter = _encounterService.Update(encounterDto);
        if (!baseEncounter.IsSuccess)
        {
            return StatusCode((int)HttpStatusCode.BadRequest, baseEncounter);
        }
        SocialEncounterDto socialEncounterDto = new SocialEncounterDto();
        socialEncounterDto.Id = socialEncounter.Id;
        socialEncounterDto.EncounterId = long.Parse(baseEncounter.Value.Id);
        socialEncounterDto.TouristsRequiredForCompletion = socialEncounter.TouristsRequiredForCompletion;
        socialEncounterDto.DistanceTreshold = socialEncounter.DistanceTreshold;
        socialEncounterDto.TouristIDs = socialEncounter.TouristIDs;
        var result = _socialEncounterService.Update(socialEncounterDto);
        if (!result.IsSuccess)
        {
            return StatusCode((int)HttpStatusCode.BadRequest, result);
        }

        var wholeSocialEncounterDto = new WholeSocialEncounterDto();
        wholeSocialEncounterDto.EncounterId = long.Parse(baseEncounter.Value.Id);
        wholeSocialEncounterDto.Name = socialEncounter.Name;
        wholeSocialEncounterDto.Description = socialEncounter.Description;
        wholeSocialEncounterDto.XpPoints = socialEncounter.XpPoints;
        wholeSocialEncounterDto.Status = socialEncounter.Status;
        wholeSocialEncounterDto.Type = socialEncounter.Type;
        wholeSocialEncounterDto.Latitude = socialEncounter.Latitude;
        wholeSocialEncounterDto.Longitude = socialEncounter.Longitude;
        wholeSocialEncounterDto.Id = result.Value.Id;
        wholeSocialEncounterDto.TouristsRequiredForCompletion = socialEncounter.TouristsRequiredForCompletion;
        wholeSocialEncounterDto.DistanceTreshold = socialEncounter.DistanceTreshold;
        wholeSocialEncounterDto.TouristIDs = socialEncounter.TouristIDs;
        wholeSocialEncounterDto.ShouldBeApproved = socialEncounter.ShouldBeApproved;

        return StatusCode((int)HttpStatusCode.NoContent, wholeSocialEncounterDto);
    }
    /*
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var result = _encounterService.Delete(id);
        return CreateResponse(result);
    }
    [HttpDelete("hiddenLocation/{baseEncounterId:int}/{hiddenLocationEncounterId:int}")]
    public ActionResult DeleteHiddenLocationEncounter(int baseEncounterId, int hiddenLocationEncounterId)
    {
        var baseEncounter = _encounterService.Delete(baseEncounterId);
        var result = _hiddenLocationEncounterService.Delete(hiddenLocationEncounterId);
        return CreateResponse(result);
    }


    [HttpDelete("social/{baseEncounterId:int}/{socialEncounterId:int}")]
    public ActionResult Delete(int baseEncounterId, int socialEncounterId)
    {
        var baseEncounter = _encounterService.Delete(baseEncounterId);
        var result = _socialEncounterService.Delete(socialEncounterId);
        return CreateResponse(result);
    }
    */
    [HttpGet("getEncounter/{encounterId}")]
    public async Task<ActionResult<EncounterDto>> GetEncounter(string encounterId)
    {
        try
        {
            // Send a GET request to the backend API to fetch the tour by user ID
            HttpResponseMessage response = await _httpClient.GetAsync($"getEncounter/{encounterId}");

            // Ensure a successful response
            response.EnsureSuccessStatusCode();

            // Read the response content as a string
            string jsonResponse = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON response into a single TourCreationDto object
            var encounterExecutionDto = JsonConvert.DeserializeObject<EncounterDto>(jsonResponse);

            // Return the TourCreationDto object as ActionResult
            return Ok(encounterExecutionDto);
        }
        catch (Exception ex)
        {
            // Return a 500 Internal Server Error with the error message if an exception occurs
            return StatusCode(500, $"An error occurred while retrieving tour creation data: {ex.Message}");
        }
    }

    [HttpDelete("{baseEncounterId:int}")]
    public ActionResult DeleteEncounter(int baseEncounterId)
    {
        var baseEncounter = _encounterService.Delete(baseEncounterId);

        if (baseEncounter.IsSuccess)
        {
            long socialEncounterId = _socialEncounterService.GetId(baseEncounterId);
            long hiddenLocationEncounterId = _hiddenLocationEncounterService.GetId(baseEncounterId);

            if (socialEncounterId != -1)
            {
                var result = _socialEncounterService.Delete((int)socialEncounterId);
                return CreateResponse(result);
            }
            else if (hiddenLocationEncounterId != -1)
            {
                var hiddenLocationResult = _hiddenLocationEncounterService.Delete((int)hiddenLocationEncounterId);
                return CreateResponse(hiddenLocationResult);
            }
        }

        // Handle the case when baseEncounterId doesn't match any specific type
        return CreateResponse(baseEncounter);
    }

    [HttpGet("hiddenLocation/{encounterId:int}")]
    public ActionResult<PagedResult<HiddenLocationEncounterDto>> GetHiddenLocationEncounterByEncounterId(int encounterId)
    {
        var hiddenLocationEncounter = _hiddenLocationEncounterService.GetHiddenLocationEncounterByEncounterId(encounterId);
        return CreateResponse(hiddenLocationEncounter);
    }

}