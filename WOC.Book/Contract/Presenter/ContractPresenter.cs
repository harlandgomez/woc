using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Agent
using Woc.Book.Agent.BusinessEntity;
using Woc.Book.Agent.Presenter;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Presenter;
using Woc.Book.Contract;
using Woc.Book.Contract.BusinessEntity;

namespace Woc.Book.Contract.Presenter
{
    public class ContractPresenter : INewBookingPresenter
    {
        INewBookingPresenter iNewBookingPresenter;
        ContractController contractController;
        public ContractPresenter()
        { 
        
        }
        public ContractPresenter(INewBookingPresenter INewBooking)
        {
            iNewBookingPresenter = INewBooking;
        }

        public List<Agents> GetAgents()
        {
            AgentPresenter agentPresenter = new AgentPresenter();
            return agentPresenter.GetAgents();
        }

        public void DataBindings()
        {
            iNewBookingPresenter.DataBindings();
        }

        public void SaveData()
        {
            iNewBookingPresenter.SaveData();
        }

        public void ClearControl()
        {
            iNewBookingPresenter.ClearControl();
        }

        public void SearchData()
        {
            iNewBookingPresenter.SearchData();
        }

        public void GetData(string Id)
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

        public String SaveData(INewBookEntity iBusinessEntity)
        {
            contractController = new ContractController();
            return contractController.SaveData(iBusinessEntity);
        }

        public String UpdateData(INewBookEntity iBusinessEntity)
        {
            contractController = new ContractController();
            return contractController.UpdateData(iBusinessEntity);
        }


        public Contracts GetUpdateData(String id)
        {
            contractController = new ContractController();
            return contractController.GetUpdateData(id);

        }

        public List<Contracts> SearchData(INewBookEntity iBusinessEntity)
        {
            contractController = new ContractController();
            return contractController.SearchData(iBusinessEntity);
        }

    }
}
