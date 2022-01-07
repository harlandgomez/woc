using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Woc.Book.Payroll.BusinessEntity;
using Woc.Book.Payroll.Presenter;
using Woc.Book.Payroll.Constant;

using Woc.Book.Base.Presenter; 
 using Woc.Book.Base;
using Woc.Book.Setting.BusinessEntity;
using Woc.Book.Setting.Presenter;

using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;

//Export To Excel
using System.Web.UI.HtmlControls;
using System.IO;
namespace WOC.Book.Accounts
{
    public partial class Payroll : System.Web.UI.Page, IAccount
    {
        #region Declaration
        PayrollPresenter payrollPresenter;
        SettingPresenter settingPresenter;

        const String dataTextField = Woc.Book.Base.Constant.Constant.DataTextField;
        const String dataValueField = Woc.Book.Base.Constant.Constant.DataValueField;
        #endregion

        #region interface
        public void SaveData(short TransactionType)
        {
            ListOfRule.Clear();
            PayrollRules payrollRules;

            for (int i = 0; i < gvRule.Rows.Count; i++)
            {

                payrollRules = new PayrollRules();
                payrollRules.RuleID = new Guid(gvRule.DataKeys[i].Values[0].ToString());

                String TimeFactorID = ((DropDownList)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.TimeFactor].FindControl("gvRuleDropDownTimeFactor")).SelectedValue;
                String startDate = ((TextBox)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.FromDate].FindControl("gvRuleTextboxFromDate")).Text;
                String endDate = ((TextBox)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.ToDate].FindControl("gvRuleTextboxToDate")).Text;
                String startTime = ((TextBox)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.FromDate].FindControl("gvRuleTextboxFromTime")).Text;
                String endTime = ((TextBox)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.ToDate].FindControl("gvRuleTextboxToTime")).Text;
                String startDay = ((DropDownList)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.FromDate].FindControl("gvRuleDropdownFromDate")).SelectedValue;
                String endDay = ((DropDownList)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.ToDate].FindControl("gvRuleDropdownToDate")).SelectedValue;
                String operatorVal = ((DropDownList)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.Operator].FindControl("gvRuleDropdownOperator")).SelectedValue;
                String amount = ((TextBox)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.Amount].FindControl("gvTextboxAmount")).Text;


                payrollRules.TimeFactorID = Convert.ToInt16(TimeFactorID);
                payrollRules.StartDate = UtilityController.StringToDate(startDate);
                payrollRules.EndDate = UtilityController.StringToDate(endDate);
                payrollRules.StartTime = startTime;
                payrollRules.EndTime = endTime;
                payrollRules.StartDay = startDay;
                payrollRules.EndDay = endDay;
                payrollRules.Operator = operatorVal;
                payrollRules.Amount = Convert.ToDecimal(amount);
                payrollRules.SortOrder = (i + 1);
                ListOfRule.Add(payrollRules);
            }
            payrollPresenter = new PayrollPresenter(this);
            lblRuleMessage.Text = payrollPresenter.SaveRules(ListOfRule);
            payrollPresenter.DataBindings();


        }

        public void DataBindings()
        {
            settingPresenter = new SettingPresenter();
            ListTimeFactor = settingPresenter.GetDropdownValues(Constant.TimeFactorList);
            ListDayOfWeek = settingPresenter.GetDropdownValues(Constant.DayOfWeekList);
            ListOfOperator = settingPresenter.GetDropdownValues(Constant.OperatorList);
            ListOfRule = payrollPresenter.GetRules();
            gvRule.DataSource = ListOfRule;
            gvRule.DataBind();

            btnAddRule.Attributes.Add("onclick", "SelectLastTab();");

        }

        public void SearchData()
        {
            payrollPresenter = new PayrollPresenter();
            PayrollDTO pr = new PayrollDTO();
            pr.payrollRules.StartDate = UtilityController.StringToDate(txtStartDate.Text);
            pr.payrollRules.EndDate = UtilityController.StringToDate(txtEndDate.Text);

            if (!String.IsNullOrEmpty(txtDriver.Text.Trim().ToString())){
                pr.DriverName = txtDriver.Text;
            }

            gv.DataSource = payrollPresenter.SearchData(pr);
            gv.DataBind();
            ibtnListAll.Visible = true;
        }        
        #endregion

        #region control events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {  
                    payrollPresenter = new PayrollPresenter(this);
                    payrollPresenter.DataBindings();
                }

                catch (Exception ex)
                {
                    ErrorHandlers errorHandlers = new ErrorHandlers();
                    ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                    errorHandlers.StackTrace = ex.StackTrace.ToString();
                    errorHandlers.Message = ex.Message.ToString();
                    errorHandlers.Source = ex.Source.ToString();
                    errorHandlers.Module = "Payroll";
                    errorHandlers.UserID = User.Identity.Name;
                    errorHandlerPresenter.SaveData(errorHandlers);
                    lblMessage.Text = ex.Message.ToString();
                }
            }
        }

        protected void btnAddRule_Click(object sender, EventArgs e)
        {
            try
            {            
                AddRule();
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Payroll";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblMessage.Text = ex.Message.ToString();
            }

        }

        protected void btnDeleteRule_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRule();
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Payroll";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblMessage.Text = ex.Message.ToString();
            }
        }

        protected void gvRule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Int16 timeFactorValue = Int16.Parse(DataBinder.Eval(e.Row.DataItem, "TimeFactorID").ToString());
                String operatorValue = DataBinder.Eval(e.Row.DataItem, "Operator").ToString();
                String startDayValue = DataBinder.Eval(e.Row.DataItem, "StartDay").ToString();
                String endDayValue = DataBinder.Eval(e.Row.DataItem, "EndDay").ToString();

                DropDownList ddlTimeFactor = (DropDownList)e.Row.Cells[(short)Constant.GridRuleColumn.TimeFactor].FindControl("gvRuleDropDownTimeFactor");
                DropDownList ddlFromDayOfWeek = (DropDownList)e.Row.Cells[(short)Constant.GridRuleColumn.FromDate].FindControl("gvRuleDropdownFromDate");
                DropDownList ddlToDayOfWeek = (DropDownList)e.Row.Cells[(short)Constant.GridRuleColumn.FromDate].FindControl("gvRuleDropdownToDate");
                TextBox txtFromDate = (TextBox)e.Row.Cells[(short)Constant.GridRuleColumn.FromDate].FindControl("gvRuleTextboxFromDate");
                TextBox txtFromTime = (TextBox)e.Row.Cells[(short)Constant.GridRuleColumn.FromDate].FindControl("gvRuleTextboxFromTime");
                TextBox txtToDate = (TextBox)e.Row.Cells[(short)Constant.GridRuleColumn.FromDate].FindControl("gvRuleTextboxToDate");
                TextBox txtToTime = (TextBox)e.Row.Cells[(short)Constant.GridRuleColumn.FromDate].FindControl("gvRuleTextboxToTime");
                DropDownList ddlOperator = (DropDownList)e.Row.Cells[(short)Constant.GridRuleColumn.Operator].FindControl("gvRuleDropdownOperator");
                
                ddlTimeFactor.DataSource = ListTimeFactor;
                ddlTimeFactor.DataTextField = dataTextField;
                ddlTimeFactor.DataValueField = dataValueField;
                ddlTimeFactor.DataBind();
                ddlTimeFactor.Items.FindByValue(timeFactorValue.ToString()).Selected = true;

                ddlFromDayOfWeek.DataSource = ListDayOfWeek;
                ddlFromDayOfWeek.DataTextField = dataTextField;
                ddlFromDayOfWeek.DataValueField = dataValueField;
                ddlFromDayOfWeek.DataBind();

                ddlToDayOfWeek.DataSource = ListDayOfWeek;
                ddlToDayOfWeek.DataTextField = dataTextField;
                ddlToDayOfWeek.DataValueField = dataValueField;
                ddlToDayOfWeek.DataBind();

                ddlOperator.DataSource = ListOfOperator;
                ddlOperator.DataTextField = dataTextField;
                ddlOperator.DataValueField = dataValueField;
                ddlOperator.DataBind();
                ddlOperator.Items.FindByValue(operatorValue).Selected = true;

                switch (timeFactorValue)
                {
                    case 1:
                        ddlFromDayOfWeek.Items.FindByValue(startDayValue).Selected = true;
                        ddlToDayOfWeek.Items.FindByValue(endDayValue).Selected = true;
                        ddlFromDayOfWeek.CssClass = "viscol";
                        ddlToDayOfWeek.CssClass = "viscol";
                        txtFromDate.CssClass = "hiddencol";
                        txtToDate.CssClass = "hiddencol";
                        txtFromTime.CssClass = "hiddencol";
                        txtToTime.CssClass = "hiddencol";
                        break;
                    case 2:
                        ddlToDayOfWeek.CssClass = "hiddencol";
                        ddlFromDayOfWeek.CssClass = "hiddencol";
                        txtFromDate.CssClass = "viscol";
                        txtToDate.CssClass = "viscol";
                        txtFromTime.CssClass = "hiddencol";
                        txtToTime.CssClass = "hiddencol";
                        break;
                    case 3:
                        ddlToDayOfWeek.CssClass = "hiddencol";
                        ddlFromDayOfWeek.CssClass = "hiddencol";
                        txtFromDate.CssClass = "hiddencol";
                        txtToDate.CssClass = "hiddencol";
                        txtFromTime.CssClass = "viscol";
                        txtToTime.CssClass = "viscol";
                        break;
                }
                
                ddlTimeFactor.Attributes.Add(@"onchange", @"ShowHideControls('"+ ddlTimeFactor.ClientID +"','" + 
                                                                                 ddlFromDayOfWeek.ClientID + "','" + 
                                                                                 txtFromDate.ClientID + "','" + 
                                                                                 txtFromTime.ClientID + "','" +
                                                                                 ddlToDayOfWeek.ClientID + "','" +
                                                                                 txtToDate.ClientID + "','" +
                                                                                 txtToTime.ClientID + "');");


            }
        }

        protected void btnSaveRule_Click(object sender, EventArgs e)
        {
            payrollPresenter = new PayrollPresenter(this);
            payrollPresenter.SaveData((short)Constant.TransactionMode.SaveRules);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            payrollPresenter = new PayrollPresenter(this);
            payrollPresenter.SearchData();
        }

        protected void ibtnListAll_Click(object sender, ImageClickEventArgs e)
        {
            String fileName = Woc.Book.Base.Constant.Constant.ExportToExcelTypeID.Payroll.ToString() + ".xls";
            string style = @"<style> .text { mso-number-format:\@; } </script> ";

            Response.ClearContent();
            Response.AddHeader("content-disposition", String.Format("attachment;filename={0}",fileName));
            Response.ContentType = "application/excel";

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            gv.RenderControl(htw);
            Response.Write(style);
            Response.Write(sw.ToString());
            Response.End();
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Attributes.Add("class", "text");

            }
        }

        protected void gv_PreRender(object sender, EventArgs e)
        {
            MergeRows(gv);
        }

        protected void gvRule_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        
        }
        #endregion

        #region Helper Methods

        private void AddRule()
        {
            ListOfRule.Clear();
            PayrollRules payrollRules;

            for (int i = 0; i < gvRule.Rows.Count; i++)
            {

                payrollRules = new PayrollRules();
                payrollRules.RuleID = new Guid(gvRule.DataKeys[i].Values[0].ToString());

                String TimeFactorID = ((DropDownList)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.TimeFactor].FindControl("gvRuleDropDownTimeFactor")).SelectedValue;
                String startDate = ((TextBox)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.FromDate].FindControl("gvRuleTextboxFromDate")).Text;
                String endDate = ((TextBox)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.ToDate].FindControl("gvRuleTextboxToDate")).Text;
                String startTime = ((TextBox)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.FromDate].FindControl("gvRuleTextboxFromTime")).Text;
                String endTime = ((TextBox)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.ToDate].FindControl("gvRuleTextboxToTime")).Text;
                String startDay = ((DropDownList)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.FromDate].FindControl("gvRuleDropdownFromDate")).SelectedValue;
                String endDay = ((DropDownList)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.ToDate].FindControl("gvRuleDropdownToDate")).SelectedValue;
                String operatorVal = ((DropDownList)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.Operator].FindControl("gvRuleDropdownOperator")).SelectedValue;
                String amount = ((TextBox)gvRule.Rows[i].Cells[(short)Constant.GridRuleColumn.Amount].FindControl("gvTextboxAmount")).Text;


                payrollRules.TimeFactorID = Convert.ToInt16(TimeFactorID);
                payrollRules.StartDate = UtilityController.StringToDate(startDate);
                payrollRules.EndDate = UtilityController.StringToDate(endDate);
                payrollRules.StartTime = startTime;
                payrollRules.EndTime = endTime;
                payrollRules.StartDay = startDay;
                payrollRules.EndDay = startDay;
                payrollRules.Operator = operatorVal;
                payrollRules.Amount = Convert.ToDecimal(amount);
                ListOfRule.Add(payrollRules);
            }

            payrollRules = new PayrollRules();
            payrollRules.RuleID = Guid.NewGuid();
            payrollRules.TimeFactorID = 1;
            payrollRules.StartDate = DateTime.Today;
            payrollRules.EndDate = DateTime.Today;
            payrollRules.StartTime = "0000";
            payrollRules.EndTime = "0000";
            payrollRules.StartDay = "1";
            payrollRules.EndDay = "1";
            payrollRules.Operator = "+";
            payrollRules.Amount = Convert.ToDecimal("0.0");
            ListOfRule.Add(payrollRules);
            gvRule.DataSource = ListOfRule;
            gvRule.DataBind();
        }

        public static void MergeRows(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                if (row.Cells[0].Text == previousRow.Cells[0].Text)
                {
                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 :
                                            previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;
                }

            }
        }

        private void DeleteRule()
        {
            PayrollRules payrollRules;
            payrollPresenter = new PayrollPresenter();

            List<PayrollRules> listPayrollRules = new List<PayrollRules>();

            for (int idx = 0; idx < gvRule.Rows.Count; idx++)
            {
                CheckBox gvCheckBoxDelete = (CheckBox)gvRule.Rows[idx].Cells[(int)Constant.GridRuleColumn.CheckDelete].FindControl("gvCheckBoxDelete");
                if (gvCheckBoxDelete.Checked)
                {
                    payrollRules = new PayrollRules();
                    payrollRules.RuleID = (Guid)gvRule.DataKeys[idx].Values[(int)Constant.GridRuleKeys.RuleID];
                    listPayrollRules.Add(payrollRules);
                }
            }
            lblRuleMessage.Text =  payrollPresenter.DeleteRules(listPayrollRules);

            payrollPresenter = new PayrollPresenter(this);
            payrollPresenter.DataBindings();
        }
        #endregion

        #region Properties
        private List<PayrollRules> ListOfRule
        {
            get
            {
                if (ViewState["Rules"] == null)
                {
                    List<PayrollRules> listofRule = new List<PayrollRules>();
                    ViewState.Add("Rules", listofRule);
                }
                return (List<PayrollRules>)ViewState["Rules"];
            }
            set
            {
                ViewState.Add("Rules", value);
            }
        }

        private List<DropDowns> ListTimeFactor
        {
            get
            {
                if (ViewState["TimeFactor"] == null)
                {
                    List<DropDowns> listTimeFactor= new List<DropDowns>();
                    ViewState.Add("TimeFactor", listTimeFactor);
                }
                return (List<DropDowns>)ViewState["TimeFactor"];
            }
            set
            {
                ViewState.Add("TimeFactor", value);
            }
        }

        private List<DropDowns> ListDayOfWeek
        {
            get
            {
                if (ViewState["DayOfWeek"] == null)
                {
                    List<DropDowns> listDayOfWeek = new List<DropDowns>();
                    ViewState.Add("DayOfWeek", listDayOfWeek);
                }
                return (List<DropDowns>)ViewState["DayOfWeek"];
            }
            set
            {
                ViewState.Add("DayOfWeek", value);
            }
        }

        private List<DropDowns> ListOfOperator
        {
            get
            {
                if (ViewState["Operator"] == null)
                {
                    List<DropDowns> listOfOperator = new List<DropDowns>();
                    ViewState.Add("Operator", listOfOperator);
                }
                return (List<DropDowns>)ViewState["Operator"];
            }
            set
            {
                ViewState.Add("Operator", value);
            }
        }  

        #endregion







        
    }

}