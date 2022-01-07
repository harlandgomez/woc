using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.BusDriverStatus.BusinessEntity;
using Woc.Book.BusDriverStatus.Service;
using Woc.Book.Base;
using Woc.Book.Base.BusinessEntity;


namespace Woc.Book.BusDriverStatus
{
 internal class BusDriverStatusController
    {
      BusDriverStatusService busDriverStatusService;
      public BusDriverStatusController()
      { 
      
      }
      public void SaveStartData(IOperation iOperation)
      {
          busDriverStatusService = new BusDriverStatusService();
          busDriverStatusService.SaveStartData(iOperation);
      }
      public void SaveEndData(IOperation iOperation)
      {
          busDriverStatusService = new BusDriverStatusService();
          busDriverStatusService.SaveEndData(iOperation);
      }
      public void SaveData(IOperation iOperation, Constant.Constant.StatusOptions statusType)
      {
          try
          {
             
              busDriverStatusService = new BusDriverStatusService();
              if (Constant.Constant.StatusOptions.Bus == statusType)
              {
                  busDriverStatusService.SaveBusData(iOperation);
              }
              else  if (Constant.Constant.StatusOptions.Driver == statusType)
              {                
                  busDriverStatusService.SaveDriverData(iOperation);
              }
             
          }
          catch
          {
              throw;
          }
      }
      public String UpdateData(IOperation iOperation)
      {
          return string.Empty;
         
      }

      public String DeleteData(IOperation iOperation)
      {
          busDriverStatusService = new BusDriverStatusService();
          return busDriverStatusService.DeleteOperation(iOperation);
      }
      public List<DriverBuses> SearchData(IOperation iOperation)
      {
          String StrBus;
          String StrDriver;
          try
          {
              busDriverStatusService = new BusDriverStatusService();
              StrBus = "select BusNo,'N/A' as Driver,BusStatus as [Status],BusDateStatus as  DateStatus from BusStatus";
              StrDriver = "Select 'NA' as BusNo, DriverStatus As Driver,[Status],DriverDateStatus as DateStatus from   DriverStatus";

              DriverBuses driverBuses = new DriverBuses();
              driverBuses = (DriverBuses)iOperation;

             
                  if (driverBuses.StartTime != Convert.ToDateTime("1/1/0001 12:00:00 AM") && driverBuses.EndTime != Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                  {
                      StrBus = StrBus + " where TimeFrom >= '" + driverBuses.StartTime.ToString() + "' and TimeTo <= '" + driverBuses.EndTime.ToString() + "'";
                  }
                  if (driverBuses.BusNo != null || driverBuses.BusNo != string.Empty)
                  {
                      if (driverBuses.StartTime != Convert.ToDateTime("1/1/0001 12:00:00 AM") && driverBuses.EndTime != Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                      {
                          StrBus = StrBus + " and  BusNo = '" + driverBuses.BusNo + "'";

                      }

                      else
                      {
                          StrBus = StrBus + " Where BusNo = '" + driverBuses.BusNo + "'";

                      }
                  }

                  if (driverBuses.StartTime != Convert.ToDateTime("1/1/0001 12:00:00 AM") && driverBuses.EndTime != Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                  {
                      StrDriver = StrDriver + " where TimeFrom >= '" + driverBuses.StartTime.ToString() + "' and TimeTo <= '" + driverBuses.EndTime.ToString() + "'";
                  }
                  if (driverBuses.Driver != null || driverBuses.Driver != string.Empty)
                  {
                      if (driverBuses.StartTime != Convert.ToDateTime("1/1/0001 12:00:00 AM") && driverBuses.EndTime != Convert.ToDateTime("1/1/0001 12:00:00 AM"))
                      {
                          StrDriver = StrDriver + " and  DriverStatus = '" + driverBuses.Driver + "'";

                      }

                      else
                      {
                          StrDriver = StrDriver + " Where DriverStatus = '" + driverBuses.Driver + "'";

                      }
                  }

                  return busDriverStatusService.SearchData(StrBus, StrDriver);  
          }
          catch
          {
              throw;
          }
      }
      public List<DriverBuses> SearchCOSData(IOperation iOperation)
      {
         
          String StrCOS;
          try
          {
              busDriverStatusService = new BusDriverStatusService();
              StrCOS = "SELECT DISTINCT dbo.Operation.OperationDate, dbo.OperationDetail.BusNo, dbo.OperationDetail.DriverName, dbo.OperationDetail.Route, dbo.OperationDetail.Customer," +
                      "dbo.OperationDetail.Contact, (SELECT Top 1  CashOrder from ADHOC where Adhoc.AdhocCode = dbo.Operation.RefNo) AS Amount FROM dbo.Operation INNER JOIN dbo.OperationDetail ON dbo.Operation.OperationID = dbo.OperationDetail.OperationID";
           
              DriverBuses driverBuses = new DriverBuses();
              driverBuses = (DriverBuses)iOperation;

              if (driverBuses.StartTime != Convert.ToDateTime("1/1/0001 12:00:00 AM") && driverBuses.EndTime != Convert.ToDateTime("1/1/0001 12:00:00 AM"))
              {
                  StrCOS = StrCOS + " where dbo.Operation.OperationDate >= '" + driverBuses.StartTime.ToString() + "' and dbo.Operation.OperationDate <= '" + driverBuses.EndTime.ToString() + "'";
              }
              if (!string.IsNullOrEmpty(driverBuses.Driver))
              {
                  if (driverBuses.StartTime != Convert.ToDateTime("1/1/0001 12:00:00 AM") && driverBuses.EndTime != Convert.ToDateTime("1/1/0001 12:00:00 AM") && driverBuses.Driver != string.Empty && driverBuses.Driver != null)
                  {
                      StrCOS = StrCOS + " and  dbo.OperationDetail.DriverName = '" + driverBuses.Driver + "'";

                  }

                  else
                  {
                      StrCOS = StrCOS + " Where dbo.OperationDetail.DriverName = '" + driverBuses.Driver + "'";

                  }
              }
              if (!string.IsNullOrEmpty(driverBuses.BusNo))
              {
                  if (driverBuses.StartTime != Convert.ToDateTime("1/1/0001 12:00:00 AM") && driverBuses.EndTime != Convert.ToDateTime("1/1/0001 12:00:00 AM") && driverBuses.BusNo != string.Empty)
                  {
                      StrCOS = StrCOS + " and  dbo.OperationDetail.BusNo = '" + driverBuses.BusNo + "'";

                  }

                  else
                  {
                      StrCOS = StrCOS + " Where dbo.OperationDetail.BusNo  = '" + driverBuses.BusNo + "'";

                  }
              }
                  

                  return busDriverStatusService.SearchCOSData(StrCOS);
            
            
          }
          catch
          {
              throw;
          }
      }
      public Boolean OperationExist(DateTime dDailyTrip)
      {

          busDriverStatusService = new BusDriverStatusService();
          return busDriverStatusService.CheckOperation(dDailyTrip);

      }

    }
}
