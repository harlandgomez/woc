using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Reporting.WebForms;
namespace Woc.Book.Base
{
    public class ReportController
    {
        /// <summary>
        /// Sets the embedded resource for a report
        /// </summary>
        public void SetReportEmbeddedResource(ReportViewer viewer, string reportName)
        {
            viewer.LocalReport.ReportEmbeddedResource = reportName;
        }
    }
}
