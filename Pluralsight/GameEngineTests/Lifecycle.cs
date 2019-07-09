using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameEngineTests
{
    [TestClass()]
    public class Lifecycle
    {
        static string SomeTestContext;

        [TestInitialize()]
        public void LifecycleInit()
        {
            Console.WriteLine("Test initialize lifecycle");
        }

        [TestCleanup()]
        public void LifecycleClean()
        {
            Console.WriteLine("Test cleanup lifecycle");
        }

        [ClassInitialize()]
        public static void LifecycleClassInit(TestContext context)
        {
            Console.WriteLine("Class init lifecycle");

            Console.WriteLine("data loaded from disk or some expensive object creation");
            SomeTestContext = "42";
        }

        [ClassCleanup()]
        public static void LifecycleClassClean()
        {
            Console.WriteLine("Class cleanup lifecycle");
        }

        [TestMethod]
        public void TestA()
        {
            Console.WriteLine("Test A starting");
            Console.WriteLine($"Shared test context: {SomeTestContext}");
        }

        [TestMethod]
        public void TestB()
        {
            Console.WriteLine("Test B starting");
            Console.WriteLine($"Shared test context: {SomeTestContext}");
        }
    }
}
