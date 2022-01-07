using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.DailyTrip.BusinessEntity;
namespace Woc.Book.ReportAgent.BusinessEntity
{
    public class ReportAgents : DailyTripsDTO 
    {
        string m_Company;
        public string Company
        {
            get { return m_Company; }
            set { m_Company = value; }
        }

        string m_DriverClaim;
        public string DriverClaim
        {
            get { return m_DriverClaim; }
            set { m_DriverClaim = value; }
        }

        string m_CashOrder;
        public string CashOrder
        {
            get { return m_CashOrder; }
            set { m_CashOrder = value; }
        }

        
    }
}
