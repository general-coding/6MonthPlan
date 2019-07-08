using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods.InterfaceExtensions
{
    public static class IReferenceDataSourceExtensions
    {
        public static IEnumerable<ReferenceDataItem> GetItemsByCode
            (this IReferenceDataSource source
            , string code)
        {
            return source.GetReferenceDataItems().Where(x => x.Code == code);
        }
    }
}
