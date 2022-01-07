using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Text;

using Woc.Book.Base.Presenter; 
 using Woc.Book.Base;
using Woc.Book.Base.Constant;
//ErrorHandler
using Woc.Book.ErrorHandler;
using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;

//
using Woc.Book.DailyTrip;
using Woc.Book.DailyTripRFrame.Presenter;
using Woc.Book.DailyTrip.BusinessEntity;
using Woc.Book.DailyTrip.Service;
namespace WOC.Book.Operation
{
    public partial class DailyTripsRFrame : System.Web.UI.Page, IOperationPresenter
    {
        DailyTripRFramePresenter dailyTripPresenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dailyTripPresenter = new DailyTripRFramePresenter(this);
                dailyTripPresenter.DataBindings();
            }
        }

        protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                GridView gv = (GridView)e.Item.FindControl("gv");
                Label lbl = (Label)e.Item.FindControl("lblBusNo");
                HiddenField hdnSubcon = (HiddenField)e.Item.FindControl("hdnSubcon");

                if (gv != null)
                {
                    dailyTripPresenter = new DailyTripRFramePresenter();
                    DailyTripsDTO dailyDTO = new DailyTripsDTO();

                    dailyDTO.BusNo = lbl.Text.Trim();

                    if (Request.QueryString["opsdate"] != null && dailyDTO.BusNo != null)
                    {
                        dailyDTO.OperationDate = UtilityController.StringToDate(Request.QueryString["opsdate"]);
                        dailyDTO.IsSubcon = Convert.ToInt16(hdnSubcon.Value);
                        gv.Width = Unit.Pixel(430);
                        gv.DataSource = dailyTripPresenter.GetDetailData(dailyDTO);
                        gv.DataBind();
                    }
                }
            }
        }

        public void DataBindings()
        {
            if (Request.QueryString["opsdate"] != null)
            {
                dailyTripPresenter = new DailyTripRFramePresenter();
                rpt.DataSource = dailyTripPresenter.GetHeadersData();
                rpt.DataBind();
            }

        }
        public void SaveData()
        {

        }
        public void ClearControl()
        {

        }
        public void SearchData()
        {

        }
        public void GetData(String Id)
        {

        }
        public void UpdateData()
        {

        }
        public void DeleteData()
        {

        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HiddenField hdnId = (HiddenField)e.Row.Cells[(int)Constant.gridViewIndexOperationDetail.Route].Controls[0].FindControl("hdnId");
                    TextBox txtPickup = (TextBox)e.Row.Cells[(int)Constant.gridViewIndexOperationDetail.TripTime].Controls[0].FindControl("txtPickup");
                    TextBox txtRoute = (TextBox)e.Row.Cells[(int)Constant.gridViewIndexOperationDetail.Route].Controls[1].FindControl("txtRoute");
                    TextBox txtAgent = (TextBox)e.Row.Cells[(int)Constant.gridViewIndexOperationDetail.Agent].Controls[0].FindControl("txtAgent");
                    TextBox txtPerson = (TextBox)e.Row.Cells[(int)Constant.gridViewIndexOperationDetail.Person].Controls[0].FindControl("txtPerson");
                    TextBox txtContact = (TextBox)e.Row.Cells[(int)Constant.gridViewIndexOperationDetail.Contact].Controls[0].FindControl("txtContact");

                    String opsDate = Request.QueryString["opsdate"].ToString();
                    Guid operationDetailID = new Guid(hdnId.Value);

                    if (operationDetailID != Guid.Empty)
                    {
                        txtPickup.Attributes.Add("OnChange", @"SaveRouteAjax('triptime'," + txtPickup.ClientID + ",'" + opsDate + "','" + hdnId.Value + "');");
                        txtRoute.Attributes.Add("OnChange", @"SaveRouteAjax('route'," + txtRoute.ClientID + ",'" + opsDate + "','" + hdnId.Value + "');");
                        txtAgent.Attributes.Add("OnChange", @"SaveRouteAjax('agent'," + txtAgent.ClientID + ",'" + opsDate + "','" + hdnId.Value + "');");
                        txtPerson.Attributes.Add("OnChange", @"SaveRouteAjax('person'," + txtPerson.ClientID + ",'" + opsDate + "','" + hdnId.Value + "');");
                        txtContact.Attributes.Add("OnChange", @"SaveRouteAjax('contact'," + txtContact.ClientID + ",'" + opsDate + "','" + hdnId.Value + "');");
                    }
                    else
                    {
                        String opsID = ((HiddenField)e.Row.Cells[(int)Constant.gridViewIndexOperationDetail.Route].Controls[2].FindControl("hdnOpsID")).ClientID;
                        String busNo=  ((HiddenField)e.Row.Cells[(int)Constant.gridViewIndexOperationDetail.Route].Controls[3].FindControl("hdnBusNo")).ClientID;
                        String driver = ((HiddenField)e.Row.Cells[(int)Constant.gridViewIndexOperationDetail.Route].Controls[4].FindControl("hdnDriverName")).ClientID;
                        String contactNo = ((HiddenField)e.Row.Cells[(int)Constant.gridViewIndexOperationDetail.Route].Controls[5].FindControl("hdnDriverContact")).ClientID;

                        String attribValue = @"InsertRouteAjax(window.event," + opsID + ", " + busNo + ", " + driver + ", " + contactNo + ", '" + opsDate + "', " + txtPickup.ClientID + ", " + txtRoute.ClientID + ", " + txtAgent.ClientID + ", " + txtPerson.ClientID + ", " + txtContact.ClientID + ")";

                        //txtPickup.Attributes.Add("OnChange", attribValue);
                        //txtRoute.Attributes.Add("OnChange", attribValue);
                        //txtAgent.Attributes.Add("OnChange", attribValue);
                        //txtPerson.Attributes.Add("OnChange", attribValue);
                        txtContact.Attributes.Add("OnChange", attribValue);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "DailyTrip";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Delete"))
                {
                    int index = Convert.ToInt16(e.CommandArgument);

                    GridView customersGridView = (GridView)e.CommandSource;
                    GridViewRow row = customersGridView.Rows[index];
                    HiddenField hdnId = (HiddenField)row.Cells[1].Controls[0].FindControl("hdnId");

                    DriverDetailDTO driverDTO = new DriverDetailDTO();
                    dailyTripPresenter = new DailyTripRFramePresenter();

                    driverDTO.OperationDetailID = new Guid(hdnId.Value);
                    String message = dailyTripPresenter.DeleteData(driverDTO);

                    dailyTripPresenter = new DailyTripRFramePresenter(this);
                    dailyTripPresenter.DataBindings();

                }
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "DailyTrip";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }

        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (!ClientScript.IsClientScriptBlockRegistered("ReloadParent"))
            {
                StringBuilder jquery = new StringBuilder();
                jquery.Append("<script language='javascript' type='text/javascript'> ");
                jquery.Append("RefreshParent('" + Request.QueryString["opsdate"] + "');");
                jquery.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ReloadParent", jquery.ToString());
            }
        }
    }
}