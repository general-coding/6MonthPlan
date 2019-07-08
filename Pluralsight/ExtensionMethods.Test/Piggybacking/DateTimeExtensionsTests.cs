using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml;

namespace ExtensionMethods.Piggybacking.Test
{
    [TestClass()]
    public class DateTimeExtensionsTests
    {
        [TestMethod()]
        public void ToXMLDateTimeTest()
        {
            //-- Arrange
            DateTime dateTime = new DateTime(2013, 10, 24, 13, 10, 15, 951);

            //-- Act
            string actual = dateTime.ToXMLDateTime();

            //-- Assert
            Assert.AreEqual("2013-10-24T13:10:15.951Z", actual);
        }

        [TestMethod()]
        public void ToXMLDateTimeTest_Local()
        {
            //-- Arrange
            DateTime dateTime = new DateTime(2013, 10, 24, 13, 10, 15, 951);

            //-- Act
            string actual = dateTime.ToXMLDateTime(XmlDateTimeSerializationMode.Local);

            //-- Assert
            Assert.AreEqual("2013-10-24T13:10:15.951-05:00", actual);
        }
    }
}