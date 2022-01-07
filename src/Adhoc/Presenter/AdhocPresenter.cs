using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Presenter;


//Agent
using Woc.Book.Agent.BusinessEntity;
using Woc.Book.Agent.Presenter;

//Internal
using Woc.Book.Adhoc;
using Woc.Book.Adhoc.BusinessEntity;
using Woc.Book.Setting.Presenter;
using Woc.Book.Setting.BusinessEntity;

namespace Woc.Book.Adhoc.Presenter
{
    public class AdhocPresenter : INewBookingPresenter
    {
        INewBookingPresenter iNewBookingPresenter;
        AdhocController adhocController;
       public AdhocPresenter()
        { 
        
        }
       public AdhocPresenter(INewBookingPresenter INewBooking)
        {
            iNewBookingPresenter = INewBooking;
        }
       public  void DataBindings()
        {
            iNewBookingPresenter.DataBindings();

        }
       public void SaveData()
       {
           iNewBookingPresenter.SaveData();
       }
       
       public void SearchData()
       {
           iNewBookingPresenter.SearchData();
       }
       public void GetData(String Id)
       {
           iNewBookingPresenter.GetData(Id);
       }
       public void UpdateData()
       {
           iNewBookingPresenter.UpdateData();
       }
       public void DeleteData()
       {
           iNewBookingPresenter.DeleteData();
       }

       public String VoidData(INewBookEntity iNewBookEntity)
       {
           AdhocController adhocController = new AdhocController();
           return adhocController.VoidData(iNewBookEntity);
       }

       public String SaveData(List<Adhocs> listAdhoc)
       {
           adhocController = new AdhocController();
           return adhocController.SaveData(listAdhoc);
       }

       public String UpdateData(List<Adhocs> listAdhoc)
       {
           adhocController = new AdhocController();
           return adhocController.UpdateData(listAdhoc);
       }
       public List<Adhocs> SearchData(INewBookEntity iNewBookEntity)
       {
           adhocController = new AdhocController();
           return adhocController.SearchData(iNewBookEntity);
       }

       public void ClearControl()
       {
           iNewBookingPresenter.ClearControl();
       }

       public List<Adhocs> GetUpdateData(String AdhocCode)
       {
           adhocController = new AdhocController();
           return adhocController.GetUpdateData(AdhocCode);

       }
       public String DeleteData(INewBookEntity iNewBookEntity)
       {

           adhocController = new AdhocController();
           return adhocController.DeleteData(iNewBookEntity);
       }

       public List<Adhocs> GetTempData(List<Adhocs> adhocStaff)
       {
           adhocController = new AdhocController();
           return adhocController.GetTempData(adhocStaff);

       }
       public List<Agents> GetAgents()
       {
           AgentPresenter agentPresenter = new AgentPresenter();
           return agentPresenter.GetAgents();
       }
       public List<DropDowns> GetDropdownValues(String settingCode)
       {
           SettingPresenter settingPresenter = new SettingPresenter();
           return  settingPresenter.GetDropdownValues(settingCode);
       
       }
       public List<Adhocs> SearchPendingData(INewBookEntity iNewBookEntity)
       {
           adhocController = new AdhocController();
           return adhocController.SearchPendingData(iNewBookEntity);
       }

       public Guid GetAgentIDByUserName(String userName)
       {
           AgentPresenter agentPresenter = new AgentPresenter();
           return agentPresenter.GetAgentIDByUserName(userName);
       }

       public String GetAgentNameByID(Guid agentID)
       {
           AgentPresenter agentPresenter = new AgentPresenter();
           return agentPresenter.GetAgentNameByID(agentID);
       }

       public List<Adhocs> GetPendingDataByAgentID(Guid agentID)
       {
           adhocController = new AdhocController();
           return adhocController.GetPendingDataByAgentID(agentID);
       }
       public String ConfirmRejectBooking(List<Adhocs> listAdhoc)
       {
           adhocController = new AdhocController();
           return adhocController.ConfirmRejectBooking(listAdhoc);
       }
    }
}
