using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.SqlClient;
using System.Data;

using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;

using Woc.Book.DebtorSettlement.BusinessEntity;
using Woc.Book.DebtorSettlement.Constant;

//Agent 
using Woc.Book.Agent.BusinessEntity;


namespace Woc.Book.DebtorSettlement.Service
{
 internal class DebtorSettlementService
    {
     public List<DebtorSettlements> SearchData(String agentID, String invoice)
     {
         StringBuilder sql = new StringBuilder();
         DebtorSettlementDTO  debtorSettlementDTO  = new DebtorSettlementDTO();
         DebtorSettlements debtorSettlements = new DebtorSettlements();
         List<DebtorSettlements> ListDebtorSettlement = new List<DebtorSettlements>();

         sql = new StringBuilder();
         sql.AppendLine("SELECT AgentID");
         sql.AppendLine("	, InvoiceCode");
         sql.AppendLine("	, InvoiceDate");
         sql.AppendLine("	, TotalAmount");
         sql.AppendLine("	, Deposit");
         sql.AppendLine("	, Balance");
         sql.AppendLine("	, dbo.udf_CreditNoteSumByInvoiceCode(InvoiceCode) AS CNAmount");
         sql.AppendLine("	, CASE (SELECT COUNT(*) FROM CreditNote CN WHERE CN.InvoiceCode = Invoice.InvoiceCode)");
         sql.AppendLine("	   WHEN 0 THEN 'Create'");
         sql.AppendLine("	   WHEN 1 THEN (SELECT CN.CreditNoteCode FROM CreditNote CN WHERE CN.InvoiceCode = Invoice.InvoiceCode)");
         sql.AppendLine("	   ELSE 'Show' END AS CNLinkLabel");
         sql.AppendLine("FROM Invoice ");
         sql.AppendLine("WHERE Balance > 0 AND ActiveStatus = 'A'");

         if (!string.IsNullOrEmpty(agentID) && !string.IsNullOrEmpty(invoice))
         {
             sql.AppendLine("AND AgentID = '" + agentID + "'");
             sql.AppendLine("AND InvoiceCode = '" + invoice + "'");
         }
         else if (!string.IsNullOrEmpty(agentID))
         {
             sql.AppendLine("AND AgentID = '" + agentID + "' ");
         }
         else if (!string.IsNullOrEmpty(invoice))
         {
             sql.Clear();
             sql.AppendLine("AND InvoiceCode = '" + invoice + "'");
         }

         using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
         {
             
             using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
             {
                 cmd.CommandType = CommandType.Text;
                 using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                 {
                     DataTable table = new DataTable();
                     ad.Fill(table);

                     if (table.DefaultView.Count > 0)
                     {
                         for (int i = 0; i < table.Rows.Count; i++)
                         {
                             debtorSettlements.InvoiceCode = table.Rows[i]["InvoiceCode"].ToString();
                             debtorSettlements.InvoiceDate = Convert.ToDateTime(table.Rows[i]["InvoiceDate"]);
                             debtorSettlements.TotalAmount = Convert.ToDecimal(table.Rows[i]["TotalAmount"]);
                             debtorSettlements.Deposit = Convert.ToDecimal(table.Rows[i]["Deposit"]);
                             debtorSettlements.Balance = Convert.ToDecimal(table.Rows[i]["Balance"]);

                             if (String.IsNullOrEmpty(table.Rows[i]["CNAmount"].ToString()))
                             {
                                 debtorSettlements.CNAmount = 0;
                             }
                             else
                             {
                                 debtorSettlements.CNAmount = Convert.ToDecimal(table.Rows[i]["CNAmount"]);
                             }

                             debtorSettlements.CNLinkLabel = table.Rows[i]["CNLinkLabel"].ToString();

                             ListDebtorSettlement.Add(debtorSettlements);
                             debtorSettlements = new DebtorSettlements();
                         }
                     }
                     conn.Close();
                     ad.Dispose();
                     conn.Dispose();
                 }
             }
         }

         return ListDebtorSettlement;
     }
     public String SaveData(IAccountEntity iAccount)
     {

        DebtorSettlementDTO debtorSettlementDTO = new DebtorSettlementDTO();

        debtorSettlementDTO = (DebtorSettlementDTO)iAccount;

        BatchSavePayment(debtorSettlementDTO.ListPayments);
        BatchUpdateInvoiceBalance(debtorSettlementDTO.ListPayments);

        return Woc.Book.Base.Constant.Constant.MessageSaved;
     }

     private void BatchSavePayment(List<Payments> listPayment)
     {
         DataTable table = new DataTable();

         table.Columns.Add(new DataColumn("TransactionMode", typeof(int)));
         table.Columns.Add(new DataColumn("PaymentID", typeof(Guid)));
         table.Columns.Add(new DataColumn("AgentID", typeof(Guid)));
         table.Columns.Add(new DataColumn("InvoiceCode", typeof(String)));
         table.Columns.Add(new DataColumn("PaymentAmount", typeof(Decimal)));
         table.Columns.Add(new DataColumn("PaymentDate", typeof(DateTime)));
         table.Columns.Add(new DataColumn("PaymentMode", typeof(String)));
         table.Columns.Add(new DataColumn("Bank", typeof(String)));
         table.Columns.Add(new DataColumn("Description", typeof(String)));
         table.Columns.Add(new DataColumn("ChequeNumber", typeof(String)));
         table.Columns.Add(new DataColumn("Status", typeof(String)));
         table.Columns.Add(new DataColumn("CreatedBy", typeof(Guid)));
         table.Columns.Add(new DataColumn("Remarks", typeof(String)));
         
         
         foreach (Payments payments in listPayment)
         {
             DataRow row = table.NewRow();
             row["TransactionMode"] = 1;
             row["PaymentID"] = Guid.NewGuid();
             row["AgentID"] = payments.AgentID;
             row["InvoiceCode"] = payments.InvoiceCode;
             row["PaymentAmount"] = payments.PaymentAmount;
             row["PaymentDate"] = DateTime.Now;
             row["PaymentMode"] = payments.PaymentMode;
             row["Bank"] = payments.Bank;
             row["Description"] = payments.Description;
             row["ChequeNumber"] = payments.ChequeNumber;
             row["Remarks"] = payments.Remarks;
             row["Status"] = payments.Status;
             row["CreatedBy"] = payments.CreatedBy;
             table.Rows.Add(row);
         }

         using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
         {
             // Create a SqlDataAdapter based on a SELECT query.
             SqlDataAdapter adapter = new SqlDataAdapter();

             // Create a SqlCommand to execute the stored procedure.
             adapter.InsertCommand = new SqlCommand("usp_WocBookPayment", connection);
             adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

            
             adapter.InsertCommand.Parameters.Add("@TransactionMode", SqlDbType.Int, 4, "TransactionMode");
             adapter.InsertCommand.Parameters.Add("@PaymentID", SqlDbType.UniqueIdentifier, 16, "PaymentID");
             adapter.InsertCommand.Parameters.Add("@AgentID", SqlDbType.UniqueIdentifier, 16, "AgentID");
             adapter.InsertCommand.Parameters.Add("@InvoiceCode", SqlDbType.NVarChar, 100, "InvoiceCode");
             adapter.InsertCommand.Parameters.Add("@PaymentAmount", SqlDbType.Money, 8, "PaymentAmount");
             adapter.InsertCommand.Parameters.Add("@PaymentDate", SqlDbType.DateTime, 8, "PaymentDate");
             adapter.InsertCommand.Parameters.Add("@PaymentMode", SqlDbType.NVarChar, 50, "PaymentMode");
             adapter.InsertCommand.Parameters.Add("@Bank", SqlDbType.NVarChar, 250, "Bank");
             adapter.InsertCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 250, "Description");
             adapter.InsertCommand.Parameters.Add("@ChequeNumber", SqlDbType.NVarChar, 50, "ChequeNumber");
             adapter.InsertCommand.Parameters.Add("@Remarks", SqlDbType.NVarChar, 250, "Remarks");
             adapter.InsertCommand.Parameters.Add("@Status", SqlDbType.NVarChar, 250, "Status");
             adapter.InsertCommand.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier, 16, "CreatedBy");
             
             // Update the database.
             adapter.Update(table);
         }
     }


     private void BatchUpdateInvoiceBalance(List<Payments> listPayment)
     {
         DataTable table = new DataTable();

         table.Columns.Add(new DataColumn("TransactionMode", typeof(int)));
         table.Columns.Add(new DataColumn("AgentID", typeof(Guid)));
         table.Columns.Add(new DataColumn("InvoiceCode", typeof(String)));
         table.Columns.Add(new DataColumn("Deposit", typeof(Decimal)));
         table.Columns.Add(new DataColumn("Balance", typeof(Decimal)));
         table.Columns.Add(new DataColumn("UpdatedBy", typeof(Guid)));

         foreach (Payments payments in listPayment)
         {
             DataRow row = table.NewRow();
             row["TransactionMode"] = 12;
             row["AgentID"] = payments.AgentID;
             row["InvoiceCode"] = payments.InvoiceCode;
             row["Deposit"] = payments.Deposit;
             row["Balance"] = payments.Balance;
             row["UpdatedBy"] = payments.UpdatedBy;
             table.Rows.Add(row);
         }

         using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
         {
             // Create a SqlDataAdapter based on a SELECT query.
             SqlDataAdapter adapter = new SqlDataAdapter();

             // Create a SqlCommand to execute the stored procedure.
             adapter.InsertCommand = new SqlCommand("usp_WocBookInvoice", connection);
             adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

             adapter.InsertCommand.Parameters.Add("@TransactionMode", SqlDbType.Int, 4, "TransactionMode");
             adapter.InsertCommand.Parameters.Add("@AgentID", SqlDbType.UniqueIdentifier, 16, "AgentID");
             adapter.InsertCommand.Parameters.Add("@InvoiceCode", SqlDbType.NVarChar, 50, "InvoiceCode");
             adapter.InsertCommand.Parameters.Add("@Deposit", SqlDbType.Money, 8, "Deposit");
             adapter.InsertCommand.Parameters.Add("@Balance", SqlDbType.Money, 8, "Balance");
             adapter.InsertCommand.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier, 16, "UpdatedBy");

             // Update the database.
             adapter.Update(table);
         }
     }


     public List<Agents> GetAgent()
     {
         try
         {
             List<Agents> ListAgents = new List<Agents>();
             Agents agents;
             using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
             {
                 using (SqlCommand cmd = new SqlCommand("Select A.AgentID, A.Agent FROM Agent A WHERE EXISTS (Select * FROM Invoice WHERE AgentID = A.AgentID)", conn))
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
                          
                         foreach (DataRow row in table.Rows)
                         {
                             agents = new Agents();
                             agents.AgentID = new Guid(row["AgentID"].ToString());
                             agents.Agent = row["Agent"].ToString();
                             ListAgents.Add(agents);
                         }

                        
                     }
                 }
             }
             return ListAgents;
         
         }

         catch
         {
             return null;
         }
     }
    }
}
