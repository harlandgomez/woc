using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.DailyTrip.BusinessEntity;
using Woc.Book.DailyTrip.Service;
using Woc.Book.Base;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.DailyTrip
{
    internal class DailyTripController : IOperationController
    {
        DailyTripService dailyTripService;
      public DailyTripController()
      { 
      
      }
      public void SaveData(IOperation iOperation)
      { }
      public void SaveStartData(IOperation iOperation)
      {
          dailyTripService = new DailyTripService();
          dailyTripService.SaveStartData(iOperation);
      }
      public void SaveEndData(IOperation iOperation)
      {
          dailyTripService = new DailyTripService();
          dailyTripService.SaveEndData(iOperation);
      }
      public void SaveData(List<DailyTripsDTO> listDailyTripsDTO)
      {
          dailyTripService = new DailyTripService();
          dailyTripService.SaveData(listDailyTripsDTO);
      }
      public String UpdateData(IOperation iOperation)
      {
          return string.Empty;
         
      }

      public String DeleteData(IOperation iOperation)
      {
          dailyTripService = new DailyTripService();
        return  dailyTripService.DeleteOperation(iOperation);
      }
      public List<DailyTripsDTO> SearchData(DateTime dDailyTrip)
      {
          dailyTripService = new DailyTripService();
          return dailyTripService.SearchData(dDailyTrip);
      }
      public Boolean OperationExist(DateTime dDailyTrip)
      {

          dailyTripService = new DailyTripService();
          return dailyTripService.CheckOperation(dDailyTrip);

      }

    }
}
