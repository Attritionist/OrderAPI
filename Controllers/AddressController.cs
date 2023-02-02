using Microsoft.AspNetCore.Mvc;
using OrderAPI.Interfaces;
using OrderAPI.Models;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly ICustomerRepository _addressRepository;

        public AddressController(ICustomerRepository orderRepository1)
        {
            _addressRepository = orderRepository1;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomers()
        {
            var customers = _addressRepository.GetCustomers();
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
                return Ok(customers);       
        }

        [HttpGet("{customerId}/Address")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomerNameByAddress(int customerId, string city, string street, int zipcode)
        {
            if (!_addressRepository.CustomerExists(customerId))
                return NotFound();
            var customeraddress = _addressRepository.GetCustomerNameByAddress(city,street,zipcode);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(customeraddress);
        }

    }
}
