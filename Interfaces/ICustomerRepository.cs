using OrderAPI.Models;

namespace OrderAPI.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        Customer GetCustomerByName(string firstname, string lastname);
        Customer GetCustomerNameByAddress(string city, string street, string zipcode);
        bool CustomerExists(int id);
        bool AddressExist(int id);

    }
}
