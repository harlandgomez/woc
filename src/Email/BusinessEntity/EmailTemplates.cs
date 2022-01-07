using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Email.BusinessEntity
{
    [Serializable]
    public class EmailTemplates
    {
        private Guid m_EmailTemplateID;
        private string m_EmailTemplate;
        private string m_EmailContent;
        private string m_EmailSubject;

        public Guid EmailTemplateID
        {
            get { return m_EmailTemplateID; }
            set { m_EmailTemplateID = value; }
        }
        public string EmailTemplate
        {
            get { return m_EmailTemplate; }
            set { m_EmailTemplate = value; }
        }
        public string EmailContent
        {
            get { return m_EmailContent; }
            set { m_EmailContent = value; }
        }
        public string EmailSubject
        {
            get { return m_EmailSubject; }
            set { m_EmailSubject = value; }
        }

    }

}
