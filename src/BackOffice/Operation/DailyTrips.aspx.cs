using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Woc.Book.Base.Presenter; 
 using Woc.Book.Base;

//ErrorHandler
using Woc.Book.ErrorHandler;
using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;

//
using Woc.Book.DailyTrip;
using Woc.Book.DailyTrip.Presenter;
using Woc.Book.DailyTrip.BusinessEntity;
using Woc.Book.DailyTrip.Service;
using Woc.Book.DailyTrip.Constant;
using Woc.Book.Base.BusinessEntity;
namespace WOC.Book.Operation
{
    public partial class DailyTrips : System.Web.UI.Page, IOperationPresenter
    {
        DailyTripPresenter dailyTripPresenter;
        List<DailyTripsDTO> ListSearchData;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dailyTripPresenter = new DailyTripPresenter();
                if (Request.QueryString["opsdate"] != null)
                {
                    SearchDate = Request.QueryString["opsdate"];
                    dailyTripPresenter = new DailyTripPresenter(this);
                    dailyTripPresenter.SearchData();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            dailyTripPresenter = new DailyTripPresenter(this);
            dailyTripPresenter.SearchData();
        }

     

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            dailyTripPresenter = new DailyTripPresenter();
        }


        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            dailyTripPresenter = new DailyTripPresenter();
            //e.Row.Attributes.Add("onkeypress", @"javascript:if (event.keyCode == 13) {__doPostBack('" + gv.UniqueID + "', 'Select$" + e.Row.RowIndex.ToString() + "'); return false; }");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String script = string.Empty;

                TextBox txtStartBusNo = (TextBox)e.Row.FindControl("txtStartBusNo");
                TextBox txtEndBusNo = (TextBox)e.Row.FindControl("txtEndBusNo");
                TextBox txtStartTime = (TextBox)e.Row.FindControl("txtStartTime");
                TextBox txtEndTime = (TextBox)e.Row.FindControl("txtEndTime");
                Label lblRefNo = (Label)e.Row.FindControl("lblRefNo");
                Label lblRemarks = (Label)e.Row.FindControl("lblRemarks");
                Label lblRoute = (Label)e.Row.FindControl("lblRoute");
                Label lblPax = (Label)e.Row.FindControl("lblPax");
                String tripFrom = gv.DataKeys[e.Row.RowIndex].Values[(int) Constant.GvDailyTripKeys.TripFrom].ToString();
                String tripTo = gv.DataKeys[e.Row.RowIndex].Values[(int)Constant.GvDailyTripKeys.TripTo].ToString();
                String tripType = gv.DataKeys[e.Row.RowIndex].Values[(int)Constant.GvDailyTripKeys.TripType].ToString();
                String operationType = gv.DataKeys[e.Row.RowIndex].Values[(int)Constant.GvDailyTripKeys.OperationType].ToString();
                Guid tripID = new Guid(gv.DataKeys[e.Row.RowIndex].Values[(int)Constant.GvDailyTripKeys.TripID].ToString());

                if (!String.IsNullOrEmpty(txtStartBusNo.Text))
                {
                    txtStartBusNo.Enabled = false;
                    txtStartTime.Enabled = false;
                }

                if (!String.IsNullOrEmpty(txtEndBusNo.Text))
                {
                    txtEndBusNo.Enabled = false;
                    txtEndTime.Enabled = false;
                }


                hdnJqueryBus.Value = hdnJqueryBus.Value + " $('#" + txtStartBusNo.ClientID + "').autocomplete('../AutocompleteData/AutocompleteOperation.ashx?category=BusNo&paremeter=" + txtStartBusNo.Text + "');";
                hdnJqueryBus.Value = hdnJqueryBus.Value + " $('#" + txtEndBusNo.ClientID + "').autocomplete('../AutocompleteData/AutocompleteOperation.ashx?category=BusNo&paremeter=" + txtEndBusNo.Text + "');";

                script = @"InsertOperationAjax(window.event,'" + txtStartTime.ClientID + "','" + 
                                                                 txtStartBusNo.ClientID + "','" + 
                                                                 txtEndTime.ClientID + "','" + 
                                                                 txtEndBusNo.ClientID + "'," + "'" + 
                                                                 lblRefNo.Text + "','" + 
                                                                 lblRemarks.Text + "','"+ 
                                                                 lblRoute.Text +"','"+ 
                                                                 lblPax.Text +"','"+
                                                                 txtDate.Text + "','" +
                                                                 tripFrom + "','" +
                                                                 tripTo + "','" +
                                                                 tripType + "','" + 
                                                                 operationType + "','" + 
                                                                 tripID.ToString() + "');";

                txtStartBusNo.Attributes.Add("onkeypress", script);
                txtEndBusNo.Attributes.Add("onkeypress", script);
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                RegisterScript(hdnJqueryBus.Value);
            }
        }

        public void DataBindings()
        {   
            dailyTripPresenter = new DailyTripPresenter();
            btnSearch.Attributes.Add("onclick", "HideDatePicker();");
            lblRecordFound.Text = string.Empty;
        }
        public void SaveData()
        {
            dailyTripPresenter = new DailyTripPresenter();
        }
        public void ClearControl()
        {
            dailyTripPresenter = new DailyTripPresenter();
        }
        public void SearchData()
        {
            try
            {
                dailyTripPresenter = new DailyTripPresenter();
                ListSearchData = new List<DailyTripsDTO>();
                ListSearchData = dailyTripPresenter.SearchData(UtilityController.StringToDate(txtDate.Text));
                gv.DataSource = ListSearchData;
                gv.DataBind();


                rightFrame.Attributes.Add("src", "DailyTripsRFrame.aspx?opsdate=" + txtDate.Text);
                lblRecordFound.Text = String.Format(Woc.Book.DailyTrip.Constant.Constant.recordFoundMessage, gv.Rows.Count);

                if (gv.Rows.Count > 0)
                {
                    btnPrint.Disabled = false;
                }
                else
                {
                    btnPrint.Disabled = true;
                }
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Staff";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblRecordFound.Text = Constant.recordFoundMessage;
            }

        }
        public void GetData(String Id)
        {
            dailyTripPresenter = new DailyTripPresenter();
        }
        public void UpdateData()
        {
            dailyTripPresenter = new DailyTripPresenter();
        }
        public void DeleteData()
        {
            DailyTripsDTO dailyTripsDTO = new DailyTripsDTO();
            dailyTripPresenter = new DailyTripPresenter();
            dailyTripsDTO.OperationDate = UtilityController.StringToDate(txtDate.Text);
            dailyTripPresenter.DeleteData(dailyTripsDTO);
        }


        private void RegisterScript(String busJquery)
        {
            if (!ClientScript.IsClientScriptBlockRegistered("AutoComplete"))
            {
                StringBuilder jquery = new StringBuilder();
                jquery.Append("<script language='javascript' type='text/javascript'> ");
                jquery.Append(" $(document).ready(function () { ");
                jquery.Append(busJquery);
                jquery.Append(" });");
                jquery.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "AutoComplete", jquery.ToString());
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            dailyTripPresenter = new DailyTripPresenter(this);
            dailyTripPresenter.DeleteData();
            if (Request.QueryString["opsdate"] != null)
            {
                SearchDate = Request.QueryString["opsdate"];
            }
            dailyTripPresenter = new DailyTripPresenter(this);
            dailyTripPresenter.SearchData();
        }

        private string SearchDate
        {
            get{ return txtDate.Text; }
            set { txtDate.Text = value; }
        }

    }
}