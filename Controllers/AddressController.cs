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

        public AddressController(ICustomerRepository addressRepository1)
        {
            _addressRepository = addressRepository1;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]

        [HttpGet("{firstname}/lastname")]
        [ProducesResponseType(200, Type = typeof(Address))]
        [ProducesResponseType(400)]
        public ActionResult<Address> GetAddressByName(string firstname, string lastname)
        {
            var customer = _addressRepository.GetCustomerByName(firstname, lastname);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer.Address);
        }
    }
}
