using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base;
using Woc.Book.Base.Service;
//Internal
using Woc.Book.Report.Service;
using Woc.Book.Report.BusinessEntity;
using Microsoft.Reporting.WebForms;

//StatementOfAccount
using Woc.Book.StatementOfAccount.BusinessEntity;

using Woc.Book.Invoice.BusinessEntity;
using Woc.Book.CreditNote.BusinessEntity;
using Woc.Book.Setting.Service;
using Woc.Book.Report;

namespace Woc.Book.Report
{
    internal  class ReportController
    {
        ReportService _service;

        public Reports GetReport(String id)
        {
            _service = new ReportService();
            return _service.GetReport(id);
        }

        public Reports GetReportByCode(String code)
        {
            _service = new ReportService();
            return _service.GetReportByCode(code);
        }

        public List<InvoiceDetails> GetInvoiceDetailsByInvoiceID(String id)
        {
            _service = new ReportService();
            return _service.GetInvoiceDetailsByInvoiceID(id);
        }

        public List<ReportParameters> GetParametersByReportID(String id)
        {
            _service = new ReportService();
            return _service.GetParametersByReportID(id);
        }

        public Invoices GetInvoice(String id)
        {
            _service = new ReportService();
            return _service.GetInvoice(id);
        }

        public CreditNotesDTO GetCreditNoteByID(String id)
        {
            SettingService settingService = new SettingService();
            _service = new ReportService();

            CreditNotesDTO creditNotes = _service.GetCreditNoteByID(id);
            Decimal gstPercent = Convert.ToDecimal(settingService.GetSettingValue("GST_PERCENTAGE").ToString());

            switch (creditNotes.GSTTypeCode.ToUpper())
            {
                case "NO":
                    creditNotes.TotalAmount = creditNotes.CreditNoteAmount;
                    creditNotes.GSTAmount = 0;
                    break;
                case "INC":
                    creditNotes.TotalAmount = creditNotes.CreditNoteAmount;
                    creditNotes.GSTAmount = (creditNotes.CreditNoteAmount * gstPercent);
                    break;
                case "EXC":
                    creditNotes.TotalAmount = (creditNotes.CreditNoteAmount * gstPercent) + creditNotes.CreditNoteAmount;
                    creditNotes.GSTAmount = (creditNotes.CreditNoteAmount * gstPercent);
                    break;
            }
            return creditNotes;
        }

        public StatementOfAccountDTO GetSOAParameters(String companyCode, Guid agentID)
        {
           ReportService reportService= new ReportService();
           return  reportService.GetSOAParemeters(companyCode,agentID);
        }
        public StatementOfAccounts GetStatementOfAccount(DateTime dateFrom, DateTime dateTo)
        {
            StatementOfAccounts statementOfAccounts = new StatementOfAccounts();
            statementOfAccounts.InvoiceDateFrom = dateFrom;
            statementOfAccounts.InvoiceDateTo = dateTo;
            return statementOfAccounts;
        }


        public DataTable ConvertTo<T>(IList<T> list)
        {
            return CollectionHelper.ConvertTo<T>(list);
        }

        public DataTable CreateTable<T>()
        {
            return CollectionHelper.CreateTable<T>();
        }

        public T CreateItem<T>(DataRow row)
        {
            return CollectionHelper.CreateItem<T>(row);
        }

        /// <summary>
        /// Contruct the javascript for pop up 
        /// </summary>
        public String GetPopUpScript(String ReportCode, params string[] param)
        {
            ReportService reportService= new ReportService();
            Reports reports = reportService.GetReportByCode(ReportCode);
            List<ReportParameters> reportParameterList = reportService.GetParametersByReportID(reports.ReportID.ToString());
            
            String scriptText = System.Web.Configuration.WebConfigurationManager.AppSettings["ReportPath"];
            
            if (reports.ReportType == Properties.Resources.ReportTypeCrystalReport)
            {
                scriptText += Properties.Resources.ReportPageCrystalReport + "?" + Properties.Resources.QueryStringReportCode + "=" + ReportCode;               
            }

            //Populate Query String against the report parameters
            for(Int32 idx = 0; idx < reportParameterList.Count; idx++)
            {
                scriptText += "&" + reportParameterList[idx].ParameterCode + "=" + param[idx];
            }

            scriptText = "javascript:window.open('" + scriptText + "')";

            return scriptText;
        }


    }
}
