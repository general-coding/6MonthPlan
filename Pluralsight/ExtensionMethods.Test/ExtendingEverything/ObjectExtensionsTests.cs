using ExtensionMethods.InterfaceExtensions;
using ExtensionMethods.InterfaceExtensions.Implement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ExtensionMethods.ExtendingEverything.Test
{
    [TestClass()]
    public class ObjectExtensionsTests
    {
        [TestMethod()]
        public void ToJsonStringTest_Int()
        {
            //-- Arrange
            int obj = int.MaxValue;

            //-- Act
            Debug.WriteLine("obj - " + obj.ToJsonString());

            //-- Assert
        }

        [TestMethod()]
        public void ToJsonStringTest_DateTime()
        {
            //-- Arrange
            DateTime obj = DateTime.Now;

            //-- Act
            Debug.WriteLine("obj - " + obj.ToJsonString());

            //-- Assert
        }

        [TestMethod()]
        public void ToJsonStringTest_ReferenceDataItem()
        {
            //-- Arrange
            ReferenceDataItem obj = new ReferenceDataItem
            {
                Code = "abc",
                Description = "Alpha Bravo Charlie"
            };

            //-- Act
            Debug.WriteLine("obj - " + obj.ToJsonString());

            //-- Assert
        }

        [TestMethod()]
        public void ToJsonStringTest_IEnumerable()
        {
            //-- Arrange
            IEnumerable<IReferenceDataSource> obj = new List<IReferenceDataSource>()
            {
                new ApiReferenceDataSource()
            };

            //-- Act
            Debug.WriteLine("obj - " + obj.ToJsonString());

            //-- Assert
        }

        [TestMethod()]
        public void GetJsonTypeDescription_Int()
        {
            //-- Arrange
            int obj = int.MaxValue;

            //-- Act
            Debug.WriteLine("obj - " + obj.GetJsonTypeDescription());

            //-- Assert
        }

        [TestMethod()]
        public void GetJsonTypeDescription_DateTime()
        {
            //-- Arrange
            DateTime obj = DateTime.Now;

            //-- Act
            Debug.WriteLine("obj - " + obj.GetJsonTypeDescription());

            //-- Assert
        }

        [TestMethod()]
        public void GetJsonTypeDescription_ReferenceDataItem()
        {
            //-- Arrange
            ReferenceDataItem obj = new ReferenceDataItem
            {
                Code = "abc",
                Description = "Alpha Bravo Charlie"
            };

            //-- Act
            Debug.WriteLine("obj - " + obj.GetJsonTypeDescription());

            //-- Assert
        }

        [TestMethod()]
        public void GetJsonTypeDescription_IEnumerable()
        {
            //-- Arrange
            IEnumerable<IReferenceDataSource> obj = new List<IReferenceDataSource>()
            {
                new ApiReferenceDataSource()
            };

            //-- Act
            Debug.WriteLine("obj - " + obj.GetJsonTypeDescription());

            //-- Assert
        }
    }
}