using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionMethods.Advanced.InstrumentationExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ExtensionMethods.Advanced.InstrumentationExtension.Test
{
    [TestClass()]
    public class InstrumentationExtensionsTests
    {
        [TestMethod()]
        public void GetPreciseElapseTimeTest()
        {
            //-- Arrange
            Instrumentation instrumentation = new Instrumentation();

            //-- Act
            instrumentation.Start();

            Thread.Sleep(750);

            double elapsedTime = instrumentation.GetPreciseElapsedTime();

            Debug.Write(elapsedTime);

            //-- Assert
            Assert.IsTrue(elapsedTime >= 0.75 && elapsedTime < 0.780);
        }

        [TestMethod()]
        public void GetReallyPreciseElapsedTimeTest()
        {
            //-- Arrange
            Instrumentation instrumentation = new Instrumentation();

            //-- Act
            instrumentation.StartWithPrecision();

            Thread.Sleep(750);

            double elapsedTime = instrumentation.GetReallyPreciseElapsedTime();

            Debug.Write(elapsedTime);

            //-- Assert
            Assert.IsTrue(elapsedTime >= 750);
        }
    }
}