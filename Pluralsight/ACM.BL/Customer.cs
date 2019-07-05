using ACM.Common;
using ACME.Common;
using System;
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

        /// <summary>
        /// Calculates the percent of the step goal reached.
        /// </summary>
        /// <param name="goalSteps"></param>
        /// <param name="actualSteps"></param>
        /// <returns></returns>
        public decimal CalculatePercentOfGoalSteps(string goalSteps, string actualSteps)
        {
            if (string.IsNullOrWhiteSpace(goalSteps))
            {
                throw new ArgumentException("Goal must be entered", "goalSteps");
            }

            if (string.IsNullOrWhiteSpace(actualSteps))
            {
                throw new ArgumentException("Actual steps count must be entered", "actualSteps");
            }

            if (!decimal.TryParse(goalSteps, out decimal goalStepCount))
            {
                throw new ArgumentException("Goal must be numeric", "goalSteps");
            }

            if (!decimal.TryParse(actualSteps, out decimal actualStepCount))
            {
                throw new ArgumentException("Actual steps must be numeric", "actualSteps");
            }

            return CalculatePercentOfGoalSteps(goalStepCount, actualStepCount);
        }

        public decimal CalculatePercentOfGoalSteps(decimal goalStepCount, decimal actualStepCount)
        {
            if (goalStepCount <= 0)
            {
                throw new ArgumentException("Goal must be greater than 0", "goalSteps");
            }

            return Math.Round(actualStepCount / goalStepCount * 100, 2);
        }

        public OperationResult ValidateEmail()
        {
            var op = new OperationResult();

            if (string.IsNullOrWhiteSpace(EmailAddress))
            {
                op.Success = false;
                op.AddMessage("Email address is null");
            }

            if (op.Success)
            {
                var isValidFormat = true;
                // Code here that validates the format of the email
                // using Regular Expressions.
                if (!isValidFormat)
                {
                    op.Success = false;
                    op.AddMessage("Email address is not in a correct format");
                }
            }

            if (op.Success)
            {
                var isRealDomain = true;
                // Code here that confirms whether domain exists.
                if (!isRealDomain)
                {
                    op.Success = false;
                    op.AddMessage("Email address does not include a valid domain");
                }
            }
            return op;
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
