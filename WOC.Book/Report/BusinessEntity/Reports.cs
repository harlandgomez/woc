using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Report.BusinessEntity
{
    [Serializable]
    public class Reports
    {
        private Guid m_ReportID;
        private string m_ReportName;
        private string m_ReportType;
        private string m_ReportPath;
        private string m_ReportCode;
        public Guid ReportID
        {
            get { return m_ReportID; }
            set { m_ReportID = value; }
        }
        public string ReportName
        {
            get { return m_ReportName; }
            set { m_ReportName = value; }
        }
        public string ReportType
        {
            get { return m_ReportType; }
            set { m_ReportType = value; }
        }
        public string ReportCode
        {
            get { return m_ReportCode; }
            set { m_ReportCode = value; }
        }
        public string ReportPath
        {
            get { return m_ReportPath; }
            set { m_ReportPath = value; }
        }

        public List<ReportParameters> ListReportParameters = new List<ReportParameters>();
    }
}
