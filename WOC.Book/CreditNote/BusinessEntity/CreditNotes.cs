using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.CreditNote.BusinessEntity
{
    [Serializable]
    public class CreditNotes: IAccountEntity
    {
        private Guid m_CreditNoteID;
        private string m_CreditNoteCode;
        private DateTime m_CreditNoteDate;
        private Guid m_AgentID;
        private string m_InvoiceCode;
        private decimal m_CreditNoteAmount;
        private string m_ReasonCode;
        private string m_GSTTypeCode;
        private string m_Description;
        private string m_Attention;
        private String m_CreatedBy;

        public String CreatedBy
        {
            get { return m_CreatedBy; }
            set { m_CreatedBy = value; }
        }

        public Guid CreditNoteID
        {
            get { return m_CreditNoteID; }
            set { m_CreditNoteID = value; }
        }
        public string CreditNoteCode
        {
            get { return m_CreditNoteCode; }
            set { m_CreditNoteCode = value; }
        }
        public DateTime CreditNoteDate
        {
            get { return m_CreditNoteDate; }
            set { m_CreditNoteDate = value; }
        }
        public Guid AgentID
        {
            get { return m_AgentID; }
            set { m_AgentID = value; }
        }
        public string InvoiceCode
        {
            get { return m_InvoiceCode; }
            set { m_InvoiceCode = value; }
        }
        public decimal CreditNoteAmount
        {
            get { return m_CreditNoteAmount; }
            set { m_CreditNoteAmount = value; }
        }
        public string ReasonCode
        {
            get { return m_ReasonCode; }
            set { m_ReasonCode = value; }
        }
        public string GSTTypeCode
        {
            get { return m_GSTTypeCode; }
            set { m_GSTTypeCode = value; }
        }
        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }
        public string Attention
        {
            get { return m_Attention; }
            set { m_Attention = value; }
        }

    }
}
