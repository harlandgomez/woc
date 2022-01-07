using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// # End of Default 
using System.Data.SqlClient;
using System.Data;
using Woc.Book.Base.Service;

namespace Woc.Book.Base.Service
{
    public class GSTService
    {
        public DataTable GetGSTTypes()
        {
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {

                using (SqlCommand cmd = new SqlCommand("usp_WocBookGSTType", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
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

        public Decimal GetGSTPercentage(){
            SQLHelper helper = new SQLHelper();
            return Convert.ToDecimal(helper.GetExecuteScalarBySQL("SELECT Value FROM Setting WHERE SettingCode = 'GST_PERCENTAGE'"));
        }
    }
}
