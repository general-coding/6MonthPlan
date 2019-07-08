using System.Collections.Generic;

namespace ExtensionMethods.InterfaceExtensions.Implement
{
    public abstract class XmlDataSource
    {
        public string Name = "XML";
    }

    public class XmlReferenceDataSource : XmlDataSource, IReferenceDataSource
    {
        public IEnumerable<ReferenceDataItem> GetReferenceDataItems()
        {
            return new List<ReferenceDataItem>
            {
                new ReferenceDataItem { Code="xyz", Description="from XML"},
                new ReferenceDataItem { Code="xyz", Description="from XML 2"}
            };
        }
    }
}
