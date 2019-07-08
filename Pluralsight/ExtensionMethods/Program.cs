using ExtensionMethods.LegacyExtensions;
using ExtensionMethods.InterfaceExtensions;
using ExtensionMethods.InterfaceExtensions.Implement;
using System;
using System.Linq;
using System.Xml;
using ExtensionMethods.ExtendingCollections;
using System.Collections;

namespace ExtensionMethods
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(new DateTime(2013, 12, 31).ToLegacyFormat());

            //Console.WriteLine("John Smith".ToLegacyFormat());

            //Console.WriteLine(new DateTime(2013, 10, 24, 13, 10, 15, 951).ToXMLDateTime());

            //Console.WriteLine(new DateTime(2013, 10, 24, 13, 10, 15, 951).ToXMLDateTime(XmlDateTimeSerializationMode.Local));

            //Console.WriteLine(new DateTime(2013, 10, 24, 13, 10, 15, 951).ToXMLDateTime(XmlDateTimeSerializationMode.Utc));

            //IReferenceDataSource source;
            //source = new ApiReferenceDataSource();
            //Console.WriteLine(source.GetItemsByCode("xyz").Count());
            //source = new SqlReferenceDataSource();
            //Console.WriteLine(source.GetItemsByCode("xyz").Count());
            //source = new XmlReferenceDataSource();
            //Console.WriteLine(source.GetItemsByCode("xyz").Count());

            //IReferenceDataSource[] sourcesIRDS =
            //    new IReferenceDataSource[]
            //    {
            //        new ApiReferenceDataSource(),
            //        new SqlReferenceDataSource(),
            //        new XmlReferenceDataSource()
            //    };

            //Console.WriteLine(sourcesIRDS.GetAllItemsByCode("xyz").Count());

            //ArrayList sourcesAL = new ArrayList()
            //{
            //    new ApiReferenceDataSource(),
            //    new SqlReferenceDataSource(),
            //    new XmlReferenceDataSource()
            //};
            //sourcesAL.Add("I am not a reference data source. :P");

            //Console.WriteLine(sourcesAL.GetAllItemsByCode("xyz").Count());

            Console.Read();
        }
    }
}
