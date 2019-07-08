using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ExtensionMethods.InterfaceExtensions.Implement.Test
{
    [TestClass()]
    public class ReferenceDataSourceTests
    {
        [TestMethod()]
        public void GetReferenceDataItemsTest_API()
        {
            //-- Arrange
            IReferenceDataSource source;
            source = new ApiReferenceDataSource();

            //-- Act
            int actual = source.GetReferenceDataItems().Count();

            //-- Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod()]
        public void GetReferenceDataItemsTest_SQL()
        {
            //-- Arrange
            IReferenceDataSource source;
            source = new SqlReferenceDataSource();

            //-- Act
            int actual = source.GetReferenceDataItems().Count();

            //-- Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod()]
        public void GetReferenceDataItemsTest_XML()
        {
            //-- Arrange
            IReferenceDataSource source;
            source = new XmlReferenceDataSource();

            //-- Act
            int actual = source.GetReferenceDataItems().Count();

            //-- Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod()]
        public void GetReferenceDataItemsTest_APIByCode()
        {
            //-- Arrange
            IReferenceDataSource source;
            source = new ApiReferenceDataSource();

            //-- Act
            int actual = source.GetItemsByCode("xyz").Count();

            //-- Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod()]
        public void GetReferenceDataItemsTest_SQLByCode()
        {
            //-- Arrange
            IReferenceDataSource source;
            source = new SqlReferenceDataSource();

            //-- Act
            int actual = source.GetItemsByCode("xyz").Count();

            //-- Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod()]
        public void GetReferenceDataItemsTest_XMLByCode()
        {
            //-- Arrange
            var source = new XmlReferenceDataSource();

            //-- Act
            int actual = source.GetItemsByCode("xyz").Count();

            //-- Assert
            Assert.AreEqual(2, actual);
        }
    }
}