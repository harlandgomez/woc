using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Woc.Book.Common.Presenter;

//ErrorHandler
using Woc.Book.ErrorHandler;
using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;

//BusDriverStatus
using Woc.Book.BusDriverStatus;
using Woc.Book.BusDriverStatus.Presenter;
using Woc.Book.BusDriverStatus.BusinessEntity;
using Woc.Book.BusDriverStatus.Service;

using Woc.Book.Common.Constant;
using Woc.Book.Common.BusinessEntity;
namespace WOC.Book.Operation
{
    public partial class BusAndDriver : System.Web.UI.Page, IOperationPresenter
    {
        BusDriverStatusPresenter busDriverStatusPresenter;
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

        #region Driver_Control
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

       
        protected void btnSearchDriver_Click(object sender, EventArgs e)
        {
            Mode = true;
            busDriverStatusPresenter = new BusDriverStatusPresenter(this);
            busDriverStatusPresenter.SearchData();

        }
        #endregion
        #region Interface
            public void DataBindings()
            {
                busDriverStatusPresenter = new BusDriverStatusPresenter();
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
                        busDriverStatuses.OperationDate = Convert.ToDateTime(txtDriverDateStatus.Text);
                        busDriverStatuses.StartTime = busDriverStatuses.OperationDate.AddHours(Convert.ToInt32(txtDriverTimeFrom.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtDriverTimeFrom.Text.Substring(2, 2)));
                        busDriverStatuses.EndTime = busDriverStatuses.OperationDate.AddHours(Convert.ToInt32(txtDriverTimeTo.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtDriverTimeTo.Text.Substring(2, 2)));
                        busDriverStatuses.Status = txtNewDriverStatus.Text;
                        busDriverStatuses.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                        busDriverStatuses.CreatedDate = DateTime.Now;
                        busDriverStatuses.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                        busDriverStatuses.UpdatedDate = DateTime.Now;
                        busDriverStatusPresenter.SaveData(busDriverStatuses);
                        lblDriverMessage.Text = Constant.MessageSaved;
                        busDriverStatuses.TypeMode = Woc.Book.BusDriverStatus.Constant.Constant.driver;
                    }
                    else
                    {
                        UserPresenter userPresenter = new UserPresenter();
                        busDriverStatusPresenter = new BusDriverStatusPresenter();
                        DriverBuses busDriverStatuses = new DriverBuses();
                        busDriverStatuses.TypeMode = Woc.Book.BusDriverStatus.Constant.Constant.bus;
                        busDriverStatuses.BusStatus = txtBusStatus.Text;
                        busDriverStatuses.OperationDate = Convert.ToDateTime(txtBusDateStatus.Text);
                        busDriverStatuses.StartTime = busDriverStatuses.OperationDate.AddHours(Convert.ToInt32(txtBusTimeFrom.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtBusTimeFrom.Text.Substring(2, 2)));
                        busDriverStatuses.EndTime = busDriverStatuses.OperationDate.AddHours(Convert.ToInt32(txtBusTimeTo.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtBusTimeTo.Text.Substring(2, 2)));
                        busDriverStatuses.Status = txtNewBusStatus.Text;
                        busDriverStatuses.PoNumber = txtPoNumber.Text;
                        busDriverStatuses.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                        busDriverStatuses.CreatedDate = DateTime.Now;
                        busDriverStatuses.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                        busDriverStatuses.UpdatedDate = DateTime.Now;
                        busDriverStatusPresenter.SaveData(busDriverStatuses);
                        lblBusMessage.Text = Constant.MessageSaved;
                    
                    }
                }
                catch(Exception ex)
                {
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

            }
            public void SearchData()
            {
                try
                {
                    busDriverStatusPresenter = new BusDriverStatusPresenter();
                    DriverBuses busDriverStatuses = new DriverBuses();
                    if (this.txtDriverSearchDateFrom.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.FromDate = Convert.ToDateTime(this.txtDriverSearchDateFrom.Text);
                    }
                    if (this.txtDriverSearchDateTo.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.ToDate = Convert.ToDateTime(this.txtDriverSearchDateTo.Text);
                    }
                    if (this.txtDriverSearchTimeFrom.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.StartTime = busDriverStatuses.FromDate.AddHours(Convert.ToInt32(this.txtDriverSearchTimeFrom.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(this.txtDriverSearchTimeFrom.Text.Substring(2, 2)));
                    }
                    if (this.txtDriverSearchTimeTo.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.EndTime = busDriverStatuses.ToDate.AddHours(Convert.ToInt32(this.txtDriverSearchTimeTo.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(this.txtDriverSearchTimeTo.Text.Substring(2, 2)));
                    }
                    if (txtDriverSearchDriver.Text.Trim() != string.Empty)
                    {
                        busDriverStatuses.Driver = txtDriverSearchDriver.Text.Trim();
                    }
                    lblSearchDriver.Visible = false;
                    gv.DataSource = busDriverStatusPresenter.SearchData(busDriverStatuses);

                    gv.DataBind();


                  


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

                    lblSearchDriver.Visible = true;
                    lblSearchDriver.Text = ex.Message;
                    lblSystemError.Text = ex.Message.ToString();
                   
                }

            }
            public void GetData(String Id)
            {
                busDriverStatusPresenter = new BusDriverStatusPresenter();
            }
            public void UpdateData()
            {
                busDriverStatusPresenter = new BusDriverStatusPresenter();
            }
            public void DeleteData()
            {
                //DailyTripsDTO dailyTripsDTO = new DailyTripsDTO();
                //dailyTripPresenter = new DailyTripPresenter();
                //dailyTripsDTO.OperationDate = Convert.ToDateTime(txtDate.Text);
                //dailyTripPresenter.DeleteData(dailyTripsDTO);
            }
            #endregion 
        #region Bus_control
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

        #endregion

    }
      
}