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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("Checkout")]
        public IActionResult Checkout()
        {
            var userId = User.FindFirst("UserID")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Invalid token");
            }

            var responseModel = _orderService.CreateOrderFromCart(userId);
            if (responseModel.StatusCode == StatusCodes.Status404NotFound)
            {
                return NotFound(responseModel.MessageError);
            }

            return Ok(responseModel);
        }
    }
}
