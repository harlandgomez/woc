using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Woc.Book.Agent.Presenter;
namespace FrontOffice
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AgentPresenter agentPresenter = new AgentPresenter();

                lnUserName.FormatString = "(Welcome " + agentPresenter.GetAgentNameByID(HttpContext.Current.User.Identity.Name) + ")";
            }
        }
    }
}