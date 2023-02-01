using OrderAPI.Data;
using OrderAPI.Interfaces;
using OrderAPI.Models;

namespace OrderAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Customer> GetCustomers()
        {
            return _context.Customers.OrderBy(p => p.Id).ToList();
        }
    }
}
