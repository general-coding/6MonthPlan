using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Test
{
    [TestClass()]
    public class EnumExtensionsTests
    {
        [TestMethod]
        public void GetName()
        {
            var intro = Module.Intro;
            Assert.AreEqual("Intro", intro.ToString());
            Assert.AreEqual("Intro", Enum.GetName(typeof(Module), intro));
            Assert.AreEqual("Intro", intro.GetName());
        }

        [TestMethod]
        public void GetDescription()
        {
            Assert.AreEqual("Introducing Extension Methods", Module.Intro.GetDescription()); //"Introducing Extension Methods"
            Assert.AreEqual("Library", Module.Library.GetDescription());

            Assert.AreEqual("In Progress", ModuleStatus.InProgress.GetDescription());
            Assert.AreEqual("Complete", ModuleStatus.Complete.GetDescription());
        }

        public enum Module
        {
            [ComponentModel.Description("Introducing Extension Methods")]
            Intro,
            Advanced,
            Library
        }

        public enum ModuleStatus
        {
            Todo = 1,
            [ComponentModel.Description("In Progress")]
            InProgress = 2,
            Complete = 3
        }
    }
}