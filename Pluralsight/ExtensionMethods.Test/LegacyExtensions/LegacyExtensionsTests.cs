using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionMethods.LegacyExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods.LegacyExtensions.Test
{
    [TestClass()]
    public class LegacyExtensionsTests
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