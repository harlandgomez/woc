using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Contract.BusinessEntity
{
    [Serializable]
    public class ContractValidDays
    {
        private bool m_Monday;
        private bool m_Tuesday;
        private bool m_Wednesday;
        private bool m_Thursday;
        private bool m_Friday;
        private bool m_Saturday;
        private bool m_Sunday;
        private string m_StartMonday;
        private string m_StartTuesday;
        private string m_StartWednesday;
        private string m_StartThursday;
        private string m_StartFriday;
        private string m_StartSaturday;
        private string m_StartSunday;
        private string m_StopMonday;
        private string m_StopTuesday;
        private string m_StopWednesday;
        private string m_StopThursday;
        private string m_StopFriday;
        private string m_StopSaturday;
        private string m_StopSunday;

        public bool Monday
        {
            get { return m_Monday; }
            set { m_Monday = value; }
        }
        public bool Tuesday
        {
            get { return m_Tuesday; }
            set { m_Tuesday = value; }
        }
        public bool Wednesday
        {
            get { return m_Wednesday; }
            set { m_Wednesday = value; }
        }
        public bool Thursday
        {
            get { return m_Thursday; }
            set { m_Thursday = value; }
        }
        public bool Friday
        {
            get { return m_Friday; }
            set { m_Friday = value; }
        }
        public bool Saturday
        {
            get { return m_Saturday; }
            set { m_Saturday = value; }
        }
        public bool Sunday
        {
            get { return m_Sunday; }
            set { m_Sunday = value; }
        }

        public String StartMonday
        {
            get { return m_StartMonday; }
            set { m_StartMonday = value; }
        }

        public String StartTuesday
        {
            get { return m_StartTuesday; }
            set { m_StartTuesday = value; }
        }

        public String StartWednesday
        {
            get { return m_StartWednesday; }
            set { m_StartWednesday = value; }
        }

        public String StartThursday
        {
            get { return m_StartThursday; }
            set { m_StartThursday = value; }
        }

        public String StartFriday
        {
            get { return m_StartFriday; }
            set { m_StartFriday = value; }
        }

        public String StartSaturday
        {
            get { return m_StartSaturday; }
            set { m_StartSaturday = value; }
        }

        public String StartSunday
        {
            get { return m_StartSunday; }
            set { m_StartSunday = value; }
        }

        public String StopMonday
        {
            get { return m_StopMonday; }
            set { m_StopMonday = value; }
        }

        public String StopTuesday
        {
            get { return m_StopTuesday; }
            set { m_StopTuesday = value; }
        }

        public String StopWednesday
        {
            get { return m_StopWednesday; }
            set { m_StopWednesday = value; }
        }

        public String StopThursday
        {
            get { return m_StopThursday; }
            set { m_StopThursday = value; }
        }

        public String StopFriday
        {
            get { return m_StopFriday; }
            set { m_StopFriday = value; }
        }

        public String StopSaturday
        {
            get { return m_StopSaturday; }
            set { m_StopSaturday = value; }
        }

        public String StopSunday
        {
            get { return m_StopSunday; }
            set { m_StopSunday = value; }
        }
    }
}
