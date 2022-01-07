using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;
using Woc.Book.Staff.BusinessEntity;
using Woc.Book.Staff.Constant;

namespace Woc.Book.Staff.Service
{
    internal class StaffService : IRegistrationService
    {

     public String SaveData(IBusinessEntity iBusinessEntity)
       {
       
         try
         {
            Staffs  staffs = new Staffs();
            staffs = (Staffs)iBusinessEntity;
             using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
             {
                 connection.Open();
                 using (SqlCommand command = new SqlCommand("usp_WocBookStaff", connection))
                 {
                     command.CommandType = CommandType.StoredProcedure;


                     using (SqlTransaction transaction = connection.BeginTransaction())
                     {

                         command.Parameters.Add("@LoginID", SqlDbType.NVarChar);
                         command.Parameters["@LoginID"].Value = staffs.LoginID;

                         command.Parameters.Add("@NRIC", SqlDbType.NVarChar);
                         command.Parameters["@NRIC"].Value = staffs.NRIC;

                         command.Parameters.Add("@Address1", SqlDbType.NVarChar);
                         command.Parameters["@Address1"].Value = staffs.Address1;

                         command.Parameters.Add("@Address2", SqlDbType.NVarChar);
                         command.Parameters["@Address2"].Value = staffs.Address2;

                         command.Parameters.Add("@Address3", SqlDbType.NVarChar);
                         command.Parameters["@Address3"].Value = staffs.Address3;

                         command.Parameters.Add("@Contact", SqlDbType.NVarChar);
                         command.Parameters["@Contact"].Value = staffs.Contact;

                         command.Parameters.Add("@DOB", SqlDbType.NVarChar);
                         command.Parameters["@DOB"].Value = staffs.DOB;

                         command.Parameters.Add("@CountryID", SqlDbType.UniqueIdentifier);
                         command.Parameters["@CountryID"].Value = staffs.CountryID;

                         command.Parameters.Add("@AccessLevelID", SqlDbType.UniqueIdentifier);
                         command.Parameters["@AccessLevelID"].Value = staffs.AccessLevelID;

                         command.Parameters.Add("@Password", SqlDbType.Image);
                         command.Parameters["@Password"].Value = staffs.Password;

                         command.Parameters.Add("@Salt", SqlDbType.Image);
                         command.Parameters["@Salt"].Value = staffs.Salt;

                         command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                         command.Parameters["@CreatedBy"].Value = staffs.CreatedBy;

                         command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                         command.Parameters["@UpdatedBy"].Value = staffs.CreatedBy;

                         command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                         command.Parameters["@TransactionMode"].Value = 1;

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
             Staffs staffs = new Staffs();
             staffs = (Staffs)iBusinessEntity;
             using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
             {
                 connection.Open();
                 using (SqlCommand command = new SqlCommand("usp_WocBookStaff", connection))
                 {
                     command.CommandType = CommandType.StoredProcedure;


                     using (SqlTransaction transaction = connection.BeginTransaction())
                     {

                         command.Parameters.Add("@LoginID", SqlDbType.NVarChar);
                         command.Parameters["@LoginID"].Value = staffs.LoginID;

                         command.Parameters.Add("@NRIC", SqlDbType.NVarChar);
                         command.Parameters["@NRIC"].Value = staffs.NRIC;

                         command.Parameters.Add("@Address1", SqlDbType.NVarChar);
                         command.Parameters["@Address1"].Value = staffs.Address1;

                         command.Parameters.Add("@Address2", SqlDbType.NVarChar);
                         command.Parameters["@Address2"].Value = staffs.Address2;

                         command.Parameters.Add("@Address3", SqlDbType.NVarChar);
                         command.Parameters["@Address3"].Value = staffs.Address3;

                         command.Parameters.Add("@Contact", SqlDbType.NVarChar);
                         command.Parameters["@Contact"].Value = staffs.Contact;

                         command.Parameters.Add("@DOB", SqlDbType.NVarChar);
                         command.Parameters["@DOB"].Value = staffs.DOB;

                         command.Parameters.Add("@CountryID", SqlDbType.UniqueIdentifier);
                         command.Parameters["@CountryID"].Value = staffs.CountryID;

                         command.Parameters.Add("@AccessLevelID", SqlDbType.UniqueIdentifier);
                         command.Parameters["@AccessLevelID"].Value = staffs.AccessLevelID;

                         command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                         command.Parameters["@CreatedBy"].Value = staffs.CreatedBy;

                         command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                         command.Parameters["@UpdatedBy"].Value = staffs.CreatedBy;

                         command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                         command.Parameters["@TransactionMode"].Value = 2;

                         if (staffs.TextBoxPassword.Trim() != String.Empty)
                         {
                             command.Parameters.Add("@Password", SqlDbType.Image);
                             command.Parameters["@Password"].Value = staffs.Password;

                             command.Parameters.Add("@Salt", SqlDbType.Image);
                             command.Parameters["@Salt"].Value = staffs.Salt;
                         }

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
             Staffs staffs = new Staffs();
             staffs = (Staffs)iBusinessEntity;
             using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
             {
                 connection.Open();
                 using (SqlCommand command = new SqlCommand("usp_WocBookStaff", connection))
                 {
                     command.CommandType = CommandType.StoredProcedure;


                     using (SqlTransaction transaction = connection.BeginTransaction())
                     {

                         command.Parameters.Add("@LoginID", SqlDbType.NVarChar);
                         command.Parameters["@LoginID"].Value = staffs.LoginID;

                         command.Parameters.Add("@NRIC", SqlDbType.NVarChar);
                         command.Parameters["@NRIC"].Value = staffs.NRIC;

                         command.Parameters.Add("@Address1", SqlDbType.NVarChar);
                         command.Parameters["@Address1"].Value = staffs.Address1;

                         command.Parameters.Add("@Address2", SqlDbType.NVarChar);
                         command.Parameters["@Address2"].Value = staffs.Address2;

                         command.Parameters.Add("@Address3", SqlDbType.NVarChar);
                         command.Parameters["@Address3"].Value = staffs.Address3;

                         command.Parameters.Add("@Contact", SqlDbType.NVarChar);
                         command.Parameters["@Contact"].Value = staffs.Contact;

                         command.Parameters.Add("@DOB", SqlDbType.NVarChar);
                         command.Parameters["@DOB"].Value = staffs.DOB;

                         command.Parameters.Add("@CountryID", SqlDbType.UniqueIdentifier);
                         command.Parameters["@CountryID"].Value = staffs.CountryID;

                         command.Parameters.Add("@AccessLevelID", SqlDbType.UniqueIdentifier);
                         command.Parameters["@AccessLevelID"].Value = staffs.AccessLevelID;

                         command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                         command.Parameters["@CreatedBy"].Value = staffs.CreatedBy;

                         command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                         command.Parameters["@UpdatedBy"].Value = staffs.CreatedBy;

                         command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                         command.Parameters["@TransactionMode"].Value = 3;


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

     public String ResignData(IBusinessEntity iBusinessEntity)
     {

         try
         {
             Staffs staffs = new Staffs();
             staffs = (Staffs)iBusinessEntity;
             using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
             {
                 connection.Open();
                 using (SqlCommand command = new SqlCommand("usp_WocBookStaff", connection))
                 {
                     command.CommandType = CommandType.StoredProcedure;


                     using (SqlTransaction transaction = connection.BeginTransaction())
                     {

                         command.Parameters.Add("@LoginID", SqlDbType.NVarChar);
                         command.Parameters["@LoginID"].Value = staffs.LoginID;

                         command.Parameters.Add("@NRIC", SqlDbType.NVarChar);
                         command.Parameters["@NRIC"].Value = staffs.NRIC;

                         command.Parameters.Add("@Address1", SqlDbType.NVarChar);
                         command.Parameters["@Address1"].Value = staffs.Address1;

                         command.Parameters.Add("@Address2", SqlDbType.NVarChar);
                         command.Parameters["@Address2"].Value = staffs.Address2;

                         command.Parameters.Add("@Address3", SqlDbType.NVarChar);
                         command.Parameters["@Address3"].Value = staffs.Address3;

                         command.Parameters.Add("@Contact", SqlDbType.NVarChar);
                         command.Parameters["@Contact"].Value = staffs.Contact;

                         command.Parameters.Add("@DOB", SqlDbType.NVarChar);
                         command.Parameters["@DOB"].Value = staffs.DOB;

                         command.Parameters.Add("@CountryID", SqlDbType.UniqueIdentifier);
                         command.Parameters["@CountryID"].Value = staffs.CountryID;

                         command.Parameters.Add("@AccessLevelID", SqlDbType.UniqueIdentifier);
                         command.Parameters["@AccessLevelID"].Value = staffs.AccessLevelID;

                         command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                         command.Parameters["@CreatedBy"].Value = staffs.CreatedBy;

                         command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                         command.Parameters["@UpdatedBy"].Value = staffs.CreatedBy;

                         command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                         command.Parameters["@TransactionMode"].Value = 4;


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
     public List<Staffs> SearchData(String parameter)
     {
         Staffs staffs = new Staffs();   
         List<Staffs> ListStaff = new List<Staffs>();
         using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
         {
             using (SqlCommand cmd = new SqlCommand("Select * from Users where " +  parameter , conn))
             {
                 cmd.CommandType = CommandType.Text;
                 using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                 {
                     DataTable table = new DataTable();
                     conn.Open();
                     ad.Fill(table);

                     if (table.DefaultView.Count > 0)
                     {
 
                           for (int i=0; i <table.Rows.Count; i++)
                           {
                               staffs.LoginID = table.Rows[i]["LoginID"].ToString();
                               staffs.NRIC = table.Rows[i]["NRIC"].ToString();
                               staffs.Address1 = table.Rows[i]["Address1"].ToString();
                               staffs.DOB = table.Rows[i]["DOB"].ToString();
                               staffs.Contact = table.Rows[i]["Contact"].ToString();
                               staffs.UserID = new Guid(table.Rows[i]["UserID"].ToString());
                               staffs.AccessLevelID = new Guid(table.Rows[i]["AccessLevelID"].ToString());
                               staffs.CountryID = new Guid(table.Rows[i]["CountryID"].ToString());
                            ListStaff.Add(staffs);
                            staffs = new Staffs();
                           }
 
                      }
 

                     conn.Close();
                     ad.Dispose();
                     conn.Dispose();

                 }
             }
         }
      
         return ListStaff;
     }

     public Staffs GetData(String parameter)
     {
         Staffs staffs = new Staffs();

         using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
         {
             using (SqlCommand cmd = new SqlCommand("Select * from Users where " + parameter, conn))
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
                             staffs.LoginID = table.Rows[i]["LoginID"].ToString();
                             staffs.NRIC = table.Rows[i]["NRIC"].ToString();
                             staffs.Address1 = table.Rows[i]["Address1"].ToString();
                             staffs.Address2 = table.Rows[i]["Address2"].ToString();
                             staffs.Address3 = table.Rows[i]["Address3"].ToString();
                             staffs.DOB = table.Rows[i]["DOB"].ToString();
                             staffs.Contact = table.Rows[i]["Contact"].ToString();
                             staffs.UserID = new Guid(table.Rows[i]["UserID"].ToString());
                             staffs.AccessLevelID = new Guid(table.Rows[i]["AccessLevelID"].ToString());
                             staffs.CountryID = new Guid(table.Rows[i]["CountryID"].ToString());

                         }

                     }
                     conn.Close();
                     ad.Dispose();
                     conn.Dispose();

                 }
             }
         }

         return staffs;
     }
    }
}
