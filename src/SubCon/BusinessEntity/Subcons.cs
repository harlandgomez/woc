using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.SubCon.BusinessEntity
{
    [Serializable]
    public class Subcons:IBusinessEntity
    {
        private Guid m_SubconID;
        private string m_SubconCode;
        private string m_Company;
        private string m_Initial;
        private string m_Person;
        private string m_Telephone;
        private string m_Mobile;
        private string m_Fax;
        private string m_Address;
        private string m_Remarks;
        private Guid m_CreatedBy;
        private DateTime m_CreatedDate;
        private Guid m_UpdatedBy;
        private DateTime m_UpdatedDate;
        private string m_Passes1;
        private string m_Passes2;
        private DateTime m_Expiry1;
        private DateTime m_Expiry2;
        private string m_Delete;


        public Guid SubconID
        {
            get { return m_SubconID; }
            set { m_SubconID = value; }
        }
        public string SubconCode
        {
            get { return m_SubconCode; }
            set { m_SubconCode = value; }
        }
        public string Company
        {
            get { return m_Company; }
            set { m_Company = value; }
        }
        public string Initial
        {
            get { return m_Initial; }
            set { m_Initial = value; }
        }
        public string Person
        {
            get { return m_Person; }
            set { m_Person = value; }
        }
        public string Telephone
        {
            get { return m_Telephone; }
            set { m_Telephone = value; }
        }
        public string Mobile
        {
            get { return m_Mobile; }
            set { m_Mobile = value; }
        }
        public string Fax
        {
            get { return m_Fax; }
            set { m_Fax = value; }
        }
        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
        }
        public string Remarks
        {
            get { return m_Remarks; }
            set { m_Remarks = value; }
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
        public string Delete
        {
            get { return m_Delete; }
            set { m_Delete = value; }
        }

    }

}
