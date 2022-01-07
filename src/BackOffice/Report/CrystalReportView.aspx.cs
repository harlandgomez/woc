using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection; 

//Crystal report
using CrystalDecisions;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;



using WOC.Book.App_Data;

//Invoice
using Woc.Book.Invoice.Presenter;
using Woc.Book.Invoice.BusinessEntity;

//Credit Note
using Woc.Book.CreditNote.Presenter;
using Woc.Book.CreditNote.BusinessEntity;

using Woc.Book.StatementOfAccount.BusinessEntity;
using Woc.Book.StatementOfAccount.Presenter;


using Woc.Book.Report.BusinessEntity;
using Woc.Book.Report.Presenter;
using Woc.Book.Base.Presenter; 
 using Woc.Book.Base;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Report.Constant;

using CrystalDecisions.Web;


namespace WOC.Book.Report
{
    public partial class CrystalReportView : System.Web.UI.Page
    {
        ReportPresenter reportPresenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            reportPresenter = new ReportPresenter();
            Reports reports = reportPresenter.GetReportByCode(Request.QueryString["ReportCode"]);
            GetReportDataSource(reports);

        }

        private void GetReportDataSource(Reports reports)
        {
            reportPresenter = new ReportPresenter();
            ReportDocument rptDoc = new ReportDocument();
            Object rptSource = null;


            rptDoc.Load(Server.MapPath(reports.ReportPath));

            ParameterFields paramFields = new ParameterFields();

            switch (reports.ReportName)
            {
                case "Invoice":
                    Invoices invoices = reportPresenter.GetInvoiceById(Request.QueryString["InvoiceID"]);
                    rptSource = (List<InvoiceDetails>) reportPresenter.GetInvoiceDetailsByInvoiceID(Request.QueryString["InvoiceID"]);
                    paramFields = GetReportParameters(invoices);

                    break;
                case "CreditNote":
                    CreditNotesDTO creditNotes = reportPresenter.GetCreditNoteByID(Request.QueryString["CreditNoteID"]);
                    List<CreditNotesDTO> creditNotesList = new List<CreditNotesDTO>();
                    creditNotesList.Add(creditNotes);
                    rptSource = creditNotesList;
                    paramFields = GetReportParameters(creditNotes);
                    break;

                case "StatementOfAccount":
                    StatementOfAccounts StatementOfAccountsEntity = new StatementOfAccounts();
                    StatementOfAccountDTO StatementOfAccountsDTO = reportPresenter.GetSOAParemeters("C000024", new Guid(Request.QueryString["AgentID"]));
                    StatementOfAccountsEntity.AgentID = new Guid(Request.QueryString["AgentID"].ToString());
                    if (!String.IsNullOrEmpty(Request.QueryString["dateFrom"].ToString()))
                    {
                    StatementOfAccountsEntity.InvoiceDateFrom = UtilityController.StringToDate(Request.QueryString["dateFrom"]);
                    }
                    if (!String.IsNullOrEmpty(Request.QueryString["dateTo"].ToString()))
                    {
                        StatementOfAccountsEntity.InvoiceDateTo= UtilityController.StringToDate(Request.QueryString["dateTo"]);
                    }
                    StatementOfAccountsEntity.Payment = Request.QueryString["Payment"].ToString();
                    StatementOfAccountPresenter statementOfAccountPresenter = new StatementOfAccountPresenter();
                    List<StatementOfAccounts> statementOfAccountList = statementOfAccountPresenter.SearchData(StatementOfAccountsEntity);
                    rptSource = statementOfAccountList;
                    paramFields = GetReportParameters(StatementOfAccountsDTO);
                    break;

                case "SalesReportByCustomer":
                    SalesReportbyCustomers salesReportbyCustomers = new SalesReportbyCustomers();

                    salesReportbyCustomers.Agent = Request.QueryString["Agent"].ToString();
                    if (!String.IsNullOrEmpty(Request.QueryString["dateFrom"].ToString()))
                    {
                        salesReportbyCustomers.InvoiceDateFrom = UtilityController.StringToDate(Request.QueryString["dateFrom"]);
                    }
                    if (!String.IsNullOrEmpty(Request.QueryString["dateTo"].ToString()))
                    {
                        salesReportbyCustomers.InvoiceDateTo = UtilityController.StringToDate(Request.QueryString["dateTo"]);
                    }
                    salesReportbyCustomers.Payment = Request.QueryString["Payment"].ToString();
                    StatementOfAccountPresenter statementOfAccountPresenterSales = new StatementOfAccountPresenter();
                    List<SalesReportbyCustomers> salesReportbyCustomersList = statementOfAccountPresenterSales.SearchDataSales(salesReportbyCustomers);
                    rptSource = salesReportbyCustomersList;
                    break;
                default:
                    break;
            }

            try
            {
                crystalReportViewer.ToolPanelView = ToolPanelViewType.None;
                rptDoc.SetDataSource(rptSource);

                foreach (ParameterField param in paramFields)
                {
                    //This is obsolete -> rptDoc.ParameterFields.Add(<parameter>);
                    rptDoc.DataDefinition.ParameterFields[param.Name].ApplyCurrentValues(param.CurrentValues);
                }

                crystalReportViewer.ParameterFieldInfo = paramFields;
                crystalReportViewer.ReportSource = rptDoc;
                CreatePDF(rptDoc, reports.ReportName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void CreatePDF(ReportDocument rptDoc, String initialFileName)
        {
            try
            {
                string serverPath = MapPath("~") + Constant.ServerPath;
                string pdfFileName = String.Format("{0}[{1}].pdf", initialFileName, DateTime.Now.ToString(Constant.FileDateFormat));

                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = serverPath + pdfFileName;
                CrExportOptions = rptDoc.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }
                rptDoc.Export();
                Response.Redirect(Constant.WebPath + pdfFileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private ParameterFields GetReportParameters(object entity)
        {
            ParameterFields paramFields = new ParameterFields();
            ParameterField paramField;
            ParameterDiscreteValue paramDiscreteValue;
            bool isNotRptParam = false;
            
            foreach (PropertyInfo info in entity.GetType().GetProperties())
            {
                isNotRptParam = (bool)info.GetCustomAttributes(typeof(IsNotReportParamAttrib), true).Any();

                if (info.CanRead && isNotRptParam == false)
                {

                    paramField = new ParameterField();
                    paramDiscreteValue = new ParameterDiscreteValue();
                    paramField.Name = info.Name;
                    paramDiscreteValue.Value = info.GetValue(entity, null).ToString();
                    paramField.CurrentValues.Add(paramDiscreteValue);
                    paramFields.Add(paramField);
                }
            }
            return paramFields;
        }



    }
}