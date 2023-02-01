using OrderAPI.Data;
using OrderAPI.Models;

namespace OrderAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Customers.Any())
            {
                var customers = new List<Customer>()
                {
                    new Customer()
                    {
                    FirstName = "Okan",
                    LastName = "Ugur",
                    PhoneNumber = "5301234567",
                    Address = new Address
                    {
                        City = "İzmir",
                        Street = "3rd Good Coders Street",
                        ZipCode = 35600
                    },
                    Orders = new List<Order>
                    {
                        new Order
                        {
                            OrderNumber = 0001,
                            RecipeNumber = "A001",
                            ProductName = "Some Good Code",
                            Quantity = 50
                        },
                        new Order
                        {
                            OrderNumber = 0002,
                            RecipeNumber = "A002",
                            ProductName = "Mediocre Code",
                            Quantity = 20
                        }
                    }
                },
                new Customer
                {
                    FirstName = "Ramazan",
                    LastName = "Yavuz",
                    PhoneNumber = "5307654321",
                    Address = new Address
                    {
                        City = "Antalya",
                        Street = "Based Street",
                        ZipCode = 07090
                    },
                    Orders = new List<Order>
                    {
                        new Order
                        {
                            OrderNumber = 0003,
                            RecipeNumber = "A003",
                            ProductName = "A Good Programmer Called Okan",
                            Quantity = 1
                        }
                    }
                }
            };

                dataContext.Customers.AddRange(customers);
                dataContext.SaveChanges();
            }
        }
    }
}