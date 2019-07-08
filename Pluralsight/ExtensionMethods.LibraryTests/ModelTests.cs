using System;
using ExtensionMethods.Library.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionMethods.LibraryTests
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void SaveChanges()
        {
            using (Entities container = new Entities())
            {
                var product1 = new Product
                {
                    Name = "Item 1"
                };
                var product2 = new Product
                {
                    Name = "Item 2"
                };
                var customer = new Customer
                {
                    FirstName = "Alpha",
                    LastName = "Bravo"
                };
                var order = new Order
                {
                    Reference = Guid.NewGuid().ToString(),
                    Customer = customer
                };
                order.Products.Add(product1);
                order.Products.Add(product2);
                container.Orders.Add(order);
                container.SaveChanges();
            }
        }
    }

}
