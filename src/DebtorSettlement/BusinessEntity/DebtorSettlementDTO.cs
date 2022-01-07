using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.DebtorSettlement.BusinessEntity
{
    public class DebtorSettlementDTO : Payments
    {
        private string m_AgentName;
        private string m_AgentCode;
        private DateTime m_ReceiptDate;
        private Decimal m_AmountCollectible;
        private decimal m_TransactionDifference;
        private string m_PaymentMode;
        private string m_Bank;
        private string m_Description;
        private List<Payments> m_ListPayment;

        public string AgentName
        {
            get { return m_AgentName; }
            set { m_AgentName = value; }
        }
        public string AgentCode
        {
            get { return m_AgentCode; }
            set { m_AgentCode = value; }
        }
       
        public Decimal AmountCollectible
        {
            get { return m_AmountCollectible; }
            set { m_AmountCollectible = value; }
        }
        public Decimal TransactionDifference
        {
            get { return m_TransactionDifference; }
            set { m_TransactionDifference = value; }
        }
       
        public DateTime ReceiptDate
        {
            get { return m_ReceiptDate; }
            set { m_ReceiptDate = value; }
        }
       
        
        public new string PaymentMode
        {
            get { return m_PaymentMode; }
            set { m_PaymentMode = value; }
        }
        public new string Bank
        {
            get { return m_Bank; }
            set { m_Bank = value; }
        }
        public new string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }
       
        public List<Payments> ListPayments
        {
            get { return m_ListPayment; }
            set { m_ListPayment = value; }
        }

    }
}
