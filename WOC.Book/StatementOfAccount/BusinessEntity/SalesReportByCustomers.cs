using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.StatementOfAccount.BusinessEntity
{
    public class SalesReportbyCustomers : IAccountEntity
    {
        

        private DateTime m_InvoiceDate;

        public DateTime InvoiceDate
        {
            get { return m_InvoiceDate; }
            set { m_InvoiceDate = value; }
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
        private Decimal m_Debit;
        public Decimal Debit
        {
            get { return m_Debit; }
            set { m_Debit = value; }
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
        private Decimal m_Credit;
        public Decimal Credit
        {
            get { return m_Credit; }
            set { m_Credit = value; }
        }
        private string m_Description;
        public String Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }
        private string m_Agent;
        public String Agent
        {
            get { return m_Agent; }
            set { m_Agent = value; }
        }
        private string m_InvoiceNo;
        public String InvoiceNo
        {
            get { return m_InvoiceNo; }
            set { m_InvoiceNo = value; }
        }
        private string m_Customer;
        public String Customer
        {
            get { return m_Customer; }
            set { m_Customer= value; }
        }
        private string m_Remarks;
        public String Remarks
        {
            get { return m_Remarks; }
            set { m_Remarks = value; }
        }
        private string m_RefNo;
        public String RefNo
        {
            get { return m_RefNo; }
            set { m_RefNo = value; }
        }
        private string m_Status;
        public String Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }
        private string m_Payment;
        public String Payment
        {
            get { return m_Payment; }
            set { m_Payment = value; }
        }

        private String m_Prefix;
        public String Prefix
        {
            get { return m_Prefix; }
            set { m_Prefix = value; }
        }
        private Decimal m_InvoiceGSTAmount;
        public Decimal InvoiceGSTAmount
        {
            get { return m_InvoiceGSTAmount; }
            set { m_InvoiceGSTAmount = value; }
        }
        private Decimal m_InvoiceSubAmount;
        public Decimal InvoiceSubAmount
        {
            get { return m_InvoiceSubAmount; }
            set { m_InvoiceSubAmount = value; }
        }
        private Decimal m_InvoiceAmount;
        public Decimal InvoiceAmount
        {
            get { return m_InvoiceAmount; }
            set { m_InvoiceAmount = value; }
        }

        private Decimal m_AmountPaid;
        public Decimal AmountPaid
        {
            get { return m_AmountPaid; }
            set { m_AmountPaid = value; }
        }
    }
}
