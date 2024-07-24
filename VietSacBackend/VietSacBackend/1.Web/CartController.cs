using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._4.Core.Model.Order;
using VietSacBackend._4.Core.Model;

namespace VietSacBackend._1.Web
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Ensures that the user is authenticated
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("AddToCart")]
        public IActionResult AddToCart([FromBody] RequestCartModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.ProductId) || model.Quantity <= 0)
            {
                return BadRequest("Invalid cart data.");
            }

            var userId = User.FindFirst("UserID")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Invalid token");
            }

            Console.WriteLine($"[AddToCart] User ID: {userId}, Product ID: {model.ProductId}, Quantity: {model.Quantity}");

            try
            {
                var responseModel = _cartService.AddToCart(userId, model);
                if (responseModel.StatusCode == StatusCodes.Status404NotFound)
                {
                    return NotFound(responseModel.MessageError);
                }
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[AddToCart] Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while adding to cart.");
            }
        }

        [HttpDelete("RemoveFromCart/{id}")]
        public IActionResult RemoveFromCart(string id)
        {
            Console.WriteLine($"[RemoveFromCart] Cart Item ID: {id}");

            try
            {
                var responseModel = _cartService.RemoveFromCart(id);
                if (!responseModel)
                {
                    return NotFound("Cart item not found");
                }
                return Ok(new { message = "Item removed from cart" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[RemoveFromCart] Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while removing from cart.");
            }
        }

        [HttpGet("GetUserCart")]
        public IActionResult GetUserCart()
        {
            var userId = User.FindFirst("UserID")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Invalid token");
            }

            Console.WriteLine($"[GetUserCart] User ID: {userId}");

            try
            {
                var responseModel = _cartService.GetUserCart(userId);
                if (responseModel == null || !responseModel.Any())
                {
                    return NotFound("No items found in cart");
                }
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetUserCart] Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the cart.");
            }
        }

        [HttpGet("GetCartById/{id}")]
        public IActionResult GetCartById(string id)
        {
            try
            {
                var responseModel = _cartService.GetCartById(id);
                if (responseModel == null)
                {
                    return NotFound("Cart item not found");
                }
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetCartById] Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the cart item.");
            }
        }

        [HttpGet("GetAllCarts")]
        public IActionResult GetAllCarts()
        {
            try
            {
                var responseModel = _cartService.GetAllCarts();
                if (responseModel == null || !responseModel.Any())
                {
                    return NotFound("No items found in cart");
                }
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetAllCarts] Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving the cart items.");
            }
        }
    }
}
