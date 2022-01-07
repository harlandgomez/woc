using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.DebtorSettlement.BusinessEntity
{
    [Serializable]
    public class Payments: DebtorSettlements
    {
        private Guid m_PaymentID;
        private Guid m_AgentID;
        private string m_InvoiceCode;
        private decimal m_PaymentAmount;
        private DateTime m_PaymentDate;
        private string m_PaymentMode;
        private string m_Bank;
        private string m_Description;
        private string m_ChequeNumber;
        private string m_Status;

        public Guid PaymentID
        {
            get { return m_PaymentID; }
            set { m_PaymentID = value; }
        }
        public new Guid AgentID
        {
            get { return m_AgentID; }
            set { m_AgentID = value; }
        }
        public new string InvoiceCode
        {
            get { return m_InvoiceCode; }
            set { m_InvoiceCode = value; }
        }
        public decimal PaymentAmount
        {
            get { return m_PaymentAmount; }
            set { m_PaymentAmount = value; }
        }
        public DateTime PaymentDate
        {
            get { return m_PaymentDate; }
            set { m_PaymentDate = value; }
        }
        public string PaymentMode
        {
            get { return m_PaymentMode; }
            set { m_PaymentMode = value; }
        }
        public string Bank
        {
            get { return m_Bank; }
            set { m_Bank = value; }
        }
        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }
        public string ChequeNumber
        {
            get { return m_ChequeNumber; }
            set { m_ChequeNumber = value; }
        }
        public string Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

    }

}
