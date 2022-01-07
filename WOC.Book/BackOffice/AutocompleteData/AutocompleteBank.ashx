<%@ WebHandler Language="C#" Class="AutocompleteBank"  Debug ="true"%>
using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Woc.Book.Base.Service;

public class AutocompleteBank : IHttpHandler
{
    public void ProcessRequest (HttpContext context) 
    {
        string category = context.Request.QueryString["category"];
        string sql;
        using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
        {
            sql = "SELECT DISTINCT Bank FROM Payment";
            
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    conn.Open();
                    ad.Fill(table);

                    if (table.DefaultView.Count > 0)
                    {
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            context.Response.Write(table.Rows[i]["Bank"].ToString() + Environment.NewLine);
                        }

                    }
                    conn.Close();
                    ad.Dispose();
                    conn.Dispose();

                }
            }

        }
       
        
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
  
}