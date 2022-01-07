using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Woc.Book.Common.BusinessEntity;
using Woc.Book.Common.Service;
using Woc.Book.Common.Constant;
using Woc.Book.ReportDriverBus.BusinessEntity;
namespace Woc.Book.ReportDriverBus.Service
{
 internal class ReportDriverBusService
    {
     public List<ReportDriverBuses> SearchData(IOperation iOperation)
        {
            List<ReportDriverBuses> ListReportDriverBuses = new List<ReportDriverBuses>();
            ReportDriverBuses reportDriverBuses = new ReportDriverBuses();
            reportDriverBuses = (ReportDriverBuses)iOperation;
        
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {



                using (SqlCommand cmd = new SqlCommand("usp_WocBookSearchOperation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@OperationDate", SqlDbType.DateTime);
                    cmd.Parameters["@OperationDate"].Value = reportDriverBuses.OperationDate;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        conn.Open();
                        ad.Fill(table);

                        if (table.DefaultView.Count > 0)
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                reportDriverBuses.OperationDate = Convert.ToDateTime(table.Rows[i]["OperationDate"]);
                                reportDriverBuses.Route = table.Rows[i]["Route"].ToString();
                                reportDriverBuses.RefNo = table.Rows[i]["RefNo"].ToString();
                                reportDriverBuses.StartTime = Convert.ToDateTime(table.Rows[i]["StartTime"].ToString());

                                //if (table.Rows[i]["TripType"].ToString().Trim().ToLower()== "one way")
                                //{
                                if (String.IsNullOrEmpty(table.Rows[i]["EndTime"].ToString()))
                                {
                                    reportDriverBuses.EndTime = Convert.ToDateTime(Common.Constant.Constant.MinimumDate);
                                }
                                else
                                {
                                    reportDriverBuses.EndTime = Convert.ToDateTime(table.Rows[i]["EndTime"].ToString());
                                }
                                //}
                                reportDriverBuses.StartBusNo = table.Rows[i]["StartBusNo"].ToString();
                                reportDriverBuses.EndBusNo = table.Rows[i]["EndBusNo"].ToString();
                                reportDriverBuses.Remarks = table.Rows[i]["Remarks"].ToString();
                                reportDriverBuses.Pax = table.Rows[i]["Pax"].ToString();
                                ListReportDriverBuses.Add(reportDriverBuses);
                                reportDriverBuses = new ReportDriverBuses();
                            }
                        }




                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }

                return ListReportDriverBuses;

            }
        }

        public void SaveStartData(IOperation iOperation)
        {

            try
            {
                ReportDriverBuses reportDriverBuses = new ReportDriverBuses();
                reportDriverBuses = (ReportDriverBuses)iOperation;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookStartOperation", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                            command.Parameters.Add("@OperationDate", SqlDbType.DateTime);
                            command.Parameters["@OperationDate"].Value = reportDriverBuses.OperationDate;

                            command.Parameters.Add("@Route", SqlDbType.NVarChar);
                            command.Parameters["@Route"].Value = reportDriverBuses.Route;

                            command.Parameters.Add("@RefNo", SqlDbType.NVarChar);
                            command.Parameters["@RefNo"].Value = reportDriverBuses.RefNo;

                            command.Parameters.Add("@Remarks", SqlDbType.NVarChar);
                            command.Parameters["@Remarks"].Value = reportDriverBuses.Remarks;

                            command.Parameters.Add("@StartTime", SqlDbType.DateTime);
                            command.Parameters["@StartTime"].Value = reportDriverBuses.StartTime;

                            command.Parameters.Add("@StartBusNo", SqlDbType.NVarChar);
                            command.Parameters["@StartBusNo"].Value = reportDriverBuses.StartBusNo;

                            command.Parameters.Add("@Pax", SqlDbType.NVarChar);
                            command.Parameters["@Pax"].Value = reportDriverBuses.Pax;

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
                ReportDriverBuses reportDriverBuses = new ReportDriverBuses();
                reportDriverBuses = (ReportDriverBuses)iOperation;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookEndOperation", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                            command.Parameters.Add("@OperationDate", SqlDbType.DateTime);
                            command.Parameters["@OperationDate"].Value = reportDriverBuses.OperationDate;

                            command.Parameters.Add("@Route", SqlDbType.NVarChar);
                            command.Parameters["@Route"].Value = reportDriverBuses.Route;

                            command.Parameters.Add("@RefNo", SqlDbType.NVarChar);
                            command.Parameters["@RefNo"].Value = reportDriverBuses.RefNo;

                            command.Parameters.Add("@Remarks", SqlDbType.NVarChar);
                            command.Parameters["@Remarks"].Value = reportDriverBuses.Remarks;

                            command.Parameters.Add("@EndTime", SqlDbType.DateTime);
                            command.Parameters["@EndTime"].Value = reportDriverBuses.EndTime;

                            command.Parameters.Add("@EndBusNo", SqlDbType.NVarChar);
                            command.Parameters["@EndBusNo"].Value = reportDriverBuses.EndBusNo;

                            command.Parameters.Add("@Pax", SqlDbType.NVarChar);
                            command.Parameters["@Pax"].Value = reportDriverBuses.Pax;

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

        public void SaveData(IOperation iOperation)
        {

            try
            {
                ReportDriverBuses reportDriverBuses = new ReportDriverBuses();
                reportDriverBuses = (ReportDriverBuses)iOperation;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookDriverStatus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            //1
                            command.Parameters.Add("@DriverStatus", SqlDbType.NVarChar);
                            command.Parameters["@DriverStatus"].Value = reportDriverBuses.Driver;
                            //2
                            command.Parameters.Add("@DriverDateStatus", SqlDbType.NVarChar);
                            command.Parameters["@DriverDateStatus"].Value = reportDriverBuses.OperationDate;
                            //3
                            command.Parameters.Add("@TimeTo", SqlDbType.NVarChar);
                            command.Parameters["@TimeTo"].Value = reportDriverBuses.StartTime;
                            //4
                            command.Parameters.Add("@TimeFrom", SqlDbType.NVarChar);
                            command.Parameters["@TimeFrom"].Value = reportDriverBuses.EndTime;
                            //6
                            command.Parameters.Add("@Status", SqlDbType.NVarChar);
                            command.Parameters["@Status"].Value = reportDriverBuses.Status;
                            //7
                            command.Parameters.Add("@QueryTypeID", SqlDbType.Int);
                            command.Parameters["@QueryTypeID"].Value = 1;

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

        public Boolean CheckOperation(DateTime dDailyTrip)
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

                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }

            }


        }

        public String DeleteOperation(IOperation iOperation)
        {
            ReportDriverBuses reportDriverBuses = new ReportDriverBuses();
            reportDriverBuses = (ReportDriverBuses)iOperation;


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
                            command.Parameters["@OperationDate"].Value = reportDriverBuses.OperationDate;


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
