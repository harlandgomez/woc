using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Woc.Book.Base.Service;
using Woc.Book.Staff.BusinessEntity;

namespace Woc.Book.Login.Service
{
    public class LoginService
    {
        public LoginService()
        { 
        }
        public Staffs Login(String userID)
        {
            Staffs staffs = new Staffs();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {

                using (SqlCommand cmd = new SqlCommand("Select Salt, Password from Users where LoginID = '" + userID + "' ", conn))
                {

                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        conn.Open();
                        ad.Fill(table);

                        if (table.DefaultView.Count > 0)
                        {
                            staffs.Salt = (byte[])table.Rows[0]["Salt"];
                            staffs.Password = (byte[])table.Rows[0]["Password"];
                        }

                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();
                      
                    }
                }
            }
            return staffs;
        }
        public bool CheckUserNameExists(String userID)
        {
            SQLHelper sqlHelp = new SQLHelper();
            try
            {
                int count = (int) sqlHelp.GetExecuteScalarBySQL("SELECT COUNT(1) FROM Users WHERE LoginID = '" + userID + "'");

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlHelp.Dispose();
            }

        }
    }
}
