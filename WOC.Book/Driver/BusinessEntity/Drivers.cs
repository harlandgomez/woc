using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Driver.BusinessEntity
{
    [Serializable]
    public class Drivers : IBusinessEntity
    {
        private Guid m_DriverID;
        private string m_DriverName;
        private string m_Address1;
        private string m_Address2;
        private string m_Address3;
        private string m_Contact;
        private DateTime m_DateJoin;
        private Guid m_CountryID;
        private string m_BusNo;
        private Guid m_CreatedBy;
        private DateTime m_CreatedDate;
        private DateTime m_UpdatedDate;
        private string m_FIN;
        private string m_DOB;
        private string m_DriverCode;
        private string m_Delete;
        private string m_Passes1;
        private string m_Passes2;
        private string m_Passes3;
        private DateTime m_Expiry1;
        private DateTime m_Expiry2;
        private DateTime m_Expiry3;
        private Guid m_UpdatedBy;
        private bool m_Resigned;
        private DateTime m_DateResigned;


        public Guid DriverID
        {
            get { return m_DriverID; }
            set { m_DriverID = value; }
        }
        public string DriverName
        {
            get { return m_DriverName; }
            set { m_DriverName = value; }
        }
        public string Address1
        {
            get { return m_Address1; }
            set { m_Address1 = value; }
        }
        public string Address2
        {
            get { return m_Address2; }
            set { m_Address2 = value; }
        }
        public string Address3
        {
            get { return m_Address3; }
            set { m_Address3 = value; }
        }
        public string Contact
        {
            get { return m_Contact; }
            set { m_Contact = value; }
        }
        public DateTime DateJoin
        {
            get { return m_DateJoin; }
            set { m_DateJoin = value; }
        }
        public Guid CountryID
        {
            get { return m_CountryID; }
            set { m_CountryID = value; }
        }
        public string BusNo
        {
            get { return m_BusNo; }
            set { m_BusNo = value; }
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
        public DateTime UpdatedDate
        {
            get { return m_UpdatedDate; }
            set { m_UpdatedDate = value; }
        }
        public string FIN
        {
            get { return m_FIN; }
            set { m_FIN = value; }
        }
        public string DOB
        {
            get { return m_DOB; }
            set { m_DOB = value; }
        }
        public string DriverCode
        {
            get { return m_DriverCode; }
            set { m_DriverCode = value; }
        }
        public string Delete
        {
            get { return m_Delete; }
            set { m_Delete = value; }
        }
        public string Passes1
        {
            get { return m_Passes1; }
            set { m_Passes1 = value; }
        }
        public string Passes2
        {
            get { return m_Passes2; }
            set { m_Passes2 = value; }
        }
        public string Passes3
        {
            get { return m_Passes3; }
            set { m_Passes3 = value; }
        }
        public DateTime Expiry1
        {
            get { return m_Expiry1; }
            set { m_Expiry1 = value; }
        }
        public DateTime Expiry2
        {
            get { return m_Expiry2; }
            set { m_Expiry2 = value; }
        }
        public DateTime Expiry3
        {
            get { return m_Expiry3; }
            set { m_Expiry3 = value; }
        }
        public Guid UpdatedBy
        {
            get { return m_UpdatedBy; }
            set { m_UpdatedBy = value; }
        }
        public bool Resigned
        {
            get { return m_Resigned; }
            set { m_Resigned = value; }
        }
        public DateTime ResignedDate
        {
            get { return m_DateResigned; }
            set { m_DateResigned = value; }
        }
    }

}
