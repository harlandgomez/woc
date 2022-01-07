using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Presenter;

//Internal
using Woc.Book.Agent;
using Woc.Book.Agent.BusinessEntity;


namespace Woc.Book.Agent.Presenter
{
    public class AgentPresenter : IRegistrationPresenter
    {
         
        IRegistrationPresenter iRegistrationPresenter;
        AgentController agentController;
       public AgentPresenter()
        { 
        
        }
       public AgentPresenter(IRegistrationPresenter iRegistration)
        {
            iRegistrationPresenter = iRegistration;
        }
       public  void DataBindings()
        {
            iRegistrationPresenter.DataBindings();

        }
       public void SaveData()
       {
           iRegistrationPresenter.SaveData();
       }
       
       public void SearchData()
       {
           iRegistrationPresenter.SearchData();
       }
       public void GetData(String Id)
       {
           iRegistrationPresenter.GetData(Id);
       }
       public void UpdateData()
       {
           iRegistrationPresenter.UpdateData();
       }
       public void DeleteData()
       {
           iRegistrationPresenter.DeleteData();
       }
       public void ResignData()

       { 
       
       }

       public String SaveData(IBusinessEntity iBusinessEntity)
       {
           agentController = new AgentController();
           return agentController.SaveData(iBusinessEntity);
       }

       public String UpdateData(IBusinessEntity iBusinessEntity)
       {
           agentController = new AgentController();
           return agentController.UpdateData(iBusinessEntity);
           
       }
       public List<Agents> SearchData(IBusinessEntity iBusinessEntity)
       {
           agentController = new AgentController();
           return agentController.SearchData(iBusinessEntity);
       }

       public void ClearControl()
       {
           iRegistrationPresenter.ClearControl();
       }

       public Agents GetUpdateData(String id)
       {
           agentController = new AgentController();
           return agentController.GetUpdateData(id);

       }
       public String DeleteData(IBusinessEntity iBusinessEntity)
       {

           agentController = new AgentController();
           return agentController.DeleteData(iBusinessEntity);
       }

       public List<Agents> GetAgents()
       {
           agentController = new AgentController();
           return agentController.GetAgents();
       }

       public bool CheckAgentUserNameExists(String userName)
       {

           agentController = new AgentController();
           return agentController.CheckAgentUserNameExists(userName);
       }

       public Guid GetAgentIDByUserName(String userName)
       {

           agentController = new AgentController();
           return agentController.GetAgentIDByUserName(userName);
       }

       public String GetAgentNameByID(Guid agentID)
       {
           agentController = new AgentController();
           return agentController.GetAgentNameByID(agentID);
       }

       public String GetAgentNameByID(String userID)
       {
           agentController = new AgentController();
           return agentController.GetAgentNameByID(userID);
       }

       public List<Agents> GetAgentDropdownInfo()
       {
           agentController = new AgentController();
           return agentController.GetAgentDropdownInfo();
       }
    }
}

