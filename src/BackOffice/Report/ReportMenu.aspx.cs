using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WOC.Book.Report
{
    public partial class ReportMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkStatementOfAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("StatementOfAccount.aspx");
        }

        protected void lnkSaleReportByCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalesReportByCustomer.aspx");
            
        }
    }
}