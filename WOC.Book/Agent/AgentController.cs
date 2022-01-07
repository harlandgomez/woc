using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base;
//Internal
using Woc.Book.Agent.Service;
using Woc.Book.Agent.BusinessEntity;
namespace Woc.Book.Agent
{
   internal class AgentController
    {
        public String SaveData(IBusinessEntity iBusinessEntity)
        {
            AgentService agentService = new AgentService();
            Agents agents = (Agents)iBusinessEntity;

            if (agents.TextBoxPassword.Trim() != String.Empty)
            {
                UtilityController utility = new UtilityController();

                byte[] HashOut;
                byte[] SaltOut;

                utility.EncryptSaltPassword(agents.TextBoxPassword, out HashOut, out SaltOut);
                agents.Password = HashOut;
                agents.Salt = SaltOut;
            }

            return agentService.SaveData(agents);

        }

        public String UpdateData(IBusinessEntity iBusinessEntity)
        {

            AgentService agentService = new AgentService();
            Agents agents = (Agents)iBusinessEntity;

            if (agents.TextBoxPassword.Trim() != String.Empty)
            {
                UtilityController utility = new UtilityController();

                byte[] HashOut;
                byte[] SaltOut;

                utility.EncryptSaltPassword(agents.TextBoxPassword, out HashOut, out SaltOut);
                agents.Password = HashOut;
                agents.Salt = SaltOut;
            }

            return agentService.UpdateData(agents);
        }

        public String DeleteData(IBusinessEntity iBusinessEntity)
        {

            AgentService agentService = new AgentService();
            return agentService.DeleteData(iBusinessEntity);

        }
        public List<Agents> SearchData(IBusinessEntity iBusinessEntity)
        {
            AgentService agentService = new AgentService();


            Agents agents = new Agents();
            agents = (Agents)iBusinessEntity;
            string strParemeter = String.Empty;
            if (!String.IsNullOrEmpty(agents.Agent))
            {
                strParemeter = "Agent like '%" + agents.Agent + "%'";
            }
            else if (!String.IsNullOrEmpty(agents.AgentCode))
            {
                strParemeter = "AgentCode like '%" + agents.AgentCode + "%'";
            }
            else if (!String.IsNullOrEmpty(agents.Address))
            {
                strParemeter = " Address like '%" + agents.Address + "%'";
            }

            else if (!String.IsNullOrEmpty(agents.Email))
            {
                strParemeter = "Email like '%" + agents.Email + "%'";
            }

            else if (!String.IsNullOrEmpty(agents.Fax))
            {
                strParemeter = " Fax like '%" + agents.Fax + "%'";
            }
           
          
            if (string.IsNullOrEmpty(strParemeter))
            {
                strParemeter = strParemeter + " [Delete] <> 'Y'";
            }
            else
            {
                strParemeter = strParemeter + " and [Delete] <> 'Y'";
            }

            return agentService.SearchData(strParemeter);
        }

        public Agents GetUpdateData(String driverCode)
        {
            String strParemeter = "AgentCode = '" + driverCode + "'";
            AgentService agentService = new AgentService();
            return agentService.GetData(strParemeter);
        }

        public List<Agents> GetAgents()
        {
            AgentService agentService = new AgentService();
            return agentService.GetAgents();
        }

        public bool CheckAgentUserNameExists(String userName)
        {
            AgentService agentService = new AgentService();
            return agentService.CheckAgentUserNameExists(userName);
        }

        public Guid GetAgentIDByUserName(String userName)
        {
            AgentService agentService = new AgentService();
            return agentService.GetAgentIDByUserName(userName);
        }

        public String GetAgentNameByID(Guid agentID)
        {
            AgentService agentService = new AgentService();
            return agentService.GetAgentNameByID(agentID);
        }

        public String GetAgentNameByID(String userID)
        {
            AgentService agentService = new AgentService();
            return agentService.GetAgentNameByID(userID);
        }

        public List<Agents> GetAgentDropdownInfo()
        {
            AgentService agentService = new AgentService();
            return agentService.GetAgentDropdownInfo();
        }
    }
}
