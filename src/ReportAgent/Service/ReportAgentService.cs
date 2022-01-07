using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;
using Woc.Book.Base.Constant;

using Woc.Book.ReportAgent.BusinessEntity;



namespace Woc.Book.ReportAgent.Service
{
   internal class ReportAgentService
    {
       public List<ReportAgents> SearchData(DateTime dDailyTrip)
       {
           List<ReportAgents> ListReportAgents = new List<ReportAgents>();
           ReportAgents reportAgents = new ReportAgents();
           using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
           {



               using (SqlCommand cmd = new SqlCommand("usp_WocBookAgentReport", conn))
               {
                   cmd.CommandType = CommandType.StoredProcedure;
                   cmd.Parameters.Add("@OperationDate", SqlDbType.DateTime);
                   cmd.Parameters["@OperationDate"].Value = dDailyTrip;
                   using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                   {
                       DataTable table = new DataTable();
                       conn.Open();
                       ad.Fill(table);

                       if (table.DefaultView.Count > 0)
                       {
                           for (int i = 0; i < table.Rows.Count; i++)
                           {
                               reportAgents.Company = table.Rows[i]["Company"].ToString();
                               reportAgents.Route = table.Rows[i]["Route"].ToString();
                               reportAgents.RefNo = table.Rows[i]["RefNo"].ToString();
                               reportAgents.Contact = table.Rows[i]["Contact"].ToString();
                               reportAgents.StartTime = Convert.ToDateTime(table.Rows[i]["StartTime"].ToString());

                              
                               if (String.IsNullOrEmpty(table.Rows[i]["EndTime"].ToString()))
                               {
                                   reportAgents.EndTime = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                               }
                               else
                               {
                                   reportAgents.EndTime = Convert.ToDateTime(table.Rows[i]["EndTime"].ToString());
                               }
                               reportAgents.CashOrder = table.Rows[i]["CashOrder"].ToString();

                               reportAgents.StartBusNo = table.Rows[i]["StartBusNo"].ToString();
                               reportAgents.EndBusNo = table.Rows[i]["EndBusNo"].ToString();

                               ListReportAgents.Add(reportAgents);
                               reportAgents = new ReportAgents();
                           }
                       }




                       conn.Close();
                       ad.Dispose();
                       conn.Dispose();

                   }
               }

               return ListReportAgents;

           }
       }

    }
}
