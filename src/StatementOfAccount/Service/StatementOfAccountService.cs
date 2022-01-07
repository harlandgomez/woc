using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.StatementOfAccount.BusinessEntity;
using System.Data.SqlClient;
using System.Data;

using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;

using Woc.Book.Agent.BusinessEntity;
namespace Woc.Book.StatementOfAccount.Service
{
    internal class StatementOfAccountService
    {
        public List<StatementOfAccounts> SearchData(Guid agentID, DateTime  startDate, DateTime endDate, String modePayment)
        {
            StatementOfAccounts statementOfAccounts = new StatementOfAccounts();
            List<StatementOfAccounts> ListStatementOfAccount = new List<StatementOfAccounts>();
            StringBuilder sql = new StringBuilder();

            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {

                using (SqlCommand cmd = new SqlCommand("usp_WocBookSearchStatementOfAccount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (agentID != Guid.Empty)
                    {
                        cmd.Parameters.Add("@AgentID", SqlDbType.UniqueIdentifier);
                        cmd.Parameters["@AgentID"].Value = agentID;
                    }

                    if (startDate != DateTime.MinValue && endDate != DateTime.MinValue)
                    {
                        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
                        cmd.Parameters["@StartDate"].Value = startDate;

                        cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
                        cmd.Parameters["@EndDate"].Value = endDate;
                    }

                    if (modePayment != "A")
                    {
                        cmd.Parameters.Add("@PaymentStatus", SqlDbType.NVarChar);
                        cmd.Parameters["@PaymentStatus"].Value = modePayment;
                    }
                    
                    cmd.Parameters.Add("@TransactionMode", SqlDbType.NVarChar);
                    cmd.Parameters["@TransactionMode"].Value = 2;

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        conn.Open();
                        ad.Fill(table);

                        if (table.DefaultView.Count > 0)
                        {
                            Decimal debit = 0;
                            Decimal credit = 0;

                            for (int i = 0; i < table.Rows.Count; i++)
                            {


                                statementOfAccounts.InvoiceDate = Convert.ToDateTime(table.Rows[i]["InvoiceDate"]);
                                statementOfAccounts.InvoiceNo = table.Rows[i]["InvoiceCode"].ToString();
                                statementOfAccounts.Debit = Convert.ToDecimal(table.Rows[i]["Debit"]);
                                statementOfAccounts.Credit = Convert.ToDecimal(table.Rows[i]["Credit"]);
                                statementOfAccounts.Description = table.Rows[i]["Description"].ToString();

                                debit += statementOfAccounts.Debit;
                                credit += statementOfAccounts.Credit;

                                //Balance
                                statementOfAccounts.Balance = (debit - credit);

                                ListStatementOfAccount.Add(statementOfAccounts);
                                statementOfAccounts = new StatementOfAccounts();
                            }

                        }

                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }

            return ListStatementOfAccount;
        }

        public List<SalesReportbyCustomers> SearchDataSales(String prefix, DateTime startDate, DateTime endDate, String modePayment)
        {
            SalesReportbyCustomers salesReportbyCustomers = new SalesReportbyCustomers();
            List<SalesReportbyCustomers> ListSalesReportbyCustomers = new List<SalesReportbyCustomers>();
            StringBuilder sql = new StringBuilder();

            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_WocBookSearchStatementOfAccount", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;


                    if (!String.IsNullOrEmpty(prefix))
                    {
                        cmd.Parameters.Add("@Prefix", SqlDbType.NVarChar);
                        cmd.Parameters["@Prefix"].Value = prefix;
                    }

                    if (startDate != DateTime.MinValue && endDate != DateTime.MinValue)
                    {
                        cmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
                        cmd.Parameters["@StartDate"].Value = startDate;

                        cmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
                        cmd.Parameters["@EndDate"].Value = endDate;
                    }

                    if (modePayment != "A")
                    {
                        cmd.Parameters.Add("@PaymentStatus", SqlDbType.NVarChar);
                        cmd.Parameters["@PaymentStatus"].Value = modePayment;
                    }

                    cmd.Parameters.Add("@TransactionMode", SqlDbType.NVarChar);
                    cmd.Parameters["@TransactionMode"].Value = 3;

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        conn.Open();
                        ad.Fill(table);

                        if (table.DefaultView.Count > 0)
                        {
                             for (int i = 0; i < table.Rows.Count; i++)
                            {
                                salesReportbyCustomers.InvoiceDate = Convert.ToDateTime(table.Rows[i]["InvoiceDate"]);
                                salesReportbyCustomers.InvoiceNo = table.Rows[i]["InvoiceCode"].ToString();
                                //salesReportbyCustomers.Debit = Convert.ToDecimal(table.Rows[i]["InvoiceAmount"]);
                                //salesReportbyCustomers.Credit = Convert.ToDecimal(table.Rows[i]["CNAmount"]);
                                //salesReportbyCustomers.Description = table.Rows[i]["Description"].ToString();

                                salesReportbyCustomers.InvoiceDate = Convert.ToDateTime(table.Rows[i]["InvoiceDate"]);
                                salesReportbyCustomers.InvoiceNo = table.Rows[i]["InvoiceCode"].ToString();
                                salesReportbyCustomers.InvoiceAmount = Convert.ToDecimal(table.Rows[i]["TotalAmount"]);
                                salesReportbyCustomers.AmountPaid = Convert.ToDecimal(table.Rows[i]["AmountPaid"]);
                                //salesReportbyCustomers.Credit = Convert.ToDecimal(table.Rows[i]["CNAmount"]);
                                //salesReportbyCustomers.Description = table.Rows[i]["Description"].ToString();
                                salesReportbyCustomers.Remarks = table.Rows[i]["Remarks"].ToString();
                                salesReportbyCustomers.Customer = table.Rows[i]["Customer"].ToString();
                                salesReportbyCustomers.InvoiceGSTAmount = Convert.ToDecimal(Convert.ToDouble(table.Rows[i]["GstAmount"]));
                                salesReportbyCustomers.InvoiceSubAmount = Convert.ToDecimal(Convert.ToDouble(table.Rows[i]["SubTotal"]));
                                //salesReportbyCustomers.GST = Convert.ToDecimal(Convert.ToDouble(table.Rows[i]["InvoiceAmount"]) * value);

                                salesReportbyCustomers.RefNo = table.Rows[i]["RefNo"].ToString();
                                salesReportbyCustomers.Status = table.Rows[i]["Status"].ToString();
                                ListSalesReportbyCustomers.Add(salesReportbyCustomers);
                                salesReportbyCustomers = new SalesReportbyCustomers();
                            }

                        }

                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }


                return ListSalesReportbyCustomers;
            }
        }
    }
}
