using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderAPI.Interfaces;
using OrderAPI.Models;
using OrderAPI.Dto;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository1, IMapper mapper)
        {
            _customerRepository = customerRepository1;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomers()
        {
            var customers = _mapper.Map<List<CustomerDTO>>(_customerRepository.GetCustomers());
            
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
                return Ok(customers);       
        }

        [HttpGet("{customerId}")]
            [ProducesResponseType(200, Type = typeof(CustomerDTO))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomer(int customerId) 
        {
            if (!_customerRepository.CustomerExists(customerId))
                return NotFound();

            var customer = _mapper.Map<Customer>(_customerRepository.GetCustomerById(customerId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(customer);    
        }
        [HttpGet("{customerId}/Name")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomerByName(int customerId, string firstname, string lastname)
        {
            if (!_customerRepository.CustomerExists(customerId))
                return NotFound();
            var customername = _mapper.Map<Customer>(_customerRepository.GetCustomerByName(firstname, lastname));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(customername);
        } 
    }
}
