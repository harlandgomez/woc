using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Email.BusinessEntity
{

    public class Emails
    {
        private String m_SMTPUserName;
        public String SMTPUserName
        {
            get { return m_SMTPUserName; }
            set { m_SMTPUserName = value; }
        }
 
        private String m_SMTPPasswordBase64;
        public String SMTPasswordBase64
        {
            get { return m_SMTPPasswordBase64; }
            set { m_SMTPPasswordBase64 = value; }
        }

        private String m_SMTPHost;
        public String SMTPHost
        {
            get { return m_SMTPHost; }
            set { m_SMTPHost = value; }
        }

        private Int16 m_SMTPPort;
        public Int16 SMTPPort
        {
            get { return m_SMTPPort; }
            set { m_SMTPPort = value; }
        }

        private String m_SMTPBody;
        public String SMTPBody
        {
            get { return m_SMTPBody; }
            set { m_SMTPBody = value; }
        }

        private String m_SMTPMailFrom;
        public String SMTPMailFrom
        {
            get { return m_SMTPMailFrom; }
            set { m_SMTPMailFrom = value; }
        }

        private String m_SMTPRecipient;
        public String SMTPRecipient
        {
            get { return m_SMTPRecipient; }
            set { m_SMTPRecipient = value; }
        }
    }
}
