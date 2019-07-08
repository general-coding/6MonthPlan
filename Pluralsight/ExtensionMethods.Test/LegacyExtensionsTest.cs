using System;
using ExtensionMethods.LegacyExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionMethods.Test
{
    [TestClass]
    public class LegacyExtensionsTest
    {
        [TestMethod]
        public void ToLegacyFormat_C20()
        {
            //-- Arrange
            DateTime dateTime = new DateTime(1920, 12, 31);

            //-- Act
            string actual = dateTime.ToLegacyFormat();

            Console.Write(actual);

            //-- Assert
            Assert.AreEqual("0201231", actual);
        }

        [TestMethod]
        public void ToLegacyFormat_C21()
        {
            //-- Arrange
            DateTime dateTime = new DateTime(2013, 10, 31);

            //-- Act
            string actual = dateTime.ToLegacyFormat();

            Console.Write(actual);

            //-- Assert
            Assert.AreEqual("1131031", actual);
        }

        [TestMethod]
        public void ToLegacyFormat_Name()
        {
            //-- Arrange
            string name = "John Smith";

            //-- Act
            string actual = name.ToLegacyFormat();

            Console.Write(actual);

            //-- Assert
            Assert.AreEqual("SMITH,JOHN", actual);
        }
    }
}
