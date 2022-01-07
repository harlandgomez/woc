using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Presenter;

//Internal
using Woc.Book.Bus;
using Woc.Book.Bus.BusinessEntity;
namespace Woc.Book.Bus.Presenter
{
    public class BusPresenter : IRegistrationPresenter
    {
        IRegistrationPresenter iRegistrationPresenter;
        BusController busController;
       public BusPresenter()
        { 
        
        }
       public BusPresenter(IRegistrationPresenter iRegistration)
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
           busController = new BusController();
           return busController.SaveData(iBusinessEntity);
       }

       public String UpdateData(IBusinessEntity iBusinessEntity)
       {
           busController = new BusController();
           return busController.UpdateData(iBusinessEntity);
           
       }
       public List<Buses> SearchData(IBusinessEntity iBusinessEntity)
       {
            busController = new BusController();
            return busController.SearchData(iBusinessEntity);
       }

       public void ClearControl()
       {
           iRegistrationPresenter.ClearControl();
       }

       public Buses GetUpdateData(String loginID)
       {
           busController = new BusController();
           return busController.GetUpdateData(loginID);

       }
       public String DeleteData(IBusinessEntity iBusinessEntity)
       {

           busController = new BusController();
           return busController.DeleteData(iBusinessEntity);
       }
       public List<Buses> GetData()
       {

           busController = new BusController();
           return busController.GetAllBuses();
       }

    }
}
