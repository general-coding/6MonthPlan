using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACM.BL.Test
{
    [TestClass]
    public class OrderRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            //-- Arrange
            var orderRepository = new OrderRepository();
            var expected = new Order(10)
            {
                OrderDate = new DateTimeOffset(DateTime.Now.Year
                            , DateTime.Now.Month, DateTime.Now.Day
                            , DateTime.Now.Hour, 0, 0
                            , new TimeSpan(0, 0, 0))
            };

            //-- Act
            var actual = orderRepository.Retrieve(10);

            //-- Assert
            Assert.AreEqual(expected.OrderDate, actual.OrderDate);
        }
    }
}
