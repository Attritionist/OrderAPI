using Microsoft.EntityFrameworkCore;
using OrderAPI.Data;
using OrderAPI.Interfaces;
using OrderAPI.Models;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;

namespace OrderAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }
        //Multiple Customers
        public ICollection<Customer> GetCustomers()
        {
            return _context.Customers.OrderBy(c => c.Id).ToList();
        }
        //Singular Customer
        public Customer GetCustomerById(int id)
        {
            return _context.Customers.Where(c => c.Id == id).FirstOrDefault();
        }
        public Customer GetCustomerByName(string firstname, string lastname)
        {
            return _context.Customers.Where(c => c.FirstName == firstname && c.LastName == lastname).FirstOrDefault();

        }
        public Customer GetCustomerNameByAddress(string city, string street, string zipcode)
        {
            return _context.Customers.Where(c => c.Address.City == city && c.Address.Street == street && c.Address.ZipCode == zipcode).FirstOrDefault();
        }

        public bool CustomerExists(int id)
        {
            return _context.Customers.Any(c => c.Id == id);
        }

        public bool AddressExist(int id)
        {
            { return _context.Addresses.Any(a => a.Id == id); }
        }
    }
}
