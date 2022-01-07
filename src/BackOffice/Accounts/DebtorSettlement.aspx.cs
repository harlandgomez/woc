using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//WOC
using Woc.Book.Company.Presenter;
using Woc.Book.Company.BusinessEntity;
using Woc.Book.Base.Presenter; 
using Woc.Book.Base;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Constant;
using Woc.Book.Setting.Presenter;

//Agent 
using Woc.Book.Agent.BusinessEntity;
//ErrorHandler
using Woc.Book.ErrorHandler;
using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;

//DebtorSettlement
using Woc.Book.DebtorSettlement;
using Woc.Book.DebtorSettlement.Presenter;
using Woc.Book.DebtorSettlement.BusinessEntity;
using Woc.Book.DebtorSettlement.Service;
using Woc.Book.DebtorSettlement.Constant;

//Invoice
using Woc.Book.Invoice;
using Woc.Book.Invoice.BusinessEntity;
namespace WOC.Book.Accounts
{
    public partial class DebtorSettlement : System.Web.UI.Page, IAccount
    {
        #region Declaration
        DebtorSettlementPresenter debtorSettlementPresenter;
        UserPresenter userPresenter;
        #endregion

        #region ControlEvents
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    btnCancel.Attributes.Add("onclick", "SelectFirstTab();");
                    btnSearch.Attributes.Add("onclick", "SelectSecondTab();");
                    
                    debtorSettlementPresenter = new DebtorSettlementPresenter(this);
                    debtorSettlementPresenter.DataBindings();

                    if (Request.QueryString["agent"] != null && Request.QueryString["agent"] != String.Empty && Request.QueryString["agent"] != "undefined")
                    {
                        ddlAgents.SelectedItem.Selected = false;
                        ddlAgents.Items.FindByValue(Request.QueryString["agent"].ToString()).Selected = true;
                        txtInvoiceNo.Text = Request.QueryString["invoice"];
                        debtorSettlementPresenter = new DebtorSettlementPresenter(this);
                        debtorSettlementPresenter.SearchData();
                    }

                    if (ddlPaymentMode.SelectedValue == "Cheque")
                    {
                        txtChequeNumber.Enabled = true;
                    }
                    else
                    {
                        txtChequeNumber.Enabled = false;
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
                errorHandlers.Module = "DebtorSettlement";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error:"  + ex.Message.ToString();
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                debtorSettlementPresenter = new DebtorSettlementPresenter(this);
                debtorSettlementPresenter.SearchData();
                lblMessage.Text = String.Empty;
                lblSystemError.Text = String.Empty;
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "DebtorSettlement";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }

        protected void gvDebut_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            String script = string.Empty;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TextBox txtPaymentAmount = (TextBox)e.Row.FindControl("txtPaymentAmount");
                TextBox txtAmountDue = (TextBox)e.Row.FindControl("txtAmountDue");
                TextBox txtCNAmount = (TextBox)e.Row.FindControl("txtCNAmount");
                TextBox txtTotalAmount = (TextBox)e.Row.FindControl("txtTotalAmount");
                TextBox txtBalance = (TextBox)e.Row.FindControl("txtBalance");
                TextBox txtDeposit = (TextBox)e.Row.FindControl("txtDeposit");
                LinkButton lnkCNNo = (LinkButton)e.Row.FindControl("lnkCNNo");
                ImageButton ibtnCreateCN = (ImageButton)e.Row.FindControl("ibtnCreateCN");
                String invoiceCode = ((Label)e.Row.FindControl("lblInvoiceCode")).Text;
                
                invoiceCode = textToBase64(invoiceCode);
                script = @"ComputeBalance('" + txtTotalAmount.ClientID + "','" + txtCNAmount.ClientID + "','" + 
                                                txtPaymentAmount.ClientID + "','" + txtAmountDue.ClientID + "','" + 
                                                txtDeposit.ClientID + "','" + txtBalance.ClientID + "');";

                txtPaymentAmount.Attributes.Add("onblur", script);
                txtDeposit.Attributes.Add("onblur", script);

                if (lnkCNNo.Text.Trim() == "Create")
                {
                    ibtnCreateCN.Visible = false;
                }
                else {
                    ibtnCreateCN.Visible = true;
                }
                ibtnCreateCN.Attributes.Add("onClick", "PopupCreditNote('Create','" + invoiceCode + "', '" + ddlAgents.SelectedValue + "');");
                lnkCNNo.Attributes.Add("onClick", "PopupCreditNote('"+ lnkCNNo.Text +"','" + invoiceCode + "', '"+ ddlAgents.SelectedValue +"');");
            }
        }
        #endregion 

        #region Interface

        public void SaveData(Int16 TransactionType)
        {

            try
            {
                userPresenter = new UserPresenter();
                DebtorSettlementDTO debtorSettlementDTO = new DebtorSettlementDTO();
                Payments payments = new Payments();
                List<Payments> listPayment = new List<Payments>();
                Decimal transDiff = 0;
                Decimal amtToCollect = 0;

                debtorSettlementPresenter = new DebtorSettlementPresenter(this);
                debtorSettlementDTO.Description = txtDescription.Text;
                debtorSettlementDTO.ReceiptDate = DateTime.Now;


                Label lblInvoiceCode;
                LinkButton lnkCNNo;
                TextBox txtCNAmount;
                TextBox txtTotalAmount;
                TextBox txtPaymentAmount;
                TextBox txtAmountDue;
                TextBox txtAllocationForex;
                TextBox txtDeposit;
                TextBox txtBalance;
                TextBox txtRemark;
                // Select the checkboxes from the GridView control
                for (int i = 0; i < gv.Rows.Count; i++)
                {

                    GridViewRow row = gv.Rows[i];
                    bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                    if (isChecked)
                    {

                        lblInvoiceCode = (Label)row.FindControl("lblInvoiceCode");
                        lnkCNNo = (LinkButton)row.FindControl("lnkCNNo");
                        txtCNAmount = (TextBox)row.FindControl("txtCNAmount");
                        txtTotalAmount = (TextBox)row.FindControl("txtTotalAmount");
                        txtPaymentAmount = (TextBox)row.FindControl("txtPaymentAmount");
                        txtAmountDue = (TextBox)row.FindControl("txtAmountDue");
                        txtAllocationForex = (TextBox)row.FindControl("txtAllocationForex");
                        txtDeposit = (TextBox)row.FindControl("txtDeposit");
                        txtBalance = (TextBox)row.FindControl("txtBalance");
                        txtRemark = (TextBox)row.FindControl("txtRemark");

                        payments.AgentID = new Guid(ddlAgents.SelectedValue);
                        payments.InvoiceCode = lblInvoiceCode.Text;
                        payments.InvoiceDate = DateTime.Parse(gv.Rows[i].Cells[2].Text);
                        payments.CNAmount = Convert.ToDecimal(txtCNAmount.Text);
                        payments.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text);
                        payments.PaymentAmount = Convert.ToDecimal(txtPaymentAmount.Text);
                        payments.AmountDue = Convert.ToDecimal(txtAmountDue.Text);
                        payments.Deposit = Convert.ToDecimal(txtDeposit.Text);
                        payments.Remarks = txtRemark.Text;
                        payments.Balance = payments.TotalAmount - (payments.Deposit + payments.PaymentAmount);
                        payments.Deposit = (payments.Deposit + payments.PaymentAmount);
                        payments.Description = txtDescription.Text;
                        payments.PaymentDate = UtilityController.StringToDate(lblReceiptDate.Text);

                        if (ddlPaymentMode.SelectedValue != "Select")
                        {
                            payments.PaymentMode = ddlPaymentMode.SelectedValue;
                        }

                        if (!String.IsNullOrEmpty(txtBank.Text.Trim()))
                        {
                            payments.Bank = txtBank.Text;
                        }

                        if (ddlPaymentMode.SelectedValue == "Cheque")
                        {
                            payments.ChequeNumber = txtChequeNumber.Text.Trim();
                        }

                        payments.Status = (payments.Balance == 0 ? "Paid" : "Partial Paid");
                        payments.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                        payments.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                        listPayment.Add(payments);

                        transDiff += payments.Balance;
                        amtToCollect += payments.PaymentAmount;

                        payments = new Payments();

                    }

                }
                debtorSettlementDTO.AmountCollectible = amtToCollect;
                debtorSettlementDTO.TransactionDifference = transDiff;

                if (listPayment.Count > 0)
                {
                    debtorSettlementDTO.ListPayments = listPayment;
                    lblMessage.Text = debtorSettlementPresenter.SaveData(debtorSettlementDTO);
                }


            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "DebtorSettlement";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }
        public void SearchData()
        {
            if ((ddlAgents.SelectedItem.Text != "Select") || (!string.IsNullOrEmpty(txtInvoiceNo.Text.Trim())))
            {
                DebtorSettlementDTO debtorSettlementDTO = new DebtorSettlementDTO();
                debtorSettlementDTO.AgentID = new Guid(ddlAgents.SelectedItem.Value);
                debtorSettlementDTO.InvoiceCode = txtInvoiceNo.Text.Trim();
                debtorSettlementPresenter = new DebtorSettlementPresenter();
                lblAgentName.Text = ddlAgents.SelectedItem.Text;
                lblReceiptDate.Text = DateTime.Now.ToString(Properties.WebResources.dateformat); 

                gv.DataSource = debtorSettlementPresenter.SearchData(debtorSettlementDTO);
                gv.DataBind();

                if(gv.Rows.Count == 0)
                {
                    ClearControl();
                    lblSearchMessage.Text = Woc.Book.DebtorSettlement.Constant.Constant.NoRecordFound;
                }
            }
            else
            {
                ClearControl();
                gv.DataSource = null;
                gv.DataBind();
            }
        }
        public void DataBindings()
        {
            List<Agents> agentsList = null;
            debtorSettlementPresenter = new DebtorSettlementPresenter(this);
            agentsList = debtorSettlementPresenter.GetAgent();
            if (agentsList != null && agentsList.Count > 0)
            {
                ddlAgents.DataValueField = "AgentID";
                ddlAgents.DataTextField = "Agent";
                ddlAgents.DataSource = agentsList;
                ddlAgents.DataBind();
                ddlAgents.Items.Insert(0, "Select");
                ddlAgents.SelectedIndex = 0;
            }

            else
            {
                ddlAgents.DataSource = null;
                ddlAgents.DataBind();
                ddlAgents.Items.Insert(0, "Select");
                ddlAgents.SelectedIndex = 0;

            
            }
        }
        #endregion


        string textToBase64(string sAscii)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(sAscii);
            return System.Convert.ToBase64String(bytes, 0, bytes.Length);
        } 
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                debtorSettlementPresenter = new DebtorSettlementPresenter(this);
                debtorSettlementPresenter.SaveData(0);
                
                debtorSettlementPresenter = new DebtorSettlementPresenter(this);
                debtorSettlementPresenter.SearchData();
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "DebtorSettlement";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }

        protected void btnPayAll_Click(object sender, EventArgs e)
        {
            Label lblInvoiceCode;
            LinkButton lnkCNNo;
            TextBox txtCNAmount;
            TextBox txtTotalAmount;
            TextBox txtPaymentAmount;
            TextBox txtAmountDue;
            TextBox txtAllocationForex;
            TextBox txtDeposit;
            TextBox txtBalance;
            TextBox txtRemark;

            for (int i = 0; i < gv.Rows.Count; i++)
            {

                GridViewRow row = gv.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("chkSelect")).Checked;

                if (isChecked)
                {

                    lblInvoiceCode = (Label)row.FindControl("lblInvoiceCode");
                    lnkCNNo = (LinkButton)row.FindControl("lnkCNNo");
                    txtCNAmount = (TextBox)row.FindControl("txtCNAmount");
                    txtTotalAmount = (TextBox)row.FindControl("txtTotalAmount");
                    txtPaymentAmount = (TextBox)row.FindControl("txtPaymentAmount");
                    txtAmountDue = (TextBox)row.FindControl("txtAmountDue");
                    txtAllocationForex = (TextBox)row.FindControl("txtAllocationForex");
                    txtDeposit = (TextBox)row.FindControl("txtDeposit");
                    txtBalance = (TextBox)row.FindControl("txtBalance");
                    txtRemark = (TextBox)row.FindControl("txtRemark");

                    txtPaymentAmount.Text = (Convert.ToDecimal(txtPaymentAmount.Text) + Convert.ToDecimal(txtBalance.Text)).ToString();
                    txtBalance.Text = "0.0";
                }
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

       

        protected void btnSaveCreditNote_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelCreditNote_Click(object sender, EventArgs e)
        {

        }

        #region HouseKeeping
        public void ClearControl()
        {
            txtDescription.Text = string.Empty;
            txtChequeNumber.Text = string.Empty;
            txtTransactionDifference.Text = string.Empty;
            ddlPaymentMode.SelectedIndex = 2;
            txtBank.Text = string.Empty;
            gv.DataSource = null;
            gv.DataBind();
        }
        #endregion
    }
}