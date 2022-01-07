using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Woc.Book.Base.Presenter; 
 using Woc.Book.Base;

//ErrorHandler
using Woc.Book.ErrorHandler;
using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;

//BusDriverStatus
using Woc.Book.BusDriverStatus;
using Woc.Book.BusDriverStatus.Presenter;
using Woc.Book.BusDriverStatus.BusinessEntity;
using Woc.Book.BusDriverStatus.Service;
using Woc.Book.BusDriverStatus.Constant;

using Woc.Book.Base.Constant;
using Woc.Book.Base.BusinessEntity;

namespace WOC.Book.Operation
{
    public partial class DriverBusStatus : System.Web.UI.Page, IOperationPresenter
    {

        BusDriverStatusPresenter busDriverStatusPresenter;
        TypeTran typeTran;
        #region Interface
        public void DataBindings()
        {
            //busDriverStatusPresenter = new BusDriverStatusPresenter();
        }
        public void SaveData()
        {
            try
            {
                
                if (Mode)
                {
                    UserPresenter userPresenter = new UserPresenter();
                    busDriverStatusPresenter = new BusDriverStatusPresenter();
                    DriverBuses busDriverStatuses = new DriverBuses();
                    busDriverStatuses.Driver = txtDriverStatus.Text;
                    busDriverStatuses.OperationDate = UtilityController.StringToDate(txtDriverDateStatus.Text);
                    busDriverStatuses.StartTime = busDriverStatuses.OperationDate.AddHours(Convert.ToInt32(txtDriverTimeFrom.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtDriverTimeFrom.Text.Substring(2, 2)));
                    busDriverStatuses.EndTime = busDriverStatuses.OperationDate.AddHours(Convert.ToInt32(txtDriverTimeTo.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtDriverTimeTo.Text.Substring(2, 2)));
                    busDriverStatuses.Status = txtNewDriverStatus.Text;
                    busDriverStatuses.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                    busDriverStatuses.CreatedDate = DateTime.Now;
                    busDriverStatuses.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                    busDriverStatuses.UpdatedDate = DateTime.Now;
                    busDriverStatusPresenter.SaveData(busDriverStatuses, Woc.Book.BusDriverStatus.Constant.Constant.StatusOptions.Driver);
                    lblDriverMessage.Text = Woc.Book.Base.Constant.Constant.MessageSaved;
                    busDriverStatuses.TypeMode = Woc.Book.BusDriverStatus.Constant.Constant.driver;
                }
                else
                {
                    UserPresenter userPresenter = new UserPresenter();
                    busDriverStatusPresenter = new BusDriverStatusPresenter();
                    DriverBuses busDriverStatuses = new DriverBuses();
                    busDriverStatuses.TypeMode = Woc.Book.BusDriverStatus.Constant.Constant.bus;
                    busDriverStatuses.BusDateStatus = UtilityController.StringToDate(txtBusDateStatus.Text);
                    busDriverStatuses.BusNo = txtBusNo.Text;
                    busDriverStatuses.OperationDate = UtilityController.StringToDate(txtBusDateStatus.Text);
                    busDriverStatuses.StartTime = busDriverStatuses.OperationDate.AddHours(Convert.ToInt32(txtBusTimeFrom.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtBusTimeFrom.Text.Substring(2, 2)));
                    busDriverStatuses.EndTime = busDriverStatuses.OperationDate.AddHours(Convert.ToInt32(txtBusTimeTo.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtBusTimeTo.Text.Substring(2, 2)));
                    busDriverStatuses.BusStatus = txtBusStatus.Text;
                    busDriverStatuses.PO = txtPoNumber.Text;
                    busDriverStatuses.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                    busDriverStatuses.CreatedDate = DateTime.Now;
                    busDriverStatuses.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                    busDriverStatuses.UpdatedDate = DateTime.Now;
                    busDriverStatusPresenter.SaveData(busDriverStatuses, Woc.Book.BusDriverStatus.Constant.Constant.StatusOptions.Bus);
                    lblBusMessage.Text = Woc.Book.Base.Constant.Constant.MessageSaved;

                }
            }
            catch (Exception ex)
            {
                lblSystemError.Visible = true;
                lblSystemError.Text = "#Error Message: " + ex.Message.ToString();
            }

        }
        public void ClearControl()
        {
            txtDriverStatus.Text = string.Empty;
            txtDriverDateStatus.Text = string.Empty;
            txtDriverTimeTo.Text = string.Empty;
            txtDriverTimeFrom.Text = string.Empty;
            txtNewDriverStatus.Text = string.Empty;
            txtBusNo.Text = string.Empty;
            txtBusDateStatus.Text = string.Empty;
            txtBusTimeFrom.Text = string.Empty;
            txtBusTimeTo.Text = string.Empty;
            txtBusStatus.Text = string.Empty;
            txtPoNumber.Text = string.Empty;
            lblSystemError.Text = string.Empty;

        }
        public void SearchData()
        {
            try
            {
                if (typeTran == TypeTran.Driver)
                {
                    busDriverStatusPresenter = new BusDriverStatusPresenter();
                    DriverBuses busDriverStatuses = new DriverBuses();
                    if (this.txtDriverBusSearchDateFrom.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.FromDate = UtilityController.StringToDate(this.txtDriverBusSearchDateFrom.Text);
                    }
                    if (this.txtDriverBusSearchDateTo.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.ToDate = UtilityController.StringToDate(this.txtDriverBusSearchDateTo.Text);
                    }
                    if (this.txtDriverSearchTimeFrom.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.StartTime = busDriverStatuses.FromDate.AddHours(Convert.ToInt32(this.txtDriverSearchTimeFrom.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(this.txtDriverSearchTimeFrom.Text.Substring(2, 2)));
                    }
                    if (this.txtDriverSearchTimeTo.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.EndTime = busDriverStatuses.ToDate.AddHours(Convert.ToInt32(this.txtDriverSearchTimeTo.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(this.txtDriverSearchTimeTo.Text.Substring(2, 2)));
                    }
                    if (txtDriverBusSearchDriver.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.Driver = txtDriverBusSearchDriver.Text.Trim();
                    }

                    if (txtDriverBusSearchBusNo.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.BusNo = txtDriverBusSearchBusNo.Text.Trim();
                    }
                    busDriverStatuses.TypeMode = "BusDriver";
                    lblSearchDriver.Visible = false;
                    gv.DataSource = busDriverStatusPresenter.SearchData(busDriverStatuses);

                    gv.DataBind();

                }
                else if (typeTran == TypeTran.COS)
                {
                    busDriverStatusPresenter = new BusDriverStatusPresenter();
                    DriverBuses busDriverStatuses = new DriverBuses();
                    if (this.txtCOSDateFrom.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.FromDate = UtilityController.StringToDate(this.txtCOSDateFrom.Text);
                    }
                    if (this.txtCOSDateTo.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.ToDate = UtilityController.StringToDate(this.txtCOSDateTo.Text);
                    }
                    if (this.txtCOSTimeFrom.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.StartTime = busDriverStatuses.FromDate.AddHours(Convert.ToInt32(this.txtCOSTimeFrom.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(this.txtCOSTimeFrom.Text.Substring(2, 2)));
                    }
                    if (this.txtCOSTimeTo.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.EndTime = busDriverStatuses.ToDate.AddHours(Convert.ToInt32(this.txtCOSTimeTo.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(this.txtCOSTimeTo.Text.Substring(2, 2)));
                    }
                    if (txtCOSDriver.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.Driver = txtCOSDriver.Text.Trim();
                    }

                    if (txtCOSBusDriver.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.BusNo = txtCOSBusDriver.Text.Trim();
                    }
                    busDriverStatuses.TypeMode = "COS";
                    lblCOSMessage.Visible = false;
                    gvCOS.DataSource = busDriverStatusPresenter.SearchCOSData(busDriverStatuses);

                    gvCOS.DataBind();
                }



            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "BusAndDriver";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = ex.Message.ToString();

            }

        }
        public void GetData(String Id)
        {
            //busDriverStatusPresenter = new BusDriverStatusPresenter();
        }
        public void UpdateData()
        {
            //busDriverStatusPresenter = new BusDriverStatusPresenter();
        }
        public void DeleteData()
        {
            //DailyTripsDTO dailyTripsDTO = new DailyTripsDTO();
            //dailyTripPresenter = new DailyTripPresenter();
            //dailyTripsDTO.OperationDate = UtilityController.StringToDate(txtDate.Text);
            //dailyTripPresenter.DeleteData(dailyTripsDTO);
        }
        #endregion 
        #region DriverBUs_Control
            protected void btnAddDriverStatus_Click(object sender, EventArgs e)
         {

            try
            {
                Mode = true;
                busDriverStatusPresenter = new BusDriverStatusPresenter(this);
                busDriverStatusPresenter.SaveData();
                if (!lblDriverMessage.Text.Contains("unsuccessfully"))
                {
                    busDriverStatusPresenter = new BusDriverStatusPresenter(this);
                    busDriverStatusPresenter.ClearControl();
                    lblSystemError.Text = String.Empty;
                }

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "BusDriverStatus";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = ex.Message.ToString();
            }

        }

            protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                }

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "BusDriverStatus";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = ex.Message.ToString();
            }

        }

            protected void btnAddDriverPanel_Click(object sender, EventArgs e)
            {
                pnlAddDriver.Visible = true;
                pnlAddBus.Visible = false;

            }

            protected void btnAddBusPanel_Click(object sender, EventArgs e)
            {
                pnlAddDriver.Visible = false;
                pnlAddBus.Visible = true;
            }

            protected void btnAddBusStatus_Click(object sender, EventArgs e)
            {
                Mode = false;
                busDriverStatusPresenter = new BusDriverStatusPresenter(this);
                busDriverStatusPresenter.SaveData();
                if (!lblBusMessage.Text.Contains("unsuccessfully"))
                {
                    busDriverStatusPresenter = new BusDriverStatusPresenter(this);
                    busDriverStatusPresenter.ClearControl();
                    lblSystemError.Text = String.Empty;
                }
            }

            protected void btnSearchDriver_Click(object sender, EventArgs e)
            {
                typeTran = TypeTran.Driver;
                busDriverStatusPresenter = new BusDriverStatusPresenter(this);
                busDriverStatusPresenter.SearchData();
                typeTran = TypeTran.Null;
            }
            protected void btnSearchCOS_Click(object sender, EventArgs e)
            {
                typeTran = TypeTran.COS;
                busDriverStatusPresenter = new BusDriverStatusPresenter(this);
                busDriverStatusPresenter.SearchData();
                typeTran = TypeTran.Null;
            }

        #endregion
       
        #region Properties
            Boolean mode;

            public Boolean Mode
            {
                get
                {
                    return mode;
                }
                set
                {
                    mode = value;
                }
            }
            public enum TypeTran
            {
                Bus = 1,
                Driver = 2,
                COS = 3,
                Null = 4
            }

         #endregion

            

           

           
            
    }
}