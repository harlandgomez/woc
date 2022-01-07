using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Company.BusinessEntity
{
    [Serializable]
    public class Prefixes
    {
        private Guid m_CompanyPrefixID;
        private Guid m_CompanyID;
        private string m_PrefixCode;
        private string m_PrefixName;

        public Guid CompanyPrefixID
        {
            get { return m_CompanyPrefixID; }
            set { m_CompanyPrefixID = value; }
        }
        public Guid CompanyID
        {
            get { return m_CompanyID; }
            set { m_CompanyID = value; }
        }
        public string PrefixCode
        {
            get { return m_PrefixCode; }
            set { m_PrefixCode = value; }
        }
        public string PrefixName
        {
            get { return m_PrefixName; }
            set { m_PrefixName = value; }
        }

    }
}
