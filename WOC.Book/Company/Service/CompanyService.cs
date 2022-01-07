using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Company.BusinessEntity;
using Woc.Book.Base.Service;

namespace Woc.Book.Company.Service
{
    public class CompanyService : IRegistrationService
    {

        public String SaveData(IBusinessEntity iBusinessEntity)
        {

            try
            {
                Companies companies = new Companies();
                companies = (Companies)iBusinessEntity;
                String companyID = string.Empty;

                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookCompany", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                            command.Parameters.Add("@CompanyCode", SqlDbType.NVarChar);
                            command.Parameters["@CompanyCode"].Value = companies.CompanyCode;

                            command.Parameters.Add("@Company", SqlDbType.NVarChar);
                            command.Parameters["@Company"].Value = companies.Company;

                            command.Parameters.Add("@Address", SqlDbType.NVarChar);
                            command.Parameters["@Address"].Value = companies.Address;

                            command.Parameters.Add("@Telephone", SqlDbType.NVarChar);
                            command.Parameters["@Telephone"].Value = companies.Telephone;

                            command.Parameters.Add("@Fax", SqlDbType.NVarChar);
                            command.Parameters["@Fax"].Value = companies.Fax;

                            command.Parameters.Add("@Email", SqlDbType.NVarChar);
                            command.Parameters["@Email"].Value = companies.Fax;

                            command.Parameters.Add("@Website", SqlDbType.NVarChar);
                            command.Parameters["@Website"].Value = companies.Website;

                            command.Parameters.Add("@ROC", SqlDbType.NVarChar);
                            command.Parameters["@ROC"].Value = companies.ROC;

                            command.Parameters.Add("@GST", SqlDbType.NVarChar);
                            command.Parameters["@GST"].Value = companies.GST;

                            command.Parameters.Add("@ReflectToOperation", SqlDbType.NVarChar);
                            command.Parameters["@ReflectToOperation"].Value = companies.ReflectToOperation;

                            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CreatedBy"].Value = companies.CreatedBy;

                            command.Parameters.Add("@QueryTypeID", SqlDbType.Int);
                            command.Parameters["@QueryTypeID"].Value = 1;

                            command.Parameters.Add("@CompanyID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CompanyID"].Direction = ParameterDirection.Output;

                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            
                            companyID =  command.Parameters["@CompanyID"].Value.ToString();

                            transaction.Commit();

                            BatchSavePrefix(companies.PrefixList, new Guid(companyID));
                        }
                    }

                    connection.Close();
                }

                return companyID;
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
                Companies companies = new Companies();
                companies = (Companies)iBusinessEntity;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookCompany", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            command.Parameters.Add("@CompanyID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CompanyID"].Value = companies.CompanyID;

                            command.Parameters.Add("@CompanyCode", SqlDbType.NVarChar);
                            command.Parameters["@CompanyCode"].Value = companies.CompanyCode;

                            command.Parameters.Add("@Company", SqlDbType.NVarChar);
                            command.Parameters["@Company"].Value = companies.Company;

                            command.Parameters.Add("@Address", SqlDbType.NVarChar);
                            command.Parameters["@Address"].Value = companies.Address;

                            command.Parameters.Add("@Telephone", SqlDbType.NVarChar);
                            command.Parameters["@Telephone"].Value = companies.Telephone;

                            command.Parameters.Add("@Fax", SqlDbType.NVarChar);
                            command.Parameters["@Fax"].Value = companies.Fax;

                            command.Parameters.Add("@Email", SqlDbType.NVarChar);
                            command.Parameters["@Email"].Value = companies.Email;

                            command.Parameters.Add("@Website", SqlDbType.NVarChar);
                            command.Parameters["@Website"].Value = companies.Website;

                            command.Parameters.Add("@ROC", SqlDbType.NVarChar);
                            command.Parameters["@ROC"].Value = companies.ROC;

                            command.Parameters.Add("@Prefix", SqlDbType.NVarChar);
                            command.Parameters["@Prefix"].Value = companies.Prefix;

                            command.Parameters.Add("@GST", SqlDbType.NVarChar);
                            command.Parameters["@GST"].Value = companies.GST;

                            command.Parameters.Add("@ReflectToOperation", SqlDbType.NVarChar);
                            command.Parameters["@ReflectToOperation"].Value = companies.ReflectToOperation;

                            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@UpdatedBy"].Value = companies.UpdatedBy;

                            command.Parameters.Add("@QueryTypeID", SqlDbType.Int);
                            command.Parameters["@QueryTypeID"].Value = 2;

                            command.Transaction = transaction;
                            command.ExecuteNonQuery();

                            transaction.Commit();

                            BatchSavePrefix(companies.PrefixList, companies.CompanyID);
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
                Companies companies = new Companies();
                companies = (Companies)iBusinessEntity;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookCompany", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            command.Parameters.Add("@CompanyCode", SqlDbType.NVarChar);
                            command.Parameters["@CompanyCode"].Value = companies.CompanyCode;

                            command.Parameters.Add("@Company", SqlDbType.NVarChar);
                            command.Parameters["@Company"].Value = companies.Company;

                            command.Parameters.Add("@Address", SqlDbType.NVarChar);
                            command.Parameters["@Address"].Value = companies.Address;

                            command.Parameters.Add("@Telephone", SqlDbType.NVarChar);
                            command.Parameters["@Telephone"].Value = companies.Telephone;

                            command.Parameters.Add("@Fax", SqlDbType.NVarChar);
                            command.Parameters["@Fax"].Value = companies.Fax;

                            command.Parameters.Add("@Website", SqlDbType.NVarChar);
                            command.Parameters["@Website"].Value = companies.Website;

                            command.Parameters.Add("@Email", SqlDbType.NVarChar);
                            command.Parameters["@Email"].Value = companies.Email;

                            command.Parameters.Add("@ROC", SqlDbType.NVarChar);
                            command.Parameters["@ROC"].Value = companies.ROC;

                            command.Parameters.Add("@Prefix", SqlDbType.NVarChar);
                            command.Parameters["@Prefix"].Value = companies.Prefix;

                            command.Parameters.Add("@GST", SqlDbType.NVarChar);
                            command.Parameters["@GST"].Value = companies.GST;

                            command.Parameters.Add("@ReflectToOperation", SqlDbType.NVarChar);
                            command.Parameters["@ReflectToOperation"].Value = companies.ReflectToOperation;

                            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CreatedBy"].Value = companies.CreatedBy;

                            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@UpdatedBy"].Value = companies.CreatedBy;

                            command.Parameters.Add("@CompanyID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CompanyID"].Value = companies.CompanyID;

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
        
        public List<Companies> SearchData(String parameter)
        {
            Companies companies = new Companies();
            List<Companies> ListCompany = new List<Companies>();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Company WHERE " + parameter, conn))
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
                                companies.Company = table.Rows[i]["Company"].ToString();
                                companies.CompanyCode = table.Rows[i]["CompanyCode"].ToString();
                                companies.Address = table.Rows[i]["Address"].ToString();
                                companies.Telephone = table.Rows[i]["Telephone"].ToString();
                                companies.Fax = table.Rows[i]["Fax"].ToString();
                                companies.Email = table.Rows[i]["Email"].ToString();
                                companies.Website = table.Rows[i]["Website"].ToString();
                                companies.ROC = table.Rows[i]["ROC"].ToString();
                                companies.GST = table.Rows[i]["GST"].ToString();
                                companies.ReflectToOperation = table.Rows[i]["ReflectToOperation"].ToString();
                                ListCompany.Add(companies);
                                companies = new Companies();
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

        public Companies GetData(String parameter)
        {
            Companies companies = new Companies();
            SQLHelper sqlHelp = new SQLHelper();

            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Company where " + parameter, conn))
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
                                companies.CompanyID = new Guid(table.Rows[i]["CompanyID"].ToString());
                                companies.Company = table.Rows[i]["Company"].ToString();
                                companies.CompanyCode = table.Rows[i]["CompanyCode"].ToString();
                                companies.Address = table.Rows[i]["Address"].ToString();
                                companies.Telephone = table.Rows[i]["Telephone"].ToString();
                                companies.Fax = table.Rows[i]["Fax"].ToString();
                                companies.Email = table.Rows[i]["Email"].ToString();
                                companies.Website = table.Rows[i]["Website"].ToString();
                                companies.ROC = table.Rows[i]["ROC"].ToString();
                                companies.GST = table.Rows[i]["GST"].ToString();
                                companies.ReflectToOperation = table.Rows[i]["ReflectToOperation"].ToString();
                            }

                        }
                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }

            SqlDataReader reader = sqlHelp.GetReaderBySQL("Select PrefixCode, PrefixName FROM CompanyPrefix WHERE CompanyID = '" + companies.CompanyID + "'");
            List<Prefixes> prefixList = new List<Prefixes>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Prefixes prefix = new Prefixes();
                    prefix.PrefixCode = reader["PrefixCode"].ToString();
                    prefix.PrefixName = reader["PrefixName"].ToString();
                    prefixList.Add(prefix);
                }
                companies.PrefixList = prefixList;
            }

            return companies;
        }

        public List<Prefixes> GetPrefixes(Guid companyID)
        {
            Prefixes prefixes = new Prefixes();
            List<Prefixes> ListPrefix = new List<Prefixes>();

            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Prefix where companyID = '" + companyID.ToString() + "'", conn))
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
                                prefixes.CompanyPrefixID = new Guid(table.Rows[i]["CompanyPrefixID"].ToString());
                                prefixes.CompanyID = new Guid(table.Rows[i]["CompanyID"].ToString());
                                prefixes.PrefixName = table.Rows[i]["PrefixName"].ToString();
                                prefixes.PrefixCode = table.Rows[i]["PrefixCode"].ToString();
                                ListPrefix.Add(prefixes);
                                prefixes = new Prefixes();
                            }
                        }
                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }
            return ListPrefix;
        }

        private void BatchDeletePrefix(Guid companyID)
        {
            SQLHelper sqlHelp = new SQLHelper();
            try
            {
                sqlHelp.GetExecuteNonQueryBySQL("DELETE FROM CompanyPrefix WHERE CompanyID = '" + companyID.ToString() + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlHelp.Dispose();
            }
        }

        private void BatchSavePrefix(List<Prefixes> prefixList, Guid companyID)
        {
            BatchDeletePrefix(companyID);

            DataTable table = new DataTable();

            table.Columns.Add(new DataColumn("QueryTypeID", typeof(int)));
            table.Columns.Add(new DataColumn("CompanyPrefixID", typeof(Guid)));
            table.Columns.Add(new DataColumn("CompanyID", typeof(Guid)));
            table.Columns.Add(new DataColumn("PrefixCode", typeof(String)));
            table.Columns.Add(new DataColumn("PrefixName", typeof(String)));

            foreach (Prefixes prefix in prefixList)
            {
                DataRow row = table.NewRow();
                row["QueryTypeID"] = 4;
                row["CompanyPrefixID"] = Guid.NewGuid();
                row["CompanyID"] = companyID;
                row["PrefixCode"] = prefix.PrefixCode;
                row["PrefixName"] = prefix.PrefixName;
                table.Rows.Add(row);
            }

            using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
            {
                // Create a SqlDataAdapter based on a SELECT query.
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create a SqlCommand to execute the stored procedure.
                adapter.InsertCommand = new SqlCommand("usp_WocBookCompany", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;


                adapter.InsertCommand.Parameters.Add("@QueryTypeID", SqlDbType.Int, 4, "QueryTypeID");
                adapter.InsertCommand.Parameters.Add("@CompanyPrefixID", SqlDbType.UniqueIdentifier, 16, "CompanyPrefixID");
                adapter.InsertCommand.Parameters.Add("@CompanyID", SqlDbType.UniqueIdentifier, 16, "CompanyID");
                adapter.InsertCommand.Parameters.Add("@PrefixCode", SqlDbType.NVarChar, 2, "PrefixCode");
                adapter.InsertCommand.Parameters.Add("@PrefixName", SqlDbType.NVarChar, 50, "PrefixName");

                // Update the database.
                adapter.Update(table);
            }
        }

        public List<Companies> GetCompanyDropdownInfo()
        {
            Companies companies = new Companies();
            List<Companies> ListCompany = new List<Companies>();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_WocBookCompany", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@QueryTypeID", SqlDbType.Int);
                    cmd.Parameters["@QueryTypeID"].Value = 5;

                    cmd.Parameters.Add("@CompanyID", SqlDbType.UniqueIdentifier);
                    cmd.Parameters["@CompanyID"].Value = Guid.Empty;

                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        conn.Open();
                        ad.Fill(table);

                        if (table.DefaultView.Count > 0)
                        {

                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                companies.Company = table.Rows[i]["Company"].ToString();
                                companies.CompanyID = new Guid(table.Rows[i]["CompanyID"].ToString());
                                ListCompany.Add(companies);
                                companies = new Companies();
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
