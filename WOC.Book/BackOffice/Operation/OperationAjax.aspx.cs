using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Woc.Book.Base.Presenter; 
 using Woc.Book.Base;

//
using Woc.Book.DailyTripRFrame;
using Woc.Book.DailyTripRFrame.Presenter;
using Woc.Book.DailyTrip.BusinessEntity;
using Woc.Book.DailyTrip.Service;
using Woc.Book.Base.Constant;
using Woc.Book.DailyTrip.Presenter;

namespace WOC.Book.Operation
{
    public partial class OperationAjax : System.Web.UI.Page
    {
        DailyTripRFramePresenter dailyTripDetailPresenter;
        DailyTripPresenter dailyTripPresenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            String returnToClient = string.Empty;
            String action = Request.QueryString["action"].ToString().ToLower();

            if (Request.QueryString["module"].ToString().ToLower() == "operation")
            {
                switch (action)
                {
                    case "updateroute":
                        returnToClient = UpdateData();
                        break;
                    case "saveroute":
                        returnToClient = SaveData();
                        break;
                    case "saveoperation":
                        returnToClient = SaveOperation();
                        break;
                    default:
                        returnToClient = DateTime.Now.ToString();
                        break;
                }
            }

            Response.Expires = -1;
            Response.ContentType = "text/plain";
            Response.Write(returnToClient);
            Response.End();

        }

        private String UpdateData()
        {

            DriverDetailDTO driverDTO = new DriverDetailDTO();
            string fieldValue = Request.QueryString["value"].ToString();
            DateTime opsDate = UtilityController.StringToDate(Request.QueryString["opsdate"]);
            driverDTO.TripTime = UtilityController.StringToDate(Constant.MinimumDate);

            switch (Request.QueryString["fieldname"].ToString().ToLower())
            {
                case "triptime":
                    driverDTO.TripTime = opsDate.AddHours(Convert.ToDouble(fieldValue.Substring(0,2))).AddMinutes(Convert.ToDouble(fieldValue.Substring(2,2)));
                    driverDTO.FieldID = 1;
                    break;
                case "route":
                    driverDTO.DriverRoute = fieldValue.Trim();
                    driverDTO.FieldID = 2;
                    break;
                case "agent":
                    driverDTO.Customer = fieldValue.Trim();
                    driverDTO.FieldID = 3;
                    break;
                case "person":
                    driverDTO.Person = fieldValue.Trim();
                    driverDTO.FieldID = 4;
                    break;
                case "contact":
                    driverDTO.Contact = fieldValue.Trim();
                    driverDTO.FieldID = 5;
                    break;
            }
            driverDTO.OperationDetailID = new Guid(Request.QueryString["id"].ToString());
            dailyTripDetailPresenter = new DailyTripRFramePresenter();
            return dailyTripDetailPresenter.UpdateData(driverDTO);
        }

        private String SaveData()
        {
            try
            {
                DriverDetailDTO driverDTO = new DriverDetailDTO();
                DateTime opsDate = UtilityController.StringToDate(Request.QueryString["opsdate"]);
                string tripTime = Request.QueryString["triptime"].ToString();

                driverDTO.TripTime = opsDate.AddHours(Convert.ToDouble(tripTime.Substring(0, 2))).AddMinutes(Convert.ToDouble(tripTime.Substring(2, 2)));
                driverDTO.DriverRoute = Request.QueryString["route"].ToString();
                driverDTO.Customer = Request.QueryString["agent"].ToString();
                driverDTO.Person = Request.QueryString["person"].ToString();
                driverDTO.Contact = Request.QueryString["contact"].ToString();

                driverDTO.OperationID = new Guid(Request.QueryString["opsid"].ToString());
                driverDTO.BusNo = Request.QueryString["busno"].ToString();
                driverDTO.DriverName = Request.QueryString["driver"].ToString();
                driverDTO.DriverContact = Request.QueryString["contactno"].ToString();

                dailyTripDetailPresenter = new DailyTripRFramePresenter();
                dailyTripDetailPresenter.SaveData(driverDTO);
                return Woc.Book.Base.Constant.Constant.MessageSaved;
            }
            catch
            {
                return Woc.Book.Base.Constant.Constant.MessageUnSaved;
            }

        }

        private String SaveOperation()
        {
            try
            {
                dailyTripPresenter = new DailyTripPresenter();
                DailyTripsDTO dailyTripsDTO = new DailyTripsDTO();

                String startstatus = Request.QueryString["startstatus"];
                String endstatus = Request.QueryString["endstatus"];

                dailyTripsDTO.OperationDate = UtilityController.StringToDate(Request.QueryString["searchdate"]);
                dailyTripsDTO.StartTime = GetTimeByOpDate(dailyTripsDTO.OperationDate, Request.QueryString["starttime"]);
                dailyTripsDTO.StartBusNo = Request.QueryString["startbusno"];
                dailyTripsDTO.EndTime = GetTimeByOpDate(dailyTripsDTO.OperationDate, Request.QueryString["endtime"]);
                dailyTripsDTO.EndBusNo = Request.QueryString["endbusno"];
                dailyTripsDTO.RefNo = Request.QueryString["refno"];
                dailyTripsDTO.Remarks = Request.QueryString["remarks"];
                dailyTripsDTO.Route = Request.QueryString["route"];
                dailyTripsDTO.Pax = Request.QueryString["pax"];
                dailyTripsDTO.TripFrom = Request.QueryString["tripfrom"];
                dailyTripsDTO.TripTo = Request.QueryString["tripto"];
                dailyTripsDTO.TripType = Request.QueryString["triptype"];
                dailyTripsDTO.OperationType = Request.QueryString["operationType"];
                dailyTripsDTO.TripID = new Guid(Request.QueryString["tripID"]);

                if (dailyTripsDTO.StartTime != DateTime.MinValue && !String.IsNullOrEmpty(dailyTripsDTO.StartBusNo) && startstatus == "0")
                {
                    dailyTripPresenter.SaveStartData(dailyTripsDTO);
                }

                if (dailyTripsDTO.EndTime != DateTime.MinValue && !String.IsNullOrEmpty(dailyTripsDTO.EndBusNo) && endstatus == "0")
                {
                    dailyTripPresenter.SaveEndData(dailyTripsDTO);
                }

                if (!String.IsNullOrEmpty(dailyTripsDTO.EndBusNo) && !String.IsNullOrEmpty(dailyTripsDTO.StartBusNo) && startstatus == "0" && endstatus == "0")
                {
                    return "1";
                }
                else if (!String.IsNullOrEmpty(dailyTripsDTO.StartBusNo) && startstatus == "0")
                {
                    return "2";
                }
                else if (!String.IsNullOrEmpty(dailyTripsDTO.EndBusNo) && endstatus == "0")
                {
                    return "0";
                }
                else
                {
                    return "99";
                }
                
            }
            catch
            {
                return Woc.Book.Base.Constant.Constant.MessageUnSaved;
            }
        }

#region Helper Methods
        private DateTime GetTimeByOpDate(DateTime operationDate, String paramTime)
        {
            DateTime returnTime = DateTime.MinValue;
            if (paramTime != String.Empty)
            {
                returnTime = operationDate.AddHours(Convert.ToInt32(paramTime.Substring(0, 2)));
                returnTime = returnTime.AddMinutes(Convert.ToInt32(paramTime.Substring(2, 2)));
            }
            return returnTime;
        }


#endregion

    }
}