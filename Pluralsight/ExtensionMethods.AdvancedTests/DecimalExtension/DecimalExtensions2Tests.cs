using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Extensions.Test
{
    [TestClass()]
    public class DecimalExtensions2Tests
    {
        [TestMethod()]
        public void ToStringRoundedTest()
        {
            decimal input = 10.51M;
            Assert.AreEqual("10.5", input.ToStringRounded());
        }
    }
}