using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Woc.Book.SubCon.Presenter;
using Telerik.Web.UI;

namespace WOC.Book.Controls
{
    public partial class SubConDropdown : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        #region Properties
        public void UnSelectData()
        {
            cboSubCon.SelectedIndex = 0;
            cboSubCon.SelectedItem.Selected = true;
        }
        /// <summary>
        /// Gets all companies thru SubConPresenter
        /// </summary>
        public void LoadData()
        {
            SubConPresenter SubConPresenter = new SubConPresenter();
            cboSubCon.DataSource = SubConPresenter.GetDropdownInfo();
            cboSubCon.DataBind();
            cboSubCon.Items.Insert(0, new RadComboBoxItem("-Select Subcon-"));
        }

        /// <summary>
        /// Gets or sets the selected index of SubCon dropdown
        /// </summary>
        public Int32 SelectedIndex
        {
            get { return cboSubCon.SelectedIndex; }
            set { cboSubCon.SelectedIndex = value; }
        }
        /// <summary>
        /// Gets or sets the width of SubCon dropdown
        /// </summary>
        public Unit Width
        {
            get { return cboSubCon.Width; }
            set { cboSubCon.Width = value; }
        }

        /// <summary>
        /// return the selected SubConID
        /// </summary>
        public object SelectedValue
        {
            get { return cboSubCon.SelectedValue; }
        }

        /// <summary>
        /// Finds the item thru parameter value
        /// </summary>
        /// <param name="value">String</param>
        public void FindItemByValue(String value)
        {
            if (cboSubCon.SelectedItem != null)
            {
                cboSubCon.SelectedItem.Selected = false;
            }
            cboSubCon.FindItemByValue(value).Selected = true;
        }

        public bool Enabled
        {
            get { return cboSubCon.Enabled; }
            set { cboSubCon.Enabled = value; }
        }
        #endregion

    }
}