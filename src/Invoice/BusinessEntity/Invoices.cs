using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Invoice.BusinessEntity
{
    [Serializable]
    public class Invoices: IAccountEntity
    {
        private Guid m_InvoiceID;
        private string m_InvoiceCode;
        private DateTime m_InvoiceDate;
        private string m_Title;
        private Guid m_AgentID;
        private string m_Attention;
        private string m_Remarks;
        private string m_BillTo;
        private string m_Address;
        private string m_GSTTypeCode;
        private decimal m_SubTotal;
        private decimal m_GSTAmount;
        private decimal m_TotalAmount;
        private decimal m_Deposit;
        private decimal m_Balance;
        private Guid m_CreatedBy;
        private DateTime m_CreatedDate;
        private Guid m_UpdatedBy;
        private DateTime m_UpdatedDate;
        private string m_AliasInvoiceCode;
        private int m_transactionType;

        public List<InvoiceDTO> ListInvoiceDTO = new List<InvoiceDTO>();

        public Guid InvoiceID
        {
            get { return m_InvoiceID; }
            set { m_InvoiceID = value; }
        }
        public string InvoiceCode
        {
            get { return m_InvoiceCode; }
            set { m_InvoiceCode = value; }
        }
        public DateTime InvoiceDate
        {
            get { return m_InvoiceDate; }
            set { m_InvoiceDate = value; }
        }
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }
        public Guid AgentID
        {
            get { return m_AgentID; }
            set { m_AgentID = value; }
        }
        public string Attention
        {
            get { return m_Attention; }
            set { m_Attention = value; }
        }
        public string BillTo
        {
            get { return m_BillTo; }
            set { m_BillTo = value; }
        }
        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }
        public string Remarks
        {
            get { return m_Remarks; }
            set { m_Remarks = value; }
        }
        public string GSTTypeCode
        {
            get { return m_GSTTypeCode; }
            set { m_GSTTypeCode = value; }
        }
        public decimal SubTotal
        {
            get { return m_SubTotal; }
            set { m_SubTotal = value; }
        }
        public decimal GSTAmount
        {
            get { return m_GSTAmount; }
            set { m_GSTAmount = value; }
        }
        public decimal TotalAmount
        {
            get { return m_TotalAmount; }
            set { m_TotalAmount = value; }
        }
        public decimal Deposit
        {
            get { return m_Deposit; }
            set { m_Deposit = value; }
        }
        public decimal Balance
        {
            get { return m_Balance; }
            set { m_Balance = value; }
        }
        public Guid CreatedBy
        {
            get { return m_CreatedBy; }
            set { m_CreatedBy = value; }
        }
        public DateTime CreatedDate
        {
            get { return m_CreatedDate; }
            set { m_CreatedDate = value; }
        }
        public Guid UpdatedBy
        {
            get { return m_UpdatedBy; }
            set { m_UpdatedBy = value; }
        }
        public DateTime UpdatedDate
        {
            get { return m_UpdatedDate; }
            set { m_UpdatedDate = value; }
        }

        public String AliasInvoiceCode
        {
            get { return m_AliasInvoiceCode; }
            set { m_AliasInvoiceCode = value; }
        }

        [IsNotReportParamAttrib(true)] 
        public int TransactionType
        {
            get { return m_transactionType; }
            set { m_transactionType = value; }
        }

        public List<InvoiceDetails> ListInvoiceDetails = new List <InvoiceDetails>();
        public List<InvoiceDetails> ListVoidInvoiceDetails = new List<InvoiceDetails>();

    }

}
