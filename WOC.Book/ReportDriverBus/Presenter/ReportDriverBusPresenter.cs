using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Common.Presenter;
using Woc.Book.ReportDriverBus;
using Woc.Book.ReportDriverBus.BusinessEntity;
using Woc.Book.Common.BusinessEntity;

namespace Woc.Book.ReportDriverBus.Presenter
{
    public class ReportDriverBusPresenter : IOperationPresenter
    {
        IOperationPresenter iOperationPresenter;
        ReportDriverBusController reportDriverBusController;

         public  ReportDriverBusPresenter()
       { 

       }
       public ReportDriverBusPresenter(IOperationPresenter iOperation)
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

           reportDriverBusController = new ReportDriverBusController();
           return reportDriverBusController.DeleteData(iOperation);
       }
       public List<ReportDriverBuses> SearchData(IOperation iOperation)
       {
           reportDriverBusController = new ReportDriverBusController();
           return reportDriverBusController.SearchData(iOperation);
       }
       public void SaveStartData(IOperation iOperation)
       {
           reportDriverBusController = new ReportDriverBusController();
           reportDriverBusController.SaveStartData(iOperation);
         
       }
       public void SaveEndData(IOperation iOperation)
       {
           reportDriverBusController = new ReportDriverBusController();
           reportDriverBusController.SaveEndData(iOperation);

       }
       public void SaveData(IOperation iOperation)
        {

            reportDriverBusController = new ReportDriverBusController();
            reportDriverBusController.SaveData(iOperation);

        }
       public Boolean OperationExist(DateTime dDailyTrip)
       {

           reportDriverBusController = new ReportDriverBusController();
           return reportDriverBusController.OperationExist(dDailyTrip);
       
       }

    }
}
