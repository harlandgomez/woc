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

//ErrorHandler
using Woc.Book.ErrorHandler;
using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;

//Woc.Book.StatementOfAccount

using Woc.Book.StatementOfAccount;
using Woc.Book.StatementOfAccount.Presenter;
using Woc.Book.StatementOfAccount.BusinessEntity;
using Woc.Book.StatementOfAccount.Service;

//report
using Woc.Book.Report.Presenter;

namespace WOC.Book.Report
{
    public partial class StatementOfAccount : System.Web.UI.Page, IAccount
    {
        #region Declaration
        StatementOfAccountPresenter statementOfAccountPresenter;
        #endregion
        #region Control_Event
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    statementOfAccountPresenter = new StatementOfAccountPresenter(this);
                    statementOfAccountPresenter.DataBindings();
                }


            }

            protected void btnSearch_Click(object sender, EventArgs e)
            {
                try
                {
                    statementOfAccountPresenter = new StatementOfAccountPresenter(this);
                    statementOfAccountPresenter.SearchData();
                }

                catch (Exception ex)
                {
                    ErrorHandlers errorHandlers = new ErrorHandlers();
                    ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                    errorHandlers.StackTrace = ex.StackTrace.ToString();
                    errorHandlers.Message = ex.Message.ToString();
                    errorHandlers.Source = ex.Source.ToString();
                    errorHandlers.Module = "StatementOfAccount";
                    errorHandlers.UserID = User.Identity.Name;
                    errorHandlerPresenter.SaveData(errorHandlers);
                    lblSystemError.Text = "System Error: " + ex.Message.ToString();
                }

            }

            protected void BtnPrint_Click(object sender, EventArgs e)
            {
                String strPayment = string.Empty;
                strPayment = "A";

                if (cblPayment.Items[0].Selected)
                {
                    strPayment = "P";
                }

                if (cblPayment.Items[1].Selected)
                {
                    strPayment = "U";
                }

                if (cblPayment.Items[0].Selected && cblPayment.Items[1].Selected)
                {
                    strPayment = "A";
                }

                ReportPresenter reportPresenter = new ReportPresenter();

                String script = reportPresenter.GetPopUpScript("STATEMENTOFACCOUNT", this.ddlAgent.SelectedValue, this.txtDateFrom.Text, txtDateTo.Text, strPayment);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", script, true);

            }
        #endregion
        #region Interface

        public void SaveData(Int16 TransactionType)
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
                errorHandlers.Module = "StatementOfAccount";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }
        public void SearchData()
        {
            try
            {
                StatementOfAccounts statementOfAccounts = new StatementOfAccounts();
                        
                statementOfAccounts.Payment = "A";

                if (cblPayment.Items[0].Selected)
                {
                    statementOfAccounts.Payment = "P";
                }

                if (cblPayment.Items[1].Selected)
                {
                    statementOfAccounts.Payment  = "U";
                }

                if (cblPayment.Items[0].Selected && cblPayment.Items[1].Selected)
                {
                    statementOfAccounts.Payment = "A";
                }
                           
                statementOfAccounts.InvoiceDateFrom = UtilityController.StringToDate(this.txtDateFrom.Text.Trim());
                statementOfAccounts.InvoiceDateTo = UtilityController.StringToDate(this.txtDateTo.Text.Trim());
                statementOfAccounts.AgentID = new Guid(ddlAgent.SelectedValue);
 
                statementOfAccountPresenter = new StatementOfAccountPresenter();
                gv.DataSource = statementOfAccountPresenter.SearchData(statementOfAccounts);
                gv.DataBind();


            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "StatementOfAccount";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }

        public void DataBindings()
        {
            try
            {
                statementOfAccountPresenter = new StatementOfAccountPresenter(this);

                //Bind Agent
                ddlAgent.DataSource = statementOfAccountPresenter.GetAgents();
                ddlAgent.DataTextField = "Agent";
                ddlAgent.DataValueField = "AgentID";
                ddlAgent.DataBind();

                //Set dates
                txtDateFrom.Text = DateTime.Now.AddMonths(-1).ToString(Properties.WebResources.dateformat);
                txtDateTo.Text = DateTime.Now.ToString(Properties.WebResources.dateformat);

                ((BoundField)this.gv.Columns[(int)Constant.GridViewStatementOfAccount.InvoiceDate]).DataFormatString = Properties.WebResources.gvDateFormat.ToString();
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "StatementOfAccount";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }

        }
        #endregion

             
    }
}