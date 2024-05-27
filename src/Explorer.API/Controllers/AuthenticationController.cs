﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Explorer.API.Controllers;

[Route("api/users")]
public class AuthenticationController : BaseApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    [HttpPost]
    public async Task<ActionResult<AuthenticationTokensDto>> RegisterTourist([FromBody] AccountRegistrationDto account)
    {
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://stakeholders:8082/");

        try
        {
            var json = JsonConvert.SerializeObject(account);
            var accountjson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("register", accountjson);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Result<AuthenticationTokensDto> authToken = JsonConvert.DeserializeObject<AuthenticationTokensDto>(content);
                return CreateResponse(authToken);
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while communicating with the other app while registration: " + ex.Message);
        }
    }
    /*
	[HttpPost]
	public ActionResult<AuthenticationTokensDto> RegisterTourist([FromBody] AccountRegistrationDto account)
	{
		var result = _authenticationService.RegisterTourist(account);
		return CreateResponse(result);
	}*/

    [HttpPost("login")]
    public async Task<ActionResult<AuthenticationTokensDto>> Login([FromBody] CredentialsDto credentials)
    {
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("http://stakeholders:8082/");

        try
        {
            var json = JsonConvert.SerializeObject(credentials);
            var credjson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("login", credjson);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Result<AuthenticationTokensDto> authToken = JsonConvert.DeserializeObject<AuthenticationTokensDto>(content);
                return CreateResponse(authToken);
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while communicating with the other app while registration: " + ex.Message);
        }
    }
    public class PasswordResetRequestDto
    {
        public string Email { get; set; }
    }

    [HttpPost("request")]
    public ActionResult<string> RequestPasswordReset([FromBody] PasswordResetRequestDto request)
    {
        var result = _authenticationService.RequestPasswordReset(request.Email);
        return CreateResponse(result);
    }

    [HttpPost("reset")]
    public ActionResult<string> ResetPassword([FromBody] PasswordResetDto request)
    {
        var result = _authenticationService.ResetPassword(request);
        return CreateResponse(result);
    }
}