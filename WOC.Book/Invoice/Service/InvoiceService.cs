using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using Woc.Book.Invoice.BusinessEntity;
using Woc.Book.Invoice.Constant;

using Woc.Book.Base.Service;
using Woc.Book.Base.BusinessEntity;



namespace Woc.Book.Invoice.Service
{
    public class InvoiceService: IAccountService
    {
        private Guid _invoiceID;
        private SQLHelper _sqlHelper; 
 
        public List<InvoiceDTO> SearchData(IAccountEntity iAccount)
        {
            List<InvoiceDTO> ListInvoice = new List<InvoiceDTO>();
            InvoiceDTO invoiceParam = (InvoiceDTO) iAccount;

            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_WocBookSearchInvoice", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@StartDate", invoiceParam.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", invoiceParam.EndDate);
                        cmd.Parameters.AddWithValue("@AgentID", invoiceParam.AgentID);
                        cmd.Parameters.AddWithValue("@TransactionMode", invoiceParam.TransactionMode);
                        
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();
                            conn.Open();
                            ad.Fill(table);

                            if (table.DefaultView.Count > 0)
                            {
                                for (int i = 0; i < table.Rows.Count; i++)
                                {
                                    InvoiceDTO invoices = new InvoiceDTO();
                                    invoices.RefNumber = table.Rows[i]["RefNo"].ToString();


                                    if (String.IsNullOrEmpty(table.Rows[i]["StartTime"].ToString()))
                                    {
                                        invoices.TimeDepart = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                                    }
                                    else
                                    {
                                        invoices.TimeDepart = Convert.ToDateTime(table.Rows[i]["StartTime"].ToString());
                                    }

                                    if (String.IsNullOrEmpty(table.Rows[i]["EndTime"].ToString()))
                                    {
                                        invoices.TimeReturn = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                                    }
                                    else
                                    {
                                        invoices.TimeReturn = Convert.ToDateTime(table.Rows[i]["EndTime"].ToString());
                                    }
                                    invoices.AdhocID = new Guid(table.Rows[i]["BookID"].ToString());
                                    invoices.AdhocBookDate = Convert.ToDateTime(table.Rows[i]["BookDate"].ToString());
                                    invoices.Description = table.Rows[i]["Description"].ToString();
                                    invoices.Seater =  Convert.ToInt64(table.Rows[i]["Pax"].ToString());
                                    invoices.RateType = table.Rows[i]["RatesType"].ToString();
                                    invoices.Rates = Convert.ToDouble(table.Rows[i]["Rates"].ToString());

                                    if (invoices.TimeReturn == Convert.ToDateTime(Base.Constant.Constant.MinimumDate))
                                    {
                                        invoices.Time = invoices.TimeDepart.ToString("HH:mm") + "-" + "(none)";
                                    }
                                    else
                                    {
                                        invoices.Time = invoices.TimeDepart.ToString("HH:mm") + "-" + invoices.TimeReturn.ToString("HH:mm");
                                    }

                                    ListInvoice.Add(invoices);  
                                }
                            }
                            conn.Close();
                            ad.Dispose();
                            conn.Dispose();
                        }
                    }
                return ListInvoice;
            }
        }

        public string SaveData(IAccountEntity iAccountEntity)
        {
            Invoices invoices = new Invoices();
            invoices = (Invoices)iAccountEntity;
            using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_WocBookInvoice", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    //1
                    command.Parameters.Add("@InvoiceCode", SqlDbType.NVarChar);
                    command.Parameters["@InvoiceCode"].Value = invoices.InvoiceCode;
                    //2
                    command.Parameters.Add("@InvoiceDate", SqlDbType.DateTime);
                    command.Parameters["@InvoiceDate"].Value = invoices.InvoiceDate;
                    //3
                    command.Parameters.Add("@Title", SqlDbType.NVarChar);
                    command.Parameters["@Title"].Value = invoices.Title;
                    //4
                    command.Parameters.Add("@AgentID", SqlDbType.UniqueIdentifier);
                    command.Parameters["@AgentID"].Value = invoices.AgentID;
                    //5
                    command.Parameters.Add("@Attention", SqlDbType.NVarChar);
                    command.Parameters["@Attention"].Value = invoices.Attention;
                    //6
                    command.Parameters.Add("@Remarks", SqlDbType.NVarChar);
                    command.Parameters["@Remarks"].Value = invoices.Remarks;
                    //7
                    command.Parameters.Add("@GSTTypeCode", SqlDbType.NVarChar);
                    command.Parameters["@GSTTypeCode"].Value = invoices.GSTTypeCode;
                    //8
                    command.Parameters.Add("@GSTAmount", SqlDbType.Money);
                    command.Parameters["@GSTAmount"].Value = invoices.GSTAmount;
                    //9
                    command.Parameters.Add("@TotalAmount", SqlDbType.NVarChar);
                    command.Parameters["@TotalAmount"].Value = invoices.TotalAmount;
                    //10
                    command.Parameters.Add("@SubTotal", SqlDbType.Money);
                    command.Parameters["@SubTotal"].Value = invoices.SubTotal;
                    //11
                    command.Parameters.Add("@Deposit", SqlDbType.Money);
                    command.Parameters["@Deposit"].Value = invoices.Deposit;
                    //12
                    command.Parameters.Add("@Balance", SqlDbType.Money);
                    command.Parameters["@Balance"].Value = invoices.Balance;
                    //13
                    command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                    command.Parameters["@CreatedBy"].Value = invoices.CreatedBy;
                    //14
                    command.Parameters.Add("@AliasInvoiceCode", SqlDbType.NVarChar);
                    command.Parameters["@AliasInvoiceCode"].Value = invoices.AliasInvoiceCode;
                    //15
                    command.Parameters.Add("@BillTo", SqlDbType.NVarChar);
                    command.Parameters["@BillTo"].Value = invoices.BillTo;
                    //16
                    command.Parameters.Add("@Address", SqlDbType.NVarChar);
                    command.Parameters["@Address"].Value = invoices.Address;

                    //17
                    command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                    command.Parameters["@TransactionMode"].Value = invoices.TransactionType;

                    //18
                    command.Parameters.Add("@InvoiceID", SqlDbType.UniqueIdentifier);
                    command.Parameters["@InvoiceID"].Value = invoices.InvoiceID;

                    object resultInvoiceID = command.ExecuteScalar();

                    _invoiceID = new Guid(resultInvoiceID.ToString());

                    //Batch save details
                    BatchSaveInvoiceDetails(invoices.ListInvoiceDetails);

                    //Batch void details
                    BatchVoidInvoiceDetails(invoices.ListVoidInvoiceDetails);
                }

                connection.Close();
            }

            return _invoiceID.ToString();
        }

        public void AutoComputeInvoice(IAccountEntity iAccountEntity)
        {

            Invoices invoices = new Invoices();
            invoices = (Invoices)iAccountEntity;
            using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_WocBookInvoiceAutoCompute", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        //1
                        command.Parameters.Add("@InvoiceCode", SqlDbType.NVarChar);
                        command.Parameters["@InvoiceCode"].Value = invoices.InvoiceCode;
                        //2
                        command.Parameters.Add("@InvoiceAmount", SqlDbType.Money);
                        command.Parameters["@InvoiceAmount"].Value = invoices.TotalAmount;
                        //3
                        command.Transaction = transaction;
                        transaction.Commit();
                    }
                }

                connection.Close();
            }
        }

        /// <summary>
        /// Gets the invoicecode alias
        /// </summary>
        /// <returns></returns>
        public List<Invoices> GetAliasInvoiceCodes(bool isNotActive)
        {
            List<Invoices> ListInvoice = new List<Invoices>();

            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_WocBookInvoice", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (isNotActive)
                    {
                        cmd.Parameters.AddWithValue("@TransactionMode", 7);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@TransactionMode", 6);
                    }

                    

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        conn.Open();
                        ad.Fill(table);

                        if (table.DefaultView.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                Invoices invoices = new Invoices();
                                invoices.InvoiceCode = table.Rows[i]["InvoiceCode"].ToString();
                                invoices.InvoiceID = new Guid(table.Rows[i]["InvoiceID"].ToString());
                                ListInvoice.Add(invoices);
                            }
                        }
                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();
                    }
                }
                return ListInvoice;
            }
        }

        /// <summary>
        /// Gets the invoicecode alias
        /// </summary>
        /// <returns></returns>
        public List<Invoices> GetAliasInvoiceCodes(int transactionType)
        {
            List<Invoices> ListInvoice = new List<Invoices>();

            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_WocBookInvoice", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TransactionMode", transactionType);

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        conn.Open();
                        ad.Fill(table);

                        if (table.DefaultView.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                Invoices invoices = new Invoices();
                                invoices.AliasInvoiceCode = table.Rows[i]["AliasInvoiceCode"].ToString();
                                invoices.InvoiceCode = table.Rows[i]["InvoiceCode"].ToString();
                                invoices.InvoiceID = new Guid(table.Rows[i]["InvoiceID"].ToString());
                                ListInvoice.Add(invoices);
                            }
                        }
                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();
                    }
                }
                return ListInvoice;
            }
        }
        
        public Invoices GetInvoiceDetailsByID(String id)
        {
            Invoices invoices = new Invoices();
            SqlDataReader dread;

            _sqlHelper = new SQLHelper();
            _sqlHelper.AddParameterToSQLCommandWithValue("@InvoiceID",id);
            _sqlHelper.AddParameterToSQLCommandWithValue("@TransactionMode", 5);

            dread = _sqlHelper.GetReaderByCmd("usp_WocBookInvoice");

            while (dread.Read()){
                invoices.AgentID = new Guid(dread["agentID"].ToString());
                invoices.InvoiceCode = dread["invoicecode"].ToString();
                invoices.Title = dread["Title"].ToString();
                invoices.Remarks = dread["remarks"].ToString();
                invoices.Attention = dread["Attention"].ToString();
                invoices.Address = dread["Address"].ToString();
                invoices.GSTTypeCode = dread["GSTTypeCode"].ToString();
                invoices.GSTAmount = Convert.ToDecimal(dread["GSTAmount"].ToString());
                if (String.IsNullOrEmpty(dread["invoicedate"].ToString()))
                {
                    invoices.InvoiceDate = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                }
                else
                {
                    invoices.InvoiceDate = Convert.ToDateTime(dread["invoicedate"].ToString());
                }
            }

            invoices.ListInvoiceDetails = GetInvoiceDetailsByInvoiceID(id);
            return invoices;
        }

        public List<InvoiceDetails> GetContractToBeInvoiced(IAccountEntity iAccountEntity)
        {
            InvoiceDTO invoiceDTO = (InvoiceDTO)iAccountEntity;
            SqlDataReader dread;
            InvoiceDetails invoiceDetails;
            Int32 sortBy = 0;
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT C.ContractID AS BookingID");
            sql.AppendLine("	 , CS.ContractScheduleID AS InvoiceDetailID");
            sql.AppendLine("	 , CS.ScheduleDate AS ItemDate");
            sql.AppendLine("	 , C.BookingCode AS RefNo");
            sql.AppendLine("	 , CASE WHEN UPPER(C.TripType) = 'ONE WAY' THEN C.TripFrom + ' > ' + C.TripTo ELSE C.TripFrom + ' <> ' + C.TripTo END  AS [Description]");
            sql.AppendLine("	 , C.Seater AS Pax");
            sql.AppendLine("	 , DateADD(HH, CAST(SUBSTRING(C.ContractStartTime,1,2) AS INT), DateAdd(MI,CAST(SUBSTRING(C.ContractStartTime,3,2) AS INT),C.StartDate)) AS StartTime");
            sql.AppendLine("	 , DateADD(HH, CAST(SUBSTRING(C.ContractEndTime,1,2) AS INT),DateAdd(MI,CAST(SUBSTRING(C.ContractEndTime,3,2) AS INT),C.StartDate)) AS EndTime");
            sql.AppendLine("	 , C.Rates AS UnitPrice");
            sql.AppendLine("	 , CASE WHEN C.RatesType = '1' THEN 'Contract' ELSE 'Daily' END AS RatesType");
            sql.AppendLine("FROM ContractSchedule CS, [contract] C");
            sql.AppendLine("WHERE C.ContractID = CS.ContractID");
            sql.AppendLine("AND CS.ScheduleDate > DATEADD(d, -1, '" + invoiceDTO.StartDate.ToString("yyyy-MM-dd") + "')");
            sql.AppendLine("AND CS.ScheduleDate < DATEADD(d, 1,'" + invoiceDTO.EndDate.ToString("yyyy-MM-dd") + "')");
            sql.AppendLine("AND C.ContractID in (" + invoiceDTO.ContractIDs + ")");
            sql.AppendLine("AND NOT EXISTS (SELECT * From InvoiceDetail WHERE VoidStatus = 0 AND InvoiceDetailID = CS.ContractScheduleID)");
            sql.AppendLine("ORDER BY CS.ScheduleDate, RefNo");
            _sqlHelper = new SQLHelper();

            dread = _sqlHelper.GetReaderBySQL(sql.ToString());

            List<InvoiceDetails> InvoiceDetailList = new List<InvoiceDetails>();

            while (dread.Read())
            {
                sortBy += 1;
                invoiceDetails = new InvoiceDetails();
                invoiceDetails.BookingID = new Guid(dread["BookingID"].ToString());
                invoiceDetails.InvoiceDetailID = new Guid(dread["InvoiceDetailID"].ToString());
                invoiceDetails.Description = dread["Description"].ToString();
                invoiceDetails.Pax = dread["Pax"].ToString();
                invoiceDetails.SortOrder = sortBy;
                invoiceDetails.UnitPrice = Convert.ToDecimal(dread["UnitPrice"].ToString());
                invoiceDetails.ERP = 0;
                invoiceDetails.Surcharge = 0;
                invoiceDetails.RefNo = dread["RefNo"].ToString();
                invoiceDetails.RatesType = dread["RatesType"].ToString();
                if (String.IsNullOrEmpty(dread["ItemDate"].ToString()))
                {
                    invoiceDetails.ItemDate = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                }
                else
                {
                    invoiceDetails.ItemDate = Convert.ToDateTime(dread["ItemDate"].ToString());
                }

                if (String.IsNullOrEmpty(dread["StartTime"].ToString()))
                {
                    invoiceDetails.StartTime = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                }
                else
                {
                    invoiceDetails.StartTime = Convert.ToDateTime(dread["StartTime"].ToString());
                }

                if (String.IsNullOrEmpty(dread["EndTime"].ToString()))
                {
                    invoiceDetails.EndTime = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                }
                else
                {
                    invoiceDetails.EndTime = Convert.ToDateTime(dread["EndTime"].ToString());
                }
                InvoiceDetailList.Add(invoiceDetails);
            }

            return InvoiceDetailList;
        }

        public List<InvoiceDetails> GetInvoiceDetailsByInvoiceID(String invoiceId)
        {
            List<InvoiceDetails> ListInvoiceDetails = new List<InvoiceDetails>();
            SqlDataReader dread;
            InvoiceDetails invoiceDetails;

            _sqlHelper = new SQLHelper();
            _sqlHelper.AddParameterToSQLCommandWithValue("@InvoiceID", invoiceId);
            _sqlHelper.AddParameterToSQLCommandWithValue("@TransactionMode", 6);

            dread = _sqlHelper.GetReaderByCmd("usp_WocBookInvoiceDetail");

            while (dread.Read())
            {
                invoiceDetails = new InvoiceDetails();
                invoiceDetails.BookingID = new Guid(dread["BookingID"].ToString());
                invoiceDetails.InvoiceDetailID = new Guid(dread["InvoiceDetailID"].ToString());
                invoiceDetails.TotalPrice = Convert.ToDecimal(dread["TotalPrice"].ToString());
                invoiceDetails.Description = dread["Description"].ToString();
                invoiceDetails.Pax = dread["Pax"].ToString();
                invoiceDetails.SortOrder = Convert.ToInt16(dread["SortOrder"]);
                invoiceDetails.UnitPrice = Convert.ToDecimal(dread["UnitPrice"].ToString());
                invoiceDetails.ERP = Convert.ToDecimal(dread["ERP"].ToString());
                invoiceDetails.Surcharge = Convert.ToDecimal(dread["Surcharge"].ToString());
                invoiceDetails.RefNo = dread["RefNo"].ToString();
                invoiceDetails.RatesType = dread["RatesType"].ToString();
                if (String.IsNullOrEmpty(dread["ItemDate"].ToString()))
                {
                    invoiceDetails.ItemDate = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                }
                else
                {
                    invoiceDetails.ItemDate = Convert.ToDateTime(dread["ItemDate"].ToString());
                }

                if (String.IsNullOrEmpty(dread["StartTime"].ToString()))
                {
                    invoiceDetails.StartTime = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                }
                else
                {
                    invoiceDetails.StartTime = Convert.ToDateTime(dread["StartTime"].ToString());
                }

                if (String.IsNullOrEmpty(dread["EndTime"].ToString()))
                {
                    invoiceDetails.EndTime = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                }
                else
                {
                    invoiceDetails.EndTime = Convert.ToDateTime(dread["EndTime"].ToString());
                }
                ListInvoiceDetails.Add(invoiceDetails);
            }

            return ListInvoiceDetails;
        }

        public Invoices GetInvoice(string id)
        {
            Invoices invoices = new Invoices();
            SqlDataReader dread;

            _sqlHelper = new SQLHelper();
            _sqlHelper.AddParameterToSQLCommandWithValue("@InvoiceID", id);
            _sqlHelper.AddParameterToSQLCommandWithValue("@TransactionMode", 5);

            dread = _sqlHelper.GetReaderByCmd("usp_WocBookInvoice");
            using (dread)
            {
                while (dread.Read())
                {
                    invoices.InvoiceCode = dread["InvoiceCode"].ToString();
                    invoices.AliasInvoiceCode = dread["AliasInvoiceCode"].ToString();
                    invoices.Title = dread["Title"].ToString();
                    invoices.AgentID = new Guid(dread["AgentID"].ToString());
                    invoices.BillTo = dread["BillTo"].ToString();
                    invoices.Address = dread["Address"].ToString();
                    invoices.Attention = dread["Attention"].ToString();
                    invoices.Remarks = dread["Remarks"].ToString();
                    invoices.GSTTypeCode = dread["GSTTypeCode"].ToString();
                    invoices.SubTotal = Convert.ToDecimal(dread["SubTotal"].ToString());
                    invoices.GSTAmount = Convert.ToDecimal(dread["GSTAmount"].ToString());
                    invoices.TotalAmount = Convert.ToDecimal(dread["TotalAmount"].ToString());
                    invoices.Deposit = Convert.ToDecimal(dread["Deposit"].ToString());
                    invoices.Balance = Convert.ToDecimal(dread["Balance"].ToString());

                    if (String.IsNullOrEmpty(dread["invoicedate"].ToString()))
                    {
                        invoices.InvoiceDate = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                    }
                    else
                    {
                        invoices.InvoiceDate = Convert.ToDateTime(dread["invoicedate"].ToString());
                    }
                    break;
                }
            }
            return invoices;

        }
        public String VoidInvoice(String id)
        {
            String invoiceCode;
            _sqlHelper = new SQLHelper();

            invoiceCode = (String)_sqlHelper.GetExecuteScalarBySQL(String.Format("SELECT InvoiceCode FROM Invoice WHERE InvoiceID = '{0}' ", id));
            
            try
            {
                _sqlHelper = new SQLHelper();
                _sqlHelper.AddParameterToSQLCommandWithValue("@InvoiceID", id);
                _sqlHelper.AddParameterToSQLCommandWithValue("@TransactionMode", 11);

                _sqlHelper.GetExecuteNonQueryByCommand("usp_WocBookInvoice");
            }
            catch (Exception ex)
            {
                return String.Format(Constant.Constant.UnVoidInvoiceMessage, invoiceCode, ex.Message);
            }
            return String.Format(Constant.Constant.VoidInvoiceMessage, invoiceCode);
        }

        public Decimal GetDepositByInvoiceCode(String invoiceCode)
        {
            SQLHelper helper = new SQLHelper();
            String sql = String.Format("SELECT deposit FROM Invoice WHERE invoicecode = '{0}' ", invoiceCode);
            object value = helper.GetExecuteScalarBySQL(sql);
            if ((value == null) || (value == DBNull.Value)) return 0;
            return (Decimal)value;
        }

        public bool IsInvoiceCodeExists(String invoiceCode)
        {
            SQLHelper helper = new SQLHelper();
            String sql = String.Format("SELECT COUNT(InvoiceCode) FROM Invoice WHERE invoicecode = '{0}' ", invoiceCode);
            object value = helper.GetExecuteScalarBySQL(sql);
            if (Convert.ToInt16(value) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public Invoices GetInvoiceByCode(string invoiceCode)
        {
            Invoices invoices = new Invoices();
            SqlDataReader dread;

            _sqlHelper = new SQLHelper();
            _sqlHelper.AddParameterToSQLCommandWithValue("@InvoiceCode", invoiceCode);
            _sqlHelper.AddParameterToSQLCommandWithValue("@TransactionMode", 10);

            dread = _sqlHelper.GetReaderByCmd("usp_WocBookInvoice");
            using (dread)
            {
                while (dread.Read())
                {
                    invoices.InvoiceCode = dread["InvoiceCode"].ToString();
                    invoices.AliasInvoiceCode = dread["AliasInvoiceCode"].ToString();
                    invoices.Title = dread["Title"].ToString();
                    invoices.AgentID = new Guid(dread["AgentID"].ToString());
                    invoices.BillTo = dread["BillTo"].ToString();
                    invoices.Address = dread["Address"].ToString();
                    invoices.Attention = dread["Attention"].ToString();
                    invoices.Remarks = dread["Remarks"].ToString();
                    invoices.GSTTypeCode = dread["GSTTypeCode"].ToString();
                    invoices.SubTotal = Convert.ToDecimal(dread["SubTotal"].ToString());
                    invoices.GSTAmount = Convert.ToDecimal(dread["GSTAmount"].ToString());
                    invoices.TotalAmount = Convert.ToDecimal(dread["TotalAmount"].ToString());
                    invoices.Deposit = Convert.ToDecimal(dread["Deposit"].ToString());
                    invoices.Balance = Convert.ToDecimal(dread["Balance"].ToString());
                    invoices.InvoiceID = new Guid(dread["InvoiceID"].ToString());

                    if (String.IsNullOrEmpty(dread["invoicedate"].ToString()))
                    {
                        invoices.InvoiceDate = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                    }
                    else
                    {
                        invoices.InvoiceDate = Convert.ToDateTime(dread["invoicedate"].ToString());
                    }
                    break;
                }
            }
            return invoices;

        }

        private void BatchSaveInvoiceDetails(List<InvoiceDetails> listInvoiceDetail)
        {
            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("InvoiceID", typeof(Guid)));
            table.Columns.Add(new DataColumn("InvoiceDetailID", typeof(Guid)));
            table.Columns.Add(new DataColumn("ItemDate", typeof(DateTime)));
            table.Columns.Add(new DataColumn("BookingID", typeof(Guid)));
            table.Columns.Add(new DataColumn("RefNo", typeof(String)));
            table.Columns.Add(new DataColumn("StartTime", typeof(DateTime)));
            table.Columns.Add(new DataColumn("EndTime", typeof(DateTime)));
            table.Columns.Add(new DataColumn("Description", typeof(String)));
            table.Columns.Add(new DataColumn("Pax", typeof(String)));
            table.Columns.Add(new DataColumn("ERP", typeof(Double)));
            table.Columns.Add(new DataColumn("Surcharge", typeof(Double)));
            table.Columns.Add(new DataColumn("UnitPrice", typeof(Double)));
            table.Columns.Add(new DataColumn("TotalPrice", typeof(Double)));
            table.Columns.Add(new DataColumn("SortOrder", typeof(int)));
            table.Columns.Add(new DataColumn("RatesType", typeof(String)));
            table.Columns.Add(new DataColumn("TransactionMode", typeof(int)));

            foreach (InvoiceDetails invoiceDetails in listInvoiceDetail)
            {
                DataRow row = table.NewRow();
                row["InvoiceID"] = _invoiceID;
                row["InvoiceDetailID"] = invoiceDetails.InvoiceDetailID;
                row["ItemDate"] = invoiceDetails.ItemDate;
                row["BookingID"] = invoiceDetails.BookingID;
                row["RefNo"] = invoiceDetails.RefNo;
                row["StartTime"] = invoiceDetails.StartTime;
                row["EndTime"] = invoiceDetails.EndTime;
                row["Pax"] = invoiceDetails.Pax;
                row["Description"] = invoiceDetails.Description;
                row["ERP"] = invoiceDetails.ERP;
                row["Surcharge"] = invoiceDetails.Surcharge;
                row["UnitPrice"] = invoiceDetails.UnitPrice;
                row["TotalPrice"] = invoiceDetails.TotalPrice;
                row["SortOrder"] = invoiceDetails.SortOrder;
                row["RatesType"] = invoiceDetails.RatesType;
                row["TransactionMode"] = 1;
                table.Rows.Add(row);
            }

            using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
            {
                // Create a SqlDataAdapter based on a SELECT query.
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SqlCommand to execute the stored procedure.
                adapter.InsertCommand = new SqlCommand("usp_WocBookInvoiceDetail", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

                adapter.InsertCommand.Parameters.Add("@InvoiceDetailID", SqlDbType.UniqueIdentifier, 16, "InvoiceDetailID");
                adapter.InsertCommand.Parameters.Add("@InvoiceID", SqlDbType.UniqueIdentifier, 16, "InvoiceID");
                adapter.InsertCommand.Parameters.Add("@ItemDate", SqlDbType.DateTime, 8, "ItemDate");
                adapter.InsertCommand.Parameters.Add("@BookingID", SqlDbType.UniqueIdentifier, 16, "BookingID");
                adapter.InsertCommand.Parameters.Add("@RefNo", SqlDbType.NVarChar, 100, "RefNo");
                adapter.InsertCommand.Parameters.Add("@StartTime", SqlDbType.DateTime, 8, "StartTime");
                adapter.InsertCommand.Parameters.Add("@EndTime", SqlDbType.DateTime, 8, "EndTime");
                adapter.InsertCommand.Parameters.Add("@Pax", SqlDbType.NVarChar, 100, "Pax");
                adapter.InsertCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 1000, "Description");
                adapter.InsertCommand.Parameters.Add("@ERP", SqlDbType.Money, 8, "ERP");
                adapter.InsertCommand.Parameters.Add("@Surcharge", SqlDbType.Money, 8, "Surcharge");
                adapter.InsertCommand.Parameters.Add("@UnitPrice", SqlDbType.Money, 8, "UnitPrice");
                adapter.InsertCommand.Parameters.Add("@TotalPrice", SqlDbType.Money, 8, "TotalPrice");
                adapter.InsertCommand.Parameters.Add("@SortOrder", SqlDbType.Int, 4, "SortOrder");
                adapter.InsertCommand.Parameters.Add("@RatesType", SqlDbType.NVarChar, 8, "RatesType");
                adapter.InsertCommand.Parameters.Add("@TransactionMode", SqlDbType.Int, 4, "TransactionMode");
                // Update the database.
                adapter.Update(table);
            }
        }

        private void BatchVoidInvoiceDetails(List<InvoiceDetails> listInvoiceDetail)
        {
            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("InvoiceDetailID", typeof(Guid)));
            table.Columns.Add(new DataColumn("TransactionMode", typeof(int)));

            foreach (InvoiceDetails invoiceDetails in listInvoiceDetail)
            {
                DataRow row = table.NewRow();
                row["InvoiceDetailID"] = invoiceDetails.InvoiceDetailID;
                row["TransactionMode"] = 3;
                table.Rows.Add(row);
            }

            using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
            {
                // Create a SqlDataAdapter based on a SELECT query.
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SqlCommand to execute the stored procedure.
                adapter.InsertCommand = new SqlCommand("usp_WocBookInvoiceDetail", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

                adapter.InsertCommand.Parameters.Add("@InvoiceDetailID", SqlDbType.UniqueIdentifier, 16, "InvoiceDetailID");
                adapter.InsertCommand.Parameters.Add("@TransactionMode", SqlDbType.Int, 4, "TransactionMode");
                // Update the database.
                adapter.Update(table);
            }
        }
    }
}
