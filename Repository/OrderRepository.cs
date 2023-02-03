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
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        //Multiple Orders
        public ICollection<Order> GetOrders()
        {
            return _context.Orders.OrderBy(o => o.Id).ToList();
        }
        public ICollection<Order> GetOrdersByName(string firstname, string lastname)
        {
            return _context.Orders.OrderBy(o => o.Id).Where(o => o.Customer.FirstName == firstname && o.Customer.LastName == lastname).ToList();
        }

        //Singular Order
        public Order GetOrderById(int id)
        {
            return _context.Orders.Where(o => o.Id == id).FirstOrDefault();
        }
        public Order GetOrderByOrderNo(int id)
        {
            return _context.Orders.Where(o => o.OrderNumber == id).FirstOrDefault();
        }
        public bool OrderExists(int id)
        {
            return _context.Orders.Any(o => o.Id == id);
        }
    }
}