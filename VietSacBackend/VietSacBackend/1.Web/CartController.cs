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
            var userId = User.FindFirst("UserID")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Invalid token");
            }

            Console.WriteLine($"User ID: {userId}");
            Console.WriteLine($"Product ID: {model.ProductId}, Quantity: {model.Quantity}");

            var responseModel = _cartService.AddToCart(userId, model);
            if (responseModel.StatusCode == StatusCodes.Status404NotFound)
            {
                return NotFound(responseModel.MessageError);
            }

            return Ok(responseModel);
        }

        [HttpDelete("RemoveFromCart/{id}")]
        public IActionResult RemoveFromCart(string id)
        {
            var responseModel = _cartService.RemoveFromCart(id);
            if (!responseModel)
            {
                return NotFound("Cart item not found");
            }
            return Ok(new { message = "Item removed from cart" });
        }

        [HttpGet("GetUserCart")]
        public IActionResult GetUserCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Invalid token");
            }

            var responseModel = _cartService.GetUserCart(userId);
            if (responseModel == null || !responseModel.Any())
            {
                return NotFound("No items found in cart");
            }

            return Ok(responseModel);
        }
    }
}