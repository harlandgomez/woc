using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Contract.BusinessEntity
{
    [Serializable]
    public class Contracts : INewBookEntity
    {
        private Guid m_ContractID;
        private string m_BookingCode;
        private Guid m_AgentID;
        private DateTime m_StartDate;
        private DateTime m_StopDate;
        private string m_TripType;
        private string m_TripFrom;
        private string m_TripTo;
        private string m_Seater;
        private string m_InvoiceText;
        private string m_PersonInCharge;
        private string m_Contact;
        private string m_RatesType;
        private decimal m_Rates;
        private string m_Remarks1;
        private string m_Remarks2;
        private string m_DriverClaim;
        private string m_PONumber;
        private Guid m_CreatedBy;
        private DateTime m_CreatedDate;
        private Guid m_UpdatedBy;
        private DateTime m_UpdatedDate;
        private bool m_Delete;
        private List<ContractSchedules> m_ContractSchedules;
        private string m_Prefix;
        private string m_Route;
        private string m_ContractRate;
        private string m_DailyRate;
        private string m_Agent;
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
        private string m_EndMonday;
        private string m_EndTuesday;
        private string m_EndWednesday;
        private string m_EndThursday;
        private string m_EndFriday;
        private string m_EndSaturday;
        private string m_EndSunday;
        private int m_Active;
        private string m_ContractStartTime;
        private string m_ContractEndTime;


        public Guid ContractID
        {
            get { return m_ContractID; }
            set { m_ContractID = value; }
        }
        public string BookingCode
        {
            get { return m_BookingCode; }
            set { m_BookingCode = value; }
        }
        public Guid AgentID
        {
            get { return m_AgentID; }
            set { m_AgentID = value; }
        }
        public DateTime StartDate
        {
            get { return m_StartDate; }
            set { m_StartDate = value; }
        }
        public DateTime StopDate
        {
            get { return m_StopDate; }
            set { m_StopDate = value; }
        }
        public string TripType
        {
            get { return m_TripType; }
            set { m_TripType = value; }
        }
        public string TripFrom
        {
            get { return m_TripFrom; }
            set { m_TripFrom = value; }
        }
        public string TripTo
        {
            get { return m_TripTo; }
            set { m_TripTo = value; }
        }
        public string Seater
        {
            get { return m_Seater; }
            set { m_Seater = value; }
        }
        public string InvoiceText
        {
            get { return m_InvoiceText; }
            set { m_InvoiceText = value; }
        }
        public string PersonInCharge
        {
            get { return m_PersonInCharge; }
            set { m_PersonInCharge = value; }
        }
        public string Contact
        {
            get { return m_Contact; }
            set { m_Contact = value; }
        }
        public string RatesType
        {
            get { return m_RatesType; }
            set { m_RatesType = value; }
        }
        public decimal Rates
        {
            get { return m_Rates; }
            set { m_Rates = value; }
        }
        public string Remarks1
        {
            get { return m_Remarks1; }
            set { m_Remarks1 = value; }
        }
        public string Remarks2
        {
            get { return m_Remarks2; }
            set { m_Remarks2 = value; }
        }
        public string DriverClaim
        {
            get { return m_DriverClaim; }
            set { m_DriverClaim = value; }
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
        public bool Delete
        {
            get { return m_Delete; }
            set { m_Delete = value; }
        }

        public List<ContractSchedules> ContractSchedules
        {
            get { return m_ContractSchedules; }
            set { m_ContractSchedules = value; }
        }

        public String Prefix
        {
            get { return m_Prefix; }
            set { m_Prefix = value; }
        }

        public String Route
        {
            get { return m_Route; }
            set { m_Route = value; }
        }

        public String ContractRate
        {
            get { return m_ContractRate; }
            set { m_ContractRate = value; }
        }
        public String DailyRate
        {
            get { return m_DailyRate; }
            set { m_DailyRate = value; }
        }
        public String Agent
        {
            get { return m_Agent; }
            set { m_Agent = value; }
        }
        public String PONumber
        {
            get { return m_PONumber; }
            set { m_PONumber = value; }
        }
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

        public String EndMonday
        {
            get { return m_EndMonday; }
            set { m_EndMonday = value; }
        }

        public String EndTuesday
        {
            get { return m_EndTuesday; }
            set { m_EndTuesday = value; }
        }

        public String EndWednesday
        {
            get { return m_EndWednesday; }
            set { m_EndWednesday = value; }
        }

        public String EndThursday
        {
            get { return m_EndThursday; }
            set { m_EndThursday = value; }
        }

        public String EndFriday
        {
            get { return m_EndFriday; }
            set { m_EndFriday = value; }
        }

        public String EndSaturday
        {
            get { return m_EndSaturday; }
            set { m_EndSaturday = value; }
        }

        public String EndSunday
        {
            get { return m_EndSunday; }
            set { m_EndSunday = value; }
        }
        public int ActiveStatus
        {
            get { return m_Active; }
            set { m_Active = value; }
        }

        public String ContractStartTime
        {
            get { return m_ContractStartTime; }
            set { m_ContractStartTime = value; }
        }

        public String ContractEndTime
        {
            get { return m_ContractEndTime; }
            set { m_ContractEndTime = value; }
        }
    }

}
