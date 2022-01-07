<%@ WebHandler Language="C#" Class="AutocompleteDebtorSettlementAgent"  Debug ="true"%>
using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Woc.Book.Base.Service;

public class AutocompleteDebtorSettlementAgent : IHttpHandler
{
    public void ProcessRequest (HttpContext context) 
    {
        string category = context.Request.QueryString["category"];
        string sql;
        using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
        {

            sql = "select InvoiceCode from Invoice";

            if (category != "Select")
            {
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
                                context.Response.Write(table.Rows[i]["InvoiceCode"].ToString() + Environment.NewLine);
                            }

                        }
                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
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