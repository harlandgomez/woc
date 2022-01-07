using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.StatementOfAccount.BusinessEntity;

namespace Woc.Book.StatementOfAccount.BusinessEntity
{
   public class StatementOfAccountDTO : IAccountEntity
    {
       
        private string m_Company;
        private string m_Address;
        private string m_Telephone;
        private string m_Fax;

        private string m_Agent;
        private string m_AgentAddress;
        private string m_Contact;
       
      
        public string Company
        {
            get { return m_Company; }
            set { m_Company = value; }
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

        public string Agent
        {
            get { return m_Agent; }
            set { m_Agent = value; }
        }
        public string AgentAddress
        {
            get { return m_AgentAddress; }
            set { m_AgentAddress = value; }
        }

        public string Contact
        {
            get { return m_Contact; }
            set { m_Contact = value; }
        }
        
    }
}
