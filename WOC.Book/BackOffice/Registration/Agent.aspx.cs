using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//WOC
using Woc.Book.Agent.Presenter;
using Woc.Book.Agent.BusinessEntity;

using Woc.Book.Base.Presenter; 
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Constant;
using Woc.Book.Base;

//ErrorHandler
using Woc.Book.ErrorHandler;
using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;

//Export To Excel
using System.Web.UI.HtmlControls;
using System.IO;
using Woc.Book.ExportToFile.Presenter;

namespace WOC.Book
{
    public partial class Agent : System.Web.UI.Page, IRegistrationPresenter
    {
        #region Declaration

        AgentPresenter agentPresenter;
        SequencePresenter sequencePresenter;
        ExportToFilePresenter exportToFilePresenter;
        CountryPresenter countryPresenter;

        #endregion

        #region ControlEvents
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    agentPresenter = new AgentPresenter(this);
                    agentPresenter.DataBindings();
                }

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Bus";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                agentPresenter = new AgentPresenter(this);
                agentPresenter.SaveData();
                if (!lblMessage.Text.Contains("unsuccessfully"))
                {
                    agentPresenter = new AgentPresenter(this);
                    agentPresenter.ClearControl();
                }

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source;
                errorHandlers.Module = ex.TargetSite.Module.ToString();
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }
        

        protected void btnResigned_Click(object sender, EventArgs e)
        {
            agentPresenter = new AgentPresenter(this);
            agentPresenter.ResignData();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            agentPresenter = new AgentPresenter(this);
            agentPresenter.UpdateData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            agentPresenter = new AgentPresenter(this);
            agentPresenter.DeleteData();

            agentPresenter = new AgentPresenter(this);
            agentPresenter.ClearControl();

            agentPresenter = new AgentPresenter(this);
            agentPresenter.SearchData();

        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row = Convert.ToInt16(e.CommandArgument);

                if (e.CommandName.Equals("Select"))
                {
                    string agentCode = gv.DataKeys[row].Value.ToString();
                    agentPresenter = new AgentPresenter(this);
                    agentPresenter.GetData(agentCode);
                }
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Agent";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }

        protected void lbtnListAllAgent_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            AgentPresenter agentPresenter;
            agentPresenter = new AgentPresenter(this);
            agentPresenter.SearchData();

        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;

            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            agentPresenter = new AgentPresenter(this);
            agentPresenter.SearchData();
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbtnSel = (LinkButton)e.Row.Cells[(int)Constant.gridViewIndexAgent.linkSelect].Controls[0];
                    lbtnSel.Attributes.Add("onclick", "SelectLastTab();");
                }
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Staff";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }

        protected void ddlPagingNumber_SelectedIndexChanged(object sender, EventArgs e)
        {


            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            agentPresenter = new AgentPresenter(this);
            agentPresenter.SearchData();
        }

        protected void ibtnListAll_Click(object sender, ImageClickEventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToExcelTypeID.Agent.ToString() + ".xls";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToExcelContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToExcelTypeID.Agent));
        }

        protected void ibtnListAllPDF_Click(object sender, ImageClickEventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToPDFTypeID.Agent.ToString() + ".pdf";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToPDFContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToPDFTypeID.Agent));
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                agentPresenter = new AgentPresenter();
                if (agentPresenter.CheckAgentUserNameExists(txtUserName.Text))
                {
                    lblMessage.Text = Woc.Book.Agent.Constant.Constant.MessageUserNameAlreadyExists;
                    txtUserName.Focus();
                }
                else
                {
                    lblMessage.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Staff";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }
        #endregion

        #region interface

        public void DataBindings()
        {

            try
            {
                if (!IsPostBack)
                {
                    agentPresenter = new AgentPresenter(this);
                    countryPresenter = new CountryPresenter();
                    List<Countries> CountryList = countryPresenter.GetCountryDropdownInfo();
                    agentPresenter.SearchData();

                    cboCountry.DataSource = CountryList;
                    cboCountry.DataTextField = "Country";
                    cboCountry.DataValueField = "CountryID";
                    cboCountry.DataBind();

                    cboEditCountry.DataSource = CountryList;
                    cboEditCountry.DataTextField = "Country";
                    cboEditCountry.DataValueField = "CountryID";
                    cboEditCountry.DataBind();

                    cboCountry.SelectedItem.Selected = false;
                    cboCountry.Items.FindItemByValue(Convert.ToString(countryPresenter.GetDefaultCountryID())).Selected = true;
                }

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Agent";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            } 

        }

        public void SaveData()
        {
            try
            {
                UserPresenter userPresenter = new UserPresenter();
                agentPresenter = new AgentPresenter();
                sequencePresenter = new SequencePresenter();

                Agents agents = new Agents();
                agents.AgentCode = sequencePresenter.GetNextSequence("AgentCode").ToString();
                agents.Agent = this.txtAgent.Text;
                agents.Prefix = this.txtPrefix.Text;
                agents.Address = this.txtAddress.Text;
                agents.Email = this.txtEmail.Text;
                agents.Telephone = this.txtTelephone.Text;
                agents.Fax = this.txtFax.Text;
                agents.PostalCode = this.txtPostalCode.Text;
                agents.ContactPerson1 = this.txtContactPerson1.Text;
                agents.Destination1 = this.txtDestination1.Text;
                agents.HP1 = this.txtHP1.Text;
                agents.ContactTelephone1 = this.txtContactTelephone1.Text;
                agents.CountryID = new Guid(cboCountry.SelectedValue);
                agents.Stop = rdlStop.SelectedIndex == 0 ? true : false;

                agents.ContactPerson2 = this.txtContactPerson2.Text;
                agents.Destination2 = this.txtDestination2.Text;
                agents.HP2 = this.txtHP2.Text;
                agents.ContactTelephone2 = this.txtTelephone2.Text;

                agents.StopDate = string.IsNullOrEmpty(txtStopDate.Text.Trim()) ? DateTime.MinValue: UtilityController.StringToDate(this.txtStopDate.Text);

                agents.UserName = this.txtUserName.Text;
                agents.TextBoxPassword = this.txtPassword.Text.ToString();
                agents.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                agents.CreatedDate = DateTime.Now;
                agents.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                agents.UpdatedDate = DateTime.Now;
                lblMessage.Text = agentPresenter.SaveData(agents);

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Agent";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSysMessage.Text = errorHandlers.Message;
            }


        }
        public void SearchData()
        {
            Agents agents = new Agents();
            agentPresenter = new AgentPresenter();
            switch (ddlCategory.SelectedValue)
            {
                case "Agent":
                    agents.Agent = this.txtSearch.Text.Trim();
                    break;

                case "AgentCode":
                    agents.AgentCode = this.txtSearch.Text.Trim();
                    break;
                case "Address":
                    agents.Address = this.txtSearch.Text.Trim();
                    break;
                case "Email":
                    agents.Email = this.txtSearch.Text.Trim();
                    break;
                case "Fax":
                    agents.Fax = this.txtSearch.Text.Trim();
                    break;
                case "Select":
                    break;


            }
            gv.DataSource = agentPresenter.SearchData(agents);
            gv.DataBind();
        }
        public void GetData(String loginID)
        {
            agentPresenter = new AgentPresenter();
            DisplayData(agentPresenter.GetUpdateData(loginID));
        }
        public void UpdateData()
        {
            try
            {
                UserPresenter userPresenter = new UserPresenter();
                agentPresenter = new AgentPresenter();
                sequencePresenter = new SequencePresenter();

                Agents agents = new Agents();
                agents.AgentCode = this.txtEditAgentCode.Text;
                agents.Agent = this.txtEditAgent.Text;
                agents.Prefix = this.txtEditPrefix.Text;
                agents.Address = this.txtEditAddress.Text;
                agents.Email = this.txtEditEmail.Text;
                agents.Telephone = this.txtEditTelephone.Text;
                agents.Fax = this.txtEditFax.Text;
                agents.PostalCode = this.txtEditPostalCode.Text;
                agents.ContactPerson1 = this.txtEditContactPerson1.Text;
                agents.Destination1 = this.txtEditDestination1.Text;
                agents.HP1 = this.txtEditHP1.Text;
                agents.ContactTelephone1 = this.txtEditContactTelephone1.Text;
                agents.CountryID = new Guid(this.cboEditCountry.SelectedValue);
                agents.Stop = rblEditStop.SelectedIndex == 0 ? true : false;

                agents.ContactPerson2 = this.txtEditContactPerson2.Text;
                agents.Destination2 = this.txtEditDestination2.Text;
                agents.HP2 = this.txtEditHP2.Text;
                agents.ContactTelephone2 = this.txtEditContactTelephone1.Text;
                agents.StopDate = string.IsNullOrEmpty(txtStopDate.Text.Trim()) ? DateTime.MinValue : UtilityController.StringToDate(this.txtEditStopDate.Text);
                agents.UserName = this.txtEditUserName.Text;
                agents.TextBoxPassword = this.rtxtEditPassword.Text.ToString();
                agents.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                agents.CreatedDate = DateTime.Now;
                agents.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                agents.UpdatedDate = DateTime.Now;

                lblEditMessage.Text = agentPresenter.UpdateData(agents);
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Agent";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSysMessage.Text = errorHandlers.Message;
            }


        }
        public void DeleteData()
        {
            try
            {
                UserPresenter userPresenter = new UserPresenter();
                agentPresenter = new AgentPresenter();
                sequencePresenter = new SequencePresenter();

                Agents agents = new Agents();
                agents.AgentCode = this.txtEditAgentCode.Text;
                agents.Agent = this.txtEditAgent.Text;
                agents.Prefix = this.txtEditPrefix.Text;
                agents.Address = this.txtEditAddress.Text;
                agents.Email = this.txtEditEmail.Text;
                agents.Telephone = this.txtEditTelephone.Text;
                agents.Fax = this.txtEditFax.Text;
                agents.PostalCode = this.txtEditPostalCode.Text;
                agents.ContactPerson1 = this.txtEditContactPerson1.Text;
                agents.Destination1 = this.txtEditDestination1.Text;
                agents.HP1 = this.txtEditHP1.Text;
                agents.ContactTelephone1 = this.txtEditContactTelephone1.Text;
                
                agents.Stop = rblEditStop.SelectedIndex == 0 ? true: false;
                
                agents.ContactPerson2 = this.txtEditContactPerson2.Text;
                agents.Destination2 = this.txtEditDestination2.Text;
                agents.HP2 = this.txtEditHP2.Text;
                agents.ContactTelephone2 = this.txtEditContactTelephone1.Text;
                agents.StopDate = String.IsNullOrEmpty(txtEditStopDate.Text.Trim()) ? DateTime.MinValue : UtilityController.StringToDate(this.txtEditStopDate.Text);
                agents.UserName = this.txtEditUserName.Text;
                agents.TextBoxPassword = this.rtxtEditPassword.Text.ToString();
                agents.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                agents.CreatedDate = DateTime.Now;
                agents.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                agents.UpdatedDate = DateTime.Now;
                
                lblMessage.Text = agentPresenter.DeleteData(agents);
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Agent";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }


        }
        public void ResignData()
        {
            try
            {

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Agent";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }

        #endregion

        #region HouseKeeping
        public void ClearControl()
        {
            //Add
            this.txtAgent.Text = string.Empty;
            this.txtPrefix.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtTelephone.Text = string.Empty;
            this.txtFax.Text = string.Empty;
            this.txtPostalCode.Text = string.Empty;
            this.txtContactPerson1.Text = string.Empty;
            this.txtDestination1.Text = string.Empty;
            this.txtHP1.Text = string.Empty;
            this.txtContactTelephone1.Text = string.Empty;
            this.rdlStop.SelectedIndex = 0;
            this.txtContactPerson2.Text = string.Empty;
            this.txtDestination2.Text = string.Empty;
            this.txtHP2.Text = string.Empty;
            this.txtTelephone2.Text = string.Empty;
            this.txtStopDate.Text = string.Empty;
            this.txtUserName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;

            //Update
            this.txtEditAgent.Text = string.Empty;
            this.txtEditPrefix.Text = string.Empty;
            this.txtEditAddress.Text = string.Empty;
            this.txtEditEmail.Text = string.Empty;
            this.txtEditTelephone.Text = string.Empty;
            this.txtEditFax.Text = string.Empty;
            this.txtEditPostalCode.Text = string.Empty;
            this.txtEditContactPerson1.Text = string.Empty;
            this.txtEditDestination1.Text = string.Empty;
            this.txtEditHP1.Text = string.Empty;
            this.txtEditContactTelephone1.Text = string.Empty;
            this.rblEditStop.SelectedIndex = 0;
            this.txtEditContactPerson2.Text = string.Empty;
            this.txtEditDestination2.Text = string.Empty;
            this.txtEditHP2.Text = string.Empty;
            this.txtEditContactTelephone2.Text = string.Empty;
            this.txtEditStopDate.Text = string.Empty;
            this.txtEditUserName.Text = string.Empty;
            this.rtxtEditPassword.Text = string.Empty;
        }

        public void DisplayData(Agents agents)
        {
            try
            {
                this.txtEditAgent.Text = agents.Agent;
                this.txtEditAgentCode.Text = agents.AgentCode;
                this.txtEditAddress.Text = agents.Address;
                this.txtEditEmail.Text = agents.Email;
                this.txtEditPrefix.Text = agents.Prefix;
                this.txtEditTelephone.Text = agents.Telephone;
                this.txtEditFax.Text = agents.Fax;
                this.txtEditPostalCode.Text = agents.PostalCode;
                this.txtEditContactPerson1.Text = agents.ContactPerson1;
                this.txtEditDestination1.Text = agents.Destination1;
                this.txtEditHP1.Text = agents.HP1;
                this.txtEditContactTelephone1.Text = agents.ContactTelephone1;
                this.rblEditStop.SelectedIndex = agents.Stop ? 0 : 1;
                this.txtEditStopDate.Text = agents.StopDate == DateTime.MinValue ? string.Empty : agents.StopDate.ToString(Properties.WebResources.dateformat);
                this.txtEditContactPerson2.Text = agents.ContactPerson2;
                this.txtEditDestination2.Text = agents.Destination2;
                this.txtEditHP2.Text = agents.HP2;
                this.txtEditContactTelephone2.Text = agents.ContactTelephone2;
                this.txtEditUserName.Text = agents.UserName;
                this.cboEditCountry.SelectedItem.Selected = false;
                this.cboEditCountry.Items.FindItemByValue(agents.CountryID.ToString()).Selected = true;
                this.rtxtEditPassword.Text = string.Empty;
                this.lblEditMessage.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Agent";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }


        #endregion

        protected void txtEditUserName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                agentPresenter = new AgentPresenter();
                if (agentPresenter.CheckAgentUserNameExists(txtEditUserName.Text))
                {
                    lblEditMessage.Text = Woc.Book.Agent.Constant.Constant.MessageUserNameAlreadyExists;
                    txtEditUserName.Focus();
                }
                else
                {
                    lblEditMessage.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Staff";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }



    }
}