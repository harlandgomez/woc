using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Woc.Book.Base.Service
{
   public class AccessLevelService
    {
       public DataTable GetAccessLevel()
       {
           using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
           {
               using (SqlCommand cmd = new SqlCommand("Select * from AccessLevel", conn))
               {
                   cmd.CommandType = CommandType.Text;
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
