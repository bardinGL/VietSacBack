using Microsoft.AspNetCore.Mvc;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._4.Core.Model.Product;

namespace VietSacBackend._1.Web
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // Create a new product
        [HttpPost]
        public IActionResult CreateProduct([FromBody] RequestProductModel requestProductModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }

            var responseModel = _productService.CreateProduct(requestProductModel);
            return StatusCode(responseModel.StatusCode, responseModel);
        }

        // Update an existing product by ID
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(string id, [FromBody] RequestProductModel requestProductModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }

            var responseModel = _productService.UpdateProduct(id, requestProductModel);
            return StatusCode(responseModel.StatusCode, responseModel);
        }

        // Delete a product by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(string id)
        {
            var responseModel = _productService.DeleteProduct(id);
            return StatusCode(responseModel.StatusCode, responseModel);
        }

        // Get product detail by ID
        [HttpGet("{id}")]
        public IActionResult GetProductById(string id)
        {
            var responseModel = _productService.GetProductById(id);
            return StatusCode(responseModel.StatusCode, responseModel);
        }

        // Get list of products
        [HttpGet]
        public IActionResult GetProducts()
        {
            var responseModel = _productService.GetAllProducts();
            return StatusCode(responseModel.StatusCode, responseModel);
        }

        // Get products by category
        [HttpGet("category/{categoryId}")]
        public IActionResult GetProductsByCategory(string categoryId)
        {
            var responseModel = _productService.GetProductsByCategory(categoryId);
            return Ok(responseModel);
        }

        // Get products by brand
        [HttpGet("brand/{brand}")]
        public IActionResult GetProductsByBrand(string brand)
        {
            var responseModel = _productService.GetProductsByBrand(brand);
            return Ok(responseModel);
        }

        // Get products by purpose
        [HttpGet("purpose/{purpose}")]
        public IActionResult GetProductsByPurpose(string purpose)
        {
            var responseModel = _productService.GetProductsByPurpose(purpose);
            return Ok(responseModel);
        }

        // Get all product images
        [HttpGet("images")]
        public IActionResult GetAllProductImages()
        {
            var images = _productService.GetAllProductImages();
            if (images.Any())
            {
                return Ok(images);
            }
            return NotFound("No images found.");
        }

        // Get a specific product image by ID
        [HttpGet("{id}/image")]
        public IActionResult GetProductImageById(string id)
        {
            var image = _productService.GetProductImageById(id);
            if (!string.IsNullOrEmpty(image))
            {
                return Ok(image);
            }
            return NotFound($"No image found for product ID {id}.");
        }
    }
}
