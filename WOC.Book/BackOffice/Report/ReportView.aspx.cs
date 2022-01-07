using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Collections.Specialized;

using Woc.Book.Invoice.Presenter;

using Woc.Book.Report.BusinessEntity;
using Woc.Book.Report.Presenter;
using Woc.Book.Base.Presenter; 
using Woc.Book.Base;

namespace WOC.Book.Report
{
    public partial class ReportView : System.Web.UI.Page, IReportPresenter
    {
        ReportPresenter reportPresenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reportPresenter = new ReportPresenter();

                Reports reports = reportPresenter.GetReportByCode(Request.QueryString["ReportCode"]);

                rv.LocalReport.ReportEmbeddedResource = reports.ReportPath;
                rv.LocalReport.ReportPath = reports.ReportPath;

                
                GetReportDataSourceByReportName(reports.ReportName);
                this.rv.LocalReport.Refresh();
            }

        }


        public void SearchData()
        {
            
        }

#region Helper Methods
        private void GetReportDataSourceByReportName(String reportName)
        {
            ReportDataSource rds;
            reportPresenter = new ReportPresenter();

            switch (reportName)
            {
                case "Invoice":
                    rds = new ReportDataSource("dstInvoice", reportPresenter.GetInvoice(Request.QueryString["InvoiceID"]));
                    this.rv.LocalReport.DataSources.Add(rds);
                    rds = new ReportDataSource("dstInvoiceDetail", reportPresenter.GetInvoiceDetailsByInvoiceID(Request.QueryString["InvoiceID"]));
                    this.rv.LocalReport.DataSources.Add(rds);
                    break;
                default:
                    this.rv.LocalReport.DataSources.Add(null);
                    break;
            }
        }
#endregion

    }
}