using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;
using Woc.Book.Bus.BusinessEntity;
using Woc.Book.Bus.Constant;

namespace Woc.Book.Bus.Service
{
  internal class BusService:IRegistrationService
    {

        public String SaveData(IBusinessEntity iBusinessEntity)
        {

            try
            {
                Buses buses = new Buses();
                buses = (Buses)iBusinessEntity;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookBus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            //1
                            command.Parameters.Add("@BusCode", SqlDbType.NVarChar);
                            command.Parameters["@BusCode"].Value = buses.BusCode;
                            //2
                            command.Parameters.Add("@Brand", SqlDbType.NVarChar);
                            command.Parameters["@Brand"].Value = buses.Brand;
                            //3
                            command.Parameters.Add("@Parking", SqlDbType.NVarChar);
                            command.Parameters["@Parking"].Value = buses.Parking;
                            //4
                            command.Parameters.Add("@BusNo", SqlDbType.NVarChar);
                            command.Parameters["@BusNo"].Value = buses.BusNo;
                            //6
                            command.Parameters.Add("@Year", SqlDbType.NVarChar);
                            command.Parameters["@Year"].Value = buses.BusNo1;
                            //7
                            command.Parameters.Add("@BusNo1", SqlDbType.NVarChar);
                            command.Parameters["@BusNo1"].Value = buses.BusNo1;
                            //8
                            command.Parameters.Add("@BusNo2", SqlDbType.NVarChar);
                            command.Parameters["@BusNo2"].Value = buses.BusNo2;
                            //9
                            command.Parameters.Add("@BusNo3", SqlDbType.NVarChar);
                            command.Parameters["@BusNo3"].Value = buses.BusNo3;
                            //10
                            command.Parameters.Add("@CompanyID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CompanyID"].Value = buses.CompanyID;
                            //11
                            command.Parameters.Add("@Seater", SqlDbType.NVarChar);
                            command.Parameters["@Seater"].Value = buses.Seater;
                            //12
                            command.Parameters.Add("@Type", SqlDbType.NVarChar);
                            command.Parameters["@Type"].Value = buses.Type;
                            //13
                            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CreatedBy"].Value = buses.CreatedBy;
                            //14
                            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                            command.Parameters["@CreatedDate"].Value = buses.CreatedDate;
                            //15
                            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@UpdatedBy"].Value = buses.UpdatedBy;
                            //16
                            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime);
                            command.Parameters["@UpdatedDate"].Value = buses.UpdatedDate;
                            //17
                            command.Parameters.Add("@Passes1", SqlDbType.NVarChar);
                            command.Parameters["@Passes1"].Value = buses.Passes1;
                            //18
                            command.Parameters.Add("@Passes2", SqlDbType.NVarChar);
                            command.Parameters["@Passes2"].Value = buses.Passes2;
                            //19
                            command.Parameters.Add("@Passes3", SqlDbType.NVarChar);
                            command.Parameters["@Passes3"].Value = buses.Passes3;
                            //20
                            if (buses.Expiry1 != DateTime.MinValue)
                            {
                                command.Parameters.Add("@Expiry1", SqlDbType.DateTime);
                                command.Parameters["@Expiry1"].Value = buses.Expiry1;
                            }
                            //21
                            if (buses.Expiry2 != DateTime.MinValue)
                            {
                                command.Parameters.Add("@Expiry2", SqlDbType.DateTime);
                                command.Parameters["@Expiry2"].Value = buses.Expiry2;
                            }
                            //22
                            if (buses.Expiry3 != DateTime.MinValue)
                            {
                                command.Parameters.Add("@Expiry3", SqlDbType.DateTime);
                                command.Parameters["@Expiry3"].Value = buses.Expiry3;
                            }
                            //23
                            command.Parameters.Add("@Delete", SqlDbType.NVarChar);
                            command.Parameters["@Delete"].Value = "N";
                            //24
                            command.Parameters.Add("@Scrapped", SqlDbType.Bit);
                            command.Parameters["@Scrapped"].Value = buses.Scrapped;
                            //25
                            if (buses.ScrappedDate != DateTime.MinValue)
                            {
                                command.Parameters.Add("@ScrappedDate", SqlDbType.DateTime);
                                command.Parameters["@ScrappedDate"].Value = buses.ScrappedDate;
                            }
                            //26
                            command.Parameters.Add("@SubconID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@SubconID"].Value = buses.SubconID;
                            //27
                            command.Parameters.Add("@QueryTypeID", SqlDbType.Int);
                            command.Parameters["@QueryTypeID"].Value = 1;

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

        public String UpdateData(IBusinessEntity iBusinessEntity)
        {
            try
            {
                Buses buses = new Buses();
                buses = (Buses)iBusinessEntity;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookBus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            //1
                            command.Parameters.Add("@BusCode", SqlDbType.NVarChar);
                            command.Parameters["@BusCode"].Value = buses.BusCode;
                            //2
                            command.Parameters.Add("@Brand", SqlDbType.NVarChar);
                            command.Parameters["@Brand"].Value = buses.Brand;
                            //3
                            command.Parameters.Add("@Parking", SqlDbType.NVarChar);
                            command.Parameters["@Parking"].Value = buses.Parking;
                            //5
                            command.Parameters.Add("@BusNo", SqlDbType.NVarChar);
                            command.Parameters["@BusNo"].Value = buses.BusNo;
                            //6
                            command.Parameters.Add("@Year", SqlDbType.NVarChar);
                            command.Parameters["@Year"].Value = buses.BusNo1;
                            //7
                            command.Parameters.Add("@BusNo1", SqlDbType.NVarChar);
                            command.Parameters["@BusNo1"].Value = buses.BusNo1;
                            //8
                            command.Parameters.Add("@BusNo2", SqlDbType.NVarChar);
                            command.Parameters["@BusNo2"].Value = buses.BusNo2;
                            //9
                            command.Parameters.Add("@BusNo3", SqlDbType.NVarChar);
                            command.Parameters["@BusNo3"].Value = buses.BusNo3;
                            //10
                            command.Parameters.Add("@CompanyID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CompanyID"].Value = buses.CompanyID;
                            //11
                            command.Parameters.Add("@Seater", SqlDbType.NVarChar);
                            command.Parameters["@Seater"].Value = buses.Seater;
                            //12
                            command.Parameters.Add("@Type", SqlDbType.NVarChar);
                            command.Parameters["@Type"].Value = buses.Type;
                            //13
                            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CreatedBy"].Value = buses.CreatedBy;
                            //14
                            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                            command.Parameters["@CreatedDate"].Value = buses.CreatedDate;
                            //15
                            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@UpdatedBy"].Value = buses.UpdatedBy;
                            //16
                            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime);
                            command.Parameters["@UpdatedDate"].Value = buses.UpdatedDate;
                            //17
                            command.Parameters.Add("@Passes1", SqlDbType.NVarChar);
                            command.Parameters["@Passes1"].Value = buses.Passes1;
                            //18
                            command.Parameters.Add("@Passes2", SqlDbType.NVarChar);
                            command.Parameters["@Passes2"].Value = buses.Passes2;
                            //19
                            command.Parameters.Add("@Passes3", SqlDbType.NVarChar);
                            command.Parameters["@Passes3"].Value = buses.Passes3;
                            //20
                            if (buses.Expiry1 != DateTime.MinValue)
                            {
                                command.Parameters.Add("@Expiry1", SqlDbType.DateTime);
                                command.Parameters["@Expiry1"].Value = buses.Expiry1;
                            }
                            //21
                            if (buses.Expiry2 != DateTime.MinValue)
                            {
                                command.Parameters.Add("@Expiry2", SqlDbType.DateTime);
                                command.Parameters["@Expiry2"].Value = buses.Expiry2;
                            }
                            //22
                            if (buses.Expiry3 != DateTime.MinValue)
                            {
                                command.Parameters.Add("@Expiry3", SqlDbType.DateTime);
                                command.Parameters["@Expiry3"].Value = buses.Expiry3;
                            }
                            //23
                            command.Parameters.Add("@Delete", SqlDbType.NVarChar);
                            command.Parameters["@Delete"].Value = "N";
                            //24
                            command.Parameters.Add("@Scrapped", SqlDbType.Bit);
                            command.Parameters["@Scrapped"].Value = buses.Scrapped;
                            //25
                            if (buses.ScrappedDate != DateTime.MinValue)
                            {
                                command.Parameters.Add("@ScrappedDate", SqlDbType.DateTime);
                                command.Parameters["@ScrappedDate"].Value = buses.ScrappedDate;
                            }
                            //26
                            command.Parameters.Add("@SubconID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@SubConID"].Value = buses.SubconID;
                            //26
                            command.Parameters.Add("@QueryTypeID", SqlDbType.Int);
                            command.Parameters["@QueryTypeID"].Value = 2;

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

        public String DeleteData(IBusinessEntity iBusinessEntity)
        {
            try
            {
                Buses buses = new Buses();
                buses = (Buses)iBusinessEntity;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookBus", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            //1
                            command.Parameters.Add("@BusCode", SqlDbType.NVarChar);
                            command.Parameters["@BusCode"].Value = buses.BusCode;
                            //2
                            command.Parameters.Add("@Brand", SqlDbType.NVarChar);
                            command.Parameters["@Brand"].Value = buses.Brand;
                            //3
                            command.Parameters.Add("@Parking", SqlDbType.NVarChar);
                            command.Parameters["@Parking"].Value = buses.Parking;
                            //4
                            command.Parameters.Add("@BusNo", SqlDbType.NVarChar);
                            command.Parameters["@BusNo"].Value = buses.BusNo;
                            //6
                            command.Parameters.Add("@Year", SqlDbType.NVarChar);
                            command.Parameters["@Year"].Value = buses.BusNo1;
                            //7
                            command.Parameters.Add("@BusNo1", SqlDbType.NVarChar);
                            command.Parameters["@BusNo1"].Value = buses.BusNo1;
                            //8
                            command.Parameters.Add("@BusNo2", SqlDbType.NVarChar);
                            command.Parameters["@BusNo2"].Value = buses.BusNo2;
                            //9
                            command.Parameters.Add("@BusNo3", SqlDbType.NVarChar);
                            command.Parameters["@BusNo3"].Value = buses.BusNo3;
                            //10
                            command.Parameters.Add("@CompanyID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CompanyID"].Value = buses.CompanyID;
                            //11
                            command.Parameters.Add("@Seater", SqlDbType.NVarChar);
                            command.Parameters["@Seater"].Value = buses.Seater;
                            //12
                            command.Parameters.Add("@Type", SqlDbType.NVarChar);
                            command.Parameters["@Type"].Value = buses.Type;
                            //13
                            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CreatedBy"].Value = buses.CreatedBy;
                            //14
                            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                            command.Parameters["@CreatedDate"].Value = buses.CreatedDate;
                            //15
                            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@UpdatedBy"].Value = buses.UpdatedBy;
                            //16
                            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime);
                            command.Parameters["@UpdatedDate"].Value = buses.UpdatedDate;
                            //17
                            command.Parameters.Add("@Passes1", SqlDbType.NVarChar);
                            command.Parameters["@Passes1"].Value = buses.Passes1;
                            //18
                            command.Parameters.Add("@Passes2", SqlDbType.NVarChar);
                            command.Parameters["@Passes2"].Value = buses.Passes2;
                            //19
                            command.Parameters.Add("@Passes3", SqlDbType.NVarChar);
                            command.Parameters["@Passes3"].Value = buses.Passes3;
                            //20
                            if (buses.Expiry1 != DateTime.MinValue)
                            {
                                command.Parameters.Add("@Expiry1", SqlDbType.DateTime);
                                command.Parameters["@Expiry1"].Value = buses.Expiry1;
                            }
                            //21
                            if (buses.Expiry2 != DateTime.MinValue)
                            {
                                command.Parameters.Add("@Expiry2", SqlDbType.DateTime);
                                command.Parameters["@Expiry2"].Value = buses.Expiry2;
                            }
                            //22
                            if (buses.Expiry3 != DateTime.MinValue)
                            {
                                command.Parameters.Add("@Expiry3", SqlDbType.DateTime);
                                command.Parameters["@Expiry3"].Value = buses.Expiry3;
                            }
                            //23
                            command.Parameters.Add("@Delete", SqlDbType.NVarChar);
                            command.Parameters["@Delete"].Value = "N";
                            //24
                            command.Parameters.Add("@Scrapped", SqlDbType.Bit);
                            command.Parameters["@Scrapped"].Value = buses.Scrapped;
                            //25
                            if (buses.ScrappedDate != DateTime.MinValue)
                            {
                                command.Parameters.Add("@ScrappedDate", SqlDbType.DateTime);
                                command.Parameters["@ScrappedDate"].Value = buses.ScrappedDate;
                            }
                            //26
                            command.Parameters.Add("@QueryTypeID", SqlDbType.Int);
                            command.Parameters["@QueryTypeID"].Value = 3 ;

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

        public List<Buses> SearchData(String parameter)
        {
            Buses buses = new Buses();
            List<Buses> ListBuses = new List<Buses>();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("Select Bus.*, Company.Company from Bus INNER JOIN Company ON Company.CompanyID = Bus.CompanyID where " + parameter, conn))
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
                                buses.Brand = table.Rows[i]["Brand"].ToString();
                                buses.BusCode = table.Rows[i]["BusCode"].ToString();
                                buses.BusNo = table.Rows[i]["BusNo"].ToString();
                                buses.Seater = Convert.ToInt32(table.Rows[i]["Seater"].ToString());
                                buses.CompanyID = new Guid(table.Rows[i]["CompanyID"].ToString());
                                buses.CompanyNameSearch = table.Rows[i]["Company"].ToString();
                                ListBuses.Add(buses);
                                buses = new Buses();
                            }

                        }


                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }

            return ListBuses;
        }

        public Buses GetData(String parameter)
        {
            Buses buses = new Buses();

            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Bus where " + parameter, conn))
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
                                buses.Brand = table.Rows[i]["Brand"].ToString();
                                buses.BusCode = table.Rows[i]["BusCode"].ToString();
                                buses.BusID = new Guid(table.Rows[i]["BusID"].ToString());
                                buses.BusNo = table.Rows[i]["BusNo"].ToString();
                                buses.BusNo1 = table.Rows[i]["BusNo1"].ToString();
                                buses.BusNo2 = table.Rows[i]["BusNo2"].ToString();
                                buses.BusNo3 = table.Rows[i]["BusNo3"].ToString();
                                buses.CompanyID = new Guid(table.Rows[i]["CompanyID"].ToString());
                                buses.CreatedBy = new Guid(table.Rows[i]["CreatedBy"].ToString());
                                buses.CreatedDate = Convert.ToDateTime(table.Rows[i]["CreatedDate"].ToString());
                                if (!String.IsNullOrEmpty(table.Rows[i]["Expiry1"].ToString()))
                                {
                                    buses.Expiry1 = Convert.ToDateTime(table.Rows[i]["Expiry1"].ToString());
                                }
                                if (!String.IsNullOrEmpty(table.Rows[i]["Expiry2"].ToString()))
                                {
                                    buses.Expiry2 = Convert.ToDateTime(table.Rows[i]["Expiry2"].ToString());
                                }
                                if (!String.IsNullOrEmpty(table.Rows[i]["Expiry3"].ToString()))
                                {
                                    buses.Expiry3 = Convert.ToDateTime(table.Rows[i]["Expiry3"].ToString());
                                }
                                buses.Parking = table.Rows[i]["Parking"].ToString();
                                buses.Passes1 = table.Rows[i]["Passes1"].ToString();
                                buses.Passes2 = table.Rows[i]["Passes2"].ToString();
                                buses.Passes3 = table.Rows[i]["Passes3"].ToString();
                                buses.Seater = Convert.ToInt32(table.Rows[i]["Seater"].ToString().Trim());
                                buses.Scrapped = Convert.ToBoolean(table.Rows[i]["Scrapped"]);
                                buses.Parking = table.Rows[i]["Parking"].ToString();
                                buses.Year = table.Rows[i]["Year"].ToString();

                                if (!String.IsNullOrEmpty(table.Rows[i]["ScrappedDate"].ToString()))
                                {
                                    buses.ScrappedDate = Convert.ToDateTime(table.Rows[i]["ScrappedDate"]);
                                }
                                buses.Type = table.Rows[i]["Type"].ToString();
                                buses.UpdatedBy = new Guid(table.Rows[i]["UpdatedBy"].ToString());
                                buses.UpdatedDate = Convert.ToDateTime(table.Rows[i]["UpdatedDate"].ToString());
                                if (!String.IsNullOrEmpty(table.Rows[i]["SubconID"].ToString()))
                                {
                                    buses.SubconID = new Guid(table.Rows[i]["SubconID"].ToString());
                                }
                            }

                        }
                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }

            return buses;
        }

        public List<Buses>  GetData()
        {

            Buses buses = new Buses();
            List<Buses> ListBuses = new List<Buses>();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Bus", conn))
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
                                buses.Brand = table.Rows[i]["Brand"].ToString();
                                buses.BusCode = table.Rows[i]["BusCode"].ToString();
                                buses.BusNo = table.Rows[i]["BusNo"].ToString();
                                buses.Seater = Convert.ToInt32(table.Rows[i]["Seater"].ToString());
                                buses.CompanyID = new Guid(table.Rows[i]["CompanyID"].ToString());
                                ListBuses.Add(buses);
                                buses = new Buses();
                            }

                        }


                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }

            return ListBuses;
        }
    }
}
