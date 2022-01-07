using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Agent;
using Woc.Book.Agent.BusinessEntity;

using Woc.Book.Base.BusinessEntity;

using Woc.Book.Invoice.BusinessEntity;

using Woc.Book.ReInvoice.Service;
using Woc.Book.ReInvoice.BusinessEntity;

namespace Woc.Book.ReInvoice
{
    internal class ReInvoiceController
    {
        public List<Invoices> GetListInvoice(IAccountEntity iAccountEntity)
        {
            ReInvoiceService reInvoiceSvc = new ReInvoiceService();
            return reInvoiceSvc.GetListInvoice(iAccountEntity);
        }
    }
}
