using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.Presenter;
using Woc.Book.DailyTrip;
using Woc.Book.DailyTrip.BusinessEntity;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.DailyTripRFrame.Presenter
{
    public class DailyTripRFramePresenter : IOperationPresenter
    {
        IOperationPresenter iOperationPresenter;
        DailyTripRFrameController dailyTripController;
        public DailyTripRFramePresenter()
        {

        }
        public DailyTripRFramePresenter(IOperationPresenter iOperation)
        {
            iOperationPresenter = iOperation;

        }

        public List<DailyTripsDTO> GetHeadersData()
        {
            dailyTripController = new DailyTripRFrameController();
            return dailyTripController.GetHeadersData();
        }

        public List<DriverDetailDTO> GetDetailData(IOperation iOperation)
        {
            dailyTripController = new DailyTripRFrameController();
            return dailyTripController.GetDetailData(iOperation);
        }

        public String DeleteData(IOperation iOperation)
        {
            dailyTripController = new DailyTripRFrameController();
            return dailyTripController.DeleteData(iOperation);
        }

        public void SaveData(IOperation iOperation)
        {
            dailyTripController = new DailyTripRFrameController();
            dailyTripController.SaveData(iOperation);
        }

        public String UpdateData(IOperation iOperation)
        {
            dailyTripController = new DailyTripRFrameController();
            return dailyTripController.UpdateData(iOperation);
        }

        public void DataBindings()
        {
            iOperationPresenter.DataBindings();
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
           iOperationPresenter.UpdateData();
        }
        public void DeleteData()
        {

        }
    }
}
