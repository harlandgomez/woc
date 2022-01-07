using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Microsoft.Reporting.WebForms;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Presenter;



//Internal
using Woc.Book.Report;
using Woc.Book.Report.BusinessEntity;

//StatementOfAccount
using Woc.Book.StatementOfAccount.BusinessEntity;
using Woc.Book.StatementOfAccount.Presenter;

using Woc.Book.Invoice.BusinessEntity;
using Woc.Book.CreditNote.BusinessEntity;

namespace Woc.Book.Report.Presenter
{
    public class ReportPresenter: IReportPresenter
    {
        ReportController _controller;
        IReportPresenter iReportPresenter;
       
        public ReportPresenter()
        { 
        
        }

        public ReportPresenter(IReportPresenter iReport)
        {
            iReportPresenter = iReport;
        }

        public Reports GetReport(String id)
        {
            _controller = new ReportController();
            return _controller.GetReport(id);
        }

        public Reports GetReportByCode(String code)
        {
            _controller = new ReportController();
            return _controller.GetReportByCode(code);
        }
    
        public void  SearchData()
        {
            iReportPresenter.SearchData();
        }

        public List<InvoiceDetails> GetInvoiceDetailsByInvoiceID(String id)
        {
            _controller = new ReportController();
            return _controller.GetInvoiceDetailsByInvoiceID(id);
        }

       
        public List<ReportParameters> GetParametersByReportID(String id)
        {
            _controller = new ReportController();
            return _controller.GetParametersByReportID(id);
        }


        public List<Invoices> GetInvoice(String id)
        {
            _controller = new ReportController();
            List<Invoices> listOfInvoice = new List<Invoices>();
            Invoices invoices = _controller.GetInvoice(id);
            listOfInvoice.Add(invoices);
            return listOfInvoice;
        }

        public Invoices GetInvoiceById(String id)
        {
            _controller = new ReportController();
            return _controller.GetInvoice(id);
        }

        public CreditNotesDTO GetCreditNoteByID(String id)
        {
            _controller = new ReportController();
            return _controller.GetCreditNoteByID(id);
        }

        public DataTable ConvertTo<T>(IList<T> list)
        {
            _controller = new ReportController();
            return _controller.ConvertTo<T>(list);
        }

        public DataTable CreateTable<T>()
        {
            _controller = new ReportController();
            return _controller.CreateTable<T>();
        }

        public T CreateItem<T>(DataRow row)
        {
            _controller = new ReportController();
            return _controller.CreateItem<T>(row);
        }
        public StatementOfAccountDTO GetSOAParemeters(String companyCode, Guid agentID)
        {
            _controller = new ReportController();
            return _controller.GetSOAParameters(companyCode, agentID);
        }

        public StatementOfAccounts GetStatementOfAccount(DateTime dateFrom, DateTime dateTo)
        {
            _controller = new ReportController();
            return _controller.GetStatementOfAccount(dateFrom, dateTo);
        }

        public String GetPopUpScript(String reportCode, params String[] param)
        {
            _controller = new ReportController();
            return _controller.GetPopUpScript(reportCode, param);
        }
    }
}
