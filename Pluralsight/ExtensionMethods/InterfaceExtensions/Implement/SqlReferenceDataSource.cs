using System.Collections.Generic;

namespace ExtensionMethods.InterfaceExtensions.Implement
{
    public abstract class SqlDataSource
    {
        public string Name = "SQL";
    }

    public class SqlReferenceDataSource : SqlDataSource, IReferenceDataSource
    {
        public IEnumerable<ReferenceDataItem> GetReferenceDataItems()
        {
            return new List<ReferenceDataItem> 
            {
                new ReferenceDataItem { Code="xyz", Description="from SQL"},
                new ReferenceDataItem { Code="xyz", Description="from SQL 2"}
            };
        }
    }
}
