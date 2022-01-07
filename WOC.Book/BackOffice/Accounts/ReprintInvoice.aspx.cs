using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Woc.Book.Base.Presenter; 
 using Woc.Book.Base;
using Woc.Book.ReInvoice.Presenter;
using Woc.Book.ReInvoice.BusinessEntity;
using Woc.Book.ReInvoice.Constant;
using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;

using Woc.Book.Report.Presenter;
namespace WOC.Book.Accounts
{
    public partial class ReprintInvoice : System.Web.UI.Page, IAccount

    {
        ReInvoicePresenter reInvoicePresenter;
        const String DateFormat = Woc.Book.Base.Constant.Constant.DateFormat;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    reInvoicePresenter = new ReInvoicePresenter(this);
                    reInvoicePresenter.DataBindings();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            reInvoicePresenter = new ReInvoicePresenter(this);
            reInvoicePresenter.SearchData();
        }

        protected void gv_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[(int)Constant.GridViewColumns.AgentID].CssClass = "hiddencol";
                e.Row.Cells[(int)Constant.GridViewColumns.InvoiceID].CssClass = "hiddencol";
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[(int)Constant.GridViewColumns.AgentID].CssClass = "hiddencol";
                e.Row.Cells[(int)Constant.GridViewColumns.InvoiceID].CssClass = "hiddencol";
            }
        }

        public void SaveData(short TransactionType)
        {
            
        }

        public void DataBindings()
        {
            try
            {
                reInvoicePresenter = new ReInvoicePresenter();
                lboAgent.DataSource = reInvoicePresenter.GetAgents();
                lboAgent.DataTextField = "agent";
                lboAgent.DataValueField = "agentid";
                lboAgent.DataBind();
                ddlInvoice.DataSource = reInvoicePresenter.GetListInvoice();
                ddlInvoice.DataTextField = "InvoiceCode";
                ddlInvoice.DataValueField = "InvoiceID";
                ddlInvoice.DataBind();
                ddlInvoice.Items.Insert(0, new ListItem("-- Select Invoice --", "00000000-0000-0000-0000-000000000000"));
                btnSearch.Attributes.Add("onclick", "SelectLastTab();");

                ((BoundField)this.gv.Columns[(int)Constant.GridViewColumns.InvoiceDate]).DataFormatString = Properties.WebResources.gvDateFormat.ToString();
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "ReprintInvoice";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblMessage.Text = ex.Message.ToString();
            }
        }

        public void SearchData()
        {
            try
            {
                reInvoicePresenter = new ReInvoicePresenter();
                ReInvoiceDTO reinvoices = new ReInvoiceDTO();
                reinvoices.AgentID = new Guid(lboAgent.SelectedValue.ToString());
                String startDate = "-";
                String endDate = "-";

                if (!txtStartDate.Text.Equals(string.Empty))
                {
                    reinvoices.StartDate = UtilityController.StringToDate(txtStartDate.Text);
                    startDate = reinvoices.StartDate.ToString(DateFormat);
                }

                if (!txtEndDate.Text.Equals(string.Empty))
                {
                    reinvoices.EndDate = UtilityController.StringToDate(txtEndDate.Text);
                    endDate = reinvoices.EndDate.ToString(DateFormat);
                }

                reinvoices.InvoiceID = new Guid(ddlInvoice.SelectedValue.ToString());
                gv.DataSource = reInvoicePresenter.GetListInvoice(reinvoices);
                gv.DataBind();


                if (gv.Rows.Count == 0)
                {
                    lblMessage.Text = String.Format(Constant.NoRecordFoundMessage,
                                                    startDate,
                                                    endDate,
                                                    lboAgent.SelectedItem.Text);
                }
                else
                {
                    if (ddlInvoice.SelectedIndex == 0)
                    {
                        startDate = Convert.ToDateTime(gv.DataKeys[0].Values[(int)Constant.GridKeys.InvoiceDate]).ToString(Properties.WebResources.dateformat);
                        endDate = Convert.ToDateTime(gv.DataKeys[gv.Rows.Count - 1].Values[(int)Constant.GridKeys.InvoiceDate]).ToString(Properties.WebResources.dateformat); 

                        lblMessage.Text = String.Format(Constant.RecordFoundMessage, gv.Rows.Count.ToString(),
                                                        startDate,
                                                        endDate,
                                                        lboAgent.SelectedItem.Text);
                    }
                    else
                    {
                        lblMessage.Text = string.Empty;
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
                errorHandlers.Module = "ReprintInvoice";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblMessage.Text = ex.Message.ToString();
            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row = Convert.ToInt16(e.CommandArgument);
                Guid invoiceID = new Guid(gv.DataKeys[row].Value.ToString());
                switch (e.CommandName)
                {
                    case "Select":
                        ReportPresenter reportPresenter = new ReportPresenter();

                        String script = reportPresenter.GetPopUpScript("INVOICE", invoiceID.ToString());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", script, true);
                        break;
                    case "Edit":
                        Response.Redirect(string.Format("Invoice.aspx?InvoiceID={0}",invoiceID.ToString()));
                        break;

                }

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "ReprintInvoice";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }
    }
}