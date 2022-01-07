using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base;
using Woc.Book.Base.BusinessEntity;

using Woc.Book.Invoice.BusinessEntity;
using Woc.Book.Invoice.Service;

using Woc.Book.Setting.Service;
using Woc.Book.Agent.Service;

namespace Woc.Book.Invoice
{
    internal class InvoiceController : IAccountController
    {
        InvoiceService invoiceService;
        SettingService settingService;
        public String SaveData(IAccountEntity iAccountEntity)
        {
            invoiceService = new InvoiceService();
            settingService = new SettingService();
            GSTController gstController = new GSTController();

            Invoices invoices = new Invoices();
            Decimal totalAmount = 0;
            Decimal gstPercent = Convert.ToDecimal(settingService.GetSettingValue("GST_PERCENTAGE").ToString());

            invoices = (Invoices)iAccountEntity;

            foreach (InvoiceDetails invoiceDetails in invoices.ListInvoiceDetails)
            {
                totalAmount += invoiceDetails.TotalPrice;    
            }
            
            invoices.SubTotal = totalAmount;
            
            invoices.GSTAmount = gstController.GetGSTAmount(invoices.SubTotal, invoices.GSTTypeCode);
            
            invoices.TotalAmount = gstController.GetTotalAmount(invoices.SubTotal, invoices.GSTTypeCode);

            invoices.Deposit = invoiceService.GetDepositByInvoiceCode(invoices.InvoiceCode);

            invoices.Balance = invoices.TotalAmount - invoices.Deposit;

            return invoiceService.SaveData(invoices);
        }
        public List<InvoiceDTO> SearchData(IAccountEntity iAccount)
        {
            invoiceService = new InvoiceService();
            InvoiceDTO invoices = (InvoiceDTO)iAccount;

            if (invoices.AdhocChecked && invoices.ContractChecked)
            {
                invoices.TransactionMode = 3;
            }
            else if (invoices.AdhocChecked)
            {
                invoices.TransactionMode = 2;
            }
            else if (invoices.ContractChecked)
            {
                invoices.TransactionMode = 1;
            }
            else
            {
                invoices.TransactionMode = 3;
            }

            return invoiceService.SearchData(invoices); 
        }

        public List<InvoiceDetails> GetContractToBeInvoiced(IAccountEntity iAccount)
        {
            invoiceService = new InvoiceService();
            return invoiceService.GetContractToBeInvoiced(iAccount);
        }

        public List<Invoices> GetAliasInvoiceCodes(bool isNotActive)
        {
            invoiceService = new InvoiceService();
            return invoiceService.GetAliasInvoiceCodes(isNotActive);
        }

        public List<Invoices> GetAliasInvoiceCodes(int transactionType)
        {
            invoiceService = new InvoiceService();
            return invoiceService.GetAliasInvoiceCodes(transactionType);
        }

        public Invoices GetInvoiceDetailsByID(String id)
        {
            invoiceService = new InvoiceService();
            return invoiceService.GetInvoiceDetailsByID(id);
        }

        public Invoices GetInvoiceByCode(String code)
        {
            invoiceService = new InvoiceService();
            return invoiceService.GetInvoiceByCode(code);
        }
        public String VoidInvoice(String id)
        {
            invoiceService = new InvoiceService();
            return invoiceService.VoidInvoice(id);
        }
        public List<InvoiceDetails> GetInvoiceDetailsByInvoiceID(String id)
        {
            invoiceService = new InvoiceService();
            return invoiceService.GetInvoiceDetailsByInvoiceID(id);
        }
        public bool IsInvoiceCodeExists(String invoiceCode)
        {
            invoiceService = new InvoiceService();
            return invoiceService.IsInvoiceCodeExists(invoiceCode);
        }

        public String GetNewInvoiceCode(Guid agentID)
        {
            String invoiceCode;

            SequenceController sequenceController = new SequenceController();
            String sequence = sequenceController.GetNextSequence("InvoiceCode");

            AgentService agentService = new AgentService();
            String prefix = agentService.GetPrefixById(agentID);

            SettingService settingService = new SettingService();
            String format = settingService.GetSettingValue("INVOICE_NUMBER_FORMAT");
                        
            if (format.Contains("[PREFIX]"))
            {
                format = format.Replace("[PREFIX]", prefix);
            }

            format = format.Replace("[SEQUENCE]", sequence);

            invoiceCode = DateTime.Now.ToString(format);

            return invoiceCode;
        }
    }
}
