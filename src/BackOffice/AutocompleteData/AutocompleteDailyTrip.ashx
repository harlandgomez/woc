<%@ WebHandler Language="C#" Class="AutocompleteDailyTrip"  Debug ="true"%>
using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Woc.Book.Common.Service;

public class AutocompleteDailyTrip: IHttpHandler
{
    public void ProcessRequest (HttpContext context) 
    {
        string category = context.Request.QueryString["category"];
        string sql;
        using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
        {
            if (category != "Select")
            {
                if (category == "Agent")
                {
                    category = "Agent.Agent";
                }
                else
                {
                    category = "Adhoc." + category;
                }
                
                sql = "Select  " + category + "  FROM dbo.Adhoc INNER JOIN Agent ON Adhoc.AgentID = Agent.AgentID"; 
                        
            
            
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

                                context.Response.Write(table.Rows[i][context.Request.QueryString["category"].ToString()].ToString() + Environment.NewLine);

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