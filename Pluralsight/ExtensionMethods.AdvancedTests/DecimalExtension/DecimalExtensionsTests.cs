using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ExtensionMethods.Advanced.DecimalExtension.Test
{
    [TestClass()]
    public class DecimalExtensionsTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            decimal input = 10.51M;
            Assert.AreEqual("10.5", input.ToString());
        }

        [TestMethod()]
        public void ToStringRoundedTest()
        {
            decimal input = 10.51M;
            Assert.AreEqual("10.5", input.ToStringRounded());
        }

        [TestMethod()]
        public void ToStringRoundedIComparableTest()
        {
            decimal input = 10.51M;
            Assert.AreEqual("10.5", ((IComparable)input).ToStringRounded());
        }

        [TestMethod()]
        public void ToStringRoundedIComparableDecimalTest()
        {
            decimal input = 10.51M;
            Assert.AreEqual("10.5", ((IComparable<decimal>)input).ToStringRounded());
        }
    }
}