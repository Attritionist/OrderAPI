using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderAPI.Interfaces;
using OrderAPI.Models;
using OrderAPI.Dto;
using OrderAPI.Repository;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository1) => _orderRepository = orderRepository1;
        [HttpGet("{orderId}")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public IActionResult GetOrderById(int orderId)
        {
            if (!_orderRepository.OrderExists(orderId))
                return NotFound();
            var orders = _orderRepository.GetOrderById(orderId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(orders);
        }
        [HttpGet("{orderId}/OrderNo")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public IActionResult GetOrderByOrderNo(int orderId)
        {
            if (!_orderRepository.OrderExists(orderId))
                return NotFound();
            var orders = _orderRepository.GetOrderByOrderNo(orderId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(orders);
        }
        [HttpGet("OrdersBy/{firstName}/{lastName}")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public ActionResult<List<Order>> GetOrdersByName(string firstName, string lastName)
        {
            var orders = _orderRepository.GetOrdersByName(firstName, lastName);
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }
    }
}
