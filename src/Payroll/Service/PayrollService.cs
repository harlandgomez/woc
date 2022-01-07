using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using Woc.Book.Base.Service;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Payroll.BusinessEntity;
namespace Woc.Book.Payroll.Service
{
    public class PayrollService: IAccountService
    {
        private SQLHelper _sqlHelper;

        public List<PayrollRules> GetRules()
        {
            SqlDataReader reader;
            PayrollRules payrollRules;
            List<PayrollRules> listPayrollRule = new List<PayrollRules>();
            _sqlHelper = new SQLHelper();
 
            _sqlHelper.AddParameterToSQLCommandWithValue("@TransactionMode", 4);
            reader = _sqlHelper.GetReaderByCmd("usp_WocBookPayrollRule");
            while (reader.Read())
            {
                payrollRules = new PayrollRules();
                payrollRules.RuleID = new Guid(reader["RuleID"].ToString());
                payrollRules.TimeFactorID = Convert.ToInt16(reader["TimeFactorID"].ToString());
                payrollRules.StartDate = Convert.ToDateTime(reader["StartDate"].ToString());
                payrollRules.EndDate = Convert.ToDateTime(reader["EndDate"].ToString());
                payrollRules.StartTime = reader["StartTime"].ToString();
                payrollRules.EndTime = reader["EndTime"].ToString();
                payrollRules.StartDay = reader["StartDay"].ToString();
                payrollRules.EndDay = reader["EndDay"].ToString();
                payrollRules.Operator = reader["Operator"].ToString();
                payrollRules.Amount = Convert.ToDecimal(reader["Amount"]);
                payrollRules.SortOrder = Convert.ToInt32(reader["SortOrder"]);
                listPayrollRule.Add(payrollRules);
            }
            return listPayrollRule;
        }

        public String SaveRules(List<PayrollRules> listPayrollRule)
        {
            DataTable table = new DataTable();
            try
            {
                table.Columns.Add(new DataColumn("RuleID", typeof(Guid)));
                table.Columns.Add(new DataColumn("TimeFactorID", typeof(Int16)));
                table.Columns.Add(new DataColumn("StartDate", typeof(DateTime)));
                table.Columns.Add(new DataColumn("EndDate", typeof(DateTime)));
                table.Columns.Add(new DataColumn("StartTime", typeof(String)));
                table.Columns.Add(new DataColumn("EndTime", typeof(String)));
                table.Columns.Add(new DataColumn("StartDay", typeof(String)));
                table.Columns.Add(new DataColumn("EndDay", typeof(String)));
                table.Columns.Add(new DataColumn("Operator", typeof(String)));
                table.Columns.Add(new DataColumn("Amount", typeof(Decimal)));
                table.Columns.Add(new DataColumn("SortOrder", typeof(Int32)));
                table.Columns.Add(new DataColumn("TransactionMode", typeof(Int16)));
                
                foreach (PayrollRules prr in listPayrollRule)
                {
                    DataRow row = table.NewRow();
                    row["RuleID"] = prr.RuleID;
                    row["TimeFactorID"] = prr.TimeFactorID;
                    row["StartDate"] = prr.StartDate;
                    row["EndDate"] = prr.EndDate;
                    row["StartTime"] = prr.StartTime;
                    row["EndTime"] = prr.EndTime;
                    row["StartDay"] = prr.StartDay;
                    row["EndDay"] = prr.EndDay;
                    row["Amount"] = prr.Amount;
                    row["Operator"] = prr.Operator;
                    row["SortOrder"] = prr.SortOrder;
                    row["TransactionMode"] = 1;
                    table.Rows.Add(row);
                }

                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    // Create a SqlDataAdapter based on a SELECT query.
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    // Create a SqlCommand to execute the stored procedure.
                    adapter.InsertCommand = new SqlCommand("usp_WocBookPayrollRule", connection);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

                    adapter.InsertCommand.Parameters.Add("@RuleID", SqlDbType.UniqueIdentifier, 16, "RuleID");
                    adapter.InsertCommand.Parameters.Add("@TimeFactorID", SqlDbType.Int, 1, "TimeFactorID");
                    adapter.InsertCommand.Parameters.Add("@StartDate", SqlDbType.DateTime, 8, "StartDate");
                    adapter.InsertCommand.Parameters.Add("@EndDate", SqlDbType.DateTime, 8, "EndDate");
                    adapter.InsertCommand.Parameters.Add("@StartTime", SqlDbType.NVarChar, 100, "StartTime");
                    adapter.InsertCommand.Parameters.Add("@EndTime", SqlDbType.NVarChar, 100, "EndTime");
                    adapter.InsertCommand.Parameters.Add("@StartDay", SqlDbType.NVarChar, 100, "StartDay");
                    adapter.InsertCommand.Parameters.Add("@EndDay", SqlDbType.NVarChar, 100, "EndDay");
                    adapter.InsertCommand.Parameters.Add("@Amount", SqlDbType.Money, 8, "Amount");
                    adapter.InsertCommand.Parameters.Add("@Operator", SqlDbType.NVarChar, 8, "Operator");
                    adapter.InsertCommand.Parameters.Add("@SortOrder", SqlDbType.Int, 4, "SortOrder");
                    adapter.InsertCommand.Parameters.Add("@TransactionMode", SqlDbType.Int, 4, "TransactionMode");
                    // Update the database.
                    adapter.Update(table);
                }
            }
            catch
            {
                return Woc.Book.Base.Constant.Constant.MessageUnSaved;
            }
            return Woc.Book.Base.Constant.Constant.MessageSaved;
        }

        public String DeleteRules(List<PayrollRules> listPayrollRule)
        {
            DataTable table = new DataTable();
            try
            {
                table.Columns.Add(new DataColumn("RuleID", typeof(Guid)));
                table.Columns.Add(new DataColumn("TransactionMode", typeof(Int16)));

                foreach (PayrollRules prr in listPayrollRule)
                {
                    DataRow row = table.NewRow();
                    row["RuleID"] = prr.RuleID;
                    row["TransactionMode"] = 3;
                    table.Rows.Add(row);
                }

                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    // Create a SqlDataAdapter based on a SELECT query.
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    // Create a SqlCommand to execute the stored procedure.
                    adapter.InsertCommand = new SqlCommand("usp_WocBookPayrollRule", connection);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

                    adapter.InsertCommand.Parameters.Add("@RuleID", SqlDbType.UniqueIdentifier, 16, "RuleID");
                    adapter.InsertCommand.Parameters.Add("@TransactionMode", SqlDbType.Int, 4, "TransactionMode");
                    adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;

                    // Set the batch size.
                    adapter.UpdateBatchSize = 500;

                    // Update the database.
                    adapter.Update(table);
                }
            }
            catch(Exception ex)
            {
                return String.Format(Constant.Constant.MessageUndeleted, ex.Message);
            }

            return Constant.Constant.MessageDeleted;
        }

        public List<PayrollDTO> SearchData(IAccountEntity iAccountEntity)
        {
            SqlDataReader reader;
            PayrollDTO param = (PayrollDTO) iAccountEntity;

            List<PayrollDTO> listPayroll = new List<PayrollDTO>();
            _sqlHelper = new SQLHelper();

            _sqlHelper.AddParameterToSQLCommandWithValue("@TransactionMode", 1);
            _sqlHelper.AddParameterToSQLCommandWithValue("@StartDate", param.payrollRules.StartDate);
            _sqlHelper.AddParameterToSQLCommandWithValue("@EndDate", param.payrollRules.EndDate);
            _sqlHelper.AddParameterToSQLCommandWithValue("@Driver", param.DriverName);
            reader = _sqlHelper.GetReaderByCmd("usp_WocBookSearchPayroll");

            while (reader.Read())
            {
                PayrollDTO payrolls = new PayrollDTO();
                payrolls.BusNo = reader["BusNo"].ToString();
                payrolls.TripTime = Convert.ToDateTime(reader["TripTime"].ToString());
                payrolls.DriverRoute = reader["Route"].ToString();
                payrolls.Claim = Convert.ToDecimal(reader["Claim"].ToString());
                payrolls.DriverName = reader["DriverName"].ToString();
                listPayroll.Add(payrolls);
            }
            return listPayroll;
        }

        public string SaveData(IAccountEntity iAccountEntity)
        {
            return String.Empty;   
        }
    }
}
