using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.Presenter;
using Woc.Book.Base.BusinessEntity;

using Woc.Book.CreditNote.BusinessEntity;

//Agent
using Woc.Book.Agent.BusinessEntity;
using Woc.Book.Agent;
using Woc.Book.Agent.Presenter;

//Invoice
using Woc.Book.Invoice.BusinessEntity;
using Woc.Book.Invoice.Presenter;


namespace Woc.Book.CreditNote.Presenter
{
    public class CreditNotePresenter: IAccount
    {

        IAccount iAccount;
        CreditNoteController creditNoteController;
        InvoicePresenter invoicePresenter;
        public CreditNotePresenter()
        { 
        
        }
        public CreditNotePresenter(IAccount iAccountPresenter)
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

        public List<CreditNotes> SearchData(IAccountEntity iAccount)
        {
            creditNoteController = new CreditNoteController();
            return creditNoteController.SearchData(iAccount);
        }

        public String SaveData(IAccountEntity iAccount)
        {
            creditNoteController = new CreditNoteController();
            return creditNoteController.SaveData(iAccount);
        }

        public String UpdateData(IAccountEntity iAccount)
        {
            creditNoteController = new CreditNoteController();
            return creditNoteController.UpdateData(iAccount);
        }

        public List<Invoices> GetAliasInvoiceCodes(int transactionType)
        {
            invoicePresenter = new InvoicePresenter();
            return invoicePresenter.GetAliasInvoiceCodes(transactionType);
        }

        public List<MemoReasons> GetAllReason()
        {
            creditNoteController = new CreditNoteController();
            return creditNoteController.GetAllReason();
        }

        public String BatchDeleteCreditNote(List<CreditNotes> listCrediteNote)
        {
            creditNoteController = new CreditNoteController();
            return creditNoteController.BatchDeleteCreditNote(listCrediteNote);
        }

        public bool IsInvoiceCodeExists(String invoiceCode)
        {
            invoicePresenter = new InvoicePresenter();
            return invoicePresenter.IsInvoiceCodeExists(invoiceCode);
        }

        public Invoices GetInvoiceByCode(String code)
        {
            invoicePresenter = new InvoicePresenter();
            return invoicePresenter.GetInvoiceByCode(code);
        }

        public void AutoComputeCreditNote(IAccountEntity iAccount)
        {
            creditNoteController = new CreditNoteController();
            creditNoteController.AutoComputeCreditNote(iAccount);
        }
    }
}
