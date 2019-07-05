using System.Collections.Generic;
using System.Linq;

namespace ACM.BL
{
    public class CustomerRepository
    {
        public CustomerRepository()
        {
            addressRepository = new AddressRepository();
        }

        private AddressRepository addressRepository { get; set; }

        public void Add(Customer customer)
        {
            // -- If this is a new customer, create the customer record --
            // Determine whether the customer is an existing customer.
            // If not, validate entered customer information
            // If not valid, notify the user.
            // If valid,
            // Open a connection
            // Set stored procedure parameters with the customer data.
            // Call the save stored procedure.
        }

        public void Update()
        {
            // Open a connection
            // Set stored procedure parameters with the customer data.
            // Call the save stored procedure.
        }

        /// <summary>
        /// Retrieve one customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer Retrieve(int customerId)
        {
            Customer customer = new Customer(customerId);

            if (customerId == 1)
            {
                customer.EmailAddress = "aingo@bingo.com";
                customer.FirstName = "Aingo";
                customer.LastName = "Bingo";
                customer.AddressList = addressRepository.RetrieveByCustomerId(customerId)
                                        .ToList();
            }

            return customer;
        }

        public List<Customer> Retrieve()
        {
            return new List<Customer>();
        }

        /// <summary>
        /// Save the current customer
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return true;
        }
    }
}
