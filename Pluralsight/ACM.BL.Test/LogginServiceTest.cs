using ACME.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ACM.BL.Test
{
    [TestClass]
    public class LogginServiceTest
    {
        [TestMethod]
        public void WriteToFileTest()
        {
            //-- Arrange
            var changedItems = new List<ILoggable>();

            var customer = new Customer(1)
            {
                EmailAddress = "a@b.c",
                FirstName = "a",
                LastName = "b",
                AddressList = null
            };
            changedItems.Add(customer);

            var product = new Product(2)
            {
                ProductName = "anker",
                Description = "mouse",
                CurrentPrice = 10M
            };
            changedItems.Add(product);

            //-- Act
            LoggingService.WriteToFile(changedItems);

            //-- Assert
        }
    }
}
