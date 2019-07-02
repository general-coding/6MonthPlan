using ACME.Common;
using System;
using System.Collections.Generic;

namespace ACM.BL
{
    public class Order : EntityBase, ILoggable
    {
        public Order() : this(0)
        {

        }

        public Order(int orderId)
        {
            OrderId = orderId;
            OrderItems = new List<OrderItem>();
        }

        public int OrderId { get; private set; }

        public DateTimeOffset? OrderDate { get; set; }

        public int CustomerId { get; set; }

        public int ShippingAddressId { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Validates the order
        /// </summary>
        /// <returns></returns>
        public override bool Validate()
        {
            var isValid = true;

            if (OrderDate == null) isValid = false;

            return isValid;
        }

        public override string ToString()
        {
            return " " + OrderId;
        }

        public string Log()
        {
            throw new NotImplementedException();
        }
    }
}
