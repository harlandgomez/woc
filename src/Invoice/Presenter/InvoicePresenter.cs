using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.Presenter;
using Woc.Book.Base.BusinessEntity;

using Woc.Book.Invoice.BusinessEntity;

//Agent
using Woc.Book.Agent.BusinessEntity;
using Woc.Book.Agent;
using Woc.Book.Agent.Presenter;
namespace Woc.Book.Invoice.Presenter
{
    public class InvoicePresenter : IAccount
    {

        IAccount iAccount;
        InvoiceController invoiceController;
        public InvoicePresenter()
        { 
        
        }
        public InvoicePresenter(IAccount iAccountPresenter)
        {
            iAccount = iAccountPresenter;
        }

        public void SaveData(Int16 TransactionType)
        {
            iAccount.SaveData(TransactionType);
        }

        public List<Agents> GetAgents()
        {
            AgentPresenter agentPresenter = new AgentPresenter();
            return agentPresenter.GetAgents();
        }


        public void DataBindings()
        {
            iAccount.DataBindings();
        }


        public void SearchData()
        {
            iAccount.SearchData();
        }

        public List<InvoiceDTO> SearchData(IAccountEntity iAccount)
        {
            invoiceController = new InvoiceController();
            return invoiceController.SearchData(iAccount);
        }

        public String SaveData(IAccountEntity iAccount)
        {
            invoiceController = new InvoiceController();
            return invoiceController.SaveData(iAccount);
        }

        public List<InvoiceDetails> GetContractToBeInvoiced(IAccountEntity iAccount)
        {
            invoiceController = new InvoiceController();
            return invoiceController.GetContractToBeInvoiced(iAccount);
        }
        public List<Invoices> GetAliasInvoiceCodes(bool isNotActive)
        {
            invoiceController = new InvoiceController();
            return invoiceController.GetAliasInvoiceCodes(isNotActive);
        }

        public List<Invoices> GetAliasInvoiceCodes(int transactionType)
        {
            invoiceController = new InvoiceController();
            return invoiceController.GetAliasInvoiceCodes(transactionType);
        }
        
        public Invoices GetInvoiceDetailsByID(String id)
        {
            invoiceController = new InvoiceController();
            return invoiceController.GetInvoiceDetailsByID(id);
        }

        public Invoices GetInvoiceByCode(String code)
        {
            invoiceController = new InvoiceController();
            return invoiceController.GetInvoiceByCode(code);
        }

        public String VoidInvoice(String id)
        {
            invoiceController = new InvoiceController();
            return invoiceController.VoidInvoice(id);
        }

        public List<InvoiceDetails> GetInvoiceDetailsByInvoiceID(String id)
        {
            invoiceController = new InvoiceController();
            return invoiceController.GetInvoiceDetailsByInvoiceID(id);
        }

        public bool IsInvoiceCodeExists(String invoiceCode)
        {
            invoiceController = new InvoiceController();
            return invoiceController.IsInvoiceCodeExists(invoiceCode);
        }

        public String GetNewInvoiceCode(Guid agentID)
        {
            invoiceController = new InvoiceController();
            return invoiceController.GetNewInvoiceCode(agentID);
        }
    }
}
