using Microsoft.AspNetCore.Mvc;
using VietSacBackend._2.Service.Interface;
using VietSacBackend._4.Core.Model.Order;

namespace VietSacBackend._1.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] RequestOrderModel requestOrder)
        {
            var result = _orderService.CreateOrder(requestOrder);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderById(string orderId)
        {
            var result = _orderService.GetOrderById(orderId);
            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var result = _orderService.GetAllOrders();
            return Ok(result);
        }

        [HttpPut("{orderId}")]
        public IActionResult UpdateOrder(string orderId, [FromBody] RequestOrderModel requestOrder)
        {
            var result = _orderService.UpdateOrder(orderId, requestOrder);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }

        [HttpDelete("{orderId}")]
        public IActionResult DeleteOrder(string orderId)
        {
            var result = _orderService.DeleteOrder(orderId);
            if (result)
                return Ok();
            return NotFound();
        }
    }
}
