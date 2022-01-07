using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Presenter;

//Internal
using Woc.Book.Driver;
using Woc.Book.Driver.BusinessEntity;

namespace Woc.Book.Driver.Presenter
{
    public class DriverPresenter : IRegistrationPresenter
    {
      IRegistrationPresenter iRegistrationPresenter;
      DriverController driverController;
       public DriverPresenter()
        { 
        
        }
       public DriverPresenter(IRegistrationPresenter iRegistration)
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

       public void ClearControl()
       {
           iRegistrationPresenter.ClearControl();
       }
       public void ResignData()

       { 
       
       }

       public String SaveData(IBusinessEntity iBusinessEntity)
       {
           driverController = new DriverController();
           return driverController.SaveData(iBusinessEntity);
       }

       public String UpdateData(IBusinessEntity iBusinessEntity)
       {
           driverController = new DriverController();
           return driverController.UpdateData(iBusinessEntity);
           
       }
       public List<Drivers> SearchData(IBusinessEntity iBusinessEntity)
       {
            driverController = new DriverController();
            return driverController.SearchData(iBusinessEntity);
       }


       public Drivers GetUpdateData(String loginID)
       {
           driverController = new DriverController();
           return driverController.GetUpdateData(loginID);

       }
       public String DeleteData(IBusinessEntity iBusinessEntity)
       {

           driverController = new DriverController();
           return driverController.DeleteData(iBusinessEntity);
       }
    }
}
