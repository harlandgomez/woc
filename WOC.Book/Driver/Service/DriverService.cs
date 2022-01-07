using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;
using Woc.Book.Driver.BusinessEntity;
using Woc.Book.Driver.Constant;
namespace Woc.Book.Driver.Service
{
  internal  class DriverService
    {

      public String SaveData(IBusinessEntity iBusinessEntity)
      {

          try
          {
              Drivers drivers = new Drivers();
              drivers = (Drivers)iBusinessEntity;
              using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
              {
                  connection.Open();
                  using (SqlCommand command = new SqlCommand("usp_WocBookDriver", connection))
                  {
                      command.CommandType = CommandType.StoredProcedure;


                      using (SqlTransaction transaction = connection.BeginTransaction())
                      {


                          command.Parameters.Add("@DriverCode", SqlDbType.NVarChar);
                          command.Parameters["@DriverCode"].Value = drivers.DriverCode;

                          command.Parameters.Add("@DriverName", SqlDbType.NVarChar);
                          command.Parameters["@DriverName"].Value = drivers.DriverName;

                          command.Parameters.Add("@FIN", SqlDbType.NVarChar);
                          command.Parameters["@FIN"].Value = drivers.FIN;

                          command.Parameters.Add("@Address1", SqlDbType.NVarChar);
                          command.Parameters["@Address1"].Value = drivers.Address1;

                          command.Parameters.Add("@Address2", SqlDbType.NVarChar);
                          command.Parameters["@Address2"].Value = drivers.Address2;

                          command.Parameters.Add("@Address3", SqlDbType.NVarChar);
                          command.Parameters["@Address3"].Value = drivers.Address3;

                          command.Parameters.Add("@Contact", SqlDbType.NVarChar);
                          command.Parameters["@Contact"].Value = drivers.Contact;

                          if (drivers.DateJoin != DateTime.MinValue)
                          {
                              command.Parameters.Add("@DateJoin", SqlDbType.DateTime);
                              command.Parameters["@DateJoin"].Value = drivers.DateJoin;
                          }

                          command.Parameters.Add("@DOB", SqlDbType.NVarChar);
                          command.Parameters["@DOB"].Value = drivers.DOB;

                          command.Parameters.Add("@CountryID", SqlDbType.UniqueIdentifier);
                          command.Parameters["@CountryID"].Value = drivers.CountryID;

                          command.Parameters.Add("@BusNo", SqlDbType.NVarChar);
                          command.Parameters["@BusNo"].Value = drivers.BusNo;

                          command.Parameters.Add("@Passes1", SqlDbType.NVarChar);
                          command.Parameters["@Passes1"].Value = drivers.Passes1;

                          command.Parameters.Add("@Passes2", SqlDbType.NVarChar);
                          command.Parameters["@Passes2"].Value = drivers.Passes2;

                          command.Parameters.Add("@Passes3", SqlDbType.NVarChar);
                          command.Parameters["@Passes3"].Value = drivers.Passes3;

                          //20
                          if (drivers.Expiry1 != DateTime.MinValue)
                          {
                              command.Parameters.Add("@Expiry1", SqlDbType.DateTime);
                              command.Parameters["@Expiry1"].Value = drivers.Expiry1;
                          }
                          //21
                          if (drivers.Expiry2 != DateTime.MinValue)
                          {
                              command.Parameters.Add("@Expiry2", SqlDbType.DateTime);
                              command.Parameters["@Expiry2"].Value = drivers.Expiry2;
                          }
                          //22
                          if (drivers.Expiry3 != DateTime.MinValue)
                          {
                              command.Parameters.Add("@Expiry3", SqlDbType.DateTime);
                              command.Parameters["@Expiry3"].Value = drivers.Expiry3;
                          }
                          command.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                          command.Parameters["@CreatedDate"].Value = drivers.CreatedDate;

                          command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                          command.Parameters["@CreatedBy"].Value = drivers.CreatedBy;

                          command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime);
                          command.Parameters["@UpdatedDate"].Value = drivers.UpdatedDate;

                          command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                          command.Parameters["@UpdatedBy"].Value = drivers.CreatedBy;

                          command.Parameters.Add("@Delete", SqlDbType.NVarChar);
                          command.Parameters["@Delete"].Value = "N";

                          command.Parameters.Add("@Resigned", SqlDbType.Bit);
                          command.Parameters["@Resigned"].Value =drivers.Resigned;

                            command.Parameters.Add("@ResignedDate", SqlDbType.DateTime);
                          command.Parameters["@ResignedDate"].Value =drivers.ResignedDate;

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
              Drivers drivers = new Drivers();
              drivers = (Drivers)iBusinessEntity;
              using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
              {
                  connection.Open();
                  using (SqlCommand command = new SqlCommand("usp_WocBookDriver", connection))
                  {
                      command.CommandType = CommandType.StoredProcedure;


                      using (SqlTransaction transaction = connection.BeginTransaction())
                      {


                          command.Parameters.Add("@DriverCode", SqlDbType.NVarChar);
                          command.Parameters["@DriverCode"].Value = drivers.DriverCode;

                          command.Parameters.Add("@DriverName", SqlDbType.NVarChar);
                          command.Parameters["@DriverName"].Value = drivers.DriverName;

                          command.Parameters.Add("@FIN", SqlDbType.NVarChar);
                          command.Parameters["@FIN"].Value = drivers.FIN;

                          command.Parameters.Add("@Address1", SqlDbType.NVarChar);
                          command.Parameters["@Address1"].Value = drivers.Address1;

                          command.Parameters.Add("@Address2", SqlDbType.NVarChar);
                          command.Parameters["@Address2"].Value = drivers.Address2;

                          command.Parameters.Add("@Address3", SqlDbType.NVarChar);
                          command.Parameters["@Address3"].Value = drivers.Address3;

                          command.Parameters.Add("@Contact", SqlDbType.NVarChar);
                          command.Parameters["@Contact"].Value = drivers.Contact;

                          if (drivers.DateJoin != DateTime.MinValue)
                          {
                              command.Parameters.Add("@DateJoin", SqlDbType.DateTime);
                              command.Parameters["@DateJoin"].Value = drivers.DateJoin;
                          }

                          command.Parameters.Add("@DOB", SqlDbType.NVarChar);
                          command.Parameters["@DOB"].Value = drivers.DOB;

                          command.Parameters.Add("@CountryID", SqlDbType.UniqueIdentifier);
                          command.Parameters["@CountryID"].Value = drivers.CountryID;

                          command.Parameters.Add("@BusNo", SqlDbType.NVarChar);
                          command.Parameters["@BusNo"].Value = drivers.BusNo;

                          command.Parameters.Add("@Passes1", SqlDbType.NVarChar);
                          command.Parameters["@Passes1"].Value = drivers.Passes1;

                          command.Parameters.Add("@Passes2", SqlDbType.NVarChar);
                          command.Parameters["@Passes2"].Value = drivers.Passes2;

                          command.Parameters.Add("@Passes3", SqlDbType.NVarChar);
                          command.Parameters["@Passes3"].Value = drivers.Passes3;

                          //20
                          if (drivers.Expiry1 != DateTime.MinValue)
                          {
                              command.Parameters.Add("@Expiry1", SqlDbType.DateTime);
                              command.Parameters["@Expiry1"].Value = drivers.Expiry1;
                          }
                          //21
                          if (drivers.Expiry2 != DateTime.MinValue)
                          {
                              command.Parameters.Add("@Expiry2", SqlDbType.DateTime);
                              command.Parameters["@Expiry2"].Value = drivers.Expiry2;
                          }
                          //22
                          if (drivers.Expiry3 != DateTime.MinValue)
                          {
                              command.Parameters.Add("@Expiry3", SqlDbType.DateTime);
                              command.Parameters["@Expiry3"].Value = drivers.Expiry3;
                          }

                          command.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                          command.Parameters["@CreatedDate"].Value = drivers.CreatedDate;

                          command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                          command.Parameters["@CreatedBy"].Value = drivers.CreatedBy;

                          command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime);
                          command.Parameters["@UpdatedDate"].Value = drivers.UpdatedDate;

                          command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                          command.Parameters["@UpdatedBy"].Value = drivers.CreatedBy;

                          command.Parameters.Add("@Delete", SqlDbType.NVarChar);
                          command.Parameters["@Delete"].Value = "N";

                          command.Parameters.Add("@Resigned", SqlDbType.Bit);
                          command.Parameters["@Resigned"].Value = drivers.Resigned;

                          //20
                          if (drivers.ResignedDate != DateTime.MinValue)
                          {
                              command.Parameters.Add("@ResignedDate", SqlDbType.DateTime);
                              command.Parameters["@ResignedDate"].Value = drivers.ResignedDate;
                          }
                        

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

      public List<Drivers> SearchData(String parameter)
      {
          Drivers drivers = new Drivers();
          List<Drivers> ListDriver= new List<Drivers>();
          using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
          {
              using (SqlCommand cmd = new SqlCommand("Select * from  Driver where " + parameter, conn))
             // using (SqlCommand cmd = new SqlCommand("Select * from  Driver", conn))
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
                              drivers.DriverID  = new Guid(table.Rows[i]["DriverID"].ToString());
                              drivers.DriverCode = table.Rows[i]["DriverCode"].ToString();
                              drivers.DriverName = table.Rows[i]["DriverName"].ToString();
                              drivers.FIN = table.Rows[i]["FIN"].ToString();
                              drivers.Address1 = table.Rows[i]["Address1"].ToString();
                              drivers.Contact = table.Rows[i]["Contact"].ToString();
                              drivers.DOB = table.Rows[i]["DOB"].ToString();
                              ListDriver.Add(drivers);
                              drivers = new Drivers();
                          }

                      }


                      conn.Close();
                      ad.Dispose();
                      conn.Dispose();

                  }
              }
          }

          return ListDriver;
      }

      public Drivers GetData(String parameter)
      {
          Drivers drivers = new Drivers();

          using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
          {
              using (SqlCommand cmd = new SqlCommand("Select * from Driver where " + parameter, conn))
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
                              drivers.DriverID =  new Guid(table.Rows[i]["DriverID"].ToString());
                              drivers.DriverName = table.Rows[i]["DriverName"].ToString();
                              drivers.Address1 = table.Rows[i]["Address1"].ToString();
                              drivers.Address2 = table.Rows[i]["Address2"].ToString();
                              drivers.Address3 = table.Rows[i]["Address3"].ToString();
                              drivers.Contact = table.Rows[i]["Contact"].ToString();
                              drivers.DateJoin = Convert.ToDateTime(table.Rows[i]["DateJoin"].ToString());
                              drivers.CountryID = new Guid(table.Rows[i]["CountryID"].ToString());
                              drivers.BusNo = table.Rows[i]["BusNo"].ToString();
                              drivers.CreatedBy = new Guid(table.Rows[i]["CreatedBy"].ToString());
                              drivers.CreatedDate = Convert.ToDateTime(table.Rows[i]["CreatedDate"].ToString());
                              if (!String.IsNullOrEmpty(table.Rows[i]["UpdatedDate"].ToString()))
                              {
                              drivers.UpdatedDate = Convert.ToDateTime(table.Rows[i]["UpdatedDate"].ToString());
                              
                              }
                              if (!String.IsNullOrEmpty(table.Rows[i]["UpdatedBy"].ToString()))
                              {
                                  drivers.UpdatedBy = new Guid(table.Rows[i]["UpdatedBy"].ToString());
                              }
                             
                              drivers.FIN = table.Rows[i]["FIN"].ToString();
                              drivers.DOB = table.Rows[i]["DOB"].ToString();
                              drivers.DriverCode = table.Rows[i]["DriverCode"].ToString();
                              drivers.Delete = table.Rows[i]["Delete"].ToString();
                              drivers.Passes1 = table.Rows[i]["Passes1"].ToString();
                              drivers.Passes2 = table.Rows[i]["Passes2"].ToString();
                              drivers.Passes3 = table.Rows[i]["Passes3"].ToString();

                              if (!String.IsNullOrEmpty(table.Rows[i]["Expiry1"].ToString()))
                              {
                                  drivers.Expiry1 = Convert.ToDateTime(table.Rows[i]["Expiry1"].ToString());
                              }
                              if (!String.IsNullOrEmpty(table.Rows[i]["Expiry2"].ToString()))
                              {
                                  drivers.Expiry2 = Convert.ToDateTime(table.Rows[i]["Expiry2"].ToString());
                              }
                              if (!String.IsNullOrEmpty(table.Rows[i]["Expiry3"].ToString()))
                              {
                                  drivers.Expiry3 = Convert.ToDateTime(table.Rows[i]["Expiry3"].ToString());
                              }
                              if (!String.IsNullOrEmpty(table.Rows[i]["ResignedDate"].ToString()))
                              {
                                  drivers.ResignedDate = Convert.ToDateTime(table.Rows[i]["ResignedDate"].ToString());
                              }
                          }

                      }
                      conn.Close();
                      ad.Dispose();
                      conn.Dispose();

                  }
              }
          }

          return drivers;
      }

      public String DeleteData(IBusinessEntity iBusinessEntity)
      {
          try
          {
              Drivers drivers = new Drivers();
              drivers = (Drivers)iBusinessEntity;
              using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
              {
                  connection.Open();
                  using (SqlCommand command = new SqlCommand("usp_WocBookDriver", connection))
                  {
                      command.CommandType = CommandType.StoredProcedure;


                      using (SqlTransaction transaction = connection.BeginTransaction())
                      {


                          command.Parameters.Add("@DriverCode", SqlDbType.NVarChar);
                          command.Parameters["@DriverCode"].Value = drivers.DriverCode;

                          command.Parameters.Add("@DriverName", SqlDbType.NVarChar);
                          command.Parameters["@DriverName"].Value = drivers.DriverName;

                          command.Parameters.Add("@FIN", SqlDbType.NVarChar);
                          command.Parameters["@FIN"].Value = drivers.FIN;

                          command.Parameters.Add("@Address1", SqlDbType.NVarChar);
                          command.Parameters["@Address1"].Value = drivers.Address1;

                          command.Parameters.Add("@Address2", SqlDbType.NVarChar);
                          command.Parameters["@Address2"].Value = drivers.Address2;

                          command.Parameters.Add("@Address3", SqlDbType.NVarChar);
                          command.Parameters["@Address3"].Value = drivers.Address3;

                          command.Parameters.Add("@Contact", SqlDbType.NVarChar);
                          command.Parameters["@Contact"].Value = drivers.Contact;


                          //20
                          if (drivers.DateJoin != DateTime.MinValue)
                          {
                              command.Parameters.Add("@DateJoin", SqlDbType.DateTime);
                              command.Parameters["@DateJoin"].Value = drivers.DateJoin;
                          }
                         

                          command.Parameters.Add("@DOB", SqlDbType.NVarChar);
                          command.Parameters["@DOB"].Value = drivers.DOB;

                          command.Parameters.Add("@CountryID", SqlDbType.UniqueIdentifier);
                          command.Parameters["@CountryID"].Value = drivers.CountryID;

                          command.Parameters.Add("@BusNo", SqlDbType.NVarChar);
                          command.Parameters["@BusNo"].Value = drivers.BusNo;

                          command.Parameters.Add("@Passes1", SqlDbType.NVarChar);
                          command.Parameters["@Passes1"].Value = drivers.Passes1;

                          command.Parameters.Add("@Passes2", SqlDbType.NVarChar);
                          command.Parameters["@Passes2"].Value = drivers.Passes2;

                          command.Parameters.Add("@Passes3", SqlDbType.NVarChar);
                          command.Parameters["@Passes3"].Value = drivers.Passes3;

                          //20
                          if (drivers.Expiry1 != DateTime.MinValue)
                          {
                              command.Parameters.Add("@Expiry1", SqlDbType.DateTime);
                              command.Parameters["@Expiry1"].Value = drivers.Expiry1;
                          }
                          //21
                          if (drivers.Expiry2 != DateTime.MinValue)
                          {
                              command.Parameters.Add("@Expiry2", SqlDbType.DateTime);
                              command.Parameters["@Expiry2"].Value = drivers.Expiry2;
                          }
                          //22
                          if (drivers.Expiry3 != DateTime.MinValue)
                          {
                              command.Parameters.Add("@Expiry3", SqlDbType.DateTime);
                              command.Parameters["@Expiry3"].Value = drivers.Expiry3;
                          }
                          command.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                          command.Parameters["@CreatedDate"].Value = drivers.CreatedDate;

                          command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                          command.Parameters["@CreatedBy"].Value = drivers.CreatedBy;

                          command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime);
                          command.Parameters["@UpdatedDate"].Value = drivers.UpdatedDate;

                          command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                          command.Parameters["@UpdatedBy"].Value = drivers.CreatedBy;

                          command.Parameters.Add("@Delete", SqlDbType.NVarChar);
                          command.Parameters["@Delete"].Value = "Y";

                          command.Parameters.Add("@Resigned", SqlDbType.Bit);
                          command.Parameters["@Resigned"].Value = drivers.Resigned;


                          //20
                          if (drivers.ResignedDate != DateTime.MinValue)
                          {
                              command.Parameters.Add("@ResignedDate", SqlDbType.DateTime);
                              command.Parameters["@ResignedDate"].Value = drivers.ResignedDate;
                          }

                          command.Parameters.Add("@QueryTypeID", SqlDbType.Int);
                          command.Parameters["@QueryTypeID"].Value = 3;

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
    }
}
