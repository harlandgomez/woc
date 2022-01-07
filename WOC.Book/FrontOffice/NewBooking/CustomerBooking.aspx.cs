using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//WOC
using Woc.Book.Adhoc.Presenter;
using Woc.Book.Adhoc.BusinessEntity;
using Woc.Book.Adhoc.Constant;

using Woc.Book.Base.Presenter;
using Woc.Book.Base;
using Woc.Book.Base.BusinessEntity;

//setting
using Woc.Book.Setting.Presenter;

//ErrorHandler
using Woc.Book.ErrorHandler;
using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;

namespace FrontOffice.NewBooking
{
    public partial class CustomerBooking : System.Web.UI.Page, INewBookingPresenter
    {
        #region Declaration
        AdhocPresenter adhocPresenter;
        SequencePresenter sequencePresenter;
        SettingPresenter settingPresenter;
        List<Adhocs> ListAdhoc = new List<Adhocs>();
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
                errorHandlers.Module = "Customer";
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

        protected void btnResigned_Click(object sender, EventArgs e)
        {

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
                errorHandlers.Module = "Customer";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            rprCustomer.DataSource = null;
            rprCustomer.DataBind();
            DataBindings();
            lblMessage.Text = string.Empty;
            lblSystemError.Text = string.Empty;
        }

        protected void rprCustomer_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        protected void rprEditCustomer_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
            rprCustomer.DataSource = null;
            rprCustomer.DataBind();
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
            gv.PageSize = Convert.ToInt32(this.ddlPendingPaging.SelectedValue);
            SearchPending();
        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            gv.PageSize = Convert.ToInt32(this.ddlPendingPaging.SelectedValue);
            SearchPending();
        }

        protected void rprCustomer_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                IterateRptr(rprCustomer);

                Int16 Idx = Convert.ToInt16(e.CommandArgument.ToString());
                Idx -= 1;
                ListAdhoc.RemoveAt(Idx);

                for (Int16 i = 0; i < ListAdhoc.Count; i++)
                {
                    ListAdhoc[i].Item = (i + 1);
                }

                rprCustomer.DataSource = ListAdhoc;
                rprCustomer.DataBind();
            }
        }

        protected void rprEditCustomer_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                IterateRptr(rprEditCustomer);

                Int16 Idx = Convert.ToInt16(e.CommandArgument.ToString());
                Idx -= 1;
                ListAdhoc.RemoveAt(Idx);

                for (Int16 i = 0; i < ListAdhoc.Count; i++)
                {
                    ListAdhoc[i].Item = (i + 1);
                }

                rprEditCustomer.DataSource = ListAdhoc;
                rprEditCustomer.DataBind();
            }
        }
        #endregion

        #region interface

        public void DataBindings()
        {
            try
            {

                adhocPresenter = new AdhocPresenter();
                hdnAgentID.Value = adhocPresenter.GetAgentIDByUserName(User.Identity.Name).ToString();

                ReDisplay();

                adhocPresenter = new AdhocPresenter();
                hdnEditAgentID.Value = hdnAgentID.Value;

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
                errorHandlers.Module = "Customer";
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

                foreach (RepeaterItem ri in rprCustomer.Items)
                {
                    adhocPresenter = new AdhocPresenter();

                    Adhocs adhocs = new Adhocs();
                    Label lblItemNumber = (Label)ri.FindControl("lblItemNumber");
                    TextBox txtCustomerBookDate = (TextBox)ri.FindControl("txtCustomerBookDate");
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

                    adhocs.AgentID = new Guid(hdnAgentID.Value);
                    adhocs.AdhocBookDate = UtilityController.StringToDate(txtCustomerBookDate.Text);
                    adhocs.AdhocCode = adhocs.AdhocBookDate.ToString("yyMMdd") + adhocCode;

                    hdnSavedCode.Value = adhocs.AdhocCode;

                    adhocs.Item = Convert.ToInt32(lblItemNumber.Text.Trim());
                    adhocs.TripType = rblTripType.SelectedValue;
                    adhocs.Seater = Convert.ToInt32(txtSeater.Text);
                    adhocs.TripFrom = txtFromVenue.Text;
                    adhocs.TripTo = txtToVenue.Text;
                    adhocs.IsPending = true;
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
                errorHandlers.Module = "Customer";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }

        public void SearchData()
        {
            try
            {
                adhocPresenter = new AdhocPresenter();

                gv.DataSource = adhocPresenter.GetPendingDataByAgentID(new Guid(hdnAgentID.Value));
                gv.DataBind();

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Customer";
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

                foreach (RepeaterItem ri in rprEditCustomer.Items)
                {
                    adhocPresenter = new AdhocPresenter();

                    Adhocs adhocs = new Adhocs();
                    Label lblItemNumber = (Label)ri.FindControl("lblItemNumber");
                    TextBox txtCustomerBookDate = (TextBox)ri.FindControl("txtCustomerBookDate");
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

                    adhocs.AgentID = new Guid(hdnAgentID.Value);
                    adhocs.AdhocCode = lblCustomerCode.Text;
                    adhocs.Item = Convert.ToInt32(lblItemNumber.Text.Trim());
                    adhocs.TripType = rblTripType.SelectedValue;
                    adhocs.AdhocBookDate = UtilityController.StringToDate(txtCustomerBookDate.Text);
                    adhocs.Seater = Convert.ToInt32(txtSeater.Text);
                    adhocs.TripFrom = txtFromVenue.Text;
                    adhocs.TripTo = txtToVenue.Text;
                    adhocs.IsPending = true;
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
                errorHandlers.Module = "Customer";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }

        public void DeleteData()
        {

        }



        #endregion

        #region Helper Methods
        public void VoidData(String adhocCode)
        {
            try
            {
                adhocPresenter = new AdhocPresenter(this);

                Adhocs adhocs = new Adhocs();
                adhocs.AdhocCode = adhocCode;
                adhocs.Voided = true;
                adhocs.UpdatedBy = new Guid(hdnEditAgentID.Value);

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
                errorHandlers.Module = "Customer";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }

        private void SearchPending()
        {
            try
            {
                Adhocs adhocs = new Adhocs();
                adhocPresenter = new AdhocPresenter();
                adhocs.AgentID = new Guid(hdnAgentID.Value);
                adhocs.Destination = this.txtPendingSearch.Text.Trim();
                switch (ddlPendingCategory.SelectedValue)
                {
                    case "All":
                        adhocs.Item = (int)Constant.SearchCategory.All;
                        break;
                    case "Pending":
                        adhocs.Item = (int)Constant.SearchCategory.Pending;
                        break;
                    case "Confirm":
                        adhocs.Item = (int)Constant.SearchCategory.Confirm;
                        break;
                }
                if (adhocs != null)
                {
                    gv.DataSource = adhocPresenter.SearchPendingData(adhocs);
                    gv.DataBind();
                    lblCustomerCode.Text = adhocs.AdhocCode;
                }

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Customer";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }
        #endregion

        #region HouseKeeping
        public void ClearControl()
        {
            rprCustomer.DataSource = null;
            rprCustomer.DataBind();
        }

        public void DisplayData(List<Adhocs> listAdhocs)
        {
            try
            {
                Adhocs adhocs = new Adhocs();
                adhocs = listAdhocs[0];
                lblCustomerCode.Text = adhocs.AdhocCode;

                hdnEditAgentID.Value = adhocs.AgentID.ToString();
                rprEditCustomer.DataSource = listAdhocs;
                rprEditCustomer.DataBind();
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Customer";
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

                foreach (RepeaterItem ri in rprCustomer.Items)
                {
                    Label lblItemNumber = (Label)ri.FindControl("lblItemNumber");
                    TextBox txtCustomerBookDate = (TextBox)ri.FindControl("txtCustomerBookDate");
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

                    adhocs.AgentID = new Guid(hdnAgentID.Value);
                    adhocs.Item = itemCount;
                    adhocs.TripType = rblTripType.SelectedValue;
                    adhocs.AdhocBookDate = UtilityController.StringToDate(txtCustomerBookDate.Text);
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

                rprCustomer.DataSource = ListAdhoc;
                rprCustomer.DataBind();
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


                foreach (RepeaterItem ri in rprEditCustomer.Items)
                {
                    Label lblItemNumber = (Label)ri.FindControl("lblItemNumber");
                    TextBox txtCustomerBookDate = (TextBox)ri.FindControl("txtCustomerBookDate");
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

                    adhocs.AgentID = new Guid(hdnAgentID.Value);
                    adhocs.Item = itemCount;
                    adhocs.TripType = rblTripType.SelectedValue;
                    adhocs.AdhocBookDate = UtilityController.StringToDate(txtCustomerBookDate.Text);
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


                rprEditCustomer.DataSource = ListAdhoc;
                rprEditCustomer.DataBind();

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
                TextBox txtCustomerBookDate = (TextBox)ri.FindControl("txtCustomerBookDate");
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

                adhocs.AgentID = new Guid(hdnAgentID.Value);
                adhocs.Item = itemCount;
                adhocs.TripType = rblTripType.SelectedValue;
                adhocs.AdhocBookDate = UtilityController.StringToDate(txtCustomerBookDate.Text);
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
                if (_defaultClaim == null)
                {
                    settingPresenter = new SettingPresenter();
                    _defaultClaim = settingPresenter.GetSettingValue("DEFAULT_DRIVER_CLAIM");
                }
                return _defaultClaim;
            }
        }
        #endregion

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ID = (String)e.CommandArgument;

            switch(e.CommandName)
            {
                case "Delete":
                    VoidData(ID);
                    break;
                case "Select":
                    adhocPresenter = new AdhocPresenter(this);
                    adhocPresenter.GetData(ID);
                    break;
            }

        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    ImageButton imgEdit = (ImageButton)e.Row.Cells[(int)Constant.gridViewColumn.EditImage].Controls[1];
                    imgEdit.Attributes.Add("onclick", "SelectEditTab();");
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
    }
}