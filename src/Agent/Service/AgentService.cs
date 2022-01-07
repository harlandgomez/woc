using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;
using Woc.Book.Agent.BusinessEntity;
using Woc.Book.Agent.Constant;


namespace Woc.Book.Agent.Service
{
    public class AgentService
    {
        public String SaveData(IBusinessEntity iBusinessEntity)
        {

            try
            {
                Agents agents = new Agents();
                agents = (Agents)iBusinessEntity;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookAgent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                               command.Parameters.Add("@AgentCode", SqlDbType.NVarChar);
                               command.Parameters["@AgentCode"].Value = agents.AgentCode;

                               command.Parameters.Add("@Agent", SqlDbType.NVarChar);
                               command.Parameters["@Agent"].Value = agents.Agent;

                               command.Parameters.Add("@Prefix", SqlDbType.NVarChar);
                               command.Parameters["@Prefix"].Value = agents.Prefix;
                               
                               command.Parameters.Add("@Address", SqlDbType.NVarChar);
                               command.Parameters["@Address"].Value = agents.Address;

                               command.Parameters.Add("@Email", SqlDbType.NVarChar);
                               command.Parameters["@Email"].Value = agents.Email;
                                
                               command.Parameters.Add("@Telephone", SqlDbType.NVarChar);
                               command.Parameters["@Telephone"].Value = agents.Telephone;

                               command.Parameters.Add("@Fax", SqlDbType.NVarChar);
                               command.Parameters["@Fax"].Value = agents.Fax;
                              
                              command.Parameters.Add("@PostalCode", SqlDbType.NVarChar);
                               command.Parameters["@PostalCode"].Value = agents.PostalCode;
                              
                               command.Parameters.Add("@ContactPerson1", SqlDbType.NVarChar);
                               command.Parameters["@ContactPerson1"].Value = agents.ContactPerson1;

                               command.Parameters.Add("@Destination1", SqlDbType.NVarChar);
                               command.Parameters["@Destination1"].Value = agents.Destination1;

                               command.Parameters.Add("@HP1", SqlDbType.NVarChar);
                               command.Parameters["@HP1"].Value = agents.HP1;

                               command.Parameters.Add("@Stop", SqlDbType.Bit);
                               command.Parameters["@Stop"].Value = agents.Stop;

                               if (agents.StopDate != DateTime.MinValue)
                               {
                                   command.Parameters.Add("@StopDate", SqlDbType.DateTime);
                                   command.Parameters["@StopDate"].Value = agents.StopDate;
                               }

                               command.Parameters.Add("@ContactTelephone1", SqlDbType.NVarChar);
                               command.Parameters["@ContactTelephone1"].Value = agents.ContactTelephone1;

                               command.Parameters.Add("@ContactPerson2", SqlDbType.NVarChar);
                               command.Parameters["@ContactPerson2"].Value = agents.ContactPerson2;

                               command.Parameters.Add("@Destination2", SqlDbType.NVarChar);
                               command.Parameters["@Destination2"].Value = agents.Destination2;

                                
                                                           
                               command.Parameters.Add("@HP2", SqlDbType.NVarChar);
                               command.Parameters["@HP2"].Value = agents.HP2;

                               command.Parameters.Add("@ContactTelephone2", SqlDbType.NVarChar);
                               command.Parameters["@ContactTelephone2"].Value = agents.ContactTelephone2;

                               
                               command.Parameters.Add("@UserName", SqlDbType.NVarChar);
                               command.Parameters["@UserName"].Value = agents.UserName;

                               if (agents.TextBoxPassword.Trim() != String.Empty)
                               {
                                   command.Parameters.Add("@Password", SqlDbType.Image);
                                   command.Parameters["@Password"].Value = agents.Password;

                                   command.Parameters.Add("@Salt", SqlDbType.Image);
                                   command.Parameters["@Salt"].Value = agents.Salt;
                               }

                               command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                               command.Parameters["@CreatedBy"].Value = agents.CreatedBy;
                               //14
                               command.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                               command.Parameters["@CreatedDate"].Value = agents.CreatedDate;

                               command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                               command.Parameters["@UpdatedBy"].Value = agents.UpdatedBy;
                               //16
                               command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime);
                               command.Parameters["@UpdatedDate"].Value = agents.UpdatedDate;

                               //16
                               command.Parameters.Add("@Delete", SqlDbType.NVarChar);
                               command.Parameters["@Delete"].Value ="N";

                               command.Parameters.Add("@CountryID", SqlDbType.UniqueIdentifier);
                               command.Parameters["@CountryID"].Value = agents.CountryID;

                               //17
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
                Agents agents = new Agents();
                agents = (Agents)iBusinessEntity;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookAgent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                            command.Parameters.Add("@AgentCode", SqlDbType.NVarChar);
                            command.Parameters["@AgentCode"].Value = agents.AgentCode;

                            command.Parameters.Add("@Agent", SqlDbType.NVarChar);
                            command.Parameters["@Agent"].Value = agents.Agent;

                            command.Parameters.Add("@Prefix", SqlDbType.NVarChar);
                            command.Parameters["@Prefix"].Value = agents.Prefix;

                            command.Parameters.Add("@Address", SqlDbType.NVarChar);
                            command.Parameters["@Address"].Value = agents.Address;
                            //5
                            command.Parameters.Add("@Email", SqlDbType.NVarChar);
                            command.Parameters["@Email"].Value = agents.Email;

                            command.Parameters.Add("@Telephone", SqlDbType.NVarChar);
                            command.Parameters["@Telephone"].Value = agents.Telephone;

                            command.Parameters.Add("@Fax", SqlDbType.NVarChar);
                            command.Parameters["@Fax"].Value = agents.Fax;

                            command.Parameters.Add("@PostalCode", SqlDbType.NVarChar);
                            command.Parameters["@PostalCode"].Value = agents.PostalCode;

                            command.Parameters.Add("@ContactPerson1", SqlDbType.NVarChar);
                            command.Parameters["@ContactPerson1"].Value = agents.ContactPerson1;
                            //10
                            command.Parameters.Add("@Destination1", SqlDbType.NVarChar);
                            command.Parameters["@Destination1"].Value = agents.Destination1;

                            command.Parameters.Add("@HP1", SqlDbType.NVarChar);
                            command.Parameters["@HP1"].Value = agents.HP1;

                            command.Parameters.Add("@Stop", SqlDbType.Bit);
                            command.Parameters["@Stop"].Value = agents.Stop;

                            if (agents.StopDate != DateTime.MinValue)
                            {
                                command.Parameters.Add("@StopDate", SqlDbType.DateTime);
                                command.Parameters["@StopDate"].Value = agents.StopDate;
                            }

                            command.Parameters.Add("@ContactTelephone1", SqlDbType.NVarChar);
                            command.Parameters["@ContactTelephone1"].Value = agents.ContactTelephone1;
                            //15
                            command.Parameters.Add("@ContactPerson2", SqlDbType.NVarChar);
                            command.Parameters["@ContactPerson2"].Value = agents.ContactPerson2;

                            command.Parameters.Add("@Destination2", SqlDbType.NVarChar);
                            command.Parameters["@Destination2"].Value = agents.Destination2;


                            command.Parameters.Add("@HP2", SqlDbType.NVarChar);
                            command.Parameters["@HP2"].Value = agents.HP2;

                            command.Parameters.Add("@ContactTelephone2", SqlDbType.NVarChar);
                            command.Parameters["@ContactTelephone2"].Value = agents.ContactTelephone2;

                            command.Parameters.Add("@UserName", SqlDbType.NVarChar);
                            command.Parameters["@UserName"].Value = agents.UserName;

                            if (agents.TextBoxPassword.Trim() != String.Empty)
                            {
                                command.Parameters.Add("@Password", SqlDbType.Image);
                                command.Parameters["@Password"].Value = agents.Password;

                                command.Parameters.Add("@Salt", SqlDbType.Image);
                                command.Parameters["@Salt"].Value = agents.Salt;
                            }

                            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CreatedBy"].Value = agents.CreatedBy;
                            //22
                            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                            command.Parameters["@CreatedDate"].Value = agents.CreatedDate;

                            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@UpdatedBy"].Value = agents.UpdatedBy;
                            //24
                            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime);
                            command.Parameters["@UpdatedDate"].Value = agents.UpdatedDate;

                            //25
                            command.Parameters.Add("@Delete", SqlDbType.NVarChar);
                            command.Parameters["@Delete"].Value = "N";

                            //26
                            command.Parameters.Add("@CountryID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CountryID"].Value = agents.CountryID;

                            //27
                            command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                            command.Parameters["@TransactionMode"].Value = 2;

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
                Agents agents = new Agents();
                agents = (Agents)iBusinessEntity;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookAgent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                            command.Parameters.Add("@AgentCode", SqlDbType.NVarChar);
                            command.Parameters["@AgentCode"].Value = agents.AgentCode;

                            command.Parameters.Add("@Agent", SqlDbType.NVarChar);
                            command.Parameters["@Agent"].Value = agents.Agent;

                            command.Parameters.Add("@Prefix", SqlDbType.NVarChar);
                            command.Parameters["@Prefix"].Value = agents.Prefix;

                            command.Parameters.Add("@Address", SqlDbType.NVarChar);
                            command.Parameters["@Address"].Value = agents.Address;

                            command.Parameters.Add("@Email", SqlDbType.NVarChar);
                            command.Parameters["@Email"].Value = agents.Email;

                            command.Parameters.Add("@Telephone", SqlDbType.NVarChar);
                            command.Parameters["@Telephone"].Value = agents.Telephone;

                            command.Parameters.Add("@Fax", SqlDbType.NVarChar);
                            command.Parameters["@Fax"].Value = agents.Fax;

                            command.Parameters.Add("@PostalCode", SqlDbType.NVarChar);
                            command.Parameters["@PostalCode"].Value = agents.PostalCode;

                            command.Parameters.Add("@ContactPerson1", SqlDbType.NVarChar);
                            command.Parameters["@ContactPerson1"].Value = agents.ContactPerson1;

                            command.Parameters.Add("@Destination1", SqlDbType.NVarChar);
                            command.Parameters["@Destination1"].Value = agents.Destination1;

                            command.Parameters.Add("@HP1", SqlDbType.NVarChar);
                            command.Parameters["@HP1"].Value = agents.HP1;

                            command.Parameters.Add("@Stop", SqlDbType.Bit);
                            command.Parameters["@Stop"].Value = agents.Stop;

                            if (agents.StopDate != DateTime.MinValue)
                            {
                                command.Parameters.Add("@StopDate", SqlDbType.DateTime);
                                command.Parameters["@StopDate"].Value = agents.StopDate;
                            }

                            command.Parameters.Add("@ContactTelephone1", SqlDbType.NVarChar);
                            command.Parameters["@ContactTelephone1"].Value = agents.ContactTelephone1;

                            command.Parameters.Add("@ContactPerson2", SqlDbType.NVarChar);
                            command.Parameters["@ContactPerson2"].Value = agents.ContactPerson2;

                            command.Parameters.Add("@Destination2", SqlDbType.NVarChar);
                            command.Parameters["@Destination2"].Value = agents.Destination2;


                            command.Parameters.Add("@HP2", SqlDbType.NVarChar);
                            command.Parameters["@HP2"].Value = agents.HP2;

                            command.Parameters.Add("@ContactTelephone2", SqlDbType.NVarChar);
                            command.Parameters["@ContactTelephone2"].Value = agents.ContactTelephone2;


                            command.Parameters.Add("@UserName", SqlDbType.NVarChar);
                            command.Parameters["@UserName"].Value = agents.UserName;

                            command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CreatedBy"].Value = agents.CreatedBy;
                            //14
                            command.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                            command.Parameters["@CreatedDate"].Value = agents.CreatedDate;

                            command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                            command.Parameters["@UpdatedBy"].Value = agents.UpdatedBy;
                            //16
                            command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime);
                            command.Parameters["@UpdatedDate"].Value = agents.UpdatedDate;

                            //16
                            command.Parameters.Add("@Delete", SqlDbType.NVarChar);
                            command.Parameters["@Delete"].Value = "Y";

                            //17
                            command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                            command.Parameters["@TransactionMode"].Value = 3;

                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }

                    connection.Close();
                }

                return Constant.Constant.MessageDeleted;
            }
            catch
            {

                return Constant.Constant.MessageUndeleted;
            }

        }

        public String ResignData(IBusinessEntity iBusinessEntity)
        {
            try
            {
                Agents agents = new Agents();
                agents = (Agents)iBusinessEntity;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_WocBookInsertStaff", connection))
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

        public List<Agents> SearchData(String parameter)
        {
            Agents agents = new Agents();
            List<Agents> ListAgents = new List<Agents>();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Agent where " + parameter, conn))
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
                                agents.Agent = table.Rows[i]["Agent"].ToString();
                                agents.AgentCode = table.Rows[i]["AgentCode"].ToString();
                                agents.Email = table.Rows[i]["Email"].ToString();
                                agents.Address = table.Rows[i]["Address"].ToString();
                                agents.Fax = table.Rows[i]["Fax"].ToString();
                              
                                ListAgents.Add(agents);
                                agents = new Agents();
                            }

                        }


                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }

            return ListAgents;
        }

        public Agents GetData(String parameter)
        {
            Agents agents = new Agents();

            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Agent where " + parameter, conn))
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
                                agents.AgentCode = table.Rows[i]["AgentCode"].ToString();
                                agents.Agent = table.Rows[i]["Agent"].ToString();
                                agents.Prefix = table.Rows[i]["PrefixCode"].ToString();
                                agents.Address = table.Rows[i]["Address"].ToString();
                                agents.Email = table.Rows[i]["Email"].ToString();
                                agents.Telephone = table.Rows[i]["Telephone"].ToString();
                                agents.Fax = table.Rows[i]["Fax"].ToString();
                                agents.PostalCode = table.Rows[i]["PostalCode"].ToString();
                                agents.ContactPerson1 = table.Rows[i]["ContactPerson1"].ToString();
                                agents.Destination1 = table.Rows[i]["Destination1"].ToString();
                                agents.HP1 = table.Rows[i]["HP1"].ToString();
                                agents.ContactTelephone1 = table.Rows[i]["ContactTelephone1"].ToString();
                                agents.Stop = Convert.ToBoolean(table.Rows[i]["Stop"]);
                                agents.ContactPerson2 = table.Rows[i]["ContactPerson2"].ToString();
                                agents.Destination2 = table.Rows[i]["Destination2"].ToString();
                                agents.HP2 = table.Rows[i]["HP2"].ToString();
                                agents.ContactTelephone2 = table.Rows[i]["ContactTelephone2"].ToString();
                                
                                agents.StopDate = String.IsNullOrEmpty(table.Rows[i]["StopDate"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(table.Rows[i]["StopDate"]);

                                agents.UserName = table.Rows[i]["UserName"].ToString();
                                agents.CountryID = new Guid(table.Rows[i]["CountryID"].ToString());
                            }

                        }
                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }

            return agents;
        }

        public List<Agents> GetAgents()
        {
            Agents agents = new Agents();
            List<Agents> ListAgents = new List<Agents>();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Agent ", conn))
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
                                agents.AgentID = new Guid(table.Rows[i]["AgentID"].ToString());
                                agents.Agent = table.Rows[i]["Agent"].ToString();
                                agents.AgentCode = table.Rows[i]["AgentCode"].ToString();
                                agents.Email = table.Rows[i]["Email"].ToString();
                                agents.Address = table.Rows[i]["Address"].ToString();
                                agents.Fax = table.Rows[i]["Fax"].ToString();
                                agents.Prefix = table.Rows[i]["PrefixCode"].ToString();

                                ListAgents.Add(agents);
                                agents = new Agents();
                            }

                        }


                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }

            return ListAgents;
        }

        public List<Agents> GetInvoiceAgents()
        {
            try
            {
                List<Agents> ListAgents = new List<Agents>();
                Agents agents;
                using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
                {
                    using (SqlCommand cmd = new SqlCommand("Select A.AgentID, A.Agent FROM Agent A WHERE EXISTS (Select * FROM Invoice WHERE AgentID = A.AgentID)", conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();
                            conn.Open();
                            ad.Fill(table);
                            conn.Close();
                            ad.Dispose();
                            conn.Dispose();

                            foreach (DataRow row in table.Rows)
                            {
                                agents = new Agents();
                                agents.AgentID = new Guid(row["AgentID"].ToString());
                                agents.Agent = row["Agent"].ToString();
                                ListAgents.Add(agents);
                            }


                        }
                    }
                }
                return ListAgents;

            }

            catch
            {
                return null;
            }
        }

        public String GetPrefixById(Guid agentID){
            String prefix = String.Empty;

            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("Select PrefixCode FROM Agent WHERE AgentID = '" + agentID.ToString() + "'", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.Text;
                    prefix = (String) cmd.ExecuteScalar();
                }
            }
            return prefix;
        }

        public Agents GetPasswordSaltByUserID(String userID)
        {
            Agents agents = new Agents();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {

                using (SqlCommand cmd = new SqlCommand("Select Salt, Password from Agent where UserName = '" + userID + "' ", conn))
                {

                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        conn.Open();
                        ad.Fill(table);

                        if (table.DefaultView.Count > 0)
                        {
                            agents.Salt = (byte[])table.Rows[0]["Salt"];
                            agents.Password = (byte[])table.Rows[0]["Password"];
                        }

                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }
            return agents;
        }

        public bool CheckAgentUserNameExists(String userName)
        {
            SQLHelper sqlHelp = new SQLHelper();
            try
            {
                int count = (int)sqlHelp.GetExecuteScalarBySQL("SELECT COUNT(1) FROM Agent WHERE UserName = '" + userName + "'");

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlHelp.Dispose();
            }

        }

        public Guid GetAgentIDByUserName(String userName)
        {
            SQLHelper sqlHelp = new SQLHelper();
            try
            {
                Guid agentID = (Guid)sqlHelp.GetExecuteScalarBySQL("SELECT Top 1 AgentID FROM Agent WHERE UserName = '" + userName + "' ");

                return agentID;
            }
            catch
            {
                throw;
            }
            finally
            {
                sqlHelp.Dispose();
            }
        }

        public String GetAgentNameByID(Guid agentID)
        {
            SQLHelper sqlHelp = new SQLHelper();
            try
            {
                String agentName = (String)sqlHelp.GetExecuteScalarBySQL("SELECT Agent FROM Agent WHERE agentID = '" + agentID.ToString() + "' ");

                return agentName;
            }
            catch
            {
                throw;
            }
            finally
            {
                sqlHelp.Dispose();
            }
        }

        public String GetAgentNameByID(String userID)
        {
            SQLHelper sqlHelp = new SQLHelper();
            try
            {
                String agentName = (String)sqlHelp.GetExecuteScalarBySQL("SELECT Agent FROM Agent WHERE username = '" + userID + "' ");

                return agentName;
            }
            catch
            {
                throw;
            }
            finally
            {
                sqlHelp.Dispose();
            }
        }

        public List<Agents> GetAgentDropdownInfo()
        {
            Agents agents = new Agents();
            List<Agents> ListAgent = new List<Agents>();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT AgentID, Agent FROM Agent ", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        conn.Open();
                        ad.Fill(table);
                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                        foreach (DataRow row in table.Rows)
                        {
                            agents = new Agents();
                            agents.AgentID = new Guid(row["AgentID"].ToString());
                            agents.Agent = row["Agent"].ToString();
                            ListAgent.Add(agents);
                        }


                    }
                }
            }

            return ListAgent;
        }
    }
}
