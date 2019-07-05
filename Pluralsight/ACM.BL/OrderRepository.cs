using System;
using System.Collections.Generic;

namespace ACM.BL
{
    public class OrderRepository
    {
        public void Add(Order order)
        {
            // -- Create the order for the customer. --
            // For each item ordered,
            // Validate the entered information.
            // If not valid, notify the user.
            // If valid,
            // Open a connection
            // Set stored procedure parameters with the order data.
            // Call the save stored procedure.
        }

        /// <summary>
        /// Retrieve one order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order Retrieve(int orderId)
        {
            Order order = new Order(orderId);

            if (orderId == 10)
            {
                order.OrderDate = new DateTimeOffset(DateTime.Now.Year
                                    , DateTime.Now.Month, DateTime.Now.Day
                                    , DateTime.Now.Hour, 0, 0
                                    , new TimeSpan(0, 0, 0));
            }

            return order;
        }

        /// <summary>
        /// Retrieves all orders
        /// </summary>
        /// <returns></returns>
        public List<Order> Retrieve()
        {
            return new List<Order>();
        }

        /// <summary>
        /// Saves the order
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return true;
        }
    }
}
