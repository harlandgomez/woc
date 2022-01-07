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

using Woc.Book.Report.Presenter;
namespace WOC.Book.Report
{
    public partial class SalesReportByCustomer : System.Web.UI.Page, IAccount
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

        protected void btnSearch_Click1(object sender, EventArgs e)
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
                errorHandlers.Module = "SalesReportByCustomer";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            String strPayment = string.Empty;

            if (this.cblPayment.SelectedIndex == 0)
            {
                strPayment = "P";

            }
            if (this.cblPayment.SelectedIndex == 1)
            {
                strPayment = "U";

            }
            if (this.cblPayment.SelectedIndex == 0 && this.cblPayment.SelectedIndex == 1)
            {
                strPayment = "A";
            }

            ReportPresenter reportPresenter = new ReportPresenter();

            String script = reportPresenter.GetPopUpScript("SALESREPORTBYCUSTOMER", this.txtSearch.Text.Trim(), this.txtDateFrom.Text, txtDateTo.Text, strPayment);
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
                errorHandlers.Module = "SalesReportByCustomer";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }
        public void SearchData()
        {
            try
            {
                SalesReportbyCustomers salesReportbyCustomers = new SalesReportbyCustomers();
                String strPayment = string.Empty;

                salesReportbyCustomers.Payment = "A";

                if (this.cblPayment.Items[0].Selected)
                {
                    salesReportbyCustomers.Payment = "P";
                }
                
                if (this.cblPayment.Items[1].Selected)
                {
                    salesReportbyCustomers.Payment = "U";
                }
                
                if (this.cblPayment.Items[1].Selected && this.cblPayment.Items[0].Selected)
                {
                    salesReportbyCustomers.Payment = "A";
                }

                salesReportbyCustomers.InvoiceDateFrom = UtilityController.StringToDate(this.txtDateFrom.Text.Trim());
                salesReportbyCustomers.InvoiceDateTo = UtilityController.StringToDate(this.txtDateTo.Text.Trim());
                salesReportbyCustomers.Prefix= txtSearch.Text.Trim();
                statementOfAccountPresenter = new StatementOfAccountPresenter();
                gv.DataSource = statementOfAccountPresenter.SearchDataSales(salesReportbyCustomers);
                gv.DataBind();


            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "SalesReportByCustomer";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
        }
        public void DataBindings()
        {
            this.txtDateFrom.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddMonths(-1));
            this.txtDateTo.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            ((BoundField)this.gv.Columns[(int)Constant.GridViewSalesReport.InvoiceDate]).DataFormatString = Properties.WebResources.gvDateFormat.ToString();
        }
        #endregion

       
    }
}