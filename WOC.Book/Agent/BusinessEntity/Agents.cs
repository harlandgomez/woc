using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Agent.BusinessEntity
{
    [Serializable]
    public class Agents:IBusinessEntity
    {
        private Guid m_AgentID;
        private string m_AgentCode;
        private string m_Agent;
        private string m_Prefix;
        private string m_Address;
        private string m_Email;
        private string m_Telephone;
        private string m_Fax;
        private string m_RegistrationNo;
        private string m_PostalCode;
        private string m_ContactPerson1;
        private string m_Destination1;
        private string m_HP1;
        private bool m_Stop;
        private DateTime m_StopDate;
        private string m_ContactTelephone1;
        private string m_ContactPerson2;
        private string m_Destination2;
        private string m_HP2;
        private string m_ContactTelephone2;
        private string m_UserName;
        private byte[] m_Password;
        private byte[] m_Salt;
        private string m_textBoxPassword;
        private string m_Delete;
        private Guid m_CreatedBy;
        private DateTime m_CreatedDate;
        private Guid m_UpdatedBy;
        private DateTime m_UpdatedDate;
        private Guid m_CountryID;

        
        public Guid AgentID
        {
            get { return m_AgentID; }
            set { m_AgentID = value; }
        }
        public string AgentCode
        {
            get { return m_AgentCode; }
            set { m_AgentCode = value; }
        }
        public string Agent
        {
            get { return m_Agent; }
            set { m_Agent = value; }
        }
        public string Prefix
        {
            get { return m_Prefix; }
            set { m_Prefix = value; }
        }
        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }
        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }
        public string Telephone
        {
            get { return m_Telephone; }
            set { m_Telephone = value; }
        }
        public string Fax
        {
            get { return m_Fax; }
            set { m_Fax = value; }
        }
        public string RegistrationNo
        {
            get { return m_RegistrationNo; }
            set { m_RegistrationNo = value; }
        }
        public string PostalCode
        {
            get { return m_PostalCode; }
            set { m_PostalCode = value; }
        }
        public string ContactPerson1
        {
            get { return m_ContactPerson1; }
            set { m_ContactPerson1 = value; }
        }
        public string Destination1
        {
            get { return m_Destination1; }
            set { m_Destination1 = value; }
        }
        public string HP1
        {
            get { return m_HP1; }
            set { m_HP1 = value; }
        }
        public bool Stop
        {
            get { return m_Stop; }
            set { m_Stop = value; }
        }
        public DateTime StopDate
        {
            get { return m_StopDate; }
            set { m_StopDate = value; }
        }
        public string ContactTelephone1
        {
            get { return m_ContactTelephone1; }
            set { m_ContactTelephone1 = value; }
        }
        public string ContactPerson2
        {
            get { return m_ContactPerson2; }
            set { m_ContactPerson2 = value; }
        }
        public string Destination2
        {
            get { return m_Destination2; }
            set { m_Destination2 = value; }
        }
        public string HP2
        {
            get { return m_HP2; }
            set { m_HP2 = value; }
        }
        public string ContactTelephone2
        {
            get { return m_ContactTelephone2; }
            set { m_ContactTelephone2 = value; }
        }
        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }
        public string TextBoxPassword
        {
            get { return m_textBoxPassword; }
            set { m_textBoxPassword = value; }
        }
        public string Delete
        {
            get { return m_Delete; }
            set { m_Delete = value; }
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
        public Guid CountryID
        {
            get { return m_CountryID; }
            set { m_CountryID    = value; }
        }

        public byte[] Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }
        public byte[] Salt
        {
            get { return m_Salt; }
            set { m_Salt = value; }
        }
    }
}
