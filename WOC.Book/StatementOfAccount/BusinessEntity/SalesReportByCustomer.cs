using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Common.BusinessEntity;

namespace Woc.Book.StatementOfAccount.BusinessEntity
{
    public class SalesReportByCustomer : IAccountEntity
    {
        private String m_Agent;
        public String Agent
        {
            get { return m_Agent; }
            set { m_Agent = value; }
        }
        private String m_InvoiceNo;
        public String InvoiceNo
        {
            get { return m_InvoiceNo; }
            set { m_InvoiceNo = value; }
        }

        private DateTime m_InvoiceDate;
        public DateTime InvoiceDate
        {
            get { return m_InvoiceDate; }
            set { m_InvoiceDate = value; }
        }

        private String m_Description;
        public String Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }
        private Decimal m_GST;
        public Decimal GST
        {
            get { return m_GST; }
            set { m_GST = value; }
        }

        private Decimal m_Amount;
        public Decimal Amount
        {
            get { return m_Amount; }
            set { m_Amount = value; }
        }

        private  Decimal m_Total;
        public Decimal Total
        {
            get { return m_Total; }
            set { m_Total = value; }
        }
        private Decimal m_Paid;
        public Decimal Paid
        {
            get { return m_Paid; }
            set { m_Paid = value; }
        }
        
        private DateTime m_InvoiceDateFrom;
        public DateTime InvoiceDateFrom
        {
            get { return m_InvoiceDateFrom; }
            set { m_InvoiceDateFrom = value; }
        }
        private DateTime m_InvoiceDateTo;
        public DateTime InvoiceDateTo
        {
            get { return m_InvoiceDateTo; }
            set { m_InvoiceDateTo = value; }
        }
        
       
       


    }
}
