using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//WOC
using Woc.Book.Company.Presenter;
using Woc.Book.Company.BusinessEntity;
using Woc.Book.Base.Presenter; 
 using Woc.Book.Base;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Constant;
using Woc.Book.Setting.Presenter;

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
    public partial class Company : System.Web.UI.Page, IRegistrationPresenter
    {

        #region Declaration
        CompanyPresenter companyPresenter;
        GSTPresenter gstPresenter;
        SettingPresenter settingsPresenter;
        UserPresenter userPresenter;
        SequencePresenter sequencePresenter;
        ImagePresenter imagePresenter;
        ExportToFilePresenter exportToFilePresenter;
        #endregion

        #region ControlEvents
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    companyPresenter = new CompanyPresenter(this);
                    companyPresenter.DataBindings();
                }

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Company";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message;
            }


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                companyPresenter = new CompanyPresenter(this);
                companyPresenter.SaveData();

                if (!lblMessage.Text.Contains("unsuccessfully"))
                {
                    companyPresenter = new CompanyPresenter(this);
                    companyPresenter.ClearControl();
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
                lblSystemError.Text = errorHandlers.Message;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvCompany.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            companyPresenter = new CompanyPresenter(this);
            companyPresenter.SearchData();
        }
        
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            companyPresenter = new CompanyPresenter(this);
            companyPresenter.UpdateData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            companyPresenter = new CompanyPresenter(this);
            companyPresenter.DeleteData();
        }

        protected void btnViewLetterHead_Click(object sender, EventArgs e)
        {
            try
            {
                imgLetterHead.Src = "ViewLetterHead.aspx?ID=" + hdnID.Value.ToString();

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Company";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message; 
            }
            
        }

        protected void gvCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row = Convert.ToInt16(e.CommandArgument);

                if (e.CommandName.Equals("Select"))
                {
                    string companyCode = gvCompany.DataKeys[row].Value.ToString();
                    companyPresenter = new CompanyPresenter(this);
                    companyPresenter.GetData(companyCode);
                }
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Company";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message; 
            }

        }

        /// <summary>
        /// Grid's selection of item that is to be updated in the update tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbtnSel = (LinkButton)e.Row.Cells[(int)Constant.gridViewIndexCompany.linkSelect].Controls[0];
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
                errorHandlers.Module = "Company";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message; 
            }
        }

        protected void ddlPagingNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvCompany.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            companyPresenter = new CompanyPresenter(this);
            companyPresenter.SearchData();
        }

        protected void gvCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCompany.PageIndex = e.NewPageIndex;

            gvCompany.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            companyPresenter = new CompanyPresenter(this);
            companyPresenter.SearchData();
        }

        protected void ibtnListAll_Click(object sender, ImageClickEventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToExcelTypeID.Company.ToString() + ".xls";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToExcelContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToExcelTypeID.Company));
        }

        protected void ibtnListAllPDF_Click(object sender, ImageClickEventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToPDFTypeID.Company.ToString() + ".pdf";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToPDFContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToPDFTypeID.Company));
        }

        protected void btnAddPrefix_Click(object sender, EventArgs e)
        {
            Prefixes prefixes = new Prefixes();
            prefixes.PrefixCode = txtPrefixCode.Text;
            prefixes.PrefixName = txtPrefixName.Text;
            txtPrefixCode.Text = string.Empty;
            txtPrefixName.Text = string.Empty;

            PrefixList.Add(prefixes);
            gvPrefix.DataSource = PrefixList;
            gvPrefix.DataBind();
        }
        #endregion

        #region interface

        public void DataBindings()
        {
            try
            {
                List<GSTtypes> ListGSTTypes = new List<GSTtypes>();
                gstPresenter = new GSTPresenter();
                settingsPresenter = new SettingPresenter();

                ListGSTTypes = gstPresenter.GetGSTTypes();
                ddlGST.Items.Clear();
                ddlGST.DataSource = ListGSTTypes;
                ddlGST.DataValueField = "GstTypeCode";
                ddlGST.DataTextField = "Description";
                ddlGST.DataBind();

                ddlEditGST.Items.Clear();
                ddlEditGST.DataSource = ListGSTTypes;
                ddlEditGST.DataValueField = "GstTypeCode";
                ddlEditGST.DataTextField = "Description";
                ddlEditGST.DataBind();

                btnDelete.Attributes.Add("onclick", "SelectTab(2);");
                btnAdd.Attributes.Add("onclick", "SelectTab(2);");

                companyPresenter = new CompanyPresenter(this);
                companyPresenter.SearchData();

                PrefixList.Clear();
                PrefixEditList.Clear();
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Company";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message; 
            }

        }

        /// <summary>
        /// Inserts new company 
        /// </summary>
        public void SaveData()
        {
            try
            {
                companyPresenter = new CompanyPresenter();
                Companies companies = new Companies();
                userPresenter = new UserPresenter();
                sequencePresenter = new SequencePresenter();

                companies.Company = txtCompany.Text;
                companies.CompanyCode = sequencePresenter.GetNextSequence(Constant.CompanyCode.ToString()).ToString();
                companies.Address = txtAddress.Text.Trim();
                companies.Telephone = txtTel.Text.Trim();
                companies.Fax = txtFax.Text.Trim();
                companies.Email = txtEmail.Text.Trim();
                companies.Website = txtWebsite.Text;
                companies.ROC = txtROC.Text.Trim();
                companies.GST = ddlGST.SelectedValue; 
                companies.ReflectToOperation = rblReflectToOps.SelectedValue;
                companies.CreatedDate = DateTime.Now;
                companies.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);

                if (PrefixList.Count > 0)
                {
                    companies.PrefixList = PrefixList;
                }

                if (ValidateAttach(fluLetterHead) == true)
                {
                    imagePresenter = new ImagePresenter();
                    HttpPostedFile postedFile = fluLetterHead.PostedFile;
                    int docLen = fluLetterHead.PostedFile.ContentLength;
                    byte[] docBuffer = new byte[docLen];
                    Stream objStream = fluLetterHead.PostedFile.InputStream;
                    objStream.Read(docBuffer, 0, docLen);

                    Images images = new Images();
                    images.CompanyID = new Guid(companyPresenter.SaveData(companies));
                    images.FileName = fluLetterHead.FileName;
                    images.Filesize = docLen;
                    images.ImageFile = docBuffer;
                    images.ContentType = postedFile.ContentType;
                    this.lblMessage.Text = imagePresenter.SaveImage(images);

                    if (lblMessage.Text.Contains("Unsuccessfully"))
                    {
                        companyPresenter.DeleteData(companies);
                    }
                }
                else
                {
                    this.lblMessage.Text = companyPresenter.SaveData(companies);
                }

                if(lblMessage.Text.Equals(Woc.Book.Base.Constant.Constant.MessageSaved))
                {
                    companyPresenter = new CompanyPresenter(this);
                    companyPresenter.SearchData();
                }



            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Company";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message; 
            }
        }

        /// <summary>
        /// Search for companies
        /// </summary>
        public void SearchData()
        {
            try
            {
                Companies companies = new Companies();
                companyPresenter = new CompanyPresenter();
                switch (ddlCategory.SelectedValue)
                {
                    case "Company":
                        companies.Company = this.txtSearch.Text.Trim();
                        break;
                    case "Address":
                        companies.Address = this.txtSearch.Text.Trim();
                        break;
                    case "Tel":
                        companies.Telephone = this.txtSearch.Text.Trim();
                        break;
                    case "Fax":
                        companies.Fax = this.txtSearch.Text.Trim();
                        break;
                    case "Website":
                        companies.Website = this.txtSearch.Text.Trim();
                        break;
                    case "ROC":
                        companies.ROC = this.txtSearch.Text.Trim();
                        break;
                    case "Email":
                        companies.Email = this.txtSearch.Text.Trim();
                        break;
                    case "Prefix":
                        companies.Prefix = this.txtSearch.Text.Trim();
                        break;

                }
                gvCompany.DataSource = companyPresenter.SearchData(companies);
                gvCompany.DataBind();

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Company";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message; 
            }

        }

        /// <summary>
        /// Get the company info from the grid
        /// </summary>
        /// <param name="companyCode"></param>
        public void GetData(String companyCode)
        {
            companyPresenter = new CompanyPresenter();
            DisplayData(companyPresenter.GetUpdateData(companyCode));
        }
        public void UpdateData()
        {
            try
            {
                companyPresenter = new CompanyPresenter();
                userPresenter = new UserPresenter();

                Companies companies = new Companies();
                companies.CompanyID = new Guid(hdnID.Value.Trim());
                companies.CompanyCode = txtEditCompanyCode.Text.Trim();
                companies.Company = txtEditCompany.Text.Trim();
                companies.Address = txtEditAddress.Text.Trim();
                companies.Telephone = txtEditTel.Text.Trim();
                companies.Fax = txtEditFax.Text.Trim();
                companies.Email = txtEditEmail.Text.Trim();
                companies.Website = txtEditWebsite.Text.Trim();
                companies.ROC = txtEditROC.Text.Trim();
                //companies.Prefix = txtEditPrefix.Text.Trim();
                companies.GST = ddlEditGST.SelectedValue;
                companies.ReflectToOperation = rblEditReflectToOps.SelectedValue;
                companies.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);

                if (PrefixEditList.Count > 0)
                {
                    companies.PrefixList = PrefixEditList;
                }

                if (ValidateAttach(fluEditLetterHead) == true)
                {
                    imagePresenter = new ImagePresenter();
                    HttpPostedFile postedFile = fluEditLetterHead.PostedFile;
                    int docLen = fluEditLetterHead.PostedFile.ContentLength;
                    byte[] docBuffer = new byte[docLen];
                    Stream objStream = fluEditLetterHead.PostedFile.InputStream;
                    objStream.Read(docBuffer, 0, docLen);

                    Images images = new Images();
                    images.CompanyID = companies.CompanyID;
                    images.FileName = fluEditLetterHead.FileName;
                    images.Filesize = docLen;
                    images.ImageFile = docBuffer;
                    images.ContentType = postedFile.ContentType;
                    this.lblEditMessage.Text = imagePresenter.UpdateImage(images);
                }

                if (lblEditMessage.Text.Equals(Woc.Book.Base.Constant.Constant.MessageSaved))
                {
                    imgLetterHead.Src = "ViewLetterHead.aspx?ID=" + companies.CompanyID.ToString();
                }

                this.lblEditMessage.Text = companyPresenter.UpdateData(companies);

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Company";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message; 
            }

        }

        /// <summary>
        /// Delete company as in not searchable anymore 
        /// </summary>
        public void DeleteData()
        {
            try
            {
                companyPresenter = new CompanyPresenter();
                Companies companies = new Companies();
                companies.CompanyID = new Guid(hdnID.Value.Trim());
                companies.CompanyCode = txtEditCompanyCode.Text.Trim();
                companies.Company = txtEditCompany.Text.Trim();
                companies.Address = txtEditAddress.Text.Trim();
                companies.Telephone = txtEditTel.Text.Trim();
                companies.Fax = txtEditFax.Text.Trim();
                companies.Email = txtEditEmail.Text.Trim();
                companies.Website = txtEditWebsite.Text.Trim();
                companies.ROC = txtEditROC.Text.Trim();
                //companies.Prefix = txtEditPrefix.Text.Trim();
                companies.GST = ddlEditGST.SelectedValue;
                companies.ReflectToOperation = rblEditReflectToOps.SelectedValue;
                this.lblEditMessage.Text = companyPresenter.DeleteData(companies);

                if (lblEditMessage.Text.Equals(Woc.Book.Base.Constant.Constant.MessageSaved))
                {
                    companyPresenter = new CompanyPresenter(this);
                    companyPresenter.SearchData();
                }

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Company";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message; 
            }

        }
        public void ResignData()
        {

        }

        #endregion

        #region HouseKeeping
        public void ClearControl()
        {
            txtCompany.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtTel.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtWebsite.Text = string.Empty;
            txtROC.Text = string.Empty;
            ddlGST.SelectedValue = "NO";
            rblReflectToOps.SelectedValue = "N";
            lblSystemError.Text = string.Empty;
            gvPrefix.DataSource = null;
        }

        public void DisplayData(Companies companies)
        {
            try
            {
                hdnID.Value = companies.CompanyID.ToString();
                txtEditCompanyCode.Text = companies.CompanyCode;
                txtEditCompany.Text = companies.Company;
                txtEditAddress.Text = companies.Address;
                txtEditTel.Text = companies.Telephone;
                txtEditFax.Text = companies.Fax;
                txtEditEmail.Text = companies.Email;
                txtEditWebsite.Text = companies.Website;
                txtEditROC.Text = companies.ROC;
                PrefixEditList = companies.PrefixList;
                lblEditMessage.Text = string.Empty;
                if (PrefixEditList.Count > 0)
                {
                    gvEditPrefix.DataSource = PrefixEditList;
                    gvEditPrefix.DataBind();
                }

                ddlEditGST.SelectedValue = ddlEditGST.Items.FindByValue(companies.GST.ToString()).Value;
                rblEditReflectToOps.SelectedValue = companies.ReflectToOperation;
                imgLetterHead.Src = "ViewLetterHead.aspx?ID=" + hdnID.Value.ToString();
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Company";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message; 
            }

        }
        protected bool ValidateAttach(FileUpload fuLetterHead)
        {
            if (!fuLetterHead.FileName.Equals(String.Empty))
            {

                string filename = fuLetterHead.FileName.ToLower();
                FileInfo fileInfo = new FileInfo(filename);
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Properties
        List<Prefixes> _prefixList;
        private List<Prefixes> PrefixList
        {
            get
            {
                if (ViewState["Prefix"] == null)
                {
                    _prefixList = new List<Prefixes>();
                    ViewState.Add("Prefix", _prefixList);
                }
                return (List<Prefixes>)ViewState["Prefix"];
            }
            set
            {
                ViewState.Add("Prefix", value);
            }
        }
        List<Prefixes> _prefixEditList;
        private List<Prefixes> PrefixEditList
        {
            get
            {
                if (ViewState["PrefixEdit"] == null)
                {
                    _prefixEditList = new List<Prefixes>();
                    ViewState.Add("PrefixEdit", _prefixEditList);
                }
                return (List<Prefixes>)ViewState["PrefixEdit"];
            }
            set
            {
                ViewState.Add("PrefixEdit", value);
            }
        }
        #endregion

        protected void gvPrefix_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int row = Convert.ToInt16(e.RowIndex);
                PrefixList.RemoveAt(row);
                gvPrefix.DataSource = PrefixList;
                gvPrefix.DataBind();
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Company";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message;
            }
        }

        protected void btnEditPrefix_Click(object sender, EventArgs e)
        {
            Prefixes prefixes = new Prefixes();
            prefixes.PrefixCode = txtEditPrefixCode.Text;
            prefixes.PrefixName = txtEditPrefixName.Text;
            txtEditPrefixCode.Text = string.Empty;
            txtEditPrefixName.Text = string.Empty;

            PrefixEditList.Add(prefixes);
            gvEditPrefix.DataSource = PrefixEditList;
            gvEditPrefix.DataBind();
        }

        protected void gvEditPrefix_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int row = Convert.ToInt16(e.RowIndex);
                PrefixEditList.RemoveAt(row);
                gvEditPrefix.DataSource = PrefixEditList;
                gvEditPrefix.DataBind();
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Company";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = errorHandlers.Message;
            }
        }

    }
}