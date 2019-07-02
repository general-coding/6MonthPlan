using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
