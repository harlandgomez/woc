using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.Presenter;
using Woc.Book.DailyTrip;
using Woc.Book.DailyTrip.BusinessEntity;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.DailyTrip.Presenter
{
    public class DailyTripPresenter : IOperationPresenter
    {
       IOperationPresenter iOperationPresenter;
       DailyTripController dailyTripController;
       public DailyTripPresenter()
       { 

       }
       public DailyTripPresenter(IOperationPresenter iOperation)
        {
            iOperationPresenter = iOperation; 
        
        }
       public void DataBindings()
          {

          }
       public void SaveData()
        {

           
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

           DailyTripController dailyTripController = new DailyTripController();

           return dailyTripController.DeleteData(iOperation);
       }
       public List<DailyTripsDTO> SearchData(DateTime dDailyTrip)
       {
           DailyTripController dailyTripController = new DailyTripController();

           return dailyTripController.SearchData(dDailyTrip);
       }
       public void SaveStartData(IOperation iOperation)
       {
           dailyTripController = new DailyTripController();
           dailyTripController.SaveStartData(iOperation);
         
       }
       public void SaveEndData(IOperation iOperation)
       {
           dailyTripController = new DailyTripController();
           dailyTripController.SaveEndData(iOperation);

       }
        public void SaveData( List<DailyTripsDTO> listDailyTripsDTO)
        {

            dailyTripController = new DailyTripController();
            dailyTripController.SaveData(listDailyTripsDTO);

        }
       public Boolean OperationExist(DateTime dDailyTrip)
       {

           dailyTripController = new DailyTripController();
         return  dailyTripController.OperationExist(dDailyTrip);
       
       }
    }
}
