using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Woc.Book.Agent.Presenter;
using Telerik.Web.UI;

namespace WOC.Book.Controls
{
    public partial class AgentDropdown : System.Web.UI.UserControl
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
        /// Gets all companies thru AgentPresenter
        /// </summary>
        public void LoadData()
        {
            AgentPresenter agentPresenter = new AgentPresenter();
            cboAgent.DataSource = agentPresenter.GetAgentDropdownInfo();
            cboAgent.DataBind();
            cboAgent.Items.Insert(0, new RadComboBoxItem("-Select Agent-", Guid.Empty.ToString()));
        }

        /// <summary>
        /// Gets or sets the selected index of Agent dropdown
        /// </summary>
        public Int32 SelectedIndex
        {
            get { return cboAgent.SelectedIndex; }
            set { cboAgent.SelectedIndex = value; }
        }
        /// <summary>
        /// Gets or sets the width of Agent dropdown
        /// </summary>
        public Unit Width
        {
            get { return cboAgent.Width; }
            set { cboAgent.Width = value; }
        }

        /// <summary>
        /// return the selected AgentID
        /// </summary>
        public object SelectedValue
        {
            get { return cboAgent.SelectedValue; }
        }

        /// <summary>
        /// Finds the item thru parameter value
        /// </summary>
        /// <param name="value">String</param>
        public void FindItemByValue(String value)
        {
            if (cboAgent.SelectedItem != null)
            {
                cboAgent.SelectedItem.Selected = false;
            }
            cboAgent.FindItemByValue(value).Selected = true;
        }

        #endregion
    }
}