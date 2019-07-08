using ExtensionMethods.Advanced.InternalClassesExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace ExtensionMethods.AdvancedTests.InternalClassesExtension
{
    [TestClass]
    public class InternalClassesExtensionTests
    {
        [TestMethod]
        public void InternalClasses_1()
        {
            var obj1 = new InternalClasses_1();
            Assert.AreEqual("a", obj1.GetString1());
            Assert.AreEqual("A", obj1.GetString1Upper());
            Assert.AreEqual("", obj1.GetString3Upper());

            Assert.AreEqual("abc", obj1.GetString0());
            Assert.AreEqual("ABC", obj1.GetString0Upper());
        }

        [TestMethod]
        public void InternalClasses_2()
        {
            var obj2 = new InternalClasses_1.InternalClasses_2();
            Assert.AreEqual("b", obj2.GetString2());
            Assert.AreEqual("B", obj2.GetString2Upper());
            Assert.AreEqual("", obj2.GetString3Upper());

            Assert.AreEqual("xyz", obj2.GetString0());
            Assert.AreEqual("XYZ", obj2.GetString0Upper());
        }

        [TestMethod]
        public void InternalClasses_3()
        {
            var type3 = typeof(InternalClasses_1.InternalClasses_2)
                        .GetNestedType("InternalClasses_3"
                                        , BindingFlags.NonPublic);
            var methodInfo = type3
                                .GetMethod("GetString3"
                                            , BindingFlags.NonPublic
                                            | BindingFlags.Instance);
            var obj3 = Activator.CreateInstance(type3);
            Assert.AreEqual("c", methodInfo.Invoke(obj3, null));
            Assert.AreEqual("C", obj3.GetString3Upper());
        }
    }
}
