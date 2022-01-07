using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Presenter;

//Woc.Book.StatementOfAccount
using Woc.Book.StatementOfAccount.BusinessEntity;
using Woc.Book.StatementOfAccount.Service;

using Woc.Book.Agent.BusinessEntity;
using Woc.Book.Agent.Service;

namespace Woc.Book.StatementOfAccount
{
  internal  class StatementOfAccountController
    {
        StatementOfAccountService statementOfAccountService;
        public List<StatementOfAccounts> SearchData(IAccountEntity iAccount)
        {
            try
            {
                statementOfAccountService = new StatementOfAccountService();
                StatementOfAccounts statementOfAccounts = new StatementOfAccounts();
                statementOfAccounts = (StatementOfAccounts)iAccount;
                return statementOfAccountService.SearchData(statementOfAccounts.AgentID, statementOfAccounts.InvoiceDateFrom, statementOfAccounts.InvoiceDateTo,statementOfAccounts.Payment);
             
            }

            catch
            {
                throw;
            }
        }

        public List<SalesReportbyCustomers> SearchDataSales(IAccountEntity iAccount)
        {
            try
            {
                statementOfAccountService = new StatementOfAccountService();


                SalesReportbyCustomers salesReportbyCustomers = new SalesReportbyCustomers();
                salesReportbyCustomers = (SalesReportbyCustomers)iAccount;
                return statementOfAccountService.SearchDataSales(salesReportbyCustomers.Prefix, salesReportbyCustomers.InvoiceDateFrom, salesReportbyCustomers.InvoiceDateTo, salesReportbyCustomers.Payment);

            }

            catch
            {
                throw;
            }
        }

        public List<Agents> GetAgents()
        {
            try
            {
                AgentService agentService = new AgentService();
                return agentService.GetInvoiceAgents();
            }
            catch
            {
                throw;
            }
        }
    }
}
