namespace OrderAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public Address Address { get; set; }    
        public ICollection<Order> Orders { get; set; }  

    }
}
