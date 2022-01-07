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
namespace Woc.Book.DailyTripRFrame.Service
{
    internal class DailyTripRFrameService
    {
        public List<DailyTripsDTO> GetHeadersData()
        {
            List<DailyTripsDTO> ListDailyTrips = new List<DailyTripsDTO>();
            DailyTripsDTO dailyTrips = new DailyTripsDTO();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {

                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT B.BusNo ");
                sql.Append("     ,	CASE ISNULL(S.Initial, '') WHEN '' ");
                sql.Append("	    THEN D.DriverName ");
                sql.Append("		ELSE '(' + ISNULL(S.Initial, '') + ') ' + ISNULL(D.DriverName, '')  END DriverName ");
                sql.Append("	, D.Contact");
                sql.Append("    , CASE ISNULL(S.Initial, '') WHEN '' ");
                sql.Append("	  THEN 0 ");
                sql.Append("	  ELSE 1 END IsSubCon ");
                sql.Append(" FROM Bus B ");
                sql.Append(" Left Join Subcon S ON S.SubconID = B.SubconID  ");
                sql.Append(" Left Join Driver D ON (D.BusNo = B.BusNo)");
                sql.Append(" Order By IsSubCon, D.DriverName Desc ");

                using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
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
                                if (string.IsNullOrEmpty(table.Rows[i]["BusNo"].ToString()))
                                {
                                    dailyTrips.BusNo = string.Empty;
                                }
                                else
                                {
                                    dailyTrips.BusNo = table.Rows[i]["BusNo"].ToString();
                                }
                                dailyTrips.EndBusNo = string.Empty;
                                dailyTrips.StartBusNo = string.Empty;
                                dailyTrips.Route = string.Empty;
                                dailyTrips.Remarks = string.Empty;
                                dailyTrips.BookingCode = string.Empty;
                                dailyTrips.Driver = table.Rows[i]["DriverName"].ToString();
                                dailyTrips.Contact = table.Rows[i]["Contact"].ToString();
                                dailyTrips.IsSubcon = (int) table.Rows[i]["IsSubCon"];
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

        public DataTable GetDetailData(String BusNo, DateTime OpsDate, String rowCount)
        {
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                DataTable table = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append("	SELECT TOP " + rowCount + " [Route]");
                sql.Append("	, TripTime");
                sql.Append("	, Customer");
                sql.Append("	, Person");
                sql.Append("	, Contact");
                sql.Append("	, OperationDetailID");
                sql.Append("	, OperationID");
                sql.Append("	, BusNo");
                sql.Append("	, DriverName");
                sql.Append("	, ContactNo");
                sql.Append("	, SegmentType");
                sql.Append("	FROM OperationDetail");
                sql.Append("	WHERE BusNo = '" + BusNo.Trim().Replace("'", "") + "'");
                sql.Append("	AND TripTime >= '" + OpsDate.ToString("yyyy-MM-dd") + "'");
                sql.Append("	AND TripTime < '" + OpsDate.AddDays(1).ToString("yyyy-MM-dd") + "'");
                sql.Append("	ORDER BY TripTime");
                using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        conn.Open();
                        ad.Fill(table);

                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }

                return table;

            }
        }

        public String DeleteData(IOperation iOperation)
        {

            try
            {
                DriverDetailDTO driverDTO = new DriverDetailDTO();
                driverDTO = (DriverDetailDTO)iOperation;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookOperationDetail", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                            command.Parameters.Add("@OperationDetailID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@OperationDetailID"].Value = driverDTO.OperationDetailID;

                            command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                            command.Parameters["@TransactionMode"].Value = 3;

                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }

                    connection.Close();
                }
                return Base.Constant.Constant.MessageSaved;

            }
            catch
            {
                return Base.Constant.Constant.MessageUnSaved;

            }

        }

        public String UpdateData(IOperation iOperation)
        {

            try
            {
                DriverDetailDTO driverDTO = new DriverDetailDTO();
                driverDTO = (DriverDetailDTO)iOperation;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookOperationDetail", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                            command.Parameters.Add("@OperationDetailID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@OperationDetailID"].Value = driverDTO.OperationDetailID;

                            command.Parameters.Add("@TripTime", SqlDbType.DateTime);
                            command.Parameters["@TripTime"].Value = driverDTO.TripTime;

                            command.Parameters.Add("@Route", SqlDbType.NVarChar);
                            command.Parameters["@Route"].Value = driverDTO.DriverRoute;

                            command.Parameters.Add("@Customer", SqlDbType.NVarChar);
                            command.Parameters["@Customer"].Value = driverDTO.Customer;

                            command.Parameters.Add("@Person", SqlDbType.NVarChar);
                            command.Parameters["@Person"].Value = driverDTO.Person;

                            command.Parameters.Add("@Contact", SqlDbType.NVarChar);
                            command.Parameters["@Contact"].Value = driverDTO.Contact;

                            command.Parameters.Add("@FieldID", SqlDbType.Int);
                            command.Parameters["@FieldID"].Value = driverDTO.FieldID;

                            command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                            command.Parameters["@TransactionMode"].Value = 2;

                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }

                    connection.Close();
                }

                return Base.Constant.Constant.MessageSaved;

            }
            catch
            {
                return Base.Constant.Constant.MessageUnSaved;

            }

        }

        public String SaveData(IOperation iOperation)
        {

            try
            {
                DriverDetailDTO driverDTO = new DriverDetailDTO();
                driverDTO = (DriverDetailDTO)iOperation;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookOperationDetail", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                            command.Parameters.Add("@OperationID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@OperationID"].Value = driverDTO.OperationID;

                            command.Parameters.Add("@TripTime", SqlDbType.DateTime);
                            command.Parameters["@TripTime"].Value = driverDTO.TripTime;

                            command.Parameters.Add("@Route", SqlDbType.NVarChar);
                            command.Parameters["@Route"].Value = driverDTO.DriverRoute;

                            command.Parameters.Add("@Customer", SqlDbType.NVarChar);
                            command.Parameters["@Customer"].Value = driverDTO.Customer;

                            command.Parameters.Add("@Person", SqlDbType.NVarChar);
                            command.Parameters["@Person"].Value = driverDTO.Person;

                            command.Parameters.Add("@Contact", SqlDbType.NVarChar);
                            command.Parameters["@Contact"].Value = driverDTO.Contact;

                            command.Parameters.Add("@BusNo", SqlDbType.NVarChar);
                            command.Parameters["@BusNo"].Value = driverDTO.BusNo;

                            command.Parameters.Add("@DriverName", SqlDbType.NVarChar);
                            command.Parameters["@DriverName"].Value = driverDTO.DriverName;

                            command.Parameters.Add("@ContactNo", SqlDbType.NVarChar);
                            command.Parameters["@ContactNo"].Value = driverDTO.DriverContact;
                            
                            command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                            command.Parameters["@TransactionMode"].Value = 1;

                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }

                    connection.Close();
                }

                return Base.Constant.Constant.MessageSaved;

            }
            catch
            {
                return Base.Constant.Constant.MessageUnSaved;

            }

        }
    }
}
