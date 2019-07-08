using ExtensionMethods.InterfaceExtensions;
using ExtensionMethods.InterfaceExtensions.Implement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods.ExtendingCollections.Test
{
    [TestClass()]
    public class IRefereceDataSourceCollectionsExtensionsTests
    {
        [TestMethod()]
        public void GetAllItemsByCode_Array()
        {
            //-- Arrange
            IReferenceDataSource[] sources = new IReferenceDataSource[]
            {
                new ApiReferenceDataSource(),
                new SqlReferenceDataSource(),
                new XmlReferenceDataSource()
            };

            //-- Act
            int actual = sources.GetAllItemsByCode("xyz").Count();

            //-- Assert
            Assert.AreEqual(6, actual);
        }

        [TestMethod()]
        public void GetAllItemsByCode_ArrayList()
        {
            //-- Arrange
            ArrayList sources = new ArrayList()
            {
                new ApiReferenceDataSource(),
                new SqlReferenceDataSource(),
                new XmlReferenceDataSource()
            };
            sources.Add("I am not a reference data source. :P");

            //-- Act
            int actual = sources.GetAllItemsByCode("xyz").Count();

            //-- Assert
            Assert.AreEqual(6, actual);
        }

        [TestMethod()]
        public void GetAllItemsByCode_IEnumerable_List()
        {
            //-- Arrange
            List<IReferenceDataSource> sources = new List<IReferenceDataSource>()
            {
                new ApiReferenceDataSource(),
                new SqlReferenceDataSource(),
                new XmlReferenceDataSource()
            };

            //-- Act
            int actual = sources.GetAllItemsByCode("xyz").Count();

            //-- Assert
            Assert.AreEqual(6, actual);
        }

        [TestMethod()]
        public void GetAllItemsByCode_IEnumerable_HashSet()
        {
            //-- Arrange
            HashSet<IReferenceDataSource> sources = new HashSet<IReferenceDataSource>()
            {
                new ApiReferenceDataSource(),
                new SqlReferenceDataSource(),
                new XmlReferenceDataSource()
            };

            //-- Act
            int actual = sources.GetAllItemsByCode("xyz").Count();

            //-- Assert
            Assert.AreEqual(6, actual);
        }
    }
}