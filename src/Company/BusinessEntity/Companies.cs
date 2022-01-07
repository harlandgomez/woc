using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.Company.BusinessEntity
{
    [Serializable]
    public class Companies : IBusinessEntity
    {
        private Guid m_CompanyID;
        private string m_CompanyCode;
        private string m_Company;
        private string m_Address;
        private string m_Telephone;
        private string m_Fax;
        private string m_Email;
        private string m_Website;
        private string m_ROC;
        private string m_Prefix;
        private string m_GST;
        private string m_ReflectToOperation;
        private Guid m_CreatedBy;
        private DateTime m_CreatedDate;
        private Guid m_UpdatedBy;
        private DateTime m_UpdatedDate;

        public Guid CompanyID
        {
            get { return m_CompanyID; }
            set { m_CompanyID = value; }
        }
        public string Company
        {
            get { return m_Company; }
            set { m_Company = value; }
        }
        public string CompanyCode
        {
            get { return m_CompanyCode; }
            set { m_CompanyCode = value; }
        }
        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
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
        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }
        public string Website
        {
            get { return m_Website; }
            set { m_Website = value; }
        }
        public string ROC
        {
            get { return m_ROC; }
            set { m_ROC = value; }
        }
        public string Prefix
        {
            get { return m_Prefix; }
            set { m_Prefix = value; }
        }
        public string GST
        {
            get { return m_GST; }
            set { m_GST = value; }
        }
        public string ReflectToOperation
        {
            get { return m_ReflectToOperation; }
            set { m_ReflectToOperation = value; }
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

        public List<Prefixes> PrefixList = new List<Prefixes>();

    }

}
