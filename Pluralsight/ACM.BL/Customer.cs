using ACME.Common;
using System.Collections.Generic;

namespace ACM.BL
{
    public class Customer : EntityBase, ILoggable
    {
        //Constructor chaining allows calling one constructor from another
        public Customer() : this(0)
        {

        }

        public Customer(int customerId)
        {
            CustomerId = customerId;
            AddressList = new List<Address>();
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

        public List<Address> AddressList { get; set; }

        public string CustomerType { get; set; }

        /// <summary>
        /// Validates customer data
        /// </summary>
        /// <returns>
        /// true if customer data is valid
        /// false if customer data is not valid
        /// </returns>
        public override bool Validate()
        {
            var isValid = true;

            if (string.IsNullOrEmpty(LastName)) isValid = false;
            if (string.IsNullOrEmpty(FirstName)) isValid = false;

            return isValid;
        }

        public override string ToString()
        {
            return FullName;
        }

        public string Log()
        {
            return "This is a customer";
        }
    }
}
