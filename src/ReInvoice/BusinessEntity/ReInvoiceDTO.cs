using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Invoice.BusinessEntity;

namespace Woc.Book.ReInvoice.BusinessEntity
{
    [Serializable]
    public class ReInvoiceDTO: Invoices
    {
        private DateTime m_StartDate;
        public DateTime StartDate
        {
            get { return m_StartDate; }
            set { m_StartDate = value; }
        }

        private DateTime m_EndDate;
        public DateTime EndDate
        {
            get { return m_EndDate; }
            set { m_EndDate = value; }
        }

        private Decimal m_OutStanding;
        public Decimal OutStanding
        {
            get { return m_OutStanding; }
            set { m_OutStanding = value;}
        }

        private String m_AgentName;
        public String AgentName
        {
            get { return m_AgentName; }
            set { m_AgentName = value; }
        }
    }
}
