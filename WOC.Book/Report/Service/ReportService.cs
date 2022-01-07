using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

//Common
using Woc.Book.Report.BusinessEntity;
using Woc.Book.Report.Service;

//SubCon
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;

//Invoice
using Woc.Book.Invoice.BusinessEntity;
using Woc.Book.Invoice.Service;

using Woc.Book.CreditNote.Service;
using Woc.Book.CreditNote.BusinessEntity;

//StatementOfAccount
using Woc.Book.StatementOfAccount.BusinessEntity;

namespace Woc.Book.Report.Service
{
    internal class ReportService
    {
        SQLHelper _helper;
        
        public Reports GetReport(String id)
        {
            Reports reports = new Reports();
            SqlDataReader dreader;

            _helper = new SQLHelper();

            _helper.AddParameterToSQLCommandWithValue("@TransactionMode", 5);
            _helper.AddParameterToSQLCommandWithValue("@ReportID", id);
            dreader = _helper.GetReaderByCmd("usp_WocBookReport");

            using (dreader)
            {
                while (dreader.Read())
                {
                    reports.ReportID = new Guid(id);
                    reports.ReportName = dreader["ReportName"].ToString();
                    reports.ReportType = dreader["ReportType"].ToString();
                    reports.ReportPath = dreader["ReportPath"].ToString();
                    reports.ReportCode = dreader["ReportCode"].ToString();
                    break;
                }

            }

            return reports;
        }

        public Reports GetReportByCode(String code)
        {
            Reports reports = new Reports();
            SqlDataReader dreader;

            _helper = new SQLHelper();

            _helper.AddParameterToSQLCommandWithValue("@TransactionMode", 6);
            _helper.AddParameterToSQLCommandWithValue("@ReportCode", code);
            dreader = _helper.GetReaderByCmd("usp_WocBookReport");

            using (dreader)
            {
                while (dreader.Read())
                {
                    reports.ReportID = new Guid(dreader["ReportID"].ToString());
                    reports.ReportName = dreader["ReportName"].ToString();
                    reports.ReportCode = dreader["ReportCode"].ToString();
                    reports.ReportType = dreader["ReportType"].ToString();
                    reports.ReportPath = dreader["ReportPath"].ToString();
                    break;
                }

            }

            return reports;
        }

        public List<ReportParameters> GetParametersByReportID(String id)
        {
            SqlDataReader dreader;
            List<ReportParameters> listReportParams = new List<ReportParameters>();
            ReportParameters reportParams;

            _helper = new SQLHelper();

            _helper.AddParameterToSQLCommandWithValue("@TransactionMode", 1);
            _helper.AddParameterToSQLCommandWithValue("@ReportID", id);

            dreader = _helper.GetReaderByCmd("usp_WocBookReportParameter");

            using (dreader)
            {
                while (dreader.Read())
                {
                    reportParams = new ReportParameters();
                    reportParams.ParameterCode = dreader["ParameterCode"].ToString();
                    reportParams.ParameterCaption = dreader["ParameterCaption"].ToString();
                    reportParams.ReportParameterID = new Guid(dreader["ReportParameterID"].ToString());
                    reportParams.SQL = dreader["SQL"].ToString();
                    reportParams.IsChecked = Convert.ToBoolean(dreader["IsChecked"]);
                    reportParams.ControlType = dreader["ControlType"].ToString();
                    reportParams.DataTextField = dreader["DataTextField"].ToString();
                    reportParams.DataValueField = dreader["DataValueField"].ToString();
                    listReportParams.Add(reportParams);
                }
            }
            return listReportParams;
        }

        public List<InvoiceDetails> GetInvoiceDetailsByInvoiceID(String id)
        {
            InvoiceService invoiceService = new InvoiceService();
            return invoiceService.GetInvoiceDetailsByInvoiceID(id);
        }

        public Invoices GetInvoice(String id)
        {
            InvoiceService invoiceService = new InvoiceService();
            return invoiceService.GetInvoice(id);
        }

        public CreditNotesDTO GetCreditNoteByID(String id)
        {
            CreditNoteService cnService = new CreditNoteService();
            return cnService.GetCreditNoteByID(id);
        }
        public StatementOfAccountDTO GetSOAParemeters(String companyCode, Guid agentID)
        {
            StatementOfAccountDTO statementOfAccountDTO = new StatementOfAccountDTO();
            SqlDataReader dreader;
            _helper = new SQLHelper();

            _helper.AddParameterToSQLCommandWithValue("@AgentID", agentID);
            _helper.AddParameterToSQLCommandWithValue("@CompanyCode", companyCode);
            _helper.AddParameterToSQLCommandWithValue("@TransactionMode", 1);

            dreader = _helper.GetReaderByCmd("usp_WocBookSearchStatementOfAccount");

            using (dreader)
            {
                while (dreader.Read())
                {
                    statementOfAccountDTO = new StatementOfAccountDTO();
                    statementOfAccountDTO.Company = dreader["Company"].ToString();
                    statementOfAccountDTO.Address = dreader["Address"].ToString();
                    statementOfAccountDTO.Telephone = dreader["Telephone"].ToString();
                    statementOfAccountDTO.Fax = dreader["Fax"].ToString();
                    statementOfAccountDTO.Agent = dreader["Agent"].ToString();
                    statementOfAccountDTO.AgentAddress = dreader["Address"].ToString();
                    statementOfAccountDTO.Contact = dreader["Contact"].ToString();
                   
                }
            }
            return statementOfAccountDTO;
        }
    }
}
