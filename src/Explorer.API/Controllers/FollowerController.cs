using Explorer.Payments.API.Dtos;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;


namespace Explorer.API.Controllers
{

    [Route("api/follower")]
    public class FollowerController : BaseApiController
    {
        private readonly IFollowerService _followerService;
		private readonly HttpClient _httpClient;

		public FollowerController(IFollowerService followerService, HttpClient httpClient)
        {
            _followerService = followerService;
            _httpClient = httpClient;
        }

        [HttpPost]
		public async Task<HttpResponseMessage> CreateFollow([FromBody] List<GraphUser> users)
		{
            

          var response = _httpClient.PostAsJsonAsync("http://followers:89/follower", users);

            await response;
            
            return response.Result;
		}

		//[HttpPost]
  //      public ActionResult<FollowerDto> Create([FromBody] FollowerDto follower)
  //      {
  //          var result = _followerService.Create(follower);

  //          return CreateResponse(result);
  //      }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _followerService.Delete(id);
            return CreateResponse(result);
        }


        [HttpPut("{id:int}")]
        public ActionResult<FollowerDto> Update([FromBody] FollowerDto followerDto)
        {
            var result = _followerService.Update(followerDto);
            return CreateResponse(result);
        }

        [HttpGet("{userId:int}")]
        public ActionResult<List<FollowerDto>> GetByUserId(int userId)
        {
            var result = _followerService.GetByUserId(userId);
            return CreateResponse(result);
        }

        [HttpGet("recommendations/{id}")]
        public async Task<ActionResult<List<GraphUser>>> GetFollowerRecommendations(string id)
        {
            var followers = await _httpClient.GetFromJsonAsync<GraphUser[]>("http://followers:89/recommendations/" + id);
            return followers.ToList();
        }


    }
}
