using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;
using Woc.Book.Setting.Service;

using Woc.Book.Adhoc.BusinessEntity;
using Woc.Book.Adhoc.Constant;

namespace Woc.Book.Adhoc.Service
{
   
        internal class AdhocService : INewBookingService
        {


            public String SaveData(List<Adhocs> listAdhoc)
            {
                try
                {
                    //Adhocs adhocs = new Adhocs();
                    DataTable table = new DataTable();
                    table.Columns.Add("AgentId", typeof(Guid));
                    table.Columns.Add("AdhocCode", typeof(String));
                    table.Columns.Add("AdhocBookDate", typeof(DateTime));
                    table.Columns.Add("TripType", typeof(String));
                    table.Columns.Add("TripFrom", typeof(String));
                    table.Columns.Add("TripTo", typeof(String));
                    table.Columns.Add("TimeDepart", typeof(DateTime));
                    table.Columns.Add("TimeReturn", typeof(DateTime));
                    table.Columns.Add("Seater", typeof(int));
                    table.Columns.Add("Purpose", typeof(String)); 
                    table.Columns.Add("PersonInCharge", typeof(String));
                    table.Columns.Add("DriverClaim", typeof(String));
                    table.Columns.Add("Contact", typeof(String));
                    table.Columns.Add("Delete", typeof(String));
                    table.Columns.Add("TypeCashOrder", typeof(String));
                    table.Columns.Add("CashOrder", typeof(String));
                    table.Columns.Add("IsPending", typeof(bool));
                    table.Columns.Add("TransactionMode", typeof(int));
                    
                    foreach ( Adhocs adhocs in listAdhoc)
                    {
                        DataRow dr = table.NewRow();
                           
                        dr["AgentID"] = adhocs.AgentID;
                        dr["AdhocCode"] = adhocs.AdhocCode;
                        if (adhocs.AdhocBookDate != DateTime.MinValue)
                        {
                            dr["AdhocBookDate"] = adhocs.AdhocBookDate;
                        }
                        dr["TripType"] = adhocs.TripType;
                        dr["TripFrom"] = adhocs.TripFrom;
                        dr["TripTo"] = adhocs.TripTo;
                        if (adhocs.TimeDepart != DateTime.MinValue)
                        {
                            dr["TimeDepart"] = adhocs.TimeDepart;
                        }
                        if (adhocs.TimeReturn != DateTime.MinValue)
                        {
                            dr["TimeReturn"] = adhocs.TimeReturn;
                        }
                        dr["Seater"] = adhocs.Seater;
                        dr["Purpose"] = adhocs.Purpose;
                        dr["PersonInCharge"] = adhocs.PersonInCharge;
                        dr["DriverClaim"] = adhocs.DriverClaim;
                        dr["Contact"] = adhocs.Contact;
                        dr["Delete"] = "N";
                        dr["TypeCashOrder"] = adhocs.TypeCashOrder;
                        dr["CashOrder"] = adhocs.CashOrder;
                        dr["IsPending"] = adhocs.IsPending;
                        dr["TransactionMode"] = 1;          
                        table.Rows.Add(dr);
                    }
                  

                    SqlConnection connection = new SqlConnection(UtilityService.Connection());
                    SqlCommand command = new SqlCommand("usp_WocBookAdhoc", connection); 
                    command.CommandType = CommandType.StoredProcedure; command.UpdatedRowSource = UpdateRowSource.None;       
                    // Set the Parameter with appropriate Source Column Name           
                  
                    command.Parameters.Add("@AgentID", SqlDbType.UniqueIdentifier, 16, table.Columns[0].ColumnName);
                    command.Parameters.Add("@AdhocCode", SqlDbType.NVarChar, 50, table.Columns[1].ColumnName);
                    command.Parameters.Add("@AdhocBookDate", SqlDbType.DateTime, 10, table.Columns[2].ColumnName);
                    command.Parameters.Add("@TripType", SqlDbType.NVarChar,50, table.Columns[3].ColumnName);
                    command.Parameters.Add("@TripFrom", SqlDbType.NVarChar, 50, table.Columns[4].ColumnName);
                    command.Parameters.Add("@TripTo", SqlDbType.NVarChar, 50, table.Columns[5].ColumnName);
                    command.Parameters.Add("@TimeDepart", SqlDbType.DateTime, 10, table.Columns[6].ColumnName);
                    command.Parameters.Add("@TimeReturn", SqlDbType.DateTime, 10, table.Columns[7].ColumnName);
                    command.Parameters.Add("@Seater", SqlDbType.Int, 4, table.Columns[8].ColumnName);
                    command.Parameters.Add("@Purpose", SqlDbType.NVarChar, 50, table.Columns[9].ColumnName);
                    command.Parameters.Add("@PersonInCharge", SqlDbType.NVarChar, 50, table.Columns[10].ColumnName);
                    command.Parameters.Add("@DriverClaim", SqlDbType.NVarChar, 50, table.Columns[11].ColumnName);
                    command.Parameters.Add("@Contact", SqlDbType.NVarChar, 50, table.Columns[12].ColumnName);
                    command.Parameters.Add("@Delete", SqlDbType.NVarChar, 50, table.Columns[13].ColumnName);
                    command.Parameters.Add("@TypeCashOrder", SqlDbType.NVarChar, 50, table.Columns[14].ColumnName);
                    command.Parameters.Add("@CashOrder", SqlDbType.Money,8, table.Columns[15].ColumnName);
                    command.Parameters.Add("@IsPending", SqlDbType.Bit, 1, table.Columns[16].ColumnName);
                    command.Parameters.Add("@TransactionMode", SqlDbType.Int, 4, table.Columns[17].ColumnName);
 
                    SqlDataAdapter adpt = new SqlDataAdapter();           
                    adpt.InsertCommand = command;            // Specify the number of records to be Inserted/Updated in one go. Default is 1.  
                    adpt.UpdateBatchSize = 2;                        
                    connection.Open();
                    adpt.Update(table);  


                    return Constant.Constant.MessageSaved;
                }
                catch
                {

                    return Constant.Constant.MessageUnSaved;
                }

            }

            public String UpdateData(List<Adhocs> listAdhoc)
            {

                try
                {
                    Adhocs adhocs = new Adhocs();
                    adhocs = listAdhoc[0];
                    string parameter = "AdhocCode = '" + adhocs.AdhocCode + "'";
                    using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
                    {
                        using (SqlCommand cmd = new SqlCommand("Delete Adhoc  where " + parameter, conn))
                        {
                                cmd.CommandType = CommandType.Text;
                                conn.Open(); 
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                conn.Dispose();
                        }
                    }


                    return Constant.Constant.MessageSaved;
                }
                catch
                {

                    return Constant.Constant.MessageUnSaved;
                }

            }

            public String DeleteData(INewBookEntity  iBusinessEntity)
            {

                try
                {
                    Adhocs adhocs = new Adhocs();
                    adhocs = (Adhocs)iBusinessEntity;
                    using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("usp_WocBookStaff", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;


                            using (SqlTransaction transaction = connection.BeginTransaction())
                            {

                                command.Transaction = transaction;
                                command.ExecuteNonQuery();
                                transaction.Commit();
                            }
                        }

                        connection.Close();
                    }

                    return Constant.Constant.MessageSaved;
                }
                catch
                {

                    return Constant.Constant.MessageUnSaved;
                }

            }

            public String VoidData(INewBookEntity iBusinessEntity)
            {

                try
                {
                    Adhocs adhocs = new Adhocs();
                    adhocs = (Adhocs)iBusinessEntity;
                    using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand("usp_WocBookAdhoc", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;


                            using (SqlTransaction transaction = connection.BeginTransaction())
                            {

                                command.Parameters.Add("@AdhocCode", SqlDbType.NVarChar);
                                command.Parameters["@AdhocCode"].Value = adhocs.AdhocCode;

                                command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                                command.Parameters["@UpdatedBy"].Value = adhocs.UpdatedBy;

                                command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                                command.Parameters["@TransactionMode"].Value = 2;

                                command.Parameters.Add("@Voided", SqlDbType.Bit);
                                command.Parameters["@Voided"].Value = adhocs.Voided;
                                command.Transaction = transaction;
                                command.ExecuteNonQuery();
                                transaction.Commit();
                            }
                        }

                        connection.Close();
                    }

                    return Constant.Constant.MessageSaved;
                }
                catch
                {

                    return Constant.Constant.MessageUnSaved;
                }

            }

            public List<Adhocs> SearchData(String parameter)
            {
                try
                {
                    Adhocs adhocs = new Adhocs();

                    List<Adhocs> AdhocStaff = new List<Adhocs>();
                    using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
                    {
                        StringBuilder sql = new StringBuilder();
                        sql.Append(" SELECT Adhoc.AdhocID");
                        sql.Append("	,	Agent.Agent");
                        sql.Append("	,	Adhoc.AdhocCode");
                        sql.Append("	,	Adhoc.AdhocBookDate");
                        sql.Append("	,	Adhoc.TimeDepart");
                        sql.Append("	,	Adhoc.TimeReturn");
                        sql.Append("	,	CASE Adhoc.TripType WHEN 'One Way' THEN Adhoc.TripFrom + ' > ' + Adhoc.TripTo ELSE Adhoc.TripFrom + ' <> ' + Adhoc.TripTo END AS Destination ");
                        sql.Append("	,	Adhoc.Purpose");
                        sql.Append("	,	Adhoc.PersonInCharge");
                        sql.Append("	,	Adhoc.Contact");
                        sql.Append("	,	Adhoc.Voided");
                        sql.Append("	,	CASE Adhoc.IsPending WHEN 0 THEN 'Approved' ELSE 'Pending' END AS Status ");
                        sql.Append(" FROM Adhoc");
                        sql.Append(" INNER JOIN Agent ON Adhoc.AgentID = Agent.AgentID WHERE ");

                        using (SqlCommand cmd = new SqlCommand(sql.ToString() + parameter, conn))
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
                                        adhocs.AdhocID = new Guid(table.Rows[i]["AdhocID"].ToString());

                                        if (table.Rows[i]["AdhocBookDate"] != null)
                                        {
                                            adhocs.AdhocBookDate = Convert.ToDateTime(table.Rows[i]["AdhocBookDate"]);
                                        }

                                        adhocs.AdhocCode = table.Rows[i]["AdhocCode"].ToString();
                                        adhocs.Agent = table.Rows[i]["Agent"].ToString();
                                        adhocs.Destination = table.Rows[i]["Destination"].ToString();
                                        if (table.Rows[i]["TimeReturn"] != DBNull.Value)
                                        {
                                            adhocs.TimeReturn = Convert.ToDateTime(table.Rows[i]["TimeReturn"]);
                                        }
                                        if (table.Rows[i]["TimeDepart"] != DBNull.Value)
                                        {
                                            adhocs.TimeDepart = Convert.ToDateTime(table.Rows[i]["TimeDepart"]);
                                        }
                                        adhocs.Purpose = table.Rows[i]["Purpose"].ToString();
                                        adhocs.PersonInCharge = table.Rows[i]["PersonInCharge"].ToString();
                                        adhocs.Contact = table.Rows[i]["Contact"].ToString();
                                        adhocs.Voided = (bool)table.Rows[i]["Voided"];
                                        adhocs.Status = table.Rows[i]["Status"].ToString();
                                        AdhocStaff.Add(adhocs);
                                        adhocs = new Adhocs();
                                    }

                                }


                                conn.Close();
                                ad.Dispose();
                                conn.Dispose();

                            }
                        }
                    }

                    return AdhocStaff;
                }
                catch
                {
                    throw;
                }
            }

            public List<Adhocs> SearchPendingData(String parameter)
            {
                Adhocs adhocs = new Adhocs();

                List<Adhocs> AdhocStaff = new List<Adhocs>();
                using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" SELECT Adhoc.AdhocID");
                    sql.Append("	,	Agent.Agent");
                    sql.Append("	,	Adhoc.AdhocBookDate");
                    sql.Append("	,	Adhoc.PersonInCharge");
                    sql.Append("	,	Adhoc.Contact");
                    sql.Append("	,	Adhoc.TimeDepart");
                    sql.Append("	,	Adhoc.TimeReturn");
                    sql.Append("	,	CASE Adhoc.TripType WHEN 'One Way' THEN Adhoc.TripFrom + ' > ' + Adhoc.TripTo ELSE Adhoc.TripFrom + ' <> ' + Adhoc.TripTo END AS Destination ");
                    sql.Append("	,	Adhoc.Voided");
                    sql.Append("	,	Adhoc.AdhocCode");
                    sql.Append("	,	CASE Adhoc.IsPending WHEN 0 THEN 'Approved' ELSE 'Pending' END AS Status ");
                    sql.Append(" FROM Adhoc");
                    sql.Append(" INNER JOIN Agent ON Adhoc.AgentID = Agent.AgentID WHERE 1=1 ");

                    using (SqlCommand cmd = new SqlCommand(sql.ToString() + parameter, conn))
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
                                    adhocs.AdhocCode = table.Rows[i]["AdhocCode"].ToString();
                                    adhocs.AdhocID = new Guid(table.Rows[i]["AdhocID"].ToString());
                                    adhocs.AdhocBookDate = Convert.ToDateTime(table.Rows[i]["AdhocBookDate"]);

                                    if (table.Rows[i]["AdhocBookDate"] != DBNull.Value)
                                    {
                                        adhocs.AdhocBookDate = Convert.ToDateTime(table.Rows[i]["AdhocBookDate"]);
                                    }

                                    adhocs.Agent = table.Rows[i]["Agent"].ToString();
                                    adhocs.Destination = table.Rows[i]["Destination"].ToString();

                                    if (table.Rows[i]["TimeReturn"] != DBNull.Value)
                                    {
                                        adhocs.TimeReturn = Convert.ToDateTime(table.Rows[i]["TimeReturn"]);
                                    }
                                    if (table.Rows[i]["TimeDepart"] != DBNull.Value)
                                    {
                                        adhocs.TimeDepart = Convert.ToDateTime(table.Rows[i]["TimeDepart"]);
                                    }

                                    adhocs.PersonInCharge = table.Rows[i]["PersonInCharge"].ToString();
                                    adhocs.Contact = table.Rows[i]["Contact"].ToString();
                                    adhocs.Voided = (bool)table.Rows[i]["Voided"];
                                    adhocs.Status = table.Rows[i]["Status"].ToString();
                                    AdhocStaff.Add(adhocs);
                                    adhocs = new Adhocs();
                                }

                            }

                            conn.Close();
                            ad.Dispose();
                            conn.Dispose();

                        }
                    }
                }

                return AdhocStaff;
            }

            public List<Adhocs> GetData(String parameter)
            
            {
                List<Adhocs> ListAdhocs = new List<Adhocs>();
                Adhocs adhocs = new Adhocs();

                using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from Adhoc where " + parameter + " Order By AdhocBookDate", conn))
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
                                    adhocs.AdhocCode = table.Rows[i]["AdhocCode"].ToString();
                                    adhocs.AgentID = new Guid(table.Rows[i]["AgentID"].ToString());
                                    adhocs.Item = i+ 1;

                                    if (adhocs.AdhocBookDate != DateTime.MinValue)
                                    {
                                        adhocs.AdhocBookDate = Convert.ToDateTime(table.Rows[i]["AdhocBookDate"]);
                                    }

                                    adhocs.TripType = table.Rows[i]["TripType"].ToString();
                                    adhocs.AdhocBookDate = Convert.ToDateTime(table.Rows[i]["AdhocBookDate"].ToString());
                                    adhocs.Seater = Convert.ToInt32(table.Rows[i]["Seater"].ToString());
                                    adhocs.TripFrom = table.Rows[i]["TripFrom"].ToString();
                                    adhocs.TripTo = table.Rows[i]["TripTo"].ToString();

                                    if (adhocs.TimeReturn != DateTime.MinValue)
                                    {
                                        adhocs.TimeReturn = Convert.ToDateTime(table.Rows[i]["TimeReturn"]);
                                    }

                                    if (adhocs.TimeDepart != DateTime.MinValue)
                                    {
                                        adhocs.TimeDepart = Convert.ToDateTime(table.Rows[i]["TimeDepart"]);
                                    }

                                    adhocs.Purpose = table.Rows[i]["Purpose"].ToString();
                                    adhocs.PersonInCharge = table.Rows[i]["PersonInCharge"].ToString();
                                    adhocs.Contact = table.Rows[i]["Contact"].ToString();
                                    adhocs.DriverClaim = table.Rows[i]["DriverClaim"].ToString();
                                    adhocs.TypeCashOrder = table.Rows[i]["TypeCashOrder"].ToString();
                                    adhocs.CashOrder = Decimal.Parse(table.Rows[i]["CashOrder"].ToString().Trim());
                                    ListAdhocs.Add(adhocs);
                                    adhocs = new Adhocs();

                                }

                            }
                            conn.Close();
                            ad.Dispose();
                            conn.Dispose();

                        }
                    }
                }
                return ListAdhocs;
            }

            public List<Adhocs> GetTempData(List<Adhocs> adhocStaff)
            {
                Adhocs adhocs = new Adhocs();
                SettingService settingService = new SettingService();

                adhocs.Item = 1;
                adhocs.Seater = 30;
                
                adhocs.DriverClaim = settingService.GetSettingValue("DEFAULT_DRIVER_CLAIM");

                adhocs.Purpose = String.Empty;
                adhocs.AdhocBookDate = DateTime.Now ;
                adhocStaff.Add(adhocs);
                adhocs = new Adhocs();

                return adhocStaff;
            }

            public String ConfirmRejectBooking(List<Adhocs> listAdhoc)
            {
                try
                {
                    //Adhocs adhocs = new Adhocs();
                    DataTable table = new DataTable();
                    table.Columns.Add("AdhocCode", typeof(String));
                    table.Columns.Add("TransactionMode", typeof(int));

                    foreach (Adhocs adhocs in listAdhoc)
                    {
                        DataRow dr = table.NewRow();

                        dr["AdhocCode"] = adhocs.AdhocCode;

                        if (adhocs.IsPending == false)
                        {
                            dr["TransactionMode"] = 4;
                        }
                        else
                        {
                            dr["TransactionMode"] = 5;
                        }

                        table.Rows.Add(dr);
                    }


                    SqlConnection connection = new SqlConnection(UtilityService.Connection());
                    SqlCommand command = new SqlCommand("usp_WocBookAdhocPending", connection);
                    command.CommandType = CommandType.StoredProcedure; command.UpdatedRowSource = UpdateRowSource.None;

                    // Set the Parameter with appropriate Source Column Name           
                    command.Parameters.Add("@AdhocCode", SqlDbType.NVarChar, 50, table.Columns[0].ColumnName);
                    command.Parameters.Add("@TransactionMode", SqlDbType.Int, 4, table.Columns[1].ColumnName);

                    SqlDataAdapter adpt = new SqlDataAdapter();
                    adpt.InsertCommand = command;            // Specify the number of records to be Inserted/Updated in one go. Default is 1.  
                    adpt.UpdateBatchSize = 2;
                    connection.Open();
                    adpt.Update(table);


                    return Constant.Constant.MessageSaved;
                }
                catch
                {

                    return Constant.Constant.MessageUnSaved;
                }

            }
       }
    
}
