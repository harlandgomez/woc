using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

//invoice
using Woc.Book.Invoice.Presenter;
using Woc.Book.Invoice.BusinessEntity;
using Woc.Book.Invoice.Constant;

//Common
using Woc.Book.Base;
using Woc.Book.Base.Presenter; 

//Agent
using Woc.Book.Agent.BusinessEntity;

//Error
using Woc.Book.ErrorHandler;
using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;

//Report
using Woc.Book.Report.Presenter;

namespace WOC.Book.Accounts
{
    public partial class Invoice : System.Web.UI.Page, IAccount
    {
        #region Declaration 
            InvoicePresenter invoicePresenter;
            SequencePresenter sequencePresenter;
            UserPresenter userPresenter;
            InvoiceDetails invoiceDetails;
            GSTPresenter gstPresenter;
            String DateFormat = Properties.WebResources.dateformat.ToString();
            ReportPresenter reportPresenter;

        #endregion
        
        #region Interface

        public void SaveData(Int16 TransactionType)
        {
            try
            {   
                String invoiceID = string.Empty;
                invoicePresenter = new InvoicePresenter();

                //Check if there is imported rows
                if (gvImported.Rows.Count == 0) { lblMessage.Text = Constant.NoDataToGenerate; return; }

                if (IsToBeVoided())
                {
                    invoiceID = hdnHasRegenerateID.Value;
                    lblMessage.Text = invoicePresenter.VoidInvoice(invoiceID);
                }
                else
                {
                    Invoices invoices = new Invoices();
                    sequencePresenter = new SequencePresenter();
                    userPresenter = new UserPresenter();

                    int sortBy = 0;

                    
                    invoices.AgentID = new Guid(lboAgent.SelectedValue);
                    invoices.Attention = txtAttention.Text.Trim();
                    invoices.GSTTypeCode = ddlGST.SelectedValue;
                    invoices.Remarks = txtRemarks.Text;
                    invoices.BillTo = txtPerson1.Text;
                    invoices.Address = txtAddress.Text;
                    invoices.Title = txtTitle.Text;
                    invoices.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                    //if (DateTime.TryParse(txtInvoiceDate.Text, out invDate))
                    //{
                    //    invoices.InvoiceDate = invDate;
                    //}
                    //else
                    //{
                    //    invoices.InvoiceDate = UtilityController.StringToDate(Woc.Book.Base.Constant.Constant.MinimumDate);
                    //}
                    //if (!String.IsNullOrEmpty(txtInvoiceDate.Text))
                    //{
                    //    invoices.InvoiceDate = DateTime;
                    
                    //}
                    invoices.InvoiceDate = DateTime.Now;
                    for (int i = 0; i < gvImported.Rows.Count; i++)
                    {
                        bool isCheck = ((CheckBox)gvImported.Rows[i].Cells[(int)Constant.GVImportedColumns.CheckBox].Controls[0].FindControl("gvImportedCheckbox")).Checked;

                        if (isCheck)
                        {
                            invoiceDetails = new InvoiceDetails();
                            invoiceDetails.InvoiceDetailID = new Guid(gvImported.DataKeys[i].Value.ToString());
                            invoiceDetails.BookingID = new Guid(gvImported.Rows[i].Cells[(int)Constant.GVImportedColumns.BookID].Text);
                            invoiceDetails.ItemDate = UtilityController.StringToDate(gvImported.Rows[i].Cells[(int)Constant.GVImportedColumns.BookDate].Text);
                            invoiceDetails.RefNo = gvImported.Rows[i].Cells[(int)Constant.GVImportedColumns.RefNo].Text.Trim();
                            invoiceDetails.Description = Server.HtmlDecode(((TextBox)gvImported.Rows[i].Cells[(int)Constant.GVImportedColumns.Description].Controls[0].FindControl("txtDescription")).Text);
                            invoiceDetails.Pax = ((TextBox)gvImported.Rows[i].Cells[(int)Constant.GVImportedColumns.Pax].Controls[0].FindControl("txtPax")).Text;
                            invoiceDetails.StartTime = Convert.ToDateTime(gvImported.DataKeys[i].Values[(int)Constant.GVImportedKeys.StartTime]);
                            invoiceDetails.EndTime = Convert.ToDateTime(gvImported.DataKeys[i].Values[(int)Constant.GVImportedKeys.EndTime]);
                            invoiceDetails.ERP = Convert.ToDecimal(((TextBox)gvImported.Rows[i].Cells[(int)Constant.GVImportedColumns.ERP].Controls[0].FindControl("txtERP")).Text);
                            invoiceDetails.UnitPrice = Convert.ToDecimal(((TextBox)gvImported.Rows[i].Cells[(int)Constant.GVImportedColumns.UnitPrice].Controls[0].FindControl("txtUnitPrice")).Text);
                            invoiceDetails.Surcharge = Convert.ToDecimal(((TextBox)gvImported.Rows[i].Cells[(int)Constant.GVImportedColumns.Surcharge].Controls[0].FindControl("txtSurcharge")).Text);
                            invoiceDetails.TotalPrice = (invoiceDetails.ERP + invoiceDetails.UnitPrice + invoiceDetails.Surcharge);
                            invoiceDetails.RatesType = gvImported.Rows[i].Cells[(int)Constant.GVImportedColumns.RateType].Text.Trim();
                            if (Int32.TryParse(((TextBox)gvImported.Rows[i].Cells[(int)Constant.GVImportedColumns.SortBy].Controls[0].FindControl("txtSel")).Text, out sortBy))
                            {
                                invoiceDetails.SortOrder = sortBy;
                            }
                            else
                            {
                                invoiceDetails.SortOrder = 0;
                            }
                            invoices.ListInvoiceDetails.Add(invoiceDetails);
                        }
                        else
                        {
                            invoiceDetails = new InvoiceDetails();
                            invoiceDetails.InvoiceDetailID = new Guid(gvImported.DataKeys[i].Value.ToString());
                            invoices.ListVoidInvoiceDetails.Add(invoiceDetails);
                        }
                    }

                    switch (TransactionType)
                    {
                        case (short)Constant.TransType.RegenerateInvoice:
                            invoices.TransactionType = 2;
                            invoices.InvoiceID = new Guid(hdnHasRegenerateID.Value);
                            invoices.InvoiceCode = hdnInvoiceCode.Value;
                            invoices.AliasInvoiceCode = AddRevisionToInvoiceCode(ddlAddTo.Items.FindByValue(invoices.InvoiceID.ToString()).Text);
                            break;
                        default:
                            invoices.TransactionType = 1;
                            invoices.InvoiceCode = invoicePresenter.GetNewInvoiceCode(new Guid(lboAgent.SelectedValue));
                            invoices.AliasInvoiceCode = invoices.InvoiceCode; 
                        break;

                    }
                    invoiceID = invoicePresenter.SaveData(invoices);
                }

                if (!invoiceID.Equals(string.Empty))
                {
                    reportPresenter = new ReportPresenter();

                    String script = reportPresenter.GetPopUpScript("INVOICE", invoiceID);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", script, true);
                    ClearControls();
                }
                else
                {
                    lblMessage.Text = Woc.Book.Base.Constant.Constant.MessageUnSaved;
                }
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Invoice";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblMessage.Text = ex.Message.ToString();
            }
        }
        public void SearchData()
        {
            invoicePresenter = new InvoicePresenter();
            InvoiceDTO invoiceDTOs = new InvoiceDTO();
            invoiceDTOs.AgentID = new Guid(lboAgent.SelectedValue);
            invoiceDTOs.StartDate = UtilityController.StringToDate(txtStartDate.Text);
            invoiceDTOs.EndDate = UtilityController.StringToDate(txtEndDate.Text);
            invoiceDTOs.AdhocChecked = chkAdhoc.Checked;
            invoiceDTOs.ContractChecked = chkContract.Checked;
            lblSearchMessage.Text = string.Empty;

            gv.DataSource = invoicePresenter.SearchData(invoiceDTOs);
            gv.DataBind();

            if (gv.Rows.Count > 0)
            {
                tblImport.Visible = true;
            }
            else
            {
                tblImport.Visible = false;
                lblSearchMessage.Text = Constant.NoRecordFound;
            }
        }
        public void DataBindings()
        {
            gstPresenter = new GSTPresenter();
            invoicePresenter = new InvoicePresenter();
            lboAgent.DataSource = invoicePresenter.GetAgents();
            lboAgent.DataTextField = "agent";
            lboAgent.DataValueField = "agentid";
            lboAgent.DataBind();
            txtInvoiceDate.Text = DateTime.Today.ToString(DateFormat);
            
            btnImport.Attributes.Add("onclick", "SelectLastTab();");
            btnAddTo.Attributes.Add("onclick", "SelectLastTab();");

            ddlReuse.DataSource = invoicePresenter.GetAliasInvoiceCodes(true);
            ddlReuse.DataTextField  = "InvoiceCode";
            ddlReuse.DataValueField = "InvoiceID";
            ddlReuse.DataBind();

            ddlAddTo.DataSource = invoicePresenter.GetAliasInvoiceCodes(false);
            ddlAddTo.DataTextField = "InvoiceCode";
            ddlAddTo.DataValueField = "InvoiceID";
            ddlAddTo.DataBind();

            ddlGST.DataSource = gstPresenter.GetGSTTypes();
            ddlGST.DataTextField = "Description";
            ddlGST.DataValueField = "GSTTypeCode";
            ddlGST.DataBind();

            //Set dataformatstring programmatically for book date
            ((BoundField)this.gv.Columns[(int)Constant.GridViewColumns.BookDate]).DataFormatString = Properties.WebResources.gvDateFormat.ToString();
            ((BoundField)this.gvImported.Columns[(int)Constant.GVImportedColumns.BookDate]).DataFormatString = Properties.WebResources.gvDateFormat.ToString();

            
            if (Request.QueryString["InvoiceID"] != null)
            {
                DisplayToBeInvoicedItems(Constant.LoadType.Reprint);
            }

        }

        #endregion

        #region Control Events
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    invoicePresenter = new InvoicePresenter(this);
                    invoicePresenter.DataBindings();
                }

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Invoice";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblMessage.Text = ex.Message.ToString();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            invoicePresenter = new InvoicePresenter(this);
            invoicePresenter.SearchData();
        }

        protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[(int)Constant.GridViewColumns.BookID].CssClass = "hiddencol";
                e.Row.Cells[(int)Constant.GridViewColumns.StartTime].CssClass = "hiddencol";
                e.Row.Cells[(int)Constant.GridViewColumns.EndTime].CssClass = "hiddencol";
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[(int)Constant.GridViewColumns.BookID].CssClass = "hiddencol";
                e.Row.Cells[(int)Constant.GridViewColumns.StartTime].CssClass = "hiddencol";
                e.Row.Cells[(int)Constant.GridViewColumns.EndTime].CssClass = "hiddencol";
            }
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            DisplayToBeInvoicedItems(Constant.LoadType.Imported);
        }
        
        protected void btnAddTo_Click(object sender, EventArgs e)
        {
            DisplayToBeInvoicedItems(Constant.LoadType.Additional);
        }
        
        protected void btnReuse_Click(object sender, EventArgs e)
        {
            DisplayToBeInvoicedItems(Constant.LoadType.ReUseInvoice);
        }

        protected void gvImported_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String script = String.Empty;

                e.Row.Cells[(int)Constant.GVImportedColumns.BookID].CssClass = "hiddencol";
                e.Row.Cells[(int)Constant.GVImportedColumns.RateType].CssClass = "hiddencol";
                e.Row.Cells[(int)Constant.GVImportedColumns.StartTime].CssClass = "hiddencol";
                e.Row.Cells[(int)Constant.GVImportedColumns.EndTime].CssClass = "hiddencol";
                TextBox txtERP = ((TextBox)e.Row.Cells[(int)Constant.GVImportedColumns.ERP].Controls[0].FindControl("txtERP"));
                TextBox txtSurcharge = ((TextBox)e.Row.Cells[(int)Constant.GVImportedColumns.Surcharge].Controls[0].FindControl("txtSurcharge"));

                txtERP.Text = "0";
                txtSurcharge.Text = "0";
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[(int)Constant.GVImportedColumns.BookID].CssClass = "hiddencol";
                e.Row.Cells[(int)Constant.GVImportedColumns.RateType].CssClass = "hiddencol";
                e.Row.Cells[(int)Constant.GVImportedColumns.StartTime].CssClass = "hiddencol";
                e.Row.Cells[(int)Constant.GVImportedColumns.EndTime].CssClass = "hiddencol";
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            invoicePresenter = new InvoicePresenter(this);

            if (hdnHasRegenerateID.Value == "false")
            {
                invoicePresenter.SaveData((short)Constant.TransType.GenerateInvoice);
            }
            else
            {
                invoicePresenter.SaveData((short)Constant.TransType.RegenerateInvoice);
            }
        }

        protected void gvImported_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            String script = String.Empty;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtERP = ((TextBox)e.Row.Cells[(int)Constant.GVImportedColumns.ERP].Controls[0].FindControl("txtERP"));
                TextBox txtSurcharge = ((TextBox)e.Row.Cells[(int)Constant.GVImportedColumns.Surcharge].Controls[0].FindControl("txtSurcharge"));
                TextBox txtUnitPrice = ((TextBox)e.Row.Cells[(int)Constant.GVImportedColumns.Surcharge].Controls[0].FindControl("txtUnitPrice"));
                TextBox txtTotal = ((TextBox)e.Row.Cells[(int)Constant.GVImportedColumns.Surcharge].Controls[0].FindControl("txtTotal"));


                script = "ComputeTotal('" + txtERP.ClientID + "', '" + txtSurcharge.ClientID + "','" + txtUnitPrice.ClientID + "','" + txtTotal.ClientID + "');";

                txtERP.Attributes.Add("onblur", script);
                txtSurcharge.Attributes.Add("onblur", script);
                txtUnitPrice.Attributes.Add("onblur", script);
            }
        }
    #endregion       

        #region Helper

        private void ClearControls(){
            //tab 1
            lboAgent.SelectedIndex = -1;
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            chkContract.Checked = false;
            chkAdhoc.Checked = false;
            tblImport.Visible = false;

            //tab 2
            txtPerson1.Text = string.Empty;
            txtInvoiceDate.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtAttention.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            ddlGST.SelectedIndex = 0;
            txtTitle.Text = string.Empty;
            lblMessage.Text = string.Empty;
            gvImported.Visible = false;

        }

        private void DisplayToBeInvoicedItems(Constant.LoadType loadType)
        {
            try
            {
                Invoices invoices;
                List<Agents> listAgent;
                invoicePresenter = new InvoicePresenter();
                invoices = new Invoices();
                int sortBy = 0; 
                switch (loadType)
                {
                    case Constant.LoadType.Imported:
                        

                        btnGenerate.Text = Constant.GenerateInvoiceCaption;
                        hdnHasRegenerateID.Value = "false";
                        List<String> contractIDList = new List<String>();

                        for (int i = 0; i < gv.Rows.Count; i++)
                        {
                            bool isSelected = ((CheckBox)gv.Rows[i].Cells[(int)Constant.GridViewColumns.SelCheck].Controls[0].FindControl("gvCheckbox")).Checked;
                            if (isSelected)
                            {
                                if (gv.Rows[i].Cells[(int)Constant.GridViewColumns.RateType].Text.ToUpper().Trim() != "ADHOC")
                                {
                                    contractIDList.Add("'" + gv.Rows[i].Cells[(int)Constant.GridViewColumns.BookID].Text + "'");
                                }
                            }
                        }

                        if (contractIDList.Count > 0)
                        {
                            InvoiceDTO invoiceDTOs = new InvoiceDTO();
                            invoiceDTOs.StartDate = UtilityController.StringToDate(txtStartDate.Text);
                            invoiceDTOs.EndDate = UtilityController.StringToDate(txtEndDate.Text);
                            invoiceDTOs.ContractIDs = String.Join(",", contractIDList.ToArray());
                            invoices.ListInvoiceDetails = invoicePresenter.GetContractToBeInvoiced(invoiceDTOs);
                            sortBy = invoices.ListInvoiceDetails.Count;
                        }

                        
                        for (int i = 0; i < gv.Rows.Count; i++)
                        {
                            bool isSelected = ((CheckBox)gv.Rows[i].Cells[(int)Constant.GridViewColumns.SelCheck].Controls[0].FindControl("gvCheckbox")).Checked;
                            if (isSelected)
                            {
                                if (gv.Rows[i].Cells[(int)Constant.GridViewColumns.RateType].Text.ToUpper().Trim() == "ADHOC")
                                {
                                    sortBy += 1;
                                    InvoiceDetails invoiceDetails = new InvoiceDetails();
                                    invoiceDetails.InvoiceDetailID = Guid.NewGuid();
                                    invoiceDetails.BookingID = new Guid(gv.Rows[i].Cells[(int)Constant.GridViewColumns.BookID].Text);
                                    invoiceDetails.ItemDate = UtilityController.StringToDate(gv.Rows[i].Cells[(int)Constant.GridViewColumns.BookDate].Text);
                                    invoiceDetails.RefNo = gv.Rows[i].Cells[(int)Constant.GridViewColumns.RefNo].Text.Trim();
                                    invoiceDetails.Description = Server.HtmlDecode(gv.Rows[i].Cells[(int)Constant.GridViewColumns.Description].Text.Trim());
                                    invoiceDetails.Pax = gv.Rows[i].Cells[(int)Constant.GridViewColumns.Pax].Text;
                                    invoiceDetails.StartTime = (DateTime)gv.DataKeys[i].Values[(int)Constant.GridViewKeys.StartTime];
                                    invoiceDetails.EndTime = (DateTime)gv.DataKeys[i].Values[(int)Constant.GridViewKeys.EndTime];
                                    invoiceDetails.UnitPrice = Convert.ToDecimal(gv.Rows[i].Cells[(int)Constant.GridViewColumns.Rates].Text);
                                    invoiceDetails.RatesType = gv.Rows[i].Cells[(int)Constant.GridViewColumns.RateType].Text.ToUpper().Trim();
                                    invoiceDetails.SortOrder = sortBy;
                                    invoices.ListInvoiceDetails.Add(invoiceDetails);
                                }
                            }
                        }

                        break;
                    case Constant.LoadType.Reprint:
                        invoices = invoicePresenter.GetInvoiceDetailsByID(Request.QueryString["InvoiceID"]);
                        hdnInvoiceCode.Value = invoices.InvoiceCode;
                        txtAttention.Text = invoices.Attention;
                        txtRemarks.Text = invoices.Remarks;
                        txtTitle.Text = invoices.Title;
                        lboAgent.Items.FindByValue(invoices.AgentID.ToString()).Selected = true;
                        txtInvoiceDate.Text = invoices.InvoiceDate.ToString(DateFormat);
                        btnGenerate.Text = Constant.ReGenerateInvoiceCaption;
                        hdnHasRegenerateID.Value = Request.QueryString["InvoiceID"];
                        break;
                    case Constant.LoadType.Additional:
                        invoices = invoicePresenter.GetInvoiceDetailsByID(ddlAddTo.SelectedValue);
                        hdnInvoiceCode.Value = invoices.InvoiceCode;
                        txtAttention.Text = invoices.Attention;
                        txtRemarks.Text = invoices.Remarks;
                        txtTitle.Text = invoices.Title;
                        lboAgent.Items.FindByValue(invoices.AgentID.ToString()).Selected = true;
                        txtInvoiceDate.Text = invoices.InvoiceDate.ToString(DateFormat);
                        btnGenerate.Text = Constant.ReGenerateInvoiceCaption;
                        hdnHasRegenerateID.Value = ddlAddTo.SelectedValue.ToString();
                        sortBy = invoices.ListInvoiceDetails.Count;

                        for (int i = 0; i < gv.Rows.Count; i++)
                        {
                            bool isSelected = ((CheckBox)gv.Rows[i].Cells[(int)Constant.GridViewColumns.SelCheck].Controls[0].FindControl("gvCheckbox")).Checked;
                            if (isSelected)
                            {
                                sortBy += 1;
                                InvoiceDetails invoiceDetails = new InvoiceDetails();
                                invoiceDetails.InvoiceDetailID = Guid.NewGuid();
                                invoiceDetails.BookingID = new Guid(gv.Rows[i].Cells[(int)Constant.GridViewColumns.BookID].Text);
                                invoiceDetails.ItemDate = UtilityController.StringToDate(gv.Rows[i].Cells[(int)Constant.GridViewColumns.BookDate].Text);
                                invoiceDetails.RefNo = gv.Rows[i].Cells[(int)Constant.GridViewColumns.RefNo].Text.Trim();
                                invoiceDetails.Description = Server.HtmlDecode(gv.Rows[i].Cells[(int)Constant.GridViewColumns.Description].Text.Trim());
                                invoiceDetails.Pax = gv.Rows[i].Cells[(int)Constant.GridViewColumns.Pax].Text;
                                invoiceDetails.StartTime = (DateTime)gv.DataKeys[i].Values[(int)Constant.GridViewKeys.StartTime];
                                invoiceDetails.EndTime = (DateTime)gv.DataKeys[i].Values[(int)Constant.GridViewKeys.EndTime];
                                invoiceDetails.UnitPrice = Convert.ToDecimal(gv.Rows[i].Cells[(int)Constant.GridViewColumns.Rates].Text);
                                invoiceDetails.RatesType = gv.Rows[i].Cells[(int)Constant.GridViewColumns.RateType].Text.ToUpper().Trim();
                                invoiceDetails.SortOrder = sortBy;
                                invoices.ListInvoiceDetails.Add(invoiceDetails);
                            }
                        }
                        break;
                    case Constant.LoadType.ReUseInvoice:
                        btnGenerate.Text = Constant.ReGenerateInvoiceCaption;
                        hdnHasRegenerateID.Value = ddlReuse.SelectedValue.ToString();
                        for (int i = 0; i < gv.Rows.Count; i++)
                        {
                            bool isSelected = ((CheckBox)gv.Rows[i].Cells[(int)Constant.GridViewColumns.SelCheck].Controls[0].FindControl("gvCheckbox")).Checked;
                            if (isSelected)
                            {
                                sortBy += 1;
                                InvoiceDetails invoiceDetails = new InvoiceDetails();
                                invoiceDetails.InvoiceDetailID = Guid.NewGuid();
                                invoiceDetails.BookingID = new Guid(gv.Rows[i].Cells[(int)Constant.GridViewColumns.BookID].Text);
                                invoiceDetails.ItemDate = UtilityController.StringToDate(gv.Rows[i].Cells[(int)Constant.GridViewColumns.BookDate].Text);
                                invoiceDetails.RefNo = gv.Rows[i].Cells[(int)Constant.GridViewColumns.RefNo].Text.Trim();
                                invoiceDetails.Description = Server.HtmlDecode(gv.Rows[i].Cells[(int)Constant.GridViewColumns.Description].Text.Trim());
                                invoiceDetails.Pax = gv.Rows[i].Cells[(int)Constant.GridViewColumns.Pax].Text;
                                invoiceDetails.StartTime = (DateTime) gv.DataKeys[i].Values[(int)Constant.GridViewKeys.StartTime];
                                invoiceDetails.EndTime = (DateTime)gv.DataKeys[i].Values[(int)Constant.GridViewKeys.EndTime];
                                invoiceDetails.UnitPrice = Convert.ToDecimal(gv.Rows[i].Cells[(int)Constant.GridViewColumns.Rates].Text);
                                invoiceDetails.RatesType = gv.Rows[i].Cells[(int)Constant.GridViewColumns.RateType].Text.ToUpper().Trim();
                                invoiceDetails.SortOrder = sortBy;
                                invoices.ListInvoiceDetails.Add(invoiceDetails);
                            }
                        }
                        break;
                }

                if (invoices.ListInvoiceDetails.Count > 0)
                {
                    gvImported.DataSource = invoices.ListInvoiceDetails;
                    gvImported.DataBind();


                    listAgent = invoicePresenter.GetAgents();
                    Agents agents = listAgent.Find(
                    delegate(Agents agent){ return agent.AgentID == new Guid(lboAgent.SelectedValue);}
                    );
                    txtPerson1.Text = agents.Agent;
                    txtAddress.Text = agents.Address;
                    hdnAgentPrefix.Value = agents.Prefix;
                    gvImported.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Invoice";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblMessage.Text = ex.Message.ToString();
            }
        }

        protected String FormatTime(object startTime, object endTime)
        {
            String formattedEndTime = string.Empty;
            if (Convert.ToDateTime(endTime) == DateTime.MinValue)
            {
                formattedEndTime = "(none)";
            }
            else
            {
                formattedEndTime = Convert.ToDateTime(endTime).ToString("HH:mm");
            }
            return Convert.ToDateTime(startTime).ToString("HH:mm") + " - " + formattedEndTime;
        }

        private String AddRevisionToInvoiceCode(String invoiceCode)
        {
            const String delim = Woc.Book.DailyTrip.Constant.Constant.revisionDelimiter;

            if (invoiceCode.IndexOf(delim) == -1)
            {
                return invoiceCode + delim + "1";
            }
            else
            {
                String revisionNo = Regex.Split(invoiceCode, delim)[1];
                return Regex.Split(invoiceCode, delim)[0] + delim + (Convert.ToInt16(revisionNo) + 1).ToString(); ;
            }
        }

        private bool IsToBeVoided()
        {
            if (hdnHasRegenerateID.Value != "false")
            {
                for (int i = 0; i < gvImported.Rows.Count; i++)
                {
                    bool isCheck = ((CheckBox)gvImported.Rows[i].Cells[(int)Constant.GVImportedColumns.CheckBox].Controls[0].FindControl("gvImportedCheckbox")).Checked;

                    if (isCheck)
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
#endregion



    }
}