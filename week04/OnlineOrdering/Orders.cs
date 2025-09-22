using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public List<Product> Products { get { return _products; } }
        public Customer Customer { get { return _customer; } set { _customer = value; } }

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double GetTotalCost()
        {
            double total = 0;
            foreach (var product in _products)
            {
                total += product.GetTotalPrice();
            }

            double shippingCost = _customer.IsInUSA() ? 5 : 35;
            return total + shippingCost;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (var product in _products)
            {
                label += $"- {product.Name} (ID: {product.ProductId})\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{_customer.Name}\n{_customer.Address.GetFullAddress()}";
        }
    }
}
