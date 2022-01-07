using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;
using Woc.Book.Base.Constant;
using Woc.Book.DailyTrip.BusinessEntity;
namespace Woc.Book.DailyTrip.Service
{
    internal class DailyTripService
    {
        public List<DailyTripsDTO> SearchData(DateTime dDailyTrip)
        {
            List<DailyTripsDTO> ListDailyTrips = new List<DailyTripsDTO>();
            DailyTripsDTO dailyTrips = new DailyTripsDTO();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {



                using (SqlCommand cmd = new SqlCommand("usp_WocBookSearchOperation", conn))
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
                                dailyTrips.TripID = new Guid(table.Rows[i]["TripID"].ToString());
                                dailyTrips.OperationDate = Convert.ToDateTime(table.Rows[i]["OperationDate"]);
                                dailyTrips.Route = table.Rows[i]["Route"].ToString();
                                dailyTrips.RefNo = table.Rows[i]["RefNo"].ToString();
                                dailyTrips.StartTime = Convert.ToDateTime(table.Rows[i]["StartTime"].ToString());

                                if (String.IsNullOrEmpty(table.Rows[i]["EndTime"].ToString()))
                                {
                                    dailyTrips.EndTime = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                                }
                                else
                                {
                                    dailyTrips.EndTime = Convert.ToDateTime(table.Rows[i]["EndTime"].ToString());
                                }

                                dailyTrips.StartBusNo = table.Rows[i]["StartBusNo"].ToString();
                                dailyTrips.EndBusNo = table.Rows[i]["EndBusNo"].ToString();
                                dailyTrips.Remarks = table.Rows[i]["Remarks"].ToString();
                                dailyTrips.Pax = table.Rows[i]["Pax"].ToString();
                                dailyTrips.TripFrom = table.Rows[i]["TripFrom"].ToString();
                                dailyTrips.TripTo = table.Rows[i]["TripTo"].ToString();
                                dailyTrips.TripType = table.Rows[i]["TripType"].ToString();
                                dailyTrips.OperationType = table.Rows[i]["OperationType"].ToString();
                                ListDailyTrips.Add(dailyTrips);
                                dailyTrips = new DailyTripsDTO();     
                            }
                        }




                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }

                return ListDailyTrips;

            }
        }

        public void SaveStartData(IOperation iOperation)
        {

            try
            { 
                DailyTripsDTO dailyTripsDTO = new DailyTripsDTO();
                dailyTripsDTO = (DailyTripsDTO)iOperation;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookStartOperation", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                            command.Parameters.Add("@OperationDate", SqlDbType.DateTime);
                            command.Parameters["@OperationDate"].Value = dailyTripsDTO.OperationDate;

                            command.Parameters.Add("@Route", SqlDbType.NVarChar);
                            command.Parameters["@Route"].Value = dailyTripsDTO.Route;
                          
                            command.Parameters.Add("@RefNo", SqlDbType.NVarChar);
                            command.Parameters["@RefNo"].Value = dailyTripsDTO.RefNo;

                            command.Parameters.Add("@Remarks", SqlDbType.NVarChar);
                            command.Parameters["@Remarks"].Value = dailyTripsDTO.Remarks;

                            command.Parameters.Add("@StartTime", SqlDbType.DateTime);
                            command.Parameters["@StartTime"].Value = dailyTripsDTO.StartTime;

                            command.Parameters.Add("@StartBusNo", SqlDbType.NVarChar);
                            command.Parameters["@StartBusNo"].Value = dailyTripsDTO.StartBusNo;

                            command.Parameters.Add("@EndTime", SqlDbType.DateTime);
                            command.Parameters["@EndTime"].Value = dailyTripsDTO.EndTime;

                            command.Parameters.Add("@Pax", SqlDbType.NVarChar);
                            command.Parameters["@Pax"].Value = dailyTripsDTO.Pax;

                            command.Parameters.Add("@TripFrom", SqlDbType.NVarChar);
                            command.Parameters["@TripFrom"].Value = dailyTripsDTO.TripFrom;

                            command.Parameters.Add("@TripTo", SqlDbType.NVarChar);
                            command.Parameters["@TripTo"].Value = dailyTripsDTO.TripTo;

                            command.Parameters.Add("@OperationID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@OperationID"].Value = dailyTripsDTO.TripID;

                            command.Parameters.Add("@OperationType", SqlDbType.NVarChar);
                            command.Parameters["@OperationType"].Value = dailyTripsDTO.OperationType;

                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }

                    connection.Close();
                }

               
            }
            catch
            {


               
            }
            
        }

        public void SaveEndData(IOperation iOperation)
        {

            try
            {
                DailyTripsDTO dailyTripsDTO = new DailyTripsDTO();
                dailyTripsDTO = (DailyTripsDTO)iOperation;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookEndOperation", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                            command.Parameters.Add("@OperationDate", SqlDbType.DateTime);
                            command.Parameters["@OperationDate"].Value = dailyTripsDTO.OperationDate;

                            command.Parameters.Add("@Route", SqlDbType.NVarChar);
                           
                            command.Parameters["@Route"].Value = dailyTripsDTO.Route;

                            command.Parameters.Add("@RefNo", SqlDbType.NVarChar);
                            command.Parameters["@RefNo"].Value = dailyTripsDTO.RefNo;

                            command.Parameters.Add("@Remarks", SqlDbType.NVarChar);
                            command.Parameters["@Remarks"].Value = dailyTripsDTO.Remarks;

                            command.Parameters.Add("@EndTime", SqlDbType.DateTime);
                            command.Parameters["@EndTime"].Value = dailyTripsDTO.EndTime;

                            command.Parameters.Add("@EndBusNo", SqlDbType.NVarChar);
                            command.Parameters["@EndBusNo"].Value = dailyTripsDTO.EndBusNo;

                            command.Parameters.Add("@Pax", SqlDbType.NVarChar);
                            command.Parameters["@Pax"].Value = dailyTripsDTO.Pax;

                            command.Parameters.Add("@TripFrom", SqlDbType.NVarChar);
                            command.Parameters["@TripFrom"].Value = dailyTripsDTO.TripFrom;

                            command.Parameters.Add("@TripTo", SqlDbType.NVarChar);
                            command.Parameters["@TripTo"].Value = dailyTripsDTO.TripTo;

                            command.Parameters.Add("@OperationID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@OperationID"].Value = dailyTripsDTO.TripID;

                            command.Parameters.Add("@OperationType", SqlDbType.NVarChar);
                            command.Parameters["@OperationType"].Value = dailyTripsDTO.OperationType;

                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }

                    connection.Close();
                }


            }
            catch
            {


            }

        }

        public void SaveData(List<DailyTripsDTO> listDailyTripsDTO)
        {

            try
            {

                DataTable table = new DataTable();
               
                table.Columns.Add(new DataColumn("OperationDate", typeof(DateTime)));
                table.Columns.Add(new DataColumn("Route", typeof(String)));
                table.Columns.Add(new DataColumn("RefNo", typeof(String)));
                table.Columns.Add(new DataColumn("Remarks", typeof(String)));
                table.Columns.Add(new DataColumn("StartTime", typeof(DateTime)));
                table.Columns.Add(new DataColumn("StartBusNo", typeof(String)));
                table.Columns.Add(new DataColumn("EndTime", typeof(DateTime)));
                table.Columns.Add(new DataColumn("EndBusNo", typeof(String)));

                foreach (DailyTripsDTO dailyTripsDTO in listDailyTripsDTO)
                {
                    DataRow row = table.NewRow();
                    row["OperationDate"] = dailyTripsDTO.OperationDate;
                    row["Route"] = dailyTripsDTO.Route;
                    row["RefNo"] = dailyTripsDTO.RefNo;
                    row["Remarks"] = dailyTripsDTO.Remarks;
                    row["StartTime"] = dailyTripsDTO.StartTime;
                    row["StartBusNo"] = dailyTripsDTO.StartBusNo;
                    row["EndTime"] = dailyTripsDTO.EndTime;
                    row["EndBusNo"] = dailyTripsDTO.EndBusNo;
                    table.Rows.Add(row);
                }

 
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    // Create a SqlDataAdapter based on a SELECT query.
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    // Create a SqlCommand to execute the stored procedure.
                    adapter.InsertCommand = new SqlCommand("usp_WocBookOperation", connection);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                    adapter.InsertCommand.Parameters.Add("@OperationDate", SqlDbType.Date, 16, "OperationDate");
                    adapter.InsertCommand.Parameters.Add("@Route", SqlDbType.NVarChar, 50, "Route");
                    adapter.InsertCommand.Parameters.Add("@RefNo", SqlDbType.NVarChar, 50, "RefNo");
                    adapter.InsertCommand.Parameters.Add("@Remarks", SqlDbType.NVarChar, 50, "Remarks");
                    adapter.InsertCommand.Parameters.Add("@StartTime", SqlDbType.DateTime, 16, "StartTime");
                    adapter.InsertCommand.Parameters.Add("@StartBusNo", SqlDbType.NVarChar, 50, "StartBusNo");
                    adapter.InsertCommand.Parameters.Add("@EndTime", SqlDbType.DateTime, 16, "EndTime");
                    adapter.InsertCommand.Parameters.Add("@EndBusNo", SqlDbType.NVarChar, 50, "EndBusNo");

                    // Update the database.
                    adapter.Update(table);
                }

               
            }
            catch
            {

               
            }

        }

        public  Boolean CheckOperation(DateTime dDailyTrip)
        {
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {



                using (SqlCommand cmd = new SqlCommand("usp_WocBookCheckOperation", conn))
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
                            return true;
                        }

                        else
                        {
                            return false;
                        }

                       
                       

                    }
                }

            }
            

       }

        public String DeleteOperation(IOperation iOperation)
        {
            DailyTripsDTO dailyTripsDTO = new DailyTripsDTO();
            dailyTripsDTO = (DailyTripsDTO)iOperation;


            try
            {
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookDeleteOperation", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {


                            command.Parameters.Add("@OperationDate", SqlDbType.DateTime);
                            command.Parameters["@OperationDate"].Value = dailyTripsDTO.OperationDate;

                          
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }

                    connection.Close();
                }

                return "Deleted";
            }
            catch
            {

                return "Not deleted";
            }


        }

           
        
    }
}
