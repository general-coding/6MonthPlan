using System.Collections.Generic;

namespace ACM.BL
{
    public class Customer
    {
        public Customer()
        {

        }

        public Customer(int customerId)
        {
            CustomerId = customerId;
        }

        public static int InstanceCount { get; set; }

        public int CustomerId { get; private set; }

        public string FirstName { get; set; }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public string FullName
        {
            get
            {
                string fullName = LastName;
                if (!string.IsNullOrEmpty(FirstName))
                {
                    if (!string.IsNullOrWhiteSpace(fullName))
                    {
                        fullName += ", ";
                    }
                    fullName += FirstName;
                }
                return fullName;
            }
        }

        public string EmailAddress { get; set; }

        /// <summary>
        /// Validates customer data
        /// </summary>
        /// <returns>
        /// true if customer data is valid
        /// false if customer data is not valid
        /// </returns>
        public bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrEmpty(LastName)) isValid = false;
            if (string.IsNullOrEmpty(FirstName)) isValid = false;

            return isValid;
        }

        /// <summary>
        /// Retrieve a customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>
        /// The customer object
        /// </returns>
        public Customer Retrieve(int customerId)
        {
            return new Customer();
        }

        /// <summary>
        /// Retrieves all the customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> Retrieve()
        {
            return new List<Customer>();
        }

        /// <summary>
        /// Saves the customer data
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return true;
        }
    }
}
