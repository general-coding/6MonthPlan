using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ExtensionMethods.Advanced.DateTimeExtension.Test
{
    [TestClass()]
    public class DateTimeExtensionsTests
    {
        [TestMethod()]
        public void ToXmlDateTimeTest()
        {
            string xmlDateTime2 = DateTimeExtensions.ToXmlDateTime(new DateTime(2013, 10, 24));
            Assert.AreEqual("2013-10-24T00:00:00Z", xmlDateTime2);

            string xmlDateTime = new DateTime(2013, 10, 24).ToXmlDateTime();
            Assert.AreEqual("2013-10-24T00:00:00Z", xmlDateTime);
        }
    }
}