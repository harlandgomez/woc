using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

//Common
using Woc.Book.SubCon.BusinessEntity;
using Woc.Book.SubCon.Service;

//SubCon
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;

namespace Woc.Book.SubCon.Service
{
   internal class SubConService:IRegistrationService
    {
       public String SaveData(IBusinessEntity iBusinessEntity)
       {
           try
           {
               Subcons subcons = new Subcons();
               subcons = (Subcons)iBusinessEntity;
               using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
               {
                   connection.Open();
                   using (SqlCommand command = new SqlCommand("usp_WocBookSubCon", connection))
                   {
                       command.CommandType = CommandType.StoredProcedure;


                       using (SqlTransaction transaction = connection.BeginTransaction())
                       {
                           //1
                           command.Parameters.Add("@SubConCode", SqlDbType.NVarChar);
                           command.Parameters["@SubConCode"].Value = subcons.SubconCode;
                           //2
                           command.Parameters.Add("@Company", SqlDbType.NVarChar);
                           command.Parameters["@Company"].Value = subcons.Company;
                           //3
                           command.Parameters.Add("@Initial", SqlDbType.NVarChar);
                           command.Parameters["@Initial"].Value = subcons.Initial;
                           //4
                           command.Parameters.Add("@Person", SqlDbType.NVarChar);
                           command.Parameters["@Person"].Value = subcons.Person;
                           //5
                           command.Parameters.Add("@Fax", SqlDbType.NVarChar);
                           command.Parameters["@Fax"].Value = subcons.Fax;
                           //6
                           command.Parameters.Add("@Telephone", SqlDbType.NVarChar);
                           command.Parameters["@Telephone"].Value = subcons.Telephone;
                           //7
                           command.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                           command.Parameters["@Mobile"].Value = subcons.Mobile;
                           //8
                           command.Parameters.Add("@Address", SqlDbType.NVarChar);
                           command.Parameters["@Address"].Value = subcons.Address;
                           //9
                           command.Parameters.Add("@Remarks", SqlDbType.NVarChar);
                           command.Parameters["@Remarks"].Value = subcons.Remarks;
                           //10
                           command.Parameters.Add("@Passes1", SqlDbType.NVarChar);
                           command.Parameters["@Passes1"].Value = subcons.Passes1;
                           //11
                           command.Parameters.Add("@Passes2", SqlDbType.NVarChar);
                           command.Parameters["@Passes2"].Value = subcons.Passes2;
                           //20
                           if (subcons.Expiry1 != DateTime.MinValue)
                           {
                               command.Parameters.Add("@Expiry1", SqlDbType.DateTime);
                               command.Parameters["@Expiry1"].Value = subcons.Expiry1;
                           }
                           //21
                           if (subcons.Expiry2 != DateTime.MinValue)
                           {
                               command.Parameters.Add("@Expiry2", SqlDbType.DateTime);
                               command.Parameters["@Expiry2"].Value = subcons.Expiry2;
                           }
                           //14
                           command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                           command.Parameters["@CreatedBy"].Value = subcons.CreatedBy;
                           //15
                           command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                           command.Parameters["@UpdatedBy"].Value = subcons.UpdatedBy;
                           //16
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
                Subcons subcons = new Subcons();
                subcons = (Subcons)iBusinessEntity;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookSubCon", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            //1
                            command.Parameters.Add("@SubConCode", SqlDbType.NVarChar);
                            command.Parameters["@SubConCode"].Value = subcons.SubconCode;
                            //2
                            command.Parameters.Add("@Company", SqlDbType.NVarChar);
                            command.Parameters["@Company"].Value = subcons.Company;
                            //3
                            command.Parameters.Add("@Initial", SqlDbType.NVarChar);
                            command.Parameters["@Initial"].Value = subcons.Initial;
                            //4
                            command.Parameters.Add("@Person", SqlDbType.NVarChar);
                            command.Parameters["@Person"].Value = subcons.Person;
                            //5
                            command.Parameters.Add("@Fax", SqlDbType.NVarChar);
                            command.Parameters["@Fax"].Value = subcons.Fax;
                            //6
                            command.Parameters.Add("@Telephone", SqlDbType.NVarChar);
                            command.Parameters["@Telephone"].Value = subcons.Telephone;
                            //7
                            command.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                            command.Parameters["@Mobile"].Value = subcons.Mobile;
                            //8
                            command.Parameters.Add("@Address", SqlDbType.NVarChar);
                            command.Parameters["@Address"].Value = subcons.Address;
                            //9
                            command.Parameters.Add("@Remarks", SqlDbType.NVarChar);
                            command.Parameters["@Remarks"].Value = subcons.Remarks;
                            //10
                            command.Parameters.Add("@Passes1", SqlDbType.NVarChar);
                            command.Parameters["@Passes1"].Value = subcons.Passes1;
                            //11
                            command.Parameters.Add("@Passes2", SqlDbType.NVarChar);
                            command.Parameters["@Passes2"].Value = subcons.Passes2;
                            //12
                            if (subcons.Expiry1 != DateTime.MinValue)
                            {
                                command.Parameters.Add("@Expiry1", SqlDbType.DateTime);
                                command.Parameters["@Expiry1"].Value = subcons.Expiry1;
                            }
                            //21
                            if (subcons.Expiry2 != DateTime.MinValue)
                            {
                                command.Parameters.Add("@Expiry2", SqlDbType.DateTime);
                                command.Parameters["@Expiry2"].Value = subcons.Expiry2;
                            }
                            //14
                            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CreatedBy"].Value = subcons.CreatedBy;
                            //15
                            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@UpdatedBy"].Value = subcons.UpdatedBy;
                            //16

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
                Subcons subcons = new Subcons();
                subcons = (Subcons)iBusinessEntity;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookSubCon", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            //1
                            command.Parameters.Add("@SubConCode", SqlDbType.NVarChar);
                            command.Parameters["@SubConCode"].Value = subcons.SubconCode;
                            //2
                            command.Parameters.Add("@Company", SqlDbType.NVarChar);
                            command.Parameters["@Company"].Value = subcons.Company;
                            //3
                            command.Parameters.Add("@Initial", SqlDbType.NVarChar);
                            command.Parameters["@Initial"].Value = subcons.Initial;
                            //4
                            command.Parameters.Add("@Person", SqlDbType.NVarChar);
                            command.Parameters["@Person"].Value = subcons.Person;
                            //5
                            command.Parameters.Add("@Fax", SqlDbType.NVarChar);
                            command.Parameters["@Fax"].Value = subcons.Fax;
                            //6
                            command.Parameters.Add("@Telephone", SqlDbType.NVarChar);
                            command.Parameters["@Telephone"].Value = subcons.Telephone;
                            //7
                            command.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                            command.Parameters["@Mobile"].Value = subcons.Mobile;
                            //8
                            command.Parameters.Add("@Address", SqlDbType.NVarChar);
                            command.Parameters["@Address"].Value = subcons.Address;
                            //9
                            command.Parameters.Add("@Remarks", SqlDbType.NVarChar);
                            command.Parameters["@Remarks"].Value = subcons.Remarks;
                            //10
                            command.Parameters.Add("@Passes1", SqlDbType.NVarChar);
                            command.Parameters["@Passes1"].Value = subcons.Passes1;
                            //11
                            command.Parameters.Add("@Passes2", SqlDbType.NVarChar);
                            command.Parameters["@Passes2"].Value = subcons.Passes2;
                            //12
                            if (subcons.Expiry1 != DateTime.MinValue)
                            {
                                command.Parameters.Add("@Expiry1", SqlDbType.DateTime);
                                command.Parameters["@Expiry1"].Value = subcons.Expiry1;
                            }
                            //21
                            if (subcons.Expiry2 != DateTime.MinValue)
                            {
                                command.Parameters.Add("@Expiry2", SqlDbType.DateTime);
                                command.Parameters["@Expiry2"].Value = subcons.Expiry2;
                            }
                            //14
                            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CreatedBy"].Value = subcons.CreatedBy;
                            //15
                            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@UpdatedBy"].Value = subcons.UpdatedBy;
                            //16
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

        public List<Subcons> SearchData(String parameter)
        {
            Subcons subcons = new Subcons();
            List<Subcons> ListSubCons = new List<Subcons>();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Subcon WHERE " + parameter, conn))
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
                                subcons.SubconCode = table.Rows[i]["SubconCode"].ToString();
                                subcons.Company = table.Rows[i]["Company"].ToString();
                                subcons.Initial = table.Rows[i]["Initial"].ToString();
                                subcons.Person = table.Rows[i]["Person"].ToString();
                                subcons.Mobile = table.Rows[i]["Mobile"].ToString();
                                subcons.Fax = table.Rows[i]["Fax"].ToString();
                                subcons.Address = table.Rows[i]["Address"].ToString();
                                ListSubCons.Add(subcons);
                                subcons = new Subcons();
                            }

                        }


                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }

            return ListSubCons;
        }

        public Subcons GetData(String parameter)
        {
            Subcons subCons = new Subcons();

            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Subcon where " + parameter, conn))
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
                                subCons.SubconCode = table.Rows[i]["SubconCode"].ToString();
                                subCons.SubconID = new Guid(table.Rows[i]["SubconID"].ToString());
                                subCons.Company = table.Rows[i]["Company"].ToString();
                                subCons.Initial = table.Rows[i]["Initial"].ToString();
                                subCons.Person = table.Rows[i]["Person"].ToString();
                                subCons.Telephone = table.Rows[i]["Telephone"].ToString();
                                subCons.Mobile = table.Rows[i]["Mobile"].ToString();
                                subCons.Fax = table.Rows[i]["Fax"].ToString();
                                subCons.Address = table.Rows[i]["Address"].ToString();
                                subCons.Remarks = table.Rows[i]["Remarks"].ToString();
                                subCons.CreatedBy = new Guid(table.Rows[i]["CreatedBy"].ToString());
                                subCons.CreatedDate = Convert.ToDateTime(table.Rows[i]["CreatedDate"].ToString());
                                subCons.Passes1 = table.Rows[i]["Passes1"].ToString();
                                subCons.Passes2 = table.Rows[i]["Passes2"].ToString();
                                subCons.CreatedDate = Convert.ToDateTime(table.Rows[i]["CreatedDate"].ToString());
                                if (!String.IsNullOrEmpty(table.Rows[i]["Expiry1"].ToString()))
                                {
                                    subCons.Expiry1 = Convert.ToDateTime(table.Rows[i]["Expiry1"].ToString());
                                }
                                if (!String.IsNullOrEmpty(table.Rows[i]["Expiry2"].ToString()))
                                {
                                    subCons.Expiry2 = Convert.ToDateTime(table.Rows[i]["Expiry2"].ToString());
                                } 
                                subCons.Delete = table.Rows[i]["Delete"].ToString();
                            }

                        }
                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }

            return subCons;
        }

        public List<Subcons> GetDropdownInfo()
        {
            Subcons subCons = new Subcons();
            List<Subcons> ListCompany = new List<Subcons>();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_WocBookSubcon", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@QueryTypeID", SqlDbType.Int);
                    cmd.Parameters["@QueryTypeID"].Value = 4;

                    cmd.Parameters.Add("@SubconID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@SubconID"].Value = Guid.Empty;

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        conn.Open();
                        ad.Fill(table);

                        if (table.DefaultView.Count > 0)
                        {

                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                subCons.Company = table.Rows[i]["Company"].ToString();
                                subCons.SubconID = new Guid(table.Rows[i]["SubconID"].ToString());
                                ListCompany.Add(subCons);
                                subCons = new Subcons();
                            }

                        }
                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();
                    }
                }
            }

            return ListCompany;
        }
    }
}
