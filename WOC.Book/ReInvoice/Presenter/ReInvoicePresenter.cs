using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.Presenter;
using Woc.Book.Base.BusinessEntity;

using Woc.Book.Agent.BusinessEntity;
using Woc.Book.Agent.Presenter;
using Woc.Book.ReInvoice.BusinessEntity;
using Woc.Book.Invoice.BusinessEntity;
using Woc.Book.Invoice.Presenter;
namespace Woc.Book.ReInvoice.Presenter
{
    public class ReInvoicePresenter: IAccount
    {
        IAccount iAccount;
        ReInvoiceController controller;

        public ReInvoicePresenter()
        { 
        
        }
        public ReInvoicePresenter(IAccount iAccountPresenter)
        {
            iAccount = iAccountPresenter;
        }

        public void SaveData(short TransactionType)
        {
            iAccount.SaveData(TransactionType);
        }

        public void DataBindings()
        {
            iAccount.DataBindings();
        }

        public void SearchData()
        {
            iAccount.SearchData();
        }
        public List<Agents> GetAgents()
        {
            AgentPresenter agentPresenter = new AgentPresenter();
            return agentPresenter.GetAgents();
        }

        public List<Invoices> GetListInvoice(IAccountEntity iAccountEntity)
        {
            controller = new ReInvoiceController();
            return controller.GetListInvoice(iAccountEntity);
        }
        public List<Invoices> GetListInvoice()
        {
            InvoicePresenter invoicePresenter = new InvoicePresenter();
            return invoicePresenter.GetAliasInvoiceCodes(false);
        }
    }
}
