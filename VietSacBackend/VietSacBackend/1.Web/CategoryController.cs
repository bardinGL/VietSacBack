using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._4.Core.Model.Category;

namespace VietSacBackend._1.Web
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] RequestCategoryModel requestCategoryModel)
        {
            var result = _categoryService.CreateCategory(requestCategoryModel);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(string id, [FromBody] RequestCategoryModel requestCategoryModel)
        {
            var result = _categoryService.UpdateCategory(id, requestCategoryModel);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(string id)
        {
            var result = _categoryService.DeleteCategory(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var result = _categoryService.GetAllCategories();
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(string id)
        {
            var result = _categoryService.GetCategoryById(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("by-brand/{brand}")]
        public IActionResult GetCategoriesByBrand(string brand)
        {
            var result = _categoryService.GetCategoriesByBrand(brand);
            return Ok(result);
        }

        [HttpGet("by-purpose/{purpose}")]
        public IActionResult GetCategoriesByPurpose(string purpose)
        {
            var result = _categoryService.GetCategoriesByPurpose(purpose);
            return Ok(result);
        }
    }
}
