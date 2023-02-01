using OrderAPI.Models;

namespace OrderAPI.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Customer> GetCustomers();

    }
}
