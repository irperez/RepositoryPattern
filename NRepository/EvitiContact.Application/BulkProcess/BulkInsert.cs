using EvitiContact.ContactModel;
using System.Data;
using System.Data.SqlClient;
using eviti.data.tracking.BulkImport;

namespace EvitiContact.Service.BulkProcess
{
    public class BulkInsert
    {
        public static void BulkInsertZips(ZipCodes[] zips, string connectionString)
        {
            //   https://codingsight.com/entity-framework-improving-performance-when-saving-data-to-database/
           

            //entities - entity collection EntityFramework
            using (IDataReader reader = zips.GetDataReader())
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlBulkCopy bcp = new SqlBulkCopy(connection))
            {
                connection.Open();

                bcp.DestinationTableName = "[ZipCodes]";
                bcp.ColumnMappings.Add("ID", "ID");
                bcp.ColumnMappings.Add("ZipCode", "ZipCode");
                bcp.ColumnMappings.Add("Latitude", "Latitude");
                bcp.ColumnMappings.Add("Longitude", "Longitude");
                bcp.ColumnMappings.Add("Class", "Class");
                bcp.ColumnMappings.Add("City", "City");
                bcp.ColumnMappings.Add("StateCode", "StateCode");
                bcp.WriteToServer(reader);
            }


        }
    }
}
