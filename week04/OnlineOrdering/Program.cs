using System;
using System.Collections.Generic;
using OnlineOrdering;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Addresses
            Address address1 = new Address("123 Main St", "New York", "NY", "USA");
            Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

            // Create Customers
            Customer customer1 = new Customer("Alice Johnson", address1);
            Customer customer2 = new Customer("Bob Smith", address2);

            // Create Products
            Product product1 = new Product("Laptop", "P1001", 800, 1);
            Product product2 = new Product("Mouse", "P1002", 20, 2);
            Product product3 = new Product("Keyboard", "P1003", 50, 1);
            Product product4 = new Product("Monitor", "P1004", 200, 1);

            // Create Orders
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            Order order2 = new Order(customer2);
            order2.AddProduct(product3);
            order2.AddProduct(product4);

            // Display order info
            List<Order> orders = new List<Order> { order1, order2 };

            int orderNumber = 1;
            foreach (var order in orders)
            {
                Console.WriteLine($"Order #{orderNumber}");
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine($"Total Cost: ${order.GetTotalCost():0.00}");
                Console.WriteLine(new string('-', 40)); // separator for readability
                orderNumber++;
            }
        }
    }
}
