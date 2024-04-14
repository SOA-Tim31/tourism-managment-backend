using Explorer.Blog.API.Dtos;
using Explorer.Blog.API.Public;
using Explorer.Blog.Core.Domain;
using Explorer.Blog.Core.UseCases;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.API.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Explorer.API.Controllers.Tourist.Blog
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/blog/blogpost")]
    public class BlogPostController : BaseApiController
    {
        private readonly IBlogPostService _blogPostService;
        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }
        /*
        [HttpGet]
        public ActionResult<PagedResult<BlogPostDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _blogPostService.GetAll(page, pageSize);
            return CreateResponse(result);
        }*/

        [HttpGet]
        public async Task<List<BlogPostDto>> GetAll()
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://blogs:80/");

            try
            {
                var response = await httpClient.GetAsync("blog/all");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<BlogPostDto> blogPosts = JsonConvert.DeserializeObject<List<BlogPostDto>>(content);
                    return blogPosts;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("{blogPostId:int}")]
        public async Task<ActionResult<BlogPostDto>> GetById([FromRoute] int blogPostId)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://blogs:80/");

            try
            {
                var response = await httpClient.GetAsync("blog/get/" + blogPostId);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Result<BlogPostDto> blogPost = JsonConvert.DeserializeObject<BlogPostDto>(content);
                    return CreateResponse(blogPost);
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

            //var result = _blogPostService.GetById(blogPostId);
            //return CreateResponse(result);
        }


        [HttpGet("{userId}")]
        public async Task<ActionResult<UserProfileDto>> Get([FromRoute] int userId)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://stakeholders:81/");

            try
            {
                var response = await httpClient.GetAsync("people/get/" + userId);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Result<UserProfileDto> profile = JsonConvert.DeserializeObject<UserProfileDto>(content);
                    return CreateResponse(profile);
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

            /*var result = _profileService.Get(userId);
            return CreateResponse(result);*/
        }

        



        [HttpPost("{blogPostid:int}/ratings")]
        public ActionResult<BlogPostDto> AddRating(int blogPostid, [FromBody] BlogPostRatingDto blogPostRating)
        {
            var result = _blogPostService.AddRating(blogPostid, blogPostRating);
            return CreateResponse(result);
        }

        /*
        public async Task<ActionResult<PagedResult<TourPointDto>>> Create([FromBody] TourPointDto tourPoint)
        {


            var response = await _httpClient.PostAsJsonAsync("http://localhost:8000/tourPoints", tourPoint);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }

            return Ok();
        }*/


        [HttpPost("{blogPostid:int}/comments")]
        public async Task<ActionResult<BlogPostCommentDto>> AddComment([FromBody] BlogPostCommentDto blogPostComment)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://blogs:80/");

            try
            {
                var json = JsonConvert.SerializeObject(blogPostComment);
                var blogjson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("blogComment/create", blogjson);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Result<BlogPostCommentDto> blogComment = JsonConvert.DeserializeObject<BlogPostCommentDto>(content);
                    return CreateResponse(blogComment);
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


        [HttpPost]
        public async Task<ActionResult<BlogPostDto>> Create([FromBody] BlogPostDto blogPost)
        {

            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://blogs:80/");

            try
            {
                var json = JsonConvert.SerializeObject(blogPost);
                var blogjson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("blog/create", blogjson);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Result<BlogPostDto> blog = JsonConvert.DeserializeObject<BlogPostDto>(content);
                    return CreateResponse(blog);
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
   

        [HttpPut("{blogPostId:int}/comments")]
        public ActionResult<BlogPostDto> UpdateComment(int blogPostId, [FromBody] BlogPostCommentDto editedComment)
        {
            var result = _blogPostService.UpdateComment(blogPostId, editedComment);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<BlogPostDto> Update([FromBody] BlogPostDto blogPost)
        {
            var result = _blogPostService.Update(blogPost);
            return CreateResponse(result);
        }

        [HttpDelete("{blogPostId:int}/comments/{userId:int}/{creationTime:datetime}")]
        public ActionResult<BlogPostDto> DeleteComment(int blogPostId, int userId, DateTime creationTime)
        {
            var result = _blogPostService.RemoveComment(blogPostId, userId, creationTime);
            return CreateResponse(result);
        }
        [HttpDelete("{blogPostId:int}/ratings/{userId:int}")]
        public ActionResult<BlogPostDto> DeleteRating(int blogPostId, int userId)
        {
            var result = _blogPostService.RemoveRating(blogPostId, userId);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _blogPostService.Delete(id);
            return CreateResponse(result);
        }

    }
}
