using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// # End of Default 
using System.Data.SqlClient;
using System.Data;
using Woc.Book.Common.Service;
using Woc.Book.Common.BusinessEntity;
using Woc.Book.Common.Constant;
namespace Woc.Book.Common.Service
{
    public class ExcelService
    {
        public DataTable GetExportToExcelData(int queryTypeID)
        {

            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_WocBookExportToExcel", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@QueryTypeID", queryTypeID);
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        conn.Open();
                        ad.Fill(table);
                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();
                        return table;
                    }
                }
            }

        }
    }
}
