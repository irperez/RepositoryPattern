using System;
using System.Collections.Generic;
using System.Text;

namespace eviti.data.tracking.BulkImport
{
    /// <summary>
    ///  https://codingsight.com/entity-framework-improving-performance-when-saving-data-to-database/
    /// </summary>
    public static class GenericListDataReaderExtensions
    {
        public static GenericListDataReader<T> GetDataReader<T>(this IEnumerable<T> list)
        {
            return new GenericListDataReader<T>(list);
        }
    }
}
