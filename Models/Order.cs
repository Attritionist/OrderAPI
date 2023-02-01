namespace OrderAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string RecipeNumber { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
