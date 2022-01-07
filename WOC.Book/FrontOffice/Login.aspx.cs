using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using Woc.Book.Login.Presenter;
using Woc.Book.Login.Constant;

namespace FrontOffice
{
    public partial class Login : System.Web.UI.Page, ILogin
    {
    #region Declaration
        LoginPresenter loginPresenter;
    #endregion

    #region Control_Event
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rbtnLogin_Click(object sender, EventArgs e)
        {
            loginPresenter = new LoginPresenter(this);
            loginPresenter.Logging();
        }
    #endregion 

    #region Interface
        public void Logging()
        {
            loginPresenter = new LoginPresenter();
            lblMessage.Text = loginPresenter.LoginCustomer(rtxtUserName.Text, rtxtPassword.Text);

            if (lblMessage.Text.Contains(Constant.Valid))
            {
                Authenticate();
            }
        }

        public void Authenticate()
        {
            TimeSpan SessTimeOut = new TimeSpan(0, 0, System.Web.HttpContext.Current.Session.Timeout, 0, 0);
            HttpContext.Current.Cache.Insert(rtxtPassword.Text, rtxtUserName.Text, null, DateTime.MaxValue, SessTimeOut, System.Web.Caching.CacheItemPriority.NotRemovable, null);
            FormsAuthentication.RedirectFromLoginPage(rtxtUserName.Text, true);
            Response.Redirect(Constant.DefaultView);
        }
    #endregion


    }
}