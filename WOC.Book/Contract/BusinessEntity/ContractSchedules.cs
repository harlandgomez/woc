using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Contract.BusinessEntity
{
    [Serializable]
    public class ContractSchedules
    {
        private Guid m_ContractScheduleID;
        private Guid m_ContractID;
        private DateTime m_ScheduleDate;
        private DateTime m_StartTime;
        private DateTime m_EndTime;

        public Guid ContractScheduleID
        {
            get { return m_ContractScheduleID; }
            set { m_ContractScheduleID = value; }
        }
        public Guid ContractID
        {
            get { return m_ContractID; }
            set { m_ContractID = value; }
        }
        public DateTime ScheduleDate
        {
            get { return m_ScheduleDate; }
            set { m_ScheduleDate = value; }
        }
        public DateTime StartTime
        {
            get { return m_StartTime; }
            set { m_StartTime = value; }
        }
        public DateTime EndTime
        {
            get { return m_EndTime; }
            set { m_EndTime = value; }
        }

    }

}
