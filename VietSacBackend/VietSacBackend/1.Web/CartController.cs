using Microsoft.AspNetCore.Mvc;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._4.Core.Model.Order;

namespace VietSacBackend._1.Web
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        [Route("AddToCart")]
        public IActionResult AddToCart(RequestCartModel requestCart)
        {
            var response = _cartService.AddToCart(requestCart);
            return Ok(response);
        }

        [HttpDelete]
        [Route("RemoveFromCart/{id}")]
        public IActionResult RemoveFromCart(string id)
        {
            var isSuccess = _cartService.RemoveFromCart(id);
            if (!isSuccess) return NotFound();
            return Ok();
        }

        [HttpGet]
        [Route("GetUserCart/{userId}")]
        public IActionResult GetUserCart(string userId)
        {
            var response = _cartService.GetUserCart(userId);
            return Ok(response);
        }
    }
}
