using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ACM.BL.Test
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            //-- Arrange
            Customer customer = new Customer
            {
                FirstName = "Pongo",
                LastName = "Bongo"
            };

            string expected = "Bongo, Pongo";

            //-- Act
            string actual = customer.FullName;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            //-- Arrange
            Customer customer = new Customer
            {
                LastName = "Bongo"
            };

            string expected = "Bongo";

            //-- Act
            string actual = customer.FullName;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            //-- Arrange
            Customer customer = new Customer
            {
                FirstName = "Pongo"
            };

            string expected = "Pongo";

            //-- Act
            string actual = customer.FullName;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StaticTest()
        {
            //-- Arrange
            var c1 = new Customer
            {
                FirstName = "Aingo"
            };
            Customer.InstanceCount += 1;

            var c2 = new Customer
            {
                FirstName = "Bingo"
            };
            Customer.InstanceCount += 1;

            var c3 = new Customer
            {
                FirstName = "Cingo"
            };
            Customer.InstanceCount += 1;

            int expected = 3;

            //-- Act
            int actual = Customer.InstanceCount;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateValidTest()
        {
            //-- Arrange
            Customer c1 = new Customer
            {
                FirstName = "Pongo",
                LastName = "Bongo"
            };

            bool expected = true;

            //-- Act
            bool actual = c1.Validate();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateMissingFirstName()
        {
            //-- Arrange
            Customer c1 = new Customer
            {
                LastName = "Bongo"
            };

            bool expected = false;

            //-- Act
            bool actual = c1.Validate();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateMissingLastName()
        {
            //-- Arrange
            Customer c1 = new Customer
            {
                FirstName = "Pongo"
            };

            bool expected = false;

            //-- Act
            bool actual = c1.Validate();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePercentOfGoalStepsTestValid()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "2000";
            decimal expected = 40M;

            //-- Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePercentOfGoalStepsTestValidAndSame()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "5000";
            decimal expected = 100M;

            //-- Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePercentOfGoalStepsTestValidActualIsZero()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "0";
            decimal expected = 0M;

            //-- Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStepsTestGoalIsNull()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = null;
            string actualSteps = "2000";

            //-- Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //-- Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStepsTestGoalIsEmpty()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = "";
            string actualSteps = "2000";

            //-- Act
            try
            {
                var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Goal must be numeric", ex.Message);
                throw;
            }

            //-- Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStepsTestGoalIsNotNumeric()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = "one";
            string actualSteps = "2000";

            //-- Act
            try
            {
                var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Goal must be numeric", ex.Message);
                throw;
            }

            //-- Assert
        }
    }
}
