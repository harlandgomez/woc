using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.ReInvoice.Constant
{
    public class Constant
    {
        public enum GridViewColumns
        {
            AgentID = 0,
            InvoiceID = 1,
            InvoiceDate = 2,
            InvoiceCode = 3,
            Agent = 4,
            Amount = 5,
            Outstanding = 6,
            View = 7,
            Edit = 8
        }

        public enum GridKeys
        {
            InvoiceID = 0,
            InvoiceDate = 1
        }

        public const String NoRecordFoundMessage = "No invoice found from {0} to {1} for agent: {2} ";
        public const String RecordFoundMessage = " {0} invoice(s) found  from {1} to {2} for agent: {3} ";
    }
}
