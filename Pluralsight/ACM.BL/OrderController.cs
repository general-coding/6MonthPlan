using ACM.Common;
using ACME.Common;
using System;
using System.Diagnostics;
using System.Linq;

namespace ACM.BL
{
    public class OrderController
    {
        private CustomerRepository customerRepository { get; set; }

        private OrderRepository orderRepository { get; set; }

        private InventoryRepository inventoryRepository { get; set; }

        private EmailLibrary emailLibrary { get; set; }

        public OrderController()
        {
            customerRepository = new CustomerRepository();
            orderRepository = new OrderRepository();
            inventoryRepository = new InventoryRepository();
            emailLibrary = new EmailLibrary();
        }

        public OperationResult PlaceOrder(Customer customer,
                                Order order,
                                Payment payment,
                                bool allowSplitOrders, bool emailReceipt)
        {
            Debug.Assert(customerRepository != null, "Missing customer respository instance");
            Debug.Assert(orderRepository != null, "Missing order repository instance");
            Debug.Assert(inventoryRepository != null, "Missing inventory repository instance");
            Debug.Assert(emailLibrary != null, "Missing email library instance");

            OperationResult operationResult = new OperationResult();

            if (customer == null)
            {
                throw new ArgumentNullException("Customer instance is null");
            }

            if (order == null)
            {
                throw new ArgumentNullException("Order instance is null");
            }

            if (payment == null)
            {
                throw new ArgumentNullException("Payment instance is null");
            }

            customerRepository.Add(customer);

            orderRepository.Add(order);

            inventoryRepository.OrderItems(order, allowSplitOrders);

            payment.ProcessPayment(payment);

            if (emailReceipt)
            {
                operationResult = customer.ValidateEmail();
                if (operationResult.Success)
                {
                    customerRepository.Update();

                    emailLibrary.SendEmail(customer.EmailAddress,
                                            "Here is your receipt");
                }
                else
                {
                    //Log messages
                    if (operationResult.MessageList.Any())
                        operationResult.AddMessage(operationResult.MessageList[0]);
                }
            }

            return operationResult;
        }
    }
}
