using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using Woc.Book.Base.Service;
using Woc.Book.Base.BusinessEntity;

using Woc.Book.CreditNote.BusinessEntity;

namespace Woc.Book.CreditNote.Service
{
    public class CreditNoteService: IAccountService
    {
        SQLHelper helper;
        public string SaveData(IAccountEntity iAccountEntity)
        {
            try
            {
                CreditNotes creditNotes = (CreditNotes) iAccountEntity;
                helper = new SQLHelper();
                helper.AddParameterToSQLCommandWithValue("@CreditNoteCode", creditNotes.CreditNoteCode);
                helper.AddParameterToSQLCommandWithValue("@AgentID", creditNotes.AgentID);
                helper.AddParameterToSQLCommandWithValue("@InvoiceCode", creditNotes.InvoiceCode);
                helper.AddParameterToSQLCommandWithValue("@CreditNoteAmount", creditNotes.CreditNoteAmount);
                helper.AddParameterToSQLCommandWithValue("@ReasonCode", creditNotes.ReasonCode);
                helper.AddParameterToSQLCommandWithValue("@GSTTypeCode", creditNotes.GSTTypeCode);
                helper.AddParameterToSQLCommandWithValue("@Description", creditNotes.Description);
                helper.AddParameterToSQLCommandWithValue("@Attention", creditNotes.Attention);
                helper.AddParameterToSQLCommandWithValue("@CreatedBy", creditNotes.CreatedBy);
                helper.GetExecuteNonQueryByCommand("usp_WocBookCreditNote");
                return Woc.Book.Base.Constant.Constant.MessageSaved;
            }
            catch
            {
                return Woc.Book.Base.Constant.Constant.MessageUnSaved;
            }

        }

        public string UpdateData(IAccountEntity iAccountEntity)
        {
            try
            {
                CreditNotes creditNotes = (CreditNotes)iAccountEntity;
                helper = new SQLHelper();
                helper.AddParameterToSQLCommandWithValue("@AgentID", creditNotes.AgentID);
                helper.AddParameterToSQLCommandWithValue("@CreditNoteAmount", creditNotes.CreditNoteAmount);
                helper.AddParameterToSQLCommandWithValue("@ReasonCode", creditNotes.ReasonCode);
                helper.AddParameterToSQLCommandWithValue("@GSTTypeCode", creditNotes.GSTTypeCode);
                helper.AddParameterToSQLCommandWithValue("@Description", creditNotes.Description);
                helper.AddParameterToSQLCommandWithValue("@Attention", creditNotes.Attention);
                helper.AddParameterToSQLCommandWithValue("@CreditNoteID", creditNotes.CreditNoteID);
                helper.AddParameterToSQLCommandWithValue("@TransactionMode", 2);
                helper.GetExecuteNonQueryByCommand("usp_WocBookCreditNote");
                return Woc.Book.Base.Constant.Constant.MessageSaved;
            }
            catch
            {
                return Woc.Book.Base.Constant.Constant.MessageUnSaved;
            }

        }

        public String GetCreditNoteCodeByID(Guid id)
        {
            helper = new SQLHelper();
            helper.AddParameterToSQLCommandWithValue("@CreditNoteID", id);
            helper.AddParameterToSQLCommandWithValue("@TransactionMode", 6);
            return helper.GetExecuteScalarByCommand("usp_WocBookCreditNote").ToString();
        }

        public CreditNotesDTO GetCreditNoteByID(String id)
        {
            CreditNotesDTO creditNotes = new CreditNotesDTO();
            helper = new SQLHelper();
            helper.AddParameterToSQLCommandWithValue("@CreditNoteID", new Guid(id));
            helper.AddParameterToSQLCommandWithValue("@TransactionMode", 5);
            SqlDataReader reader = helper.GetReaderByCmd("usp_WocBookCreditNote");
            while (reader.Read())
            {
                creditNotes.Attention = reader["Attention"].ToString();
                creditNotes.CreditNoteAmount = Convert.ToDecimal(reader["CreditNoteAmount"].ToString());
                creditNotes.CreditNoteCode = reader["CreditNoteCode"].ToString();
                creditNotes.CreditNoteDate = Convert.ToDateTime(reader["CreditNoteDate"].ToString());
                creditNotes.Description = reader["Description"].ToString();
                creditNotes.GSTDescription = reader["GSTDescription"].ToString();
                creditNotes.GSTTypeCode = reader["GSTTypeCode"].ToString();
                creditNotes.InvoiceCode = reader["InvoiceCode"].ToString();
                creditNotes.AgentName = reader["AgentName"].ToString();
                creditNotes.IssuedBy = reader["IssuedBy"].ToString();
                break;
            }
            return creditNotes;
        }

        public void AutoComputeCreditNote(IAccountEntity iAccountEntity)
        {

            CreditNotes creditNotes = (CreditNotes)iAccountEntity;
            using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_WocBookCreditNoteAutoCompute", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        //1
                        command.Parameters.Add("@CNNumber", SqlDbType.NVarChar);
                        command.Parameters["@CNNumber"].Value = creditNotes.CreditNoteCode;
                        //2
                        command.Parameters.Add("@CNAmount", SqlDbType.Money);
                        command.Parameters["@CNAmount"].Value = creditNotes.CreditNoteAmount;
                        //3
                        command.Transaction = transaction;
                        transaction.Commit();
                    }
                }

                connection.Close();
            }
        }


        public List<CreditNotes> SearchData(String parameter)
        {
            CreditNotes CreditNotes = new CreditNotes();
            List<CreditNotes> ListCreditNote = new List<CreditNotes>();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from CreditNote where " + parameter, conn))
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
                                CreditNotes.CreditNoteID = new Guid(table.Rows[i]["CreditNoteID"].ToString());
                                CreditNotes.CreditNoteCode = table.Rows[i]["CreditNoteCode"].ToString();


                                if (String.IsNullOrEmpty(table.Rows[i]["CreditNoteDate"].ToString()))
                                {
                                    CreditNotes.CreditNoteDate = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                                }
                                else
                                {
                                    CreditNotes.CreditNoteDate = Convert.ToDateTime(table.Rows[i]["CreditNoteDate"].ToString());
                                }

                                CreditNotes.AgentID = new Guid(table.Rows[i]["AgentID"].ToString());
                                CreditNotes.InvoiceCode = table.Rows[i]["InvoiceCode"].ToString();
                                CreditNotes.CreditNoteAmount = Convert.ToDecimal(table.Rows[i]["CreditNoteAmount"].ToString());
                                CreditNotes.ReasonCode = table.Rows[i]["ReasonCode"].ToString();
                                CreditNotes.GSTTypeCode = table.Rows[i]["GSTTypeCode"].ToString();
                                CreditNotes.Description = table.Rows[i]["Description"].ToString();
                                CreditNotes.Attention = table.Rows[i]["Attention"].ToString();
                                ListCreditNote.Add(CreditNotes);
                                CreditNotes = new CreditNotes();
                            }

                        }

                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }

            return ListCreditNote;
        }

        public List<MemoReasons> GetAllReason()
        {
            List<MemoReasons> listReason = new List<MemoReasons>();
            MemoReasons reasons = new MemoReasons();

            helper = new SQLHelper();
            helper.AddParameterToSQLCommandWithValue("@TransactionMode", 4);
            DataTable table =  helper.GetDatasetByCommand("usp_WocBookMemoReason").Tables[0];

            if (table.DefaultView.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    reasons.ReasonID = new Guid(table.Rows[i]["ReasonID"].ToString());
                    reasons.Description = table.Rows[i]["Description"].ToString();
                    reasons.ReasonCode = table.Rows[i]["ReasonCode"].ToString();
                    listReason.Add(reasons);
                    reasons = new MemoReasons();
                }
            }
            return listReason;
        }

        public String BatchDeleteCreditNote(List<CreditNotes> listCrediteNote)
        {
            DataTable table = new DataTable();
            try
            {            
                table.Columns.Add(new DataColumn("CreditNoteID", typeof(Guid)));
                table.Columns.Add(new DataColumn("TransactionMode", typeof(Int16)));

                foreach (CreditNotes creditNotes in listCrediteNote)
                {
                    DataRow row = table.NewRow();
                    row["CreditNoteID"] = creditNotes.CreditNoteID;
                    row["TransactionMode"] = 3;
                    table.Rows.Add(row);
                }

                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    // Create a SqlDataAdapter based on a SELECT query.
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    // Create a SqlCommand to execute the stored procedure.
                    adapter.InsertCommand = new SqlCommand("usp_WocBookCreditNote", connection);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

                    adapter.InsertCommand.Parameters.Add("@CreditNoteID", SqlDbType.UniqueIdentifier, 16, "CreditNoteID");
                    adapter.InsertCommand.Parameters.Add("@TransactionMode", SqlDbType.Int, 4, "TransactionMode");
                    // Update the database.
                    adapter.Update(table);
                }
                return Constant.Constant.MessageDeleted;
            }
            catch(Exception ex)
            {
                return Constant.Constant.MessageUndeleted + ": " + ex.Message;
            }


        }
    }
}
