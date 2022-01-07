using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

//WOC
using Woc.Book.Contract.Presenter;
using Woc.Book.Contract.BusinessEntity;
using Woc.Book.Base.Presenter; 
 using Woc.Book.Base;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Constant;
using Woc.Book.Setting.Presenter;

//ErrorHandler
using Woc.Book.ErrorHandler;
using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;

//Export
using Woc.Book.ExportToFile.Presenter;

namespace WOC.Book.NewBooking
{
    public partial class Contract : System.Web.UI.Page, INewBookingPresenter
    {
        #region Declarations
            ContractPresenter contractPresenter;
            UserPresenter userPresenter;
            SequencePresenter sequencePresenter;
            SettingPresenter settingPresenter;
            ExportToFilePresenter exportToFilePresenter;

            const String ContractRatesType = Woc.Book.Contract.Constant.Constant.ContractRatesType;
            const String DailyRatesType = Woc.Book.Contract.Constant.Constant.DailyRatesType;

        #endregion

        #region ControlEvents

        #region MainControls

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    contractPresenter = new ContractPresenter(this);
                    contractPresenter.DataBindings();
                }
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Contract";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message;
            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row = Convert.ToInt16(e.CommandArgument);

                if (e.CommandName.Equals("Select"))
                {
                    String id = gv.DataKeys[row].Value.ToString();
                    contractPresenter = new ContractPresenter(this);
                    contractPresenter.GetData(id);
                }
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "contract";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message;
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                contractPresenter = new ContractPresenter(this);
                contractPresenter.SaveData();
                if (!lblMessage.Text.Contains("unsuccessfully"))
                {
                    contractPresenter = new ContractPresenter(this);
                    contractPresenter.ClearControl();
                }

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source;
                errorHandlers.Module = "Contract";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblMessage.Text = ex.Message.ToString();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            contractPresenter = new ContractPresenter(this);
            contractPresenter.SearchData();
        }

        protected void ddlPagingNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            contractPresenter = new ContractPresenter(this);
            contractPresenter.SearchData();
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbtnSel = (LinkButton)e.Row.Cells[(int)Constant.gridViewIndexContract.linkSelect].Controls[0];
                    lbtnSel.Attributes.Add("onclick", "SelectLastTab();");
                }
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Contract";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message;
            }
        }

        protected void btnEditConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                contractPresenter = new ContractPresenter(this);
                contractPresenter.UpdateData(); 
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Contract";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message;
            }
        }

        protected void ibtnListAllPDF_Click(object sender, ImageClickEventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToPDFTypeID.Contract.ToString() + ".pdf";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToPDFContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToPDFTypeID.Contract));
        }

        protected void ibtnListAll_Click(object sender, ImageClickEventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToExcelTypeID.Contract.ToString() + ".xls";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToExcelContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToExcelTypeID.Contract));
        }

        #endregion

        #region CheckBox


            protected void chkTue_CheckedChanged(object sender, EventArgs e)
            {
                EnableDisableTextBox(chkTue.Checked, txtStartTue, txtEndTue);
            }

            protected void chkWed_CheckedChanged(object sender, EventArgs e)
            {
                EnableDisableTextBox(chkWed.Checked, txtStartWed, txtEndWed);
            }

            protected void chkThu_CheckedChanged(object sender, EventArgs e)
            {
                EnableDisableTextBox(chkThu.Checked, txtStartThu, txtEndThu);
            }

            protected void chkFri_CheckedChanged(object sender, EventArgs e)
            {
                EnableDisableTextBox(chkFri.Checked, txtStartFri, txtEndFri);
            }

            protected void chkSat_CheckedChanged(object sender, EventArgs e)
            {
                EnableDisableTextBox(chkSat.Checked, txtStartSat, txtEndSat);
            }

            protected void chkSun_CheckedChanged(object sender, EventArgs e)
            {
                EnableDisableTextBox(chkSun.Checked, txtStartSun, txtEndSun);
            }

            protected void chkEditMon_CheckedChanged(object sender, EventArgs e)
            {
                EnableDisableTextBox(chkEditMon.Checked, txtEditStartMon, txtEditEndMon);
            }

            protected void chkEditTue_CheckedChanged(object sender, EventArgs e)
            {
                EnableDisableTextBox(chkEditTue.Checked, txtEditStartTue, txtEditEndTue);
            }

            protected void chkEditWed_CheckedChanged(object sender, EventArgs e)
            {
                EnableDisableTextBox(chkEditWed.Checked, txtEditStartWed, txtEditEndWed);
            }

            protected void chkEditThu_CheckedChanged(object sender, EventArgs e)
            {
                EnableDisableTextBox(chkEditThu.Checked, txtEditStartThu, txtEditEndThu);
            }

            protected void chkEditFri_CheckedChanged(object sender, EventArgs e)
            {
                EnableDisableTextBox(chkEditFri.Checked, txtEditStartFri, txtEditEndFri);
            }

            protected void chkEditSat_CheckedChanged(object sender, EventArgs e)
            {
                EnableDisableTextBox(chkEditSat.Checked, txtEditStartSat, txtEditEndSat);
            }

            protected void chkEditSun_CheckedChanged(object sender, EventArgs e)
            {
                EnableDisableTextBox(chkEditSun.Checked, txtEditStartSun, txtEditEndSun);
            }
        #endregion

        #endregion

        #region Interface
        public void DataBindings()
        {
            contractPresenter = new ContractPresenter();
            settingPresenter = new SettingPresenter();

            ddlAgent.DataSource = contractPresenter.GetAgents();
            ddlAgent.DataValueField = "AgentID";
            ddlAgent.DataTextField = "Agent";
            ddlAgent.DataBind();

            ddlEditAgent.DataSource = contractPresenter.GetAgents();
            ddlEditAgent.DataValueField = "AgentID";
            ddlEditAgent.DataTextField = "Agent";
            ddlEditAgent.DataBind();

            ddlPagingNumber.DataSource = settingPresenter.GetDropdownValues(Constant.DropdownPageSize);
            ddlPagingNumber.DataTextField = Constant.DataTextField;
            ddlPagingNumber.DataValueField = Constant.DataValueField;
            ddlPagingNumber.DataBind();

            chkMon.Attributes.Add("onClick", "EnableTextbox('" + chkMon.ClientID + "', '" + txtStartMon.ClientID + "', '" + txtEndMon.ClientID + "')");
            chkTue.Attributes.Add("onClick", "EnableTextbox('" + chkTue.ClientID + "', '" + txtStartTue.ClientID + "', '" + txtEndTue.ClientID + "')");
            chkWed.Attributes.Add("onClick", "EnableTextbox('" + chkWed.ClientID + "', '" + txtStartWed.ClientID + "', '" + txtEndWed.ClientID + "')");
            chkThu.Attributes.Add("onClick", "EnableTextbox('" + chkThu.ClientID + "', '" + txtStartThu.ClientID + "', '" + txtEndThu.ClientID + "')");
            chkFri.Attributes.Add("onClick", "EnableTextbox('" + chkFri.ClientID + "', '" + txtStartFri.ClientID + "', '" + txtEndFri.ClientID + "')");
            chkSat.Attributes.Add("onClick", "EnableTextbox('" + chkSat.ClientID + "', '" + txtStartSat.ClientID + "', '" + txtEndSat.ClientID + "')");
            chkSun.Attributes.Add("onClick", "EnableTextbox('" + chkSun.ClientID + "', '" + txtStartSun.ClientID + "', '" + txtEndSun.ClientID + "')");

            chkEditMon.Attributes.Add("onClick", "EnableTextbox('" + chkEditMon.ClientID + "', '" + txtEditStartMon.ClientID + "', '" + txtEditEndMon.ClientID + "')");
            chkEditTue.Attributes.Add("onClick", "EnableTextbox('" + chkEditTue.ClientID + "', '" + txtEditStartTue.ClientID + "', '" + txtEditEndTue.ClientID + "')");
            chkEditWed.Attributes.Add("onClick", "EnableTextbox('" + chkEditWed.ClientID + "', '" + txtEditStartWed.ClientID + "', '" + txtEditEndWed.ClientID + "')");
            chkEditThu.Attributes.Add("onClick", "EnableTextbox('" + chkEditThu.ClientID + "', '" + txtEditStartThu.ClientID + "', '" + txtEditEndThu.ClientID + "')");
            chkEditFri.Attributes.Add("onClick", "EnableTextbox('" + chkEditFri.ClientID + "', '" + txtEditStartFri.ClientID + "', '" + txtEditEndFri.ClientID + "')");
            chkEditSat.Attributes.Add("onClick", "EnableTextbox('" + chkEditSat.ClientID + "', '" + txtEditStartSat.ClientID + "', '" + txtEditEndSat.ClientID + "')");
            chkEditSun.Attributes.Add("onClick", "EnableTextbox('" + chkEditSun.ClientID + "', '" + txtEditStartSun.ClientID + "', '" + txtEditEndSun.ClientID + "')");

            txtDriverClaim.Text = settingPresenter.GetSettingValue("DEFAULT_DRIVER_CLAIM");

            txtStartCopyAll.Attributes.Add("onblur", "ValidateTime('" + txtStartCopyAll.ClientID + "');");
            txtEndCopyAll.Attributes.Add("onblur", "ValidateTime('" + txtEndCopyAll.ClientID + "');");
            txtEditStartCopyAll.Attributes.Add("onblur", "ValidateTime('" + txtEditStartCopyAll.ClientID + "');");
            txtEditEndCopyAll.Attributes.Add("onblur", "ValidateTime('" + txtEditEndCopyAll.ClientID + "');");
            
            txtEditEndCopyAll.Enabled = false;
            txtEndCopyAll.Enabled = false;

            contractPresenter = new ContractPresenter(this);
            contractPresenter.SearchData();

        }

        public void SaveData()
        {
            try
            {
                contractPresenter = new ContractPresenter();
                Contracts contracts = new Contracts();
                userPresenter = new UserPresenter();
                sequencePresenter = new SequencePresenter();

                contracts.BookingCode = sequencePresenter.GetNextSequence(Constant.BookingCode.ToString()).ToString();
                contracts.AgentID = new Guid(ddlAgent.SelectedValue.ToString());
                contracts.StartDate = UtilityController.StringToDate(txtStartDate.Text.Trim());
                contracts.StopDate = UtilityController.StringToDate(txtStopDate.Text.Trim());
                
                contracts.TripType = (rbtnOneWay.Checked ? rbtnOneWay.Value : rbtnTwoWay.Value);
                
                contracts.TripFrom = txtFrom.Text.Trim();
                contracts.TripTo = txtTo.Text.Trim(); 
                contracts.Seater = txtSeater.Text;
                contracts.InvoiceText = txtInvoiceText.Text.Trim();
                contracts.PONumber = txtPONo.Text.Trim();
                contracts.PersonInCharge = txtPersonInCharge.Text.Trim();
                contracts.Contact = txtContact.Text.Trim();
                contracts.RatesType = rbtnRates.SelectedValue;
                contracts.Rates = Convert.ToDecimal(txtCharge.Text.Trim());
                contracts.Remarks1 = txtRemarks1.Text.Trim();
                contracts.Remarks2 = txtRemarks2.Text.Trim();
                contracts.DriverClaim = txtDriverClaim.Text.Trim();
                contracts.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);

                contracts.ContractStartTime = txtStartCopyAll.Text.Trim();
                contracts.ContractEndTime = txtEndCopyAll.Text.Trim();

                if (ValidateDate(txtStartDate.Text, txtStopDate.Text))
                {
                    if (chkMon.Checked)
                    {
                        contracts.Monday = true;
                        contracts.StartMonday = txtStartMon.Text.Trim();
                        contracts.EndMonday = txtEndMon.Text.Trim();
                    }

                    if (chkTue.Checked)
                    {
                        contracts.Tuesday = true;
                        contracts.StartTuesday = txtStartTue.Text.Trim();
                        contracts.EndTuesday = txtEndTue.Text.Trim();
                    }

                    if (chkWed.Checked)
                    {
                        contracts.Wednesday = true;
                        contracts.StartWednesday = txtStartWed.Text.Trim();
                        contracts.EndWednesday = txtEndWed.Text.Trim();
                    }

                    if (chkThu.Checked)
                    {
                        contracts.Thursday = true;
                        contracts.StartThursday = txtStartThu.Text.Trim();
                        contracts.EndThursday = txtEndThu.Text.Trim();
                    }

                    if (chkFri.Checked)
                    {
                        contracts.Friday = true;
                        contracts.StartFriday = txtStartFri.Text.Trim();
                        contracts.EndFriday = txtEndFri.Text.Trim();
                    }
                        
                    if (chkSat.Checked)
                    {
                        contracts.Saturday = true;
                        contracts.StartSaturday = txtStartSat.Text.Trim();
                        contracts.EndSaturday = txtEndSat.Text.Trim();
                    }
                        
                    if (chkSun.Checked)
                    {
                        contracts.Sunday = true;
                        contracts.StartSunday = txtStartSun.Text.Trim();
                        contracts.EndSunday = txtEndSun.Text.Trim();
                    }

                }

                lblMessage.Text = contractPresenter.SaveData(contracts);
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Contract";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message;
            }
        }

        public void ClearControl()
        {
            try
            {
                settingPresenter = new SettingPresenter();

                hdnId.Value = String.Empty;
                rbtnOneWay.Checked = true;
                rbtnTwoWay.Checked = true;
                ddlAgent.SelectedIndex = 0;
                txtSeater.Text = String.Empty;
                txtStartDate.Text = String.Empty;
                txtStopDate.Text = String.Empty;
                txtFrom.Text = String.Empty;
                txtTo.Text = String.Empty;
                txtInvoiceText.Text = String.Empty;
                txtPersonInCharge.Text = String.Empty;
                txtContact.Text = String.Empty;
                rbtnRates.Text = String.Empty;
                txtCharge.Text = String.Empty;
                txtRemarks1.Text = String.Empty;
                txtRemarks2.Text = String.Empty;

                txtDriverClaim.Text = settingPresenter.GetSettingValue("DEFAULT_DRIVER_CLAIM");

                //ddlGST.Text = String.Empty;
                txtPONo.Text = String.Empty;

                txtStartMon.Text = String.Empty;
                txtStartTue.Text = String.Empty;
                txtStartWed.Text = String.Empty;
                txtStartThu.Text = String.Empty;
                txtStartFri.Text = String.Empty;
                txtStartSat.Text = String.Empty;
                txtStartSun.Text = String.Empty;

                txtEndMon.Text = String.Empty;
                txtEndTue.Text = String.Empty;
                txtEndWed.Text = String.Empty;
                txtEndThu.Text = String.Empty;
                txtEndFri.Text = String.Empty;
                txtEndSat.Text = String.Empty;
                txtEndSun.Text = String.Empty;

                txtStartMon.Enabled = false;
                txtEndMon.Enabled = false;

                txtStartTue.Enabled = false;
                txtEndTue.Enabled = false;

                txtStartWed.Enabled = false;
                txtEndWed.Enabled = false;

                txtStartThu.Enabled = false;
                txtEndThu.Enabled = false;

                txtStartFri.Enabled = false;
                txtEndFri.Enabled = false;

                txtStartSat.Enabled = false;
                txtEndSat.Enabled = false;

                txtStartSun.Enabled = false;
                txtEndSun.Enabled = false;

                txtStartCopyAll.Text = string.Empty;
                txtEndCopyAll.Text = string.Empty;

                chkMon.Checked = false;
                chkTue.Checked = false;
                chkWed.Checked = false;
                chkThu.Checked = false;
                chkFri.Checked = false;
                chkSat.Checked = false;
                chkSun.Checked = false;
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Contract";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message;
            }
        }

        public void SearchData()
        {
            try
            {
                Contracts contracts = new Contracts();
                contractPresenter = new ContractPresenter();
                contracts.ActiveStatus = Convert.ToInt32(rbtnActiveStatus.SelectedValue);
                switch (ddlCategory.SelectedValue)
                {
                    case "Agent":
                        contracts.Agent = this.txtSearch.Text.Trim();
                        break;
                    case "BookingCode":
                        contracts.BookingCode = this.txtSearch.Text.Trim();
                        break;
                }
                gv.DataSource = contractPresenter.SearchData(contracts);
                gv.DataBind();

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Contract";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message;
            }
        }

        public void GetData(string Id)
        {
            contractPresenter = new ContractPresenter();
            DisplayData(contractPresenter.GetUpdateData(Id));
        }

        public void UpdateData()
        {
            try
            {
                lblSystemError.Text = String.Empty;
                contractPresenter = new ContractPresenter();
                Contracts contracts = new Contracts();
                userPresenter = new UserPresenter();
                sequencePresenter = new SequencePresenter();

                contracts.ContractID = new Guid(hdnId.Value);
                contracts.BookingCode = txtEditBookingRefNo.Text.Trim();
                contracts.AgentID = new Guid(ddlEditAgent.SelectedValue.ToString());
                contracts.StartDate = UtilityController.StringToDate(txtEditStartDate.Text);
                contracts.StopDate = UtilityController.StringToDate(txtEditStopDate.Text);
                contracts.TripType = rbtnEditOneWay.Checked ? rbtnEditOneWay.Value : rbtnEditTwoWay.Value;
                contracts.TripFrom = txtEditFrom.Text.Trim();
                contracts.TripTo = txtEditTo.Text.Trim(); 
                contracts.Seater = txtEditSeater.Text;
                contracts.InvoiceText = txtEditInvoiceText.Text.Trim();
                contracts.PONumber = txtEditPONo.Text.Trim();
                contracts.PersonInCharge = txtEditPersonInCharge.Text.Trim();
                contracts.Contact = txtEditContact.Text.Trim();
                contracts.RatesType = rbtnEditRates.SelectedValue;
                contracts.Rates = Convert.ToDecimal(txtEditCharge.Text.Trim());
                contracts.Remarks1 = txtEditRemarks1.Text.Trim();
                contracts.Remarks2 = txtEditRemarks2.Text.Trim();
                contracts.DriverClaim = txtEditDriverClaim.Text.Trim();
                contracts.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                contracts.ContractStartTime = txtEditStartCopyAll.Text.Trim();
                contracts.ContractEndTime = txtEditEndCopyAll.Text.Trim();

                if (ValidateDate(txtEditStartDate.Text, txtEditStopDate.Text))
                {
                    if (chkEditMon.Checked)
                    {
                        contracts.Monday = true;
                        contracts.StartMonday = txtEditStartMon.Text.Trim();
                        contracts.EndMonday = txtEditEndMon.Text.Trim();
                    }

                    if (chkEditTue.Checked)
                    {
                        contracts.Tuesday = true;
                        contracts.StartTuesday = txtEditStartTue.Text.Trim();
                        contracts.EndTuesday = txtEditEndTue.Text.Trim();
                    }

                    if (chkEditWed.Checked)
                    {
                        contracts.Wednesday = true;
                        contracts.StartWednesday = txtEditStartWed.Text.Trim();
                        contracts.EndWednesday = txtEditEndWed.Text.Trim();
                    }

                    if (chkEditThu.Checked)
                    {
                        contracts.Thursday = true;
                        contracts.StartThursday = txtEditStartThu.Text.Trim();
                        contracts.EndThursday = txtEditEndThu.Text.Trim();
                    }

                    if (chkEditFri.Checked)
                    {
                        contracts.Friday = true;
                        contracts.StartFriday = txtEditStartFri.Text.Trim();
                        contracts.EndFriday = txtEditEndFri.Text.Trim();
                    }

                    if (chkEditSat.Checked)
                    {
                        contracts.Saturday = true;
                        contracts.StartSaturday = txtEditStartSat.Text.Trim();
                        contracts.EndSaturday = txtEditEndSat.Text.Trim();
                    }

                    if (chkEditSun.Checked)
                    {
                        contracts.Sunday = true;
                        contracts.StartSunday = txtEditStartSun.Text.Trim();
                        contracts.EndSunday = txtEditEndSun.Text.Trim();
                    }
                }
                lblEditMessage.Text = contractPresenter.UpdateData(contracts);
                
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Contract";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message;
            }
        }

        public void DeleteData()
        {

        }

        public void DisplayData(Contracts contracts)
        {
            try
            {
                hdnId.Value = contracts.ContractID.ToString();
                ddlEditAgent.SelectedValue = contracts.AgentID.ToString();
                txtEditBookingRefNo.Text = contracts.BookingCode.ToString();
                txtEditSeater.Text = contracts.Seater;
                txtEditStartDate.Text = contracts.StartDate.ToString(Properties.WebResources.dateformat);
                txtEditStopDate.Text = contracts.StopDate.ToString(Properties.WebResources.dateformat);

                rbtnEditOneWay.Checked = contracts.TripType == rbtnEditOneWay.Value ? true : false;
                rbtnEditTwoWay.Checked = contracts.TripType == rbtnEditTwoWay.Value ? true : false;

                txtEditEndCopyAll.Enabled = rbtnEditTwoWay.Checked;

                txtEditFrom.Text = contracts.TripFrom;
                txtEditTo.Text = contracts.TripTo;
                txtEditInvoiceText.Text = contracts.InvoiceText;
                txtEditPersonInCharge.Text = contracts.PersonInCharge;
                txtEditContact.Text = contracts.Contact;
                rbtnEditRates.SelectedValue = contracts.RatesType;
                txtEditCharge.Text = contracts.Rates.ToString();
                txtEditRemarks1.Text = contracts.Remarks1;
                txtEditRemarks2.Text = contracts.Remarks2;
                txtEditDriverClaim.Text = contracts.DriverClaim;
                txtEditPONo.Text = contracts.PONumber;
                
                chkEditMon.Checked = contracts.Monday;
                chkEditTue.Checked = contracts.Tuesday;
                chkEditWed.Checked = contracts.Wednesday;
                chkEditThu.Checked = contracts.Thursday;
                chkEditFri.Checked = contracts.Friday;
                chkEditSat.Checked = contracts.Saturday;
                chkEditSun.Checked = contracts.Sunday;

                txtEditStartMon.Text = contracts.StartMonday;
                txtEditStartTue.Text = contracts.StartTuesday;
                txtEditStartWed.Text = contracts.StartWednesday;
                txtEditStartThu.Text = contracts.StartThursday;
                txtEditStartFri.Text = contracts.StartFriday;
                txtEditStartSat.Text = contracts.StartSaturday;
                txtEditStartSun.Text = contracts.StartSunday;

                txtEditEndMon.Text = contracts.EndMonday;
                txtEditEndTue.Text = contracts.EndTuesday;
                txtEditEndWed.Text = contracts.EndWednesday;
                txtEditEndThu.Text = contracts.EndThursday;
                txtEditEndFri.Text = contracts.EndFriday;
                txtEditEndSat.Text = contracts.EndSaturday;
                txtEditEndSun.Text = contracts.EndSunday;

                txtEditStartMon.Enabled = contracts.Monday;
                txtEditEndMon.Enabled = contracts.Monday;

                txtEditStartTue.Enabled = contracts.Tuesday;
                txtEditEndTue.Enabled = contracts.Tuesday;

                txtEditStartWed.Enabled = contracts.Wednesday;
                txtEditEndWed.Enabled = contracts.Wednesday;

                txtEditStartThu.Enabled = contracts.Thursday;
                txtEditEndThu.Enabled = contracts.Thursday;

                txtEditStartFri.Enabled = contracts.Friday;
                txtEditEndFri.Enabled = contracts.Friday;

                txtEditStartSat.Enabled = contracts.Saturday;
                txtEditEndSat.Enabled = contracts.Saturday;

                txtEditStartSun.Enabled = contracts.Sunday;
                txtEditEndSun.Enabled = contracts.Sunday;
                txtEditStartCopyAll.Text = contracts.ContractStartTime;
                txtEditEndCopyAll.Text = contracts.ContractEndTime;

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Contract";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message;
            }

        }
        #endregion

        #region HouseKeeping

            private void EnableDisableTextBox(bool checkboxValue, TextBox txtStart, TextBox txtEnd)
            {
                txtStart.Enabled = checkboxValue;
                txtEnd.Enabled = checkboxValue;
            }

            private bool ValidateDate(String startDate, String endDate)
            {
                try
                {
                    if (UtilityController.StringToDate(startDate) < UtilityController.StringToDate(endDate))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        #endregion












        







    }
}