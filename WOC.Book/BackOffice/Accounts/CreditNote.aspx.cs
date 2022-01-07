using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using Woc.Book.Base.Presenter; 
 using Woc.Book.Base;

using Woc.Book.Agent.BusinessEntity;
using Woc.Book.Invoice.BusinessEntity;


using Woc.Book.ErrorHandler.BusinessEntity;
using Woc.Book.ErrorHandler.Presenter;

using Woc.Book.CreditNote.Presenter;
using Woc.Book.CreditNote.Constant;
using Woc.Book.CreditNote.BusinessEntity;

using Woc.Book.Report.Presenter;

namespace WOC.Book.Accounts
{
    public partial class CreditNote : System.Web.UI.Page, IAccount
    {
        #region Declarations
        CreditNotePresenter creditNotePresenter;
        SequencePresenter sequencePresenter;
        GSTPresenter gstPresenter = new GSTPresenter();

        const String DateFormat = Woc.Book.Base.Constant.Constant.DateFormat;
        #endregion

        #region Interface
            public void SaveData(short TransactionType)
            {
                CreditNotes creditNotes = new CreditNotes();
                creditNotePresenter = new CreditNotePresenter();
                sequencePresenter = new SequencePresenter();
                switch (TransactionType)
                {
                    case (short) Constant.TransactionType.SaveCreditNote:
                        if (!String.IsNullOrEmpty(hdnAgentID.Value))
                        {
                            creditNotes.AgentID = new Guid(hdnAgentID.Value);
                        }
                        else
                        {
                            creditNotes.AgentID = new Guid(lboAgentSave.SelectedValue);
                        }
                        creditNotes.Description = txtDescriptionSave.Text;
                        creditNotes.InvoiceCode = ddlInvoiceCodeSave.SelectedValue;
                        creditNotes.ReasonCode = ddlReasonCodeSave.SelectedValue;
                        creditNotes.GSTTypeCode = ddlGST.SelectedValue;
                        creditNotes.CreditNoteCode = sequencePresenter.GetNextSequence(Constant.SequenceCode);
                        creditNotes.CreditNoteAmount = Convert.ToDecimal(txtAmount.Text);
                        creditNotes.Attention = txtAttention.Text;
                        creditNotes.CreatedBy = User.Identity.Name;
                        lblMessageSave.Text = creditNotePresenter.SaveData(creditNotes);
                        break;
                    case (short)Constant.TransactionType.UpdateCreditNote:
                        if (!String.IsNullOrEmpty(hdnAgentID.Value))
                        {
                            creditNotes.AgentID = new Guid(hdnAgentID.Value);
                        }
                        else
                        {
                            creditNotes.AgentID = new Guid(lboAgentSave.SelectedValue);
                        }
                        creditNotes.CreditNoteID = new Guid(hdnCNID.Value);
                        creditNotes.Description = txtDescriptionSave.Text;
                        creditNotes.InvoiceCode = ddlInvoiceCodeSave.SelectedValue;
                        creditNotes.ReasonCode = ddlReasonCodeSave.SelectedValue;
                        creditNotes.GSTTypeCode = ddlGST.SelectedValue;
                        creditNotes.CreditNoteAmount = Convert.ToDecimal(txtAmount.Text);
                        creditNotes.Attention = txtAttention.Text;
                        lblMessageSave.Text = creditNotePresenter.UpdateData(creditNotes);
                        break;
                }
                if (lblMessageSave.Text.Equals(Woc.Book.Base.Constant.Constant.MessageSaved))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "close", "<script language=javascript>RefreshDebtorSettlement();</script>");
                }
            }

            public void DataBindings()
            {
                Constant.LoadingType action;
                CreditNotes creditNotes;
 
                creditNotePresenter = new CreditNotePresenter(this);

                lboAgent.DataSource = creditNotePresenter.GetAgents();
                lboAgent.DataTextField = "agent";
                lboAgent.DataValueField = "agentid";
                lboAgent.DataBind();
                lboAgent.SelectedIndex = 0;

                lboAgentSave.DataSource = creditNotePresenter.GetAgents();
                lboAgentSave.DataTextField = "agent";
                lboAgentSave.DataValueField = "agentid";
                lboAgentSave.DataBind();
                lboAgentSave.SelectedIndex = 0;

                ddlInvoiceCode.DataSource = creditNotePresenter.GetAliasInvoiceCodes((short) Constant.InvoiceTransactionType.GetAliasInCreditNote);
                ddlInvoiceCode.DataTextField = "AliasInvoiceCode";
                ddlInvoiceCode.DataValueField = "InvoiceCode";
                ddlInvoiceCode.DataBind();
                ddlInvoiceCode.Items.Insert(0, new ListItem("-- Select Invoice --", string.Empty));

                ddlInvoiceCodeSave.DataSource = creditNotePresenter.GetAliasInvoiceCodes((short)Constant.InvoiceTransactionType.GetAliasInCreditNote);
                ddlInvoiceCodeSave.DataTextField = "AliasInvoiceCode";
                ddlInvoiceCodeSave.DataValueField = "InvoiceCode";
                ddlInvoiceCodeSave.DataBind();
                
                ddlReasonCodeSave.DataSource = creditNotePresenter.GetAllReason();
                ddlReasonCodeSave.DataTextField = "ReasonCode";
                ddlReasonCodeSave.DataValueField = "ReasonCode";
                ddlReasonCodeSave.DataBind();

                ddlReasonCode.DataSource = creditNotePresenter.GetAllReason();
                ddlReasonCode.DataTextField = "ReasonCode";
                ddlReasonCode.DataValueField = "ReasonCode";
                ddlReasonCode.DataBind();
                ddlReasonCode.Items.Insert(0, new ListItem("-- Select Reason Code --",string.Empty));

                //btnSave.Attributes.Add("onclick", "window.opener.location.reload(false);PutValue();self.close();");

                txtAttention.Text = String.Empty; //TODO: Change this to value from registration
                action = LoadByAction(); //Get the load type either create, edit, show or none.
                switch (action)
                {
                    case Constant.LoadingType.Create:
                        LoadSaveControls();
                        break;
                    case Constant.LoadingType.Edit:
                        LoadSaveControls();

                        creditNotes = new CreditNotes();
                        creditNotes.InvoiceCode = DecodeFrom64(Request.QueryString["InvoiceCode"]);

                        List<CreditNotes> listCreditNotes;
                        listCreditNotes = creditNotePresenter.SearchData(creditNotes);

                        foreach (CreditNotes cn in listCreditNotes)
                        {
                            txtDescriptionSave.Text = cn.Description;
                            ddlReasonCodeSave.Items.FindByValue(cn.ReasonCode).Selected = true;
                            ddlGST.Items.FindByValue(cn.GSTTypeCode).Selected = true;
                            txtAmount.Text = cn.CreditNoteAmount.ToString();
                            hdnCNID.Value = cn.CreditNoteID.ToString();
                            txtAttention.Text = cn.Attention;
                            break;
                        }
    
                        break;
                    case Constant.LoadingType.Show:
                        lboAgent.SelectedItem.Selected = false;
                        lboAgent.Items.FindByValue(Request.QueryString["AgentID"]).Selected = true;
                        ddlInvoiceCode.SelectedItem.Selected = false;
                        ddlInvoiceCode.Items.FindByValue(DecodeFrom64(Request.QueryString["InvoiceCode"])).Selected = true; 
                        btnClose.Visible = true;
                        btnClose.Attributes.Add("onclick", "RefreshDebtorSettlement();");
                        SearchData();
                        break;
                    default:
                        lblAgent.CssClass = "hiddencol";
                        break;
                }
            }

            public void SearchData()
            {
                CreditNotes creditNotes = new CreditNotes();
                creditNotePresenter = new CreditNotePresenter();

                if (lboAgent.SelectedIndex > -1)
                {
                    creditNotes.AgentID = new Guid(lboAgent.SelectedValue);
                }

                if (!String.IsNullOrEmpty(txtDescription.Text))
                {
                    creditNotes.Description = txtDescription.Text;
                }

                if (ddlInvoiceCode.SelectedIndex > 0)
                {
                    creditNotes.InvoiceCode = ddlInvoiceCode.SelectedValue;
                }

                if (ddlReasonCode.SelectedIndex > 0)
                {
                    creditNotes.ReasonCode = ddlReasonCode.SelectedValue;
                }

                if (!String.IsNullOrEmpty(txtCNDate.Text))
                {
                    creditNotes.CreditNoteDate = UtilityController.StringToDate(txtCNDate.Text);
                }

                if (!String.IsNullOrEmpty(txtCNCode.Text))
                {
                    creditNotes.CreditNoteCode = txtCNCode.Text;
                }

                gv.DataSource = creditNotePresenter.SearchData(creditNotes);
                gv.DataBind();

                if (gv.Rows.Count > 0)
                {
                    btnDelete.Visible = true;
                    lblMessage.Text = string.Empty;
                }
                else
                {
                    lblMessage.Text = Constant.MessageNoRecordFound;
                    btnDelete.Visible = false;
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
                    creditNotePresenter = new CreditNotePresenter(this);
                    creditNotePresenter.DataBindings();
                }
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "CreditNote";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSysMessage.Text = ex.Message;
            }
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String creditNoteID = gv.DataKeys[e.Row.RowIndex].Values[(short)Constant.GVDataKeyNames.CreditNoteID].ToString();
                TextBox txtDate = (TextBox)e.Row.FindControl("txtDate");
                TextBox txtAmount = (TextBox)e.Row.FindControl("txtAmount");
                TextBox txtDescription = (TextBox)e.Row.FindControl("txtDescription");
                LinkButton lnkPrint = (LinkButton)e.Row.FindControl("lnkPrint");

                txtDate.Attributes.Add("onchange", String.Format("SaveItemByAjax('{0}', 'CreditNoteDate', '{1}')", txtDate.ClientID, creditNoteID));
                txtAmount.Attributes.Add("onchange", String.Format("SaveItemByAjax('{0}', 'CreditNoteAmount', '{1}')", txtAmount.ClientID, creditNoteID));
                txtDescription.Attributes.Add("onchange", String.Format("SaveItemByAjax('{0}', 'Description', '{1}')", txtDescription.ClientID, creditNoteID));

                hdnJQueryDate.Value = hdnJQueryDate.Value + " $('#" + txtDate.ClientID + "').datepicker();";
                
                DropDownList ddlGST = (DropDownList) e.Row.FindControl("ddlGST"); 
                ddlGST.DataSource = gstPresenter.GetGSTTypes();
                ddlGST.DataTextField = "Description";
                ddlGST.DataValueField = "GSTTypeCode";
                ddlGST.DataBind();
                ddlGST.Attributes.Add("onchange", String.Format("SaveItemByAjax('{0}', 'GSTTypeCode', '{1}')", ddlGST.ClientID, creditNoteID));
                ddlGST.Items.FindByValue(gv.DataKeys[e.Row.RowIndex].Values["GSTTypeCode"].ToString()).Selected = true;

                DropDownList ddlReason = (DropDownList)e.Row.FindControl("ddlReasonCode");
                ddlReason.DataSource = creditNotePresenter.GetAllReason();
                ddlReason.DataTextField = "ReasonCode";
                ddlReason.DataValueField = "ReasonCode";
                ddlReason.DataBind();
                ddlReason.Attributes.Add("onchange", String.Format("SaveItemByAjax('{0}', 'ReasonCode', '{1}')", ddlReason.ClientID, creditNoteID));
                ddlReason.Items.FindByValue(gv.DataKeys[e.Row.RowIndex].Values["ReasonCode"].ToString()).Selected = true;

                ReportPresenter reportPresenter = new ReportPresenter();

                String script = reportPresenter.GetPopUpScript("CREDITNOTE", creditNoteID);

                //String script = "/Report/CrystalReportView.aspx?ReportCode=CREDITNOTE&CreditNoteID=" + creditNoteID;
                lnkPrint.Attributes.Add("onclick", script);
                
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                RegisterScript(hdnJQueryDate.Value);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                creditNotePresenter = new CreditNotePresenter(this);
                creditNotePresenter.SearchData();
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "CreditNote";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSysMessage.Text = ex.Message;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                creditNotePresenter = new CreditNotePresenter(this);
                if (hdnCNID.Value.Trim().Equals(string.Empty))
                {
                    creditNotePresenter.SaveData((short)Constant.TransactionType.SaveCreditNote);
                }
                else
                {
                    creditNotePresenter.SaveData((short)Constant.TransactionType.UpdateCreditNote);
                }
                
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "CreditNote";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblMessageSave.Text = ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                creditNotePresenter = new CreditNotePresenter(this);
                List<CreditNotes> listCreditNote = new List<CreditNotes>();

                for(int i = 0; i < gv.Rows.Count; i++)
                {
                    if(((CheckBox) gv.Rows[i].Cells[9].FindControl("gvCheckbox")).Checked){
                        CreditNotes creditNotes = new CreditNotes();
                        creditNotes.CreditNoteID = new Guid(gv.DataKeys[i].Values[(short)Constant.GVDataKeyNames.CreditNoteID].ToString());
                        listCreditNote.Add(creditNotes);
                    }
                }
                if (listCreditNote.Count > 0)
                {
                    lblMessage.Text = creditNotePresenter.BatchDeleteCreditNote(listCreditNote);
                    creditNotePresenter.SearchData();
                }
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "CreditNote";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSysMessage.Text = ex.Message;
            }
        }

        #endregion

        #region Helper Methods
        private void LoadSaveControls()
        {
            btnCancel.Visible = true;
            btnCancel.Attributes.Add("onclick", "window.close();");

            CreditNotes creditNotes = new CreditNotes();
            creditNotes.InvoiceCode = DecodeFrom64(Request.QueryString["InvoiceCode"]);

            if (creditNotePresenter.IsInvoiceCodeExists(creditNotes.InvoiceCode))
            {
                Invoices invoices = creditNotePresenter.GetInvoiceByCode(creditNotes.InvoiceCode);
                ddlInvoiceCodeSave.Items.FindByValue(creditNotes.InvoiceCode).Selected = true;
                ddlInvoiceCodeSave.Enabled = false;
                lboAgentSave.SelectedItem.Selected = false;
                lboAgentSave.Items.FindByValue(invoices.AgentID.ToString()).Selected = true;
                lboAgentSave.CssClass = "hiddencol";
                hdnAgentID.Value = invoices.AgentID.ToString();
                lblAgent.Text = lboAgentSave.SelectedItem.Text;
            }
        }

        private Constant.LoadingType LoadByAction()
        {
            //Constant.LoadingType

            if (Request.QueryString["Action"] != null && Request.QueryString["Action"] != String.Empty)
            {
                if (Request.QueryString["Action"] == "Show")
                {
                    return Constant.LoadingType.Show;
                }
                else if (Request.QueryString["Action"] == "Create")
                {
                    return Constant.LoadingType.Create;
                }
                else
                {
                    return Constant.LoadingType.Edit;
                }
            }
            else
            {
                return Constant.LoadingType.None;
            }
        }

        public String GetAgentName(String agentID)
        {
            if (ListAgent == null)
            {
                ListAgent = creditNotePresenter.GetAgents();
            }
            Agents agents = ListAgent.Find(
                delegate(Agents agent)
                {
                    return agent.AgentID == new Guid(agentID);
                });
            return agents.Agent;
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

        public static string DecodeFrom64(string encodedData)
        {

            byte[] bytes = System.Convert.FromBase64String(encodedData);
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetString(bytes, 0, bytes.Length); 

        }
        #endregion

        #region Properties

            private List<Agents> _listAgent;
            protected List<Agents> ListAgent
            {
                get 
                {
                    return _listAgent; 
                }
                set
                {
                    _listAgent = value;
                }
            }


        #endregion



    }
}