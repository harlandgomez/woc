using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.Presenter;
using Woc.Book.Base.BusinessEntity;

using Woc.Book.BusDriverStatus;
using Woc.Book.BusDriverStatus.BusinessEntity;
using Woc.Book.BusDriverStatus.Constant;

namespace Woc.Book.BusDriverStatus.Presenter
{
   public class BusDriverStatusPresenter
    {

       IOperationPresenter iOperationPresenter;
       BusDriverStatusController busDriverStatusController;

         public  BusDriverStatusPresenter()
       { 

       }
         public BusDriverStatusPresenter(IOperationPresenter iOperation)
        {
            iOperationPresenter = iOperation; 
        
        }
       public void DataBindings()
          {

          }
       public void SaveData()
        {
            iOperationPresenter.SaveData();
           
        }
       public void ClearControl()
        {
            iOperationPresenter.ClearControl();
        }
       public void SearchData()
       {
           iOperationPresenter.SearchData();
       }
       public void GetData(String Id)
        {
        }
       public void UpdateData()
        {
        }
       public void DeleteData()
        {

            iOperationPresenter.DeleteData();

        }
       public String DeleteData(IOperation iOperation)
       {

           busDriverStatusController = new BusDriverStatusController();
           return busDriverStatusController.DeleteData(iOperation);
       }
       public List<DriverBuses> SearchData(IOperation iOperation)
       {
           busDriverStatusController = new BusDriverStatusController();
           return busDriverStatusController.SearchData(iOperation);
       }
       public List<DriverBuses> SearchCOSData(IOperation iOperation)
       {
           busDriverStatusController = new BusDriverStatusController();
           return busDriverStatusController.SearchCOSData(iOperation);
       }
       public void SaveStartData(IOperation iOperation)
       {
           busDriverStatusController = new BusDriverStatusController();
           busDriverStatusController.SaveStartData(iOperation);
         
       }
       public void SaveEndData(IOperation iOperation)
       {
           busDriverStatusController = new BusDriverStatusController();
           busDriverStatusController.SaveEndData(iOperation);

       }
       public void SaveData(IOperation iOperation, Constant.Constant.StatusOptions statusType)
        {

            busDriverStatusController = new BusDriverStatusController();
            busDriverStatusController.SaveData(iOperation,statusType);

        }

       public Boolean OperationExist(DateTime dDailyTrip)
       {

           busDriverStatusController = new BusDriverStatusController();
           return busDriverStatusController.OperationExist(dDailyTrip);
       
       }

    }
}
