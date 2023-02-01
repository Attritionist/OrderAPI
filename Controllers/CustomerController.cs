using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderAPI.Interfaces;


namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public CustomerController(IOrderRepository orderRepository1)
        {
            _orderRepository = orderRepository1;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CustomerController>))]
        public IActionResult GetCustomers()
        {
            var customers = _orderRepository.GetCustomers();
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
                return Ok(customers);
                    
        }
    }
}
