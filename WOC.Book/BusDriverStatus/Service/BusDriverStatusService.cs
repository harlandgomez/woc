using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;
using Woc.Book.Base.Constant;


using Woc.Book.BusDriverStatus.BusinessEntity;

namespace Woc.Book.BusDriverStatus.Service
{
   internal class BusDriverStatusService
    {
        public List<DriverBuses> SearchData(String strBus, String strDriver)
        {
            List<DriverBuses> ListDriverBuses = new List<DriverBuses>();
            DriverBuses driverBuses = new DriverBuses();
        
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {

                using (SqlCommand cmd = new SqlCommand(strBus, conn))
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
                                driverBuses.BusNo = table.Rows[i]["BusNo"].ToString();
                                driverBuses.Driver = table.Rows[i]["Driver"].ToString();
                                driverBuses.Status = table.Rows[i]["Status"].ToString();
                                driverBuses.OperationDate = DateTime.Now;
                                if (String.IsNullOrEmpty(table.Rows[i]["DateStatus"].ToString()))
                                {
                                    driverBuses.OperationDate = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                                }
                                else
                                {
                                    driverBuses.OperationDate = Convert.ToDateTime(table.Rows[i]["DateStatus"].ToString());
                                }
                                
                                ListDriverBuses.Add(driverBuses);
                                driverBuses = new DriverBuses();
                            }
                        }


                        conn.Close();
                        ad.Dispose();
                       

                    }
                }
                using (SqlCommand cmd = new SqlCommand(strDriver, conn))
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
                                driverBuses.BusNo = table.Rows[i]["BusNo"].ToString();
                                driverBuses.Driver = table.Rows[i]["Driver"].ToString();
                                driverBuses.Status = table.Rows[i]["Status"].ToString();
                                driverBuses.OperationDate = DateTime.Now;
                                if (String.IsNullOrEmpty(table.Rows[i]["DateStatus"].ToString()))
                                {
                                    driverBuses.OperationDate = Convert.ToDateTime(Base.Constant.Constant.MinimumDate);
                                }
                                else
                                {
                                    driverBuses.OperationDate = Convert.ToDateTime(table.Rows[i]["DateStatus"].ToString());
                                }

                                ListDriverBuses.Add(driverBuses);
                                driverBuses = new DriverBuses();
                            }
                        }


                        conn.Close();
                        ad.Dispose();


                    }
                }

                conn.Dispose();

            }
            
            return ListDriverBuses;
        }

        public List<DriverBuses> SearchCOSData(String strCOS)
        {
            List<DriverBuses> ListDriverBuses = new List<DriverBuses>();
            DriverBuses driverBuses = new DriverBuses();

            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {

                using (SqlCommand cmd = new SqlCommand(strCOS, conn))
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
                                driverBuses.OperationDate = Convert.ToDateTime(table.Rows[i]["OperationDate"].ToString());
                                driverBuses.BusNo = table.Rows[i]["BusNo"].ToString();
                                driverBuses.Driver = table.Rows[i]["DriverName"].ToString();
                                driverBuses.Route = table.Rows[i]["Route"].ToString();
                                driverBuses.Customer = table.Rows[i]["Customer"].ToString();
                                driverBuses.Contact = table.Rows[i]["Contact"].ToString();
                                driverBuses.Amount = table.Rows[i]["Amount"].ToString();
                                ListDriverBuses.Add(driverBuses);
                                driverBuses = new DriverBuses();
                            }
                        }


                        conn.Close();
                        ad.Dispose();


                    }
                }
                
                conn.Dispose();

            }

            return ListDriverBuses;
        }

        public void SaveStartData(IOperation iOperation)
        {

            try
            {
              
                DriverBuses driverBuses = new DriverBuses();
                driverBuses = (DriverBuses)iOperation;

                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookStartOperation", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                            command.Parameters.Add("@OperationDate", SqlDbType.DateTime);
                            command.Parameters["@OperationDate"].Value = driverBuses.OperationDate;

                            command.Parameters.Add("@Route", SqlDbType.NVarChar);
                            command.Parameters["@Route"].Value = driverBuses.Route;

                            command.Parameters.Add("@RefNo", SqlDbType.NVarChar);
                            command.Parameters["@RefNo"].Value = driverBuses.RefNo;

                            command.Parameters.Add("@Remarks", SqlDbType.NVarChar);
                            command.Parameters["@Remarks"].Value = driverBuses.Remarks;

                            command.Parameters.Add("@StartTime", SqlDbType.DateTime);
                            command.Parameters["@StartTime"].Value = driverBuses.StartTime;

                            command.Parameters.Add("@StartBusNo", SqlDbType.NVarChar);
                            command.Parameters["@StartBusNo"].Value = driverBuses.StartBusNo;

                            command.Parameters.Add("@Pax", SqlDbType.NVarChar);
                            command.Parameters["@Pax"].Value = driverBuses.Pax;

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
                DriverBuses driverBuses = new DriverBuses();
                driverBuses = (DriverBuses)iOperation;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookEndOperation", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                            command.Parameters.Add("@OperationDate", SqlDbType.DateTime);
                            command.Parameters["@OperationDate"].Value = driverBuses.OperationDate;

                            command.Parameters.Add("@Route", SqlDbType.NVarChar);
                            command.Parameters["@Route"].Value = driverBuses.Route;

                            command.Parameters.Add("@RefNo", SqlDbType.NVarChar);
                            command.Parameters["@RefNo"].Value = driverBuses.RefNo;

                            command.Parameters.Add("@Remarks", SqlDbType.NVarChar);
                            command.Parameters["@Remarks"].Value = driverBuses.Remarks;

                            command.Parameters.Add("@EndTime", SqlDbType.DateTime);
                            command.Parameters["@EndTime"].Value = driverBuses.EndTime;

                            command.Parameters.Add("@EndBusNo", SqlDbType.NVarChar);
                            command.Parameters["@EndBusNo"].Value = driverBuses.EndBusNo;

                            command.Parameters.Add("@Pax", SqlDbType.NVarChar);
                            command.Parameters["@Pax"].Value = driverBuses.Pax;

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

        public void SaveDriverData(IOperation iOperation)
        {

            try
            {
                DriverBuses driverBuses = new DriverBuses();
                driverBuses = (DriverBuses)iOperation;

                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookDriverStatus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            //1
                            command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                            command.Parameters["@TransactionMode"].Value = 1;
                            //2
                            command.Parameters.Add("@DriverStatusID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@DriverStatusID"].Value = driverBuses.DriverStatusID;
                            //3
                            command.Parameters.Add("@DriverStatus", SqlDbType.NVarChar);
                            command.Parameters["@DriverStatus"].Value = driverBuses.Driver;
                            //2
                            command.Parameters.Add("@DriverDateStatus", SqlDbType.NVarChar);
                            command.Parameters["@DriverDateStatus"].Value = driverBuses.OperationDate;
                            //3
                            command.Parameters.Add("@TimeTo", SqlDbType.DateTime);
                            command.Parameters["@TimeTo"].Value = driverBuses.StartTime;
                            //4
                            command.Parameters.Add("@TimeFrom", SqlDbType.DateTime);
                            command.Parameters["@TimeFrom"].Value = driverBuses.EndTime;
                            //6
                            command.Parameters.Add("@Status", SqlDbType.NVarChar);
                            command.Parameters["@Status"].Value = driverBuses.Status;
                            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CreatedBy"].Value = driverBuses.CreatedBy;
                            //7
                            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                            command.Parameters["@CreatedDate"].Value = driverBuses.CreatedDate;
                            //8
                            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@UpdatedBy"].Value = driverBuses.UpdatedBy;
                            //9
                            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime);
                            command.Parameters["@UpdatedDate"].Value = driverBuses.UpdatedDate;
                           

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
                throw;

            }

        }

        public void SaveBusData(IOperation iOperation)
        {
            try
            {
                DriverBuses driverBuses = new DriverBuses();
                driverBuses = (DriverBuses)iOperation;

                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {

                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookBusStatus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            //1
                            command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                            command.Parameters["@TransactionMode"].Value = 1;
                            //2
                            command.Parameters.Add("@BusStatusID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@BusStatusID"].Value = driverBuses.BusStatusID;
                            
                            //2
                            command.Parameters.Add("@BusDateStatus", SqlDbType.DateTime);
                            command.Parameters["@BusDateStatus"].Value = driverBuses.BusDateStatus;
                            //3
                            command.Parameters.Add("@TimeTo", SqlDbType.DateTime);
                            command.Parameters["@TimeTo"].Value = driverBuses.StartTime;
                            //4
                            command.Parameters.Add("@TimeFrom", SqlDbType.DateTime);
                            command.Parameters["@TimeFrom"].Value = driverBuses.EndTime;

                            //3
                            command.Parameters.Add("@BusStatus", SqlDbType.NVarChar);
                            command.Parameters["@BusStatus"].Value = driverBuses.BusStatus;

                            //6
                            command.Parameters.Add("@PO", SqlDbType.NVarChar);
                            command.Parameters["@PO"].Value = driverBuses.PO;

                            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CreatedBy"].Value = driverBuses.CreatedBy;
                            //7
                            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                            command.Parameters["@CreatedDate"].Value = driverBuses.CreatedDate;
                            //8
                            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@UpdatedBy"].Value = driverBuses.UpdatedBy;
                            //9
                            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime);
                            command.Parameters["@UpdatedDate"].Value = driverBuses.UpdatedDate;

                            command.Parameters.Add("@BusNo", SqlDbType.NVarChar);
                            command.Parameters["@BusNo"].Value = driverBuses.BusNo;


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
                throw;

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




                    }
                }

            }


        }

        public String DeleteOperation(IOperation iOperation)
        {
            DriverBuses driverBuses = new DriverBuses();
            driverBuses = (DriverBuses)iOperation;

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
                            command.Parameters["@OperationDate"].Value = driverBuses.OperationDate;


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
