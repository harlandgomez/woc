using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.ReportDriverBus.BusinessEntity;
using Woc.Book.ReportDriverBus.Service;
using Woc.Book.Common;
using Woc.Book.Common.BusinessEntity;
namespace Woc.Book.ReportDriverBus
{
    internal class ReportDriverBusController : IOperationController
    {
        ReportDriverBusService reportDriverBusService;
      public ReportDriverBusController()
      { 
      
      }
      public void SaveStartData(IOperation iOperation)
      {
          reportDriverBusService = new ReportDriverBusService();
          reportDriverBusService.SaveStartData(iOperation);
      }
      public void SaveEndData(IOperation iOperation)
      {
          reportDriverBusService = new ReportDriverBusService();
          reportDriverBusService.SaveEndData(iOperation);
      }
      public void SaveData(IOperation iOperation)
      {
          reportDriverBusService = new ReportDriverBusService();
          reportDriverBusService.SaveData(iOperation);
      }
      public String UpdateData(IOperation iOperation)
      {
          return string.Empty;
         
      }

      public String DeleteData(IOperation iOperation)
      {
          reportDriverBusService = new ReportDriverBusService();
          return reportDriverBusService.DeleteOperation(iOperation);
      }
      public List<ReportDriverBuses> SearchData(IOperation iOperation)
      {
          reportDriverBusService = new ReportDriverBusService();
          return reportDriverBusService.SearchData(iOperation);
      }
      public Boolean OperationExist(DateTime dDailyTrip)
      {

          reportDriverBusService = new ReportDriverBusService();
          return reportDriverBusService.CheckOperation(dDailyTrip);

      }

    }
}
