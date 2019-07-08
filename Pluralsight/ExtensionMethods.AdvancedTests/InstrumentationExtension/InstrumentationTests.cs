using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;

namespace ExtensionMethods.Advanced.InstrumentationExtension.Test
{
    [TestClass()]
    public class InstrumentationTests
    {
        [TestMethod()]
        public void StartTest()
        {
            //-- Arrange
            Instrumentation instrumentation = new Instrumentation();

            //-- Act
            instrumentation.Start();

            Thread.Sleep(750);

            int actual = instrumentation.GetElapsedTime();

            Debug.Write(actual);

            //-- Assert
            Assert.AreEqual(1, actual);
        }
    }
}