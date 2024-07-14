using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._4.Core.Model.Blog;
using VietSacBackend._4.Core.Model;

namespace VietSacBackend._1.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(string id)
        {
            var result = await _blogService.GetBlogByIdAsync(id);
            if (result == null)
            {
                return NotFound(new ResponseModel
                {
                    MessageError = "Blog not found",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(new ResponseModel
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog([FromBody] RequestBlogModel requestBlogModel)
        {
            var result = await _blogService.AddBlogAsync(requestBlogModel);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var result = await _blogService.GetAllBlogsAsync();
            return Ok(new ResponseModel
            {
                Data = result,
                StatusCode = StatusCodes.Status200OK
            });
        }
    }
}
