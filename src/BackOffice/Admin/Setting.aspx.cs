using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Woc.Book.Setting.Presenter;
using Woc.Book.Setting.Constant;
using Woc.Book.Setting.BusinessEntity;

using Woc.Book.Base.Presenter; 
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Constant;
using Woc.Book.Base;

//ErrorHandler
using Woc.Book.ErrorHandler;
using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;


namespace WOC.Book.Admin
{
    public partial class Setting : System.Web.UI.Page, IAdminPresenter
    {
        #region Declaration
            SettingPresenter settingPresenter;
        #endregion

        #region ControlEvents
            protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    settingPresenter = new SettingPresenter(this);
                    settingPresenter.DataBindings();
                }

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Setting";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                settingPresenter = new SettingPresenter(this);
                settingPresenter.SaveData();
                if (!lblMessage.Text.Contains("unsuccessfully"))
                {
                    settingPresenter = new SettingPresenter(this);
                    settingPresenter.ClearControl();
                }

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source;
                errorHandlers.Module = "Setting";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            settingPresenter = new SettingPresenter(this);
            settingPresenter.SearchData();
        }

        protected void ibtnListAllPDF_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibtnListAll_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            settingPresenter = new SettingPresenter(this);
            settingPresenter.UpdateData();
        }

        protected void ddlPagingNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            settingPresenter = new SettingPresenter(this);
            settingPresenter.SearchData();
        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;

            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            settingPresenter = new SettingPresenter(this);
            settingPresenter.SearchData();
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row = Convert.ToInt16(e.CommandArgument);

                if (e.CommandName.Equals("Select"))
                {
                    Guid id = new Guid(gv.DataKeys[row].Value.ToString());
                    settingPresenter = new SettingPresenter(this);
                    settingPresenter.GetData(id);
                }
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Setting";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbtnSel = (LinkButton)e.Row.Cells[(int)Constant.gridViewIndexSetting.linkSelect].Controls[0];
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
                errorHandlers.Module = "Setting";
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
                settingPresenter = new SettingPresenter(this);
                settingPresenter.SearchData();

                ddlPagingNumber.DataSource = settingPresenter.GetDropdownValues(Constant.DropdownPageSize.ToString());
                ddlPagingNumber.DataTextField = Constant.DataTextField;
                ddlPagingNumber.DataValueField = Constant.DataValueField;
                ddlPagingNumber.DataBind();
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Setting";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }

        public void SaveData()
        {
            settingPresenter = new SettingPresenter();
            Settings settings = new Settings();
            settings.SettingCode = txtCode.Text.Trim();
            settings.Value = txtValue.Text.Trim();
            settings.DefaultValue = txtValue.Text.Trim();
            settings.LocaleAware = chkLocaleAware.Checked;
            settings.Description = txtDescription.Text.Trim();
            lblMessage.Text = settingPresenter.SaveData(settings);

        }

        public void ClearControl()
        {
            txtEditCode.Text = String.Empty;
            txtEditValue.Text = String.Empty;
            txtEditValue.Text = String.Empty;
            chkEditLocaleAware.Checked = false;
            txtEditDescription.Text = String.Empty;
        }

        public void SearchData()
        {
            try
            {
                Settings settings = new Settings();
                settingPresenter = new SettingPresenter();
                switch (ddlCategory.SelectedValue)
                {
                    case "SettingCode":
                        settings.SettingCode = this.txtSearch.Text.Trim();
                        break;
                    case "Value":
                        settings.Value = this.txtSearch.Text.Trim();
                        break;
                    case "DefaultValue":
                        settings.DefaultValue = this.txtSearch.Text.Trim();
                        break;
                    case "Description":
                        settings.Description = this.txtSearch.Text.Trim();
                        break;
                    case "Select":
                        break;

                }
                gv.DataSource = settingPresenter.SearchData(settings);
                gv.DataBind();

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Setting";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }

        public void GetData(Guid Id)
        {
            settingPresenter = new SettingPresenter();
            DisplayData(settingPresenter.GetUpdateData(Id));

        }

        public void UpdateData()
        {
            Settings settings = new Settings();
            settings.SettingCode = txtEditCode.Text.Trim();
            settings.Value = txtEditValue.Text.Trim();
            settings.DefaultValue = txtEditValue.Text.Trim();
            settings.LocaleAware = chkEditLocaleAware.Checked;
            settings.Description = txtEditDescription.Text.Trim();
            this.lblEditMessage.Text = settingPresenter.UpdateData(settings);
        }

        public void DeleteData()
        {

        }

        public void DisplayData(Settings settings)
        {
            try
            {

                txtEditCode.Text = settings.SettingCode;
                txtEditValue.Text = settings.Value;
                txtEditDefaultValue.Text = settings.DefaultValue;
                txtEditDescription.Text = settings.Description;
                chkLocaleAware.Checked = settings.LocaleAware;

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Setting";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }
        #endregion



    }
}