using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Report.BusinessEntity
{
    [Serializable]
    public class ReportItems
    {
        private Guid m_ParamID;
        private string m_PageName;
        private string m_WebPath;
        private string m_ServerPath;
        private string m_ReportCode;
        private string m_Script;

        public String PageName
        {
            get { return m_PageName; }
            set { m_PageName = value; }
        }

        public Guid ParamID
        {
            get { return m_ParamID; }
            set { m_ParamID = value; }
        }

        public string WebPath
        {
            get { return m_WebPath; }
            set { m_WebPath = value; }
        }

        public string ReportCode
        {
            get { return m_ReportCode; }
            set { m_ReportCode = value; }
        }

        public string ReportServerPath
        {
            get { return m_ServerPath; }
            set { m_ServerPath = value; }
        }

        public string Script
        {
            get { return m_Script; }
            set { m_Script = value; }
        }
    }
}
