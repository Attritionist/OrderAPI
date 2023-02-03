using OrderAPI.Models;

namespace OrderAPI.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Order> GetOrders();
        Order GetOrderById(int id);
        Order GetOrderByOrderNo(int id);
        ICollection<Order> GetOrdersByName(string firstname, string lastname);
        bool OrderExists(int id);


    }
}
