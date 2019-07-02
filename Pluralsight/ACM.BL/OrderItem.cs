using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderItem
    {
        public OrderItem()
        {

        }

        public OrderItem(int orderItemId)
        {
            OrderItemId = orderItemId;
        }

        public int OrderItemId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal? PurchasePrice { get; set; }

        /// <summary>
        /// Validate the order
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            bool isValid = true;

            if (Quantity <= 0) isValid = false;
            if (ProductId <= 0) isValid = false;
            if (PurchasePrice == null) isValid = false;

            return isValid;
        }

        /// <summary>
        /// Retrieves on order item
        /// </summary>
        /// <param name="orderItemId"></param>
        /// <returns></returns>
        public Order Retrieve(int orderItemId)
        {
            return new Order();
        }

        /// <summary>
        /// Retrieves all order items
        /// </summary>
        /// <returns></returns>
        public List<Order> Retrieve()
        {
            return new List<Order>();
        }

        /// <summary>
        /// Saves an order item
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return true;
        }
    }
}
