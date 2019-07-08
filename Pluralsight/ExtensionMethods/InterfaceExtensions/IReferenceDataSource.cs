using System.Collections.Generic;

namespace ExtensionMethods.InterfaceExtensions
{
    public interface IReferenceDataSource
    {
        IEnumerable<ReferenceDataItem> GetReferenceDataItems();
    }
}
