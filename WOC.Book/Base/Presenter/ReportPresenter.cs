using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Common;
using Microsoft.Reporting.WebForms;

namespace Woc.Book.Common.Presenter
{
    public class ReportPresenter
    {
        ReportController reportController;

        public void SetReportEmbeddedResource(ReportViewer viewer, string reportName)
        {
            reportController = new ReportController();
            reportController.SetReportEmbeddedResource(viewer, reportName);
        }
    }
}
