using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Adhoc.BusinessEntity
{
     [Serializable]
    public class Adhocs : INewBookEntity
    {
        private Guid m_AdhocID;
        private Guid m_AgentID;
        private DateTime m_AhhocBookDate;
        private DateTime m_AhhocBookDateFrom;
        private DateTime m_AhhocBookDateTo;
        private string m_TripType;
        private string m_TripFrom;
        private string m_TripTo;
        private DateTime m_TimeDepart;
        private DateTime m_TimeReturn;
        private long m_Seater;
        private string m_Purpose;
        private string m_PersonInCharge;
        private string m_DriverClaim;
        private int m_Item;
        private string m_RefNumber;
        private string m_Contact;
        private Guid m_CreatedBy;
        private DateTime m_CreatedDate;
        private Guid m_UpdatedBy;
        private DateTime m_UpdatedDate;
        private string m_AdhocCode;
        private String m_Agent;
        private String m_Destination;
        private bool m_Voided;
        private String m_TypeCashOrder;
        private Decimal m_CashOrder;
        private bool m_IsPending;
        private String m_Status;
        private bool m_IsFromAdhoc;


        public String Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        public String TypeCashOrder
        {
            get { return m_TypeCashOrder; }
            set { m_TypeCashOrder = value; }
        }
        public Decimal CashOrder
        {
            get { return m_CashOrder; }
            set { m_CashOrder = value; }
        }

	    public bool IsPending
	    {
            get { return m_IsPending; }
            set { m_IsPending = value; }
	    }

        public string Agent
        {
            get { return m_Agent; }
            set { m_Agent = value; }
        }
        public string AdhocCode
        {
            get { return m_AdhocCode; }
            set { m_AdhocCode = value; }
        }
        public string RefNumber
        {
            get { return m_RefNumber; }
            set { m_RefNumber = value; }
        }
        public Guid AdhocID
        {
            get { return m_AdhocID; }
            set { m_AdhocID = value; }
        }
        public Guid AgentID
        {
            get { return m_AgentID; }
            set { m_AgentID = value; }
        }

        public int Item
        {
            get { return m_Item; }
            set { m_Item = value; }
        }

        public bool Voided
        {
            get { return m_Voided; }
            set { m_Voided = value; }
        }

        public DateTime AdhocBookDate
        {
            get { return m_AhhocBookDate; }
            set { m_AhhocBookDate = value; }
        }
        public DateTime AdhocBookDateFrom
        {
            get { return m_AhhocBookDateFrom; }
            set { m_AhhocBookDateFrom = value; }
        }
        public DateTime AdhocBookDateTo
        {
            get { return m_AhhocBookDateTo; }
            set { m_AhhocBookDateTo = value; }
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
        public DateTime TimeDepart
        {
            get { return m_TimeDepart; }
            set { m_TimeDepart = value; }
        }
        public DateTime TimeReturn
        {
            get { return m_TimeReturn; }
            set { m_TimeReturn = value; }
        }
        public long Seater
        {
            get { return m_Seater; }
            set { m_Seater = value; }
        }
        public string Purpose
        {
            get { return m_Purpose; }
            set { m_Purpose = value; }
        }
        public string PersonInCharge
        {
            get { return m_PersonInCharge; }
            set { m_PersonInCharge = value; }
        }
        public string DriverClaim
        {
            get { return m_DriverClaim; }
            set { m_DriverClaim = value; }
        }

        public string Contact
        {
            get { return m_Contact; }
            set { m_Contact = value; }
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

        public string Destination
        {
            get { return m_Destination; }
            set { m_Destination = value; }
        }

        public bool IsFromAdhoc
        {
            get { return m_IsFromAdhoc; }
            set { m_IsFromAdhoc = value; }
        }
    }
}
