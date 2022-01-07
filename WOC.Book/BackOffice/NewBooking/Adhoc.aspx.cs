using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

//WOC
using Woc.Book.Adhoc.Presenter;
using Woc.Book.Adhoc.BusinessEntity;
using Woc.Book.Base.Constant;

using Woc.Book.Base.Presenter; 
using Woc.Book.Base;
using Woc.Book.Base.BusinessEntity;

//setting
using Woc.Book.Setting.Presenter;

//ErrorHandler
using Woc.Book.ErrorHandler;
using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;

//Export To File
using Woc.Book.ExportToFile.Presenter;

namespace WOC.Book.NewBooking
{
    public partial class Adhoc : System.Web.UI.Page, INewBookingPresenter
    {
        #region Declaration
        AdhocPresenter adhocPresenter;
        SequencePresenter sequencePresenter;
        SettingPresenter settingPresenter;
        UserPresenter userPresenter;
        List<Adhocs> ListAdhoc = new List<Adhocs>();
        ExportToFilePresenter exportToFilePresenter = new ExportToFilePresenter();
        private String m_PrevRefNo = String.Empty;
        #endregion

        #region ControlEvents
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    adhocPresenter = new AdhocPresenter(this);
                    adhocPresenter.DataBindings();
                    
                }

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Adhoc";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ReDisplay();

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source;
                errorHandlers.Module = ex.TargetSite.Module.ToString();
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            adhocPresenter = new AdhocPresenter(this);
            adhocPresenter.SearchData();
        }

        protected void btnResigned_Click(object sender, EventArgs e)
        {
            //adhocPresenter = new AdhocPresenter(this);
            //adhocPresenter.ResignData();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                adhocPresenter = new AdhocPresenter(this);
                adhocPresenter.SaveData();
                if (lblMessage.Text.Contains(Constant.MessageSaved))
                {
                    adhocPresenter = new AdhocPresenter(this);
                    adhocPresenter.ClearControl();
                }

                if (lblMessage.Text.Equals(Constant.MessageSaved))
                {
                    lblMessage.Text = String.Format(Woc.Book.Adhoc.Constant.Constant.BookingMessageSaved, hdnSavedCode.Value);
                }
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Adhoc";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //adhocPresenter = new AdhocPresenter(this);
            //adhocPresenter.DeleteData();
        }
        protected void gv_RowDeleting(Object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row = Convert.ToInt16(e.CommandArgument);

                if (e.CommandName.Equals("Select"))
                {
                    string ID = gv.DataKeys[row].Value.ToString();
                    adhocPresenter = new AdhocPresenter(this);
                    adhocPresenter.GetData(ID);
                }
                else if (e.CommandName.Equals("Delete"))
                {
                    string ID = gv.DataKeys[row].Value.ToString();
                    VoidData(ID);
                }
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Adhoc";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }

        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;

            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            adhocPresenter = new AdhocPresenter(this);
            adhocPresenter.SearchData();

        }

        protected void ddlPagingNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            adhocPresenter = new AdhocPresenter(this);
            adhocPresenter.SearchData();
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                   
                    String voided = e.Row.Cells[(int)Constant.gridViewIndexAdhoc.Voided].Text;
                    if (voided.ToUpper() == "TRUE")
                    {
                        e.Row.BackColor = System.Drawing.Color.Gray;
                        e.Row.Cells[((int)Constant.gridViewIndexAdhoc.Voided) - 1].Enabled = false;
                        e.Row.Cells[((int)Constant.gridViewIndexAdhoc.Voided) - 2].Enabled = false;
                    }
                    else
                    {
                        LinkButton lbtnSel = (LinkButton)e.Row.Cells[(int)Constant.gridViewIndexAdhoc.linkSelect].Controls[0];
                        lbtnSel.Attributes.Add("onclick", "SelectLastTab();");

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
                errorHandlers.Module = "Adhoc";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }

        protected void ibtnListAllPDF_Click(object sender, ImageClickEventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToPDFTypeID.Adhoc.ToString() + ".pdf";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToPDFContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToPDFTypeID.Adhoc));
        }

        protected void ibtnListAll_Click(object sender, ImageClickEventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToExcelTypeID.Adhoc.ToString() + ".xls";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToExcelContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToExcelTypeID.Adhoc));
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            rprAdhoc.DataSource = null;
            rprAdhoc.DataBind();
            DataBindings();
            lblMessage.Text = string.Empty;
            lblSystemError.Text = string.Empty;
        }

        protected void rprAdhoc_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item){
                RadioButtonList rblTripType = (RadioButtonList)e.Item.FindControl("rblTripType");
                TextBox txtTimeDepart = (TextBox)e.Item.FindControl("txtTimeDepart");
                TextBox txtTimeReturn = (TextBox)e.Item.FindControl("txtTimeReturn");
                ImageButton btnDeleteItem = (ImageButton)e.Item.FindControl("btnDeleteItem");

                btnDeleteItem.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this trip?');");

                foreach (ListItem li in rblTripType.Items)
                {
                    if (li.Text == "One Way")
                    {
                        li.Attributes.Add("onClick", "DisableReturn('" + txtTimeDepart.ClientID + "','" + txtTimeReturn.ClientID + "');");
                        if (li.Selected)
                        {
                            txtTimeReturn.Enabled = false;
                        }
                        else
                        {
                            txtTimeReturn.Enabled = true;
                        }
                    }
                    else if (li.Text == "Two Ways")
                    {
                        li.Attributes.Add("onClick", "EnableReturn('" + txtTimeDepart.ClientID + "','" + txtTimeReturn.ClientID + "');");
                    }
                }


            }
            
        }

        protected void rprEditAdhoc_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                RadioButtonList rblTripType = (RadioButtonList)e.Item.FindControl("rblTripType");
                TextBox txtTimeDepart = (TextBox)e.Item.FindControl("txtTimeDepart");
                TextBox txtTimeReturn = (TextBox)e.Item.FindControl("txtTimeReturn");
                ImageButton btnDeleteItem = (ImageButton)e.Item.FindControl("btnDeleteItem");

                btnDeleteItem.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this trip?');");

                foreach (ListItem li in rblTripType.Items)
                {
                    if (li.Text == "One Way")
                    {
                        li.Attributes.Add("onClick", "DisableReturn('" + txtTimeDepart.ClientID + "','" + txtTimeReturn.ClientID + "');");

                        if (li.Selected)
                        {
                            txtTimeReturn.Enabled = false;
                        }
                        else
                        {
                            txtTimeReturn.Enabled = true;
                        }

                    }
                    else if (li.Text == "Two Ways")
                    {
                        li.Attributes.Add("onClick", "EnableReturn('" + txtTimeDepart.ClientID + "','" + txtTimeReturn.ClientID + "');");
                    }
                }
            }

        }

        protected void ddlAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            rprAdhoc.DataSource = null;
            rprAdhoc.DataBind();
            ReDisplay();
        }

        protected void btnEditAdd_Click(object sender, EventArgs e)
        {
            ReEditDisplay();
        }

        protected void btnEditConfirm_Click(object sender, EventArgs e)
        {
            adhocPresenter = new AdhocPresenter(this);
            adhocPresenter.UpdateData();
            lblSystemError.Text = string.Empty;
        }

        protected void btnPendingSearch_Click(object sender, EventArgs e)
        {
            gvPending.PageSize = Convert.ToInt32(this.ddlPendingPaging.SelectedValue);
            SearchPending();
        }

        protected void gvPending_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPending.PageIndex = e.NewPageIndex;
            gvPending.PageSize = Convert.ToInt32(this.ddlPendingPaging.SelectedValue);
            SearchPending();
        }

        protected void rprAdhoc_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                IterateRptr(rprAdhoc);

                Int16 Idx = Convert.ToInt16(e.CommandArgument.ToString());
                Idx -= 1;
                ListAdhoc.RemoveAt(Idx);

                for(Int16 i = 0; i < ListAdhoc.Count; i++)
                {
                    ListAdhoc[i].Item = (i + 1);
                }

                rprAdhoc.DataSource = ListAdhoc;
                rprAdhoc.DataBind();
            }
        }

        protected void rprEditAdhoc_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                IterateRptr(rprEditAdhoc);

                Int16 Idx = Convert.ToInt16(e.CommandArgument.ToString());
                Idx -= 1;
                ListAdhoc.RemoveAt(Idx);

                for (Int16 i = 0; i < ListAdhoc.Count; i++)
                {
                    ListAdhoc[i].Item = (i + 1);
                }

                rprEditAdhoc.DataSource = ListAdhoc;
                rprEditAdhoc.DataBind();
            }
        }

        protected void gvPending_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[(int)Woc.Book.Adhoc.Constant.Constant.gvPendingColumn.Agent].CssClass = (cboPendingAgent.SelectedIndex > 0 ? "hiddencol" : String.Empty);
        }

        protected void gvPending_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkConfirm = (CheckBox) e.Row.Cells[(int)Woc.Book.Adhoc.Constant.Constant.gvPendingColumn.Checkbox].FindControl("chkConfirm");
                String status = e.Row.Cells[(int)Woc.Book.Adhoc.Constant.Constant.gvPendingColumn.Status].Text.Trim();

                if (status.Trim() == "Approved")
                {
                    chkConfirm.Enabled = false;
                }

                String refNo = gvPending.DataKeys[e.Row.RowIndex].Values[(short)Woc.Book.Adhoc.Constant.Constant.GvPendingDataKeyNames.RefNo].ToString();
                if (refNo == m_PrevRefNo)
                {
                    chkConfirm.Enabled = false;
                }
                m_PrevRefNo = gvPending.DataKeys[e.Row.RowIndex].Values[(short)Woc.Book.Adhoc.Constant.Constant.GvPendingDataKeyNames.RefNo].ToString();

            }
        }

        protected void imgConfirm_Click(object sender, ImageClickEventArgs e)
        {
            ConfirmReject(true);
        }

        protected void imgReject_Click(object sender, ImageClickEventArgs e)
        {
            ConfirmReject(false);
        }
        #endregion

        #region interface

        public void DataBindings()
        {
            try
            {

                adhocPresenter = new AdhocPresenter();
                ddlAgent.DataSource = adhocPresenter.GetAgents();
                ddlAgent.DataValueField = "AgentID";
                ddlAgent.DataTextField = "Agent";
                ddlAgent.DataBind();

                ReDisplay();

                adhocPresenter = new AdhocPresenter();
                ddlEditAgent.DataSource = adhocPresenter.GetAgents();
                ddlEditAgent.DataValueField = "AgentID";
                ddlEditAgent.DataTextField = "Agent";
                ddlEditAgent.DataBind();

                ddlCategory.Attributes.Add("onchange", "SwitchControl();");

                tdDepartureDateFrom.Style.Add("display", "none");
                tdDepartureDateTo.Style.Add("display", "none");

                adhocPresenter = new AdhocPresenter(this);
                adhocPresenter.SearchData();
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Adhoc";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }

        }

        public void SaveData()
        {
            try
            {
                sequencePresenter = new SequencePresenter();
                string adhocCode = sequencePresenter.GetNextSequence(Constant.AdhocCode.ToString()).ToString();

                foreach (RepeaterItem ri in rprAdhoc.Items)
                {
                    adhocPresenter = new AdhocPresenter();
                  
                    Adhocs adhocs = new Adhocs();
                    Label lblItemNumber = (Label)ri.FindControl("lblItemNumber");
                    TextBox txtAdhocBookDate = (TextBox)ri.FindControl("txtAdhocBookDate");
                    TextBox txtFromVenue = (TextBox)ri.FindControl("txtFromVenue");
                    TextBox txtToVenue = (TextBox)ri.FindControl("txtToVenue");
                    TextBox txtTimeDepart = (TextBox)ri.FindControl("txtTimeDepart");
                    TextBox txtTimeReturn = (TextBox)ri.FindControl("txtTimeReturn");
                    TextBox txtPurpose = (TextBox)ri.FindControl("txtPurpose");
                    TextBox txtPersonInCharge = (TextBox)ri.FindControl("txtPersonInCharge");
                    TextBox txtContact = (TextBox)ri.FindControl("txtContact");
                    RadioButtonList rblTripType = (RadioButtonList)ri.FindControl("rblTripType");
                    TextBox txtSeater = (TextBox)ri.FindControl("txtSeater");
                    TextBox txtDriverClaim = (TextBox)ri.FindControl("txtDriverClaim");
                    RadioButtonList rblCashOrder = (RadioButtonList)ri.FindControl("rblCashOrder");
                    TextBox txtCashOrder = (TextBox)ri.FindControl("txtCashOrder");

                    adhocs.AgentID = new Guid(ddlAgent.SelectedValue);
                    adhocs.AdhocBookDate = UtilityController.StringToDate(txtAdhocBookDate.Text);
                    adhocs.AdhocCode = adhocs.AdhocBookDate.ToString("yyMMdd") + adhocCode;
                    
                    hdnSavedCode.Value = adhocs.AdhocCode;

                    adhocs.Item = Convert.ToInt32(lblItemNumber.Text.Trim());
                    adhocs.TripType = rblTripType.SelectedValue;
                    adhocs.Seater = Convert.ToInt32(txtSeater.Text);
                    adhocs.TripFrom = txtFromVenue.Text;
                    adhocs.TripTo = txtToVenue.Text;
                    if (txtTimeDepart.Text != string.Empty)
                    {
                        adhocs.TimeDepart = adhocs.AdhocBookDate.AddHours(Convert.ToInt32(txtTimeDepart.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtTimeDepart.Text.Substring(2, 2)));
                    }
                    if (txtTimeReturn.Text != string.Empty)
                    {
                        adhocs.TimeReturn = adhocs.AdhocBookDate.AddHours(Convert.ToInt32(txtTimeReturn.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtTimeReturn.Text.Substring(2, 2)));
                    }
                    
                    adhocs.Purpose = txtPurpose.Text;
                    adhocs.PersonInCharge = txtPersonInCharge.Text;
                    adhocs.Contact = txtContact.Text;
                    adhocs.DriverClaim = txtDriverClaim.Text;
                    adhocs.TypeCashOrder = rblCashOrder.SelectedValue;
                    if (rblCashOrder.SelectedValue == "No")
                    {
                        adhocs.CashOrder = 0;
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(txtCashOrder.Text.Trim()))
                        {
                            adhocs.CashOrder = Decimal.Parse(txtCashOrder.Text.Trim());
                        }
                        else
                        {
                            adhocs.CashOrder = 0;
                        }
                    }
                    ListAdhoc.Add(adhocs);
                    adhocs = new Adhocs();
                }
                lblMessage.Text = adhocPresenter.SaveData(ListAdhoc);
                lblSystemError.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Adhoc";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }


        }

        public void SearchData()
        {
            try
            {
                Adhocs adhocs = new Adhocs();
                adhocPresenter = new AdhocPresenter();
                
                switch (ddlCategory.SelectedValue)
                {
                    case "Agent":
                        adhocs.Agent = this.txtSearch.Text.Trim();
                        tdDepartureDateFrom.Style.Add("display","none");
                        tdDepartureDateTo.Style.Add("display", "none");
                        break;
                    case "AdhocCode":
                        adhocs.AdhocCode = this.txtSearch.Text.Trim();
                        tdDepartureDateFrom.Style.Add("display","none");
                        tdDepartureDateTo.Style.Add("display", "none");
                        
                        break;
                    case "AdhocBookDate":
                        adhocs.AdhocBookDateFrom = UtilityController.StringToDate(txtFromDate.Text.Trim());
                        adhocs.AdhocBookDateTo = UtilityController.StringToDate(txtToDate.Text.Trim());
                        tdDepartureDateFrom.Style.Remove("display");
                        tdDepartureDateTo.Style.Remove("display");
                        tdSearch.Style.Add("display", "none");
                        break;

                    case "Select":
                        tdDepartureDateFrom.Style.Add("display","none");
                        tdDepartureDateTo.Style.Add("display", "none");
                        
                        break;
                }
                gv.DataSource = adhocPresenter.SearchData(adhocs);
                gv.DataBind();

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Adhoc";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }

        }

        public void GetData(String adhocCode)
        {
            adhocPresenter = new AdhocPresenter();
            DisplayData(adhocPresenter.GetUpdateData(adhocCode));
        }

        public void UpdateData()
        {
            try
            {
                sequencePresenter = new SequencePresenter();
                
                foreach (RepeaterItem ri in rprEditAdhoc.Items)
                {
                    adhocPresenter = new AdhocPresenter();

                    Adhocs adhocs = new Adhocs();
                    Label lblItemNumber = (Label)ri.FindControl("lblItemNumber");
                    TextBox txtAdhocBookDate = (TextBox)ri.FindControl("txtAdhocBookDate");
                    TextBox txtFromVenue = (TextBox)ri.FindControl("txtFromVenue");
                    TextBox txtToVenue = (TextBox)ri.FindControl("txtToVenue");
                    TextBox txtTimeDepart = (TextBox)ri.FindControl("txtTimeDepart");
                    TextBox txtTimeReturn = (TextBox)ri.FindControl("txtTimeReturn");
                    TextBox txtPurpose = (TextBox)ri.FindControl("txtPurpose");
                    TextBox txtPersonInCharge = (TextBox)ri.FindControl("txtPersonInCharge");
                    TextBox txtContact = (TextBox)ri.FindControl("txtContact");
                    RadioButtonList rblTripType = (RadioButtonList)ri.FindControl("rblTripType");
                    TextBox txtSeater = (TextBox)ri.FindControl("txtSeater");
                    TextBox txtDriverClaim = (TextBox)ri.FindControl("txtDriverClaim");
                    RadioButtonList rblCashOrder = (RadioButtonList)ri.FindControl("rblCashOrder");
                    TextBox txtCashOrder = (TextBox)ri.FindControl("txtCashOrder");

                    adhocs.AgentID = new Guid(ddlAgent.SelectedValue);
                    adhocs.AdhocCode = txtAdhocCode.Text;
                    adhocs.Item = Convert.ToInt32(lblItemNumber.Text.Trim());
                    adhocs.TripType = rblTripType.SelectedValue;
                    adhocs.AdhocBookDate = UtilityController.StringToDate(txtAdhocBookDate.Text);
                    adhocs.Seater = Convert.ToInt32(txtSeater.Text);
                    adhocs.TripFrom = txtFromVenue.Text;
                    adhocs.TripTo = txtToVenue.Text;
                    if (txtTimeDepart.Text != string.Empty)
                    {
                        adhocs.TimeDepart = adhocs.AdhocBookDate.AddHours(Convert.ToInt32(txtTimeDepart.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtTimeDepart.Text.Substring(2, 2)));
                    }
                    if (txtTimeReturn.Text != string.Empty)
                    {
                        adhocs.TimeReturn = adhocs.AdhocBookDate.AddHours(Convert.ToInt32(txtTimeReturn.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtTimeReturn.Text.Substring(2, 2)));
                    } 
                    adhocs.Purpose = txtPurpose.Text;
                    adhocs.PersonInCharge = txtPersonInCharge.Text;
                    adhocs.Contact = txtContact.Text;
                    adhocs.DriverClaim = txtDriverClaim.Text;
                    adhocs.TypeCashOrder = rblCashOrder.SelectedValue;
                    if (rblCashOrder.SelectedValue == "No")
                    {
                        adhocs.CashOrder = 0;
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(txtCashOrder.Text.Trim()))
                        {
                            adhocs.CashOrder = Decimal.Parse(txtCashOrder.Text.Trim());
                        }
                        else
                        {
                            adhocs.CashOrder = 0;
                        }
                    }
                    ListAdhoc.Add(adhocs);
                    adhocs = new Adhocs();
                }
                lblEditMessage.Text = adhocPresenter.UpdateData(ListAdhoc);
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Adhoc";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }

        public void DeleteData()
        {
            try
            {

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Adhoc";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }

        public void VoidData(String adhocCode)
        {
            try
            {
                adhocPresenter = new AdhocPresenter(this);
                userPresenter = new UserPresenter();

                Adhocs adhocs = new Adhocs();
                adhocs.AdhocCode = adhocCode;
                adhocs.Voided = true;
                adhocs.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);

                if (adhocPresenter.VoidData(adhocs).Contains("Successfully"))
                {
                    adhocPresenter.SearchData();
                }

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Adhoc";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }

        }

        #endregion

        #region Helper Methods
        private void SearchPending()
        {
            try
            {
                Adhocs adhocs = new Adhocs();
                adhocPresenter = new AdhocPresenter();
                adhocs.IsFromAdhoc = true;

                switch (ddlPendingCategory.SelectedValue)
                {
                    case "AdhocBookDate":
                        adhocs.AdhocBookDate = UtilityController.StringToDate(this.txtPendingAdhocBookDate.Text.Trim());
                        break;
                    case "Route":
                        adhocs.Destination = this.txtPendingSearch.Text.Trim();
                        break;
                    case "Pending":
                        adhocs.IsPending = true;
                        if (cboPendingAgent.SelectedIndex > 0)
                        {
                            adhocs.AgentID = new Guid(cboPendingAgent.SelectedValue.ToString());
                        }
                        break;
                    case "Confirm":
                        adhocs.IsPending = false;
                        if (cboPendingAgent.SelectedIndex > 0)
                        {
                            adhocs.AgentID = new Guid(cboPendingAgent.SelectedValue.ToString());
                        }
                        break;
                }
                if (adhocs != null)
                {
                    gvPending.DataSource = adhocPresenter.SearchPendingData(adhocs);
                    gvPending.DataBind();
                    txtAdhocCode.Text = adhocs.AdhocCode;
                }
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Adhoc";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }

        private void ConfirmReject(bool isConfirmed)
        {
            List<Adhocs> adhocList = new List<Adhocs>();
            for (Int16 i = 0; i < gvPending.Rows.Count; i++)
            {
                CheckBox chkConfirm = (CheckBox)gvPending.Rows[i].FindControl("chkConfirm");
                if (chkConfirm.Checked)
                {
                    Adhocs adhocs = new Adhocs();
                    adhocs.AdhocCode = gvPending.DataKeys[i].Values[(Int16)Woc.Book.Adhoc.Constant.Constant.GvPendingDataKeyNames.RefNo].ToString();
                    adhocs.IsPending = (isConfirmed = false);
                    adhocList.Add(adhocs);
                }
            }
            if (adhocList.Count > 0)
            {
                adhocPresenter = new AdhocPresenter();
                if (Constant.MessageSaved == adhocPresenter.ConfirmRejectBooking(adhocList))
                {
                    MailMessage mailMessage = new MailMessage(new MailAddress("harlandgomez@gmail.com")
                                               , new MailAddress("harland_02@yahoo.com"));
                    mailMessage.Subject = "Sending mail through gmail account";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = "<B>Sending mail thorugh gmail from asp.net</B>";

                    System.Net.NetworkCredential networkCredentials = new
                    System.Net.NetworkCredential("harlandgomez@gmail.com", "Tehl@r214");

                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = networkCredentials;
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.Send(mailMessage);

                    Response.Write("Mail Successfully sent");
                }
            }

        }
        #endregion

        #region HouseKeeping
        public void ClearControl()
        {
            rprAdhoc.DataSource = null;
            rprAdhoc.DataBind();
        }

        public void DisplayData(List<Adhocs> listAdhocs)
        {
            try
            {
                Adhocs adhocs = new Adhocs();
                adhocs = listAdhocs[0];
                txtAdhocCode.Text = adhocs.AdhocCode;

                ddlEditAgent.SelectedValue = ddlEditAgent.Items.FindByValue(adhocs.AgentID.ToString()).Value; 
                rprEditAdhoc.DataSource = listAdhocs;
                rprEditAdhoc.DataBind();
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Adhoc";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }

        }

        public List<Adhocs> GetListAdhoc()
        {
            List<Adhocs> adhocStaff = new List<Adhocs>();
            Adhocs adhocs = new Adhocs();
            adhocs.DriverClaim = String.Empty;
            adhocs.Purpose = String.Empty;
            adhocStaff.Add(adhocs);
            adhocs = new Adhocs();



            return adhocStaff;

        }

        private void ReDisplay()
        {
            try
            {
                Adhocs adhocs;
                Adhocs prevAdhocs = null;
                Int16 itemCount = 0;
 
                adhocPresenter = new AdhocPresenter();
                adhocs = new Adhocs();

                foreach (RepeaterItem ri in rprAdhoc.Items)
                {
                    Label lblItemNumber = (Label)ri.FindControl("lblItemNumber");
                    TextBox txtAdhocBookDate = (TextBox)ri.FindControl("txtAdhocBookDate");
                    TextBox txtFromVenue = (TextBox)ri.FindControl("txtFromVenue");
                    TextBox txtToVenue = (TextBox)ri.FindControl("txtToVenue");
                    TextBox txtTimeDepart = (TextBox)ri.FindControl("txtTimeDepart");
                    TextBox txtTimeReturn = (TextBox)ri.FindControl("txtTimeReturn");
                    TextBox txtPurpose = (TextBox)ri.FindControl("txtPurpose");
                    TextBox txtPersonInCharge = (TextBox)ri.FindControl("txtPersonInCharge");
                    TextBox txtContact = (TextBox)ri.FindControl("txtContact");
                    RadioButtonList rblTripType = (RadioButtonList)ri.FindControl("rblTripType");
                    TextBox txtSeater = (TextBox)ri.FindControl("txtSeater");
                    TextBox txtDriverClaim = (TextBox)ri.FindControl("txtDriverClaim");
                    RadioButtonList rblCashOrder = (RadioButtonList)ri.FindControl("rblCashOrder");
                    TextBox txtCashOrder = (TextBox)ri.FindControl("txtCashOrder");
                    itemCount += 1;

                    adhocs.AgentID = new Guid(ddlAgent.SelectedValue);
                    adhocs.Item = itemCount;
                    adhocs.TripType = rblTripType.SelectedValue;
                    adhocs.AdhocBookDate = UtilityController.StringToDate(txtAdhocBookDate.Text);
                    adhocs.Seater = Convert.ToInt32(txtSeater.Text);
                    adhocs.TripFrom = txtFromVenue.Text;
                    adhocs.TripTo = txtToVenue.Text;

                    if (txtTimeDepart.Text != string.Empty)
                    {
                        adhocs.TimeDepart = adhocs.AdhocBookDate.AddHours(Convert.ToInt32(txtTimeDepart.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtTimeDepart.Text.Substring(2, 2)));
                    }
                    if (txtTimeReturn.Text != string.Empty)
                    {
                        adhocs.TimeReturn = adhocs.AdhocBookDate.AddHours(Convert.ToInt32(txtTimeReturn.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtTimeReturn.Text.Substring(2, 2)));
                    }
                    adhocs.Purpose = txtPurpose.Text;
                    adhocs.PersonInCharge = txtPersonInCharge.Text;
                    adhocs.Contact = txtContact.Text;
                    adhocs.DriverClaim = txtDriverClaim.Text;
                    adhocs.TypeCashOrder = rblCashOrder.SelectedValue;
                    if (rblCashOrder.SelectedValue == "No")
                    {
                        adhocs.CashOrder = 0;
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(txtCashOrder.Text.Trim()))
                        {
                            adhocs.CashOrder = Decimal.Parse(txtCashOrder.Text.Trim());
                        }
                        else
                        {
                            adhocs.CashOrder = 0;
                        }
                    }
                    ListAdhoc.Add(adhocs);
                    prevAdhocs = adhocs;
                    adhocs = new Adhocs();
                }

                if (prevAdhocs != null)
                {
                    adhocs.AgentID = prevAdhocs.AgentID;
                    adhocs.CashOrder = prevAdhocs.CashOrder;
                    adhocs.AdhocBookDate = prevAdhocs.AdhocBookDate;
                    adhocs.AdhocBookDateFrom = prevAdhocs.AdhocBookDateFrom;
                    adhocs.AdhocBookDateTo = prevAdhocs.AdhocBookDateTo;
                    adhocs.Contact= prevAdhocs.Contact;
                    adhocs.Destination = prevAdhocs.Destination;
                    adhocs.DriverClaim = prevAdhocs.DriverClaim;
                    adhocs.PersonInCharge = prevAdhocs.PersonInCharge;
                    adhocs.Purpose = prevAdhocs.Purpose;
                    adhocs.Seater = prevAdhocs.Seater;
                    adhocs.TimeDepart = prevAdhocs.TimeDepart;
                    adhocs.TimeReturn = prevAdhocs.TimeReturn;
                    adhocs.TripFrom= prevAdhocs.TripFrom;
                    adhocs.TripTo = prevAdhocs.TripTo;
                    adhocs.TripType = prevAdhocs.TripType;
                    adhocs.TypeCashOrder = prevAdhocs.TypeCashOrder;

                    adhocs.Item = (itemCount + 1);
                    ListAdhoc.Add(adhocs);
                        
                    adhocs = new Adhocs();
                }
                else
                {
                    adhocs.Item = (itemCount + 1);
                    adhocs.Seater = 30;
                    
                    adhocs.DriverClaim = DefaultClaim;

                    adhocs.Purpose = String.Empty;
                    adhocs.AdhocBookDate = DateTime.Now;
                    ListAdhoc.Add(adhocs);
                    adhocs = new Adhocs();
                }
                
                rprAdhoc.DataSource = ListAdhoc;
                rprAdhoc.DataBind();
                lblSystemError.Text = string.Empty;

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source;
                errorHandlers.Module = ex.TargetSite.Module.ToString();
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }

        private void ReEditDisplay()
        {
            try
            {
                Adhocs adhocs = new Adhocs();
                adhocPresenter = new AdhocPresenter();
                Adhocs prevAdhocs = null;
                Int16 itemCount = 0;
 

                foreach (RepeaterItem ri in rprEditAdhoc.Items)
                {
                    Label lblItemNumber = (Label)ri.FindControl("lblItemNumber");
                    TextBox txtAdhocBookDate = (TextBox)ri.FindControl("txtAdhocBookDate");
                    TextBox txtFromVenue = (TextBox)ri.FindControl("txtFromVenue");
                    TextBox txtToVenue = (TextBox)ri.FindControl("txtToVenue");
                    TextBox txtTimeDepart = (TextBox)ri.FindControl("txtTimeDepart");
                    TextBox txtTimeReturn = (TextBox)ri.FindControl("txtTimeReturn");
                    TextBox txtPurpose = (TextBox)ri.FindControl("txtPurpose");
                    TextBox txtPersonInCharge = (TextBox)ri.FindControl("txtPersonInCharge");
                    TextBox txtContact = (TextBox)ri.FindControl("txtContact");
                    RadioButtonList rblTripType = (RadioButtonList)ri.FindControl("rblTripType");
                    TextBox txtSeater = (TextBox)ri.FindControl("txtSeater");
                    TextBox txtDriverClaim = (TextBox)ri.FindControl("txtDriverClaim");
                    RadioButtonList rblCashOrder = (RadioButtonList)ri.FindControl("rblCashOrder");
                    TextBox txtCashOrder = (TextBox)ri.FindControl("txtCashOrder");
                    itemCount += 1;

                    adhocs.AgentID = new Guid(ddlAgent.SelectedValue);
                    adhocs.Item = itemCount;
                    adhocs.TripType = rblTripType.SelectedValue;
                    adhocs.AdhocBookDate = UtilityController.StringToDate(txtAdhocBookDate.Text);
                    adhocs.Seater = Convert.ToInt32(txtSeater.Text);
                    adhocs.TripFrom = txtFromVenue.Text;
                    adhocs.TripTo = txtToVenue.Text;
                    adhocs.TimeDepart = DateTime.Now;
                    adhocs.TimeReturn = DateTime.Now;
                    adhocs.Purpose = txtPurpose.Text;
                    adhocs.PersonInCharge = txtPersonInCharge.Text;
                    adhocs.Contact = txtContact.Text;
                    adhocs.DriverClaim = txtDriverClaim.Text;
                    adhocs.TypeCashOrder = rblCashOrder.SelectedValue;
                    if (rblCashOrder.SelectedValue == "No")
                    {
                        adhocs.CashOrder = 0;
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(txtCashOrder.Text.Trim()))
                        {
                            adhocs.CashOrder = Decimal.Parse(txtCashOrder.Text.Trim());
                        }
                        else
                        {
                            adhocs.CashOrder = 0;
                        }
                    }
                    ListAdhoc.Add(adhocs);
                    prevAdhocs = adhocs;
                    adhocs = new Adhocs();
                }

                if (prevAdhocs != null)
                {
                    adhocs.AgentID = prevAdhocs.AgentID;
                    adhocs.CashOrder = prevAdhocs.CashOrder;
                    adhocs.AdhocBookDate = prevAdhocs.AdhocBookDate;
                    adhocs.AdhocBookDateFrom = prevAdhocs.AdhocBookDateFrom;
                    adhocs.AdhocBookDateTo = prevAdhocs.AdhocBookDateTo;
                    adhocs.Contact = prevAdhocs.Contact;
                    adhocs.Destination = prevAdhocs.Destination;
                    adhocs.DriverClaim = prevAdhocs.DriverClaim;
                    adhocs.PersonInCharge = prevAdhocs.PersonInCharge;
                    adhocs.Purpose = prevAdhocs.Purpose;
                    adhocs.Seater = prevAdhocs.Seater;
                    adhocs.TimeDepart = prevAdhocs.TimeDepart;
                    adhocs.TimeReturn = prevAdhocs.TimeReturn;
                    adhocs.TripFrom = prevAdhocs.TripFrom;
                    adhocs.TripTo = prevAdhocs.TripTo;
                    adhocs.TripType = prevAdhocs.TripType;
                    adhocs.TypeCashOrder = prevAdhocs.TypeCashOrder;

                    adhocs.Item = (itemCount + 1);
                    ListAdhoc.Add(adhocs);
                    adhocs = new Adhocs();
                }
                else
                {
                    adhocs.Item = (itemCount + 1);
                    adhocs.Seater = 30;

                    adhocs.DriverClaim = DefaultClaim;

                    adhocs.Purpose = String.Empty;
                    adhocs.AdhocBookDate = DateTime.Now;
                    ListAdhoc.Add(adhocs);
                    adhocs = new Adhocs();
                }


                rprEditAdhoc.DataSource = ListAdhoc;
                rprEditAdhoc.DataBind();

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source;
                errorHandlers.Module = ex.TargetSite.Module.ToString();
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }

        private void IterateRptr(Repeater rptr)
        {
            Adhocs adhocs;
            Int16 itemCount = 0;
            adhocPresenter = new AdhocPresenter();
            adhocs = new Adhocs();
            
            foreach (RepeaterItem ri in rptr.Items)
            {
                Label lblItemNumber = (Label)ri.FindControl("lblItemNumber");
                TextBox txtAdhocBookDate = (TextBox)ri.FindControl("txtAdhocBookDate");
                TextBox txtFromVenue = (TextBox)ri.FindControl("txtFromVenue");
                TextBox txtToVenue = (TextBox)ri.FindControl("txtToVenue");
                TextBox txtTimeDepart = (TextBox)ri.FindControl("txtTimeDepart");
                TextBox txtTimeReturn = (TextBox)ri.FindControl("txtTimeReturn");
                TextBox txtPurpose = (TextBox)ri.FindControl("txtPurpose");
                TextBox txtPersonInCharge = (TextBox)ri.FindControl("txtPersonInCharge");
                TextBox txtContact = (TextBox)ri.FindControl("txtContact");
                RadioButtonList rblTripType = (RadioButtonList)ri.FindControl("rblTripType");
                TextBox txtSeater = (TextBox)ri.FindControl("txtSeater");
                TextBox txtDriverClaim = (TextBox)ri.FindControl("txtDriverClaim");
                RadioButtonList rblCashOrder = (RadioButtonList)ri.FindControl("rblCashOrder");
                TextBox txtCashOrder = (TextBox)ri.FindControl("txtCashOrder");
                itemCount += 1;

                adhocs.AgentID = new Guid(ddlAgent.SelectedValue);
                adhocs.Item = itemCount;
                adhocs.TripType = rblTripType.SelectedValue;
                adhocs.AdhocBookDate = UtilityController.StringToDate(txtAdhocBookDate.Text);
                adhocs.Seater = Convert.ToInt32(txtSeater.Text);
                adhocs.TripFrom = txtFromVenue.Text;
                adhocs.TripTo = txtToVenue.Text;

                if (txtTimeDepart.Text != string.Empty)
                {
                    adhocs.TimeDepart = adhocs.AdhocBookDate.AddHours(Convert.ToInt32(txtTimeDepart.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtTimeDepart.Text.Substring(2, 2)));
                }
                if (txtTimeReturn.Text != string.Empty)
                {
                    adhocs.TimeReturn = adhocs.AdhocBookDate.AddHours(Convert.ToInt32(txtTimeReturn.Text.Substring(0, 2))).AddMinutes(Convert.ToInt32(txtTimeReturn.Text.Substring(2, 2)));
                }
                adhocs.Purpose = txtPurpose.Text;
                adhocs.PersonInCharge = txtPersonInCharge.Text;
                adhocs.Contact = txtContact.Text;
                adhocs.DriverClaim = txtDriverClaim.Text;
                adhocs.TypeCashOrder = rblCashOrder.SelectedValue;
                if (rblCashOrder.SelectedValue == "No")
                {
                    adhocs.CashOrder = 0;
                }
                else
                {
                    if (!String.IsNullOrEmpty(txtCashOrder.Text.Trim()))
                    {
                        adhocs.CashOrder = Decimal.Parse(txtCashOrder.Text.Trim());
                    }
                    else
                    {
                        adhocs.CashOrder = 0;
                    }
                }
                ListAdhoc.Add(adhocs);
                adhocs = new Adhocs();
            }
        }

        #endregion
        
        #region properties
            private String _defaultClaim;
            public String DefaultClaim
            {
                get 
                { 
                    if (_defaultClaim == null){
                        settingPresenter = new SettingPresenter();
                        _defaultClaim = settingPresenter.GetSettingValue("DEFAULT_DRIVER_CLAIM");
                    }
                    return _defaultClaim; 
                }
            }
        #endregion

    }

    }
