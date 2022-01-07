using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Woc.Book.Company.Presenter;

namespace WOC.Book.Controls
{
    public partial class CompanyDropdown : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        #region Properties
        /// <summary>
        /// Gets all companies thru CompanyPresenter
        /// </summary>
        public void LoadData()
        {
            CompanyPresenter companyPresenter = new CompanyPresenter();
            cboCompany.DataSource = companyPresenter.GetCompanyDropdownInfo();
            cboCompany.DataBind();
        }

        /// <summary>
        /// Gets or sets the selected index of Company dropdown
        /// </summary>
        public Int32 SelectedIndex
        {
            get { return cboCompany.SelectedIndex; }
            set { cboCompany.SelectedIndex = value; }
        }
        /// <summary>
        /// Gets or sets the width of Company dropdown
        /// </summary>
        public Unit Width
        {
            get { return cboCompany.Width; }
            set { cboCompany.Width = value; }
        }

        /// <summary>
        /// return the selected companyID
        /// </summary>
        public object SelectedValue
        {
            get { return cboCompany.SelectedValue; }
        }

        /// <summary>
        /// Finds the item thru parameter value
        /// </summary>
        /// <param name="value">String</param>
        public void FindItemByValue(String value)
        {
            if (cboCompany.SelectedItem != null)
            {
                cboCompany.SelectedItem.Selected = false;
            }
            cboCompany.FindItemByValue(value).Selected = true;
        }

        #endregion

    }
}