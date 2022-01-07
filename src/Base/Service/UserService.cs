using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Woc.Book.Base.Service;

namespace Woc.Book.Base.Service
{
   public class UserService
    {
       public Guid GetLoginID(String userID)
       {

           using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
           {

               using (SqlCommand cmd = new SqlCommand("Select UserID from Users where LoginID = '" + userID + "'", conn))
               {

                   cmd.CommandType = CommandType.Text;
                   cmd.Connection.Open();


                   Guid loginID = new Guid(cmd.ExecuteScalar().ToString());
                   conn.Close();

                   conn.Dispose();

                   return loginID;


               }
           }
       }
    }
}
