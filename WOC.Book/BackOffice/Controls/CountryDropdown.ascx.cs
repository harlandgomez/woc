using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Woc.Book.Base.Presenter;

namespace WOC.Book.Controls
{
    public partial class CountryDropdown : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (cboCountry.Items.Count == 0)
                {
                    LoadData();
                }
            }
        }

        #region Properties
        /// <summary>
        /// Gets all companies thru CountryPresenter
        /// </summary>
        public void LoadData()
        {
            CountryPresenter CountryPresenter = new CountryPresenter();
            cboCountry.DataSource = CountryPresenter.GetCountryDropdownInfo();
            cboCountry.DataBind();
        }

        /// <summary>
        /// Gets or sets the selected index of Country dropdown
        /// </summary>
        public Int32 SelectedIndex
        {
            get { return cboCountry.SelectedIndex; }
            set { cboCountry.SelectedIndex = value; }
        }
        /// <summary>
        /// Gets or sets the width of Country dropdown
        /// </summary>
        public Unit Width
        {
            get { return cboCountry.Width; }
            set { cboCountry.Width = value; }
        }

        /// <summary>
        /// return the selected CountryID
        /// </summary>
        public object SelectedValue
        {
            get { return cboCountry.SelectedValue; }
        }

        /// <summary>
        /// Finds the item thru parameter value
        /// </summary>
        /// <param name="value">String</param>
        public void FindItemByValue(String value)
        {
            if (cboCountry.SelectedItem != null)
            {
                cboCountry.SelectedItem.Selected = false;
            }
            cboCountry.FindItemByValue(value).Selected = true;
        }

        public void LoadDataWithDefaultCountry()
        {
            if (cboCountry.Items.Count == 0)
            {
                LoadData();
            }
            CountryPresenter countryPresenter = new CountryPresenter();
            Guid defaultValue = countryPresenter.GetDefaultCountryID();
            cboCountry.FindItemByValue(defaultValue.ToString()).Selected = true;
        }
        #endregion
    }
}