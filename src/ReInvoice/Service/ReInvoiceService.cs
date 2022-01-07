using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Invoice.BusinessEntity;
using Woc.Book.Base.Service;
using Woc.Book.Base.BusinessEntity;

using Woc.Book.ReInvoice.BusinessEntity;
using System.Data.SqlClient;

namespace Woc.Book.ReInvoice.Service
{
    public class ReInvoiceService
    {
        SQLHelper _sqlHelper = new SQLHelper();

        public List<Invoices> GetListInvoice(IAccountEntity iAccountEntity)
        {
            ReInvoiceDTO reInvoices = (ReInvoiceDTO)iAccountEntity;
            List<Invoices> listInvoice = new List<Invoices>();
           
            SqlDataReader dreader;

            _sqlHelper.AddParameterToSQLCommandWithValue("@AgentID", reInvoices.AgentID);

            if (reInvoices.StartDate != DateTime.MinValue)
            {
                _sqlHelper.AddParameterToSQLCommandWithValue("@StartDate", reInvoices.StartDate);
            }

            if (reInvoices.EndDate != DateTime.MinValue)
            {
                _sqlHelper.AddParameterToSQLCommandWithValue("@EndDate", reInvoices.EndDate);
            }

            _sqlHelper.AddParameterToSQLCommandWithValue("@InvoiceID", reInvoices.InvoiceID);
            _sqlHelper.AddParameterToSQLCommandWithValue("@TransactionMode", 4);
            dreader = _sqlHelper.GetReaderByCmd("usp_WocBookSearchInvoice");

            while (dreader.Read())
            {
                ReInvoiceDTO invoices = new ReInvoiceDTO();
                invoices.InvoiceID = new Guid(dreader["InvoiceID"].ToString());
                invoices.InvoiceCode = dreader["InvoiceCode"].ToString();
                invoices.InvoiceDate = Convert.ToDateTime(dreader["InvoiceDate"]);
                invoices.AgentID = reInvoices.AgentID;
                invoices.AgentName = dreader["AgentName"].ToString();
                invoices.TotalAmount = Convert.ToDecimal(dreader["TotalAmount"]);
                invoices.OutStanding = Convert.ToDecimal(dreader["Balance"]);
                listInvoice.Add(invoices);
            }
            return listInvoice;
        }
    }
}
