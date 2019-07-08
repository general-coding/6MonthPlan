using ExtensionMethods.InterfaceExtensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods.ExtendingCollections
{
    public static class IRefereceDataSourceCollectionsExtensions
    {
        public static IEnumerable<ReferenceDataItem> GetAllItemsByCode
            (this IEnumerable sources
            , string code)
        {
            List<ReferenceDataItem> items = new List<ReferenceDataItem>();

            foreach (var source in sources)
            {
                if (source is IReferenceDataSource refDataSource)
                {
                    items.AddRange(refDataSource.GetItemsByCode(code));
                }
            }

            return items;
        }

        public static IEnumerable<ReferenceDataItem> GetAllItemsByCode
            (this IEnumerable<IReferenceDataSource> sources
            , string code)
        {
            return sources.SelectMany(x => x.GetItemsByCode(code));
        }
    }
}
