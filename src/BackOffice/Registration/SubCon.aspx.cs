using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//WOC
using Woc.Book.SubCon.Presenter;
using Woc.Book.SubCon.BusinessEntity;


//Common
using Woc.Book.Base.Presenter; 
 using Woc.Book.Base;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Constant;

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
    public partial class SubCon : System.Web.UI.Page, IRegistrationPresenter
    {
        #region Declaration

        SubConPresenter subConPresenter;
        SequencePresenter sequencePresenter;
        ExportToFilePresenter exportToFilePresenter;
        #endregion

        #region ControlEvents
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    subConPresenter = new SubConPresenter(this);
                    subConPresenter.DataBindings();
                }

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "SubCon";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                subConPresenter = new SubConPresenter(this);
                subConPresenter.SaveData();
                if (!lblMessage.Text.Contains("unsuccessfully"))
                {
                    subConPresenter = new SubConPresenter(this);
                    subConPresenter.ClearControl();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            subConPresenter = new SubConPresenter(this);
            subConPresenter.SearchData();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            subConPresenter = new SubConPresenter(this);
            subConPresenter.UpdateData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            subConPresenter = new SubConPresenter(this);
            subConPresenter.DeleteData();
        }

        protected void gvSubCon_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row = Convert.ToInt16(e.CommandArgument);

                if (e.CommandName.Equals("Select"))
                {
                    string busCode = gvSubCon.DataKeys[row].Value.ToString();
                    subConPresenter = new SubConPresenter(this);
                    subConPresenter.GetData(busCode);
                }
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "SubCon";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }
        protected void lbtnListAllBus_Click(object sender, EventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToExcelTypeID.SubCon.ToString() + ".xls";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToExcelContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToExcelTypeID.SubCon));
        }

        /// <summary>
        /// Grid's selection of item that is to be updated in the update tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvSubCon_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbtnSel = (LinkButton)e.Row.Cells[(int) Constant.gridViewIndexSubcon.linkSelect].Controls[0];
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
                errorHandlers.Module = "Subcon";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }

        protected void ibtnListAll_Click(object sender, ImageClickEventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToExcelTypeID.SubCon.ToString() + ".xls";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToExcelContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToExcelTypeID.SubCon));
        }

        protected void ibtnListAllPDF_Click(object sender, ImageClickEventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToPDFTypeID.SubCon.ToString() + ".pdf";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToPDFContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToPDFTypeID.SubCon));
        }

        protected void ddlPagingNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvSubCon.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            subConPresenter = new SubConPresenter(this);
            subConPresenter.SearchData();
        }

        protected void gvSubCon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSubCon.PageIndex = e.NewPageIndex;

            gvSubCon.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            subConPresenter = new SubConPresenter(this);
            subConPresenter.SearchData();
        }
        #endregion

        #region interface

        public void DataBindings()
        {
            subConPresenter = new SubConPresenter(this);
            subConPresenter.SearchData();

        }
        public void SaveData()
        {
            try
            {
                UserPresenter userPresenter = new UserPresenter();
                sequencePresenter = new SequencePresenter();
                subConPresenter = new SubConPresenter();
                Subcons subcons = new Subcons();

                subcons.Company = txtCompany.Text.Trim();
                subcons.SubconCode = sequencePresenter.GetNextSequence("SubconCode").ToString();
                subcons.Address = txtAddress.Text;
                subcons.Remarks = txtRemarks.Text;
                subcons.Initial = txtInitial.Text.Trim(); 
                subcons.Person = txtPerson.Text.Trim();
                subcons.Telephone = txtTel.Text.Trim();
                subcons.Mobile = txtHP.Text.Trim();
                subcons.Fax = txtFax.Text;
                subcons.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                subcons.CreatedDate = DateTime.Now;
                subcons.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                subcons.UpdatedDate = DateTime.Now;
                subcons.Passes1 = txtPasses1.Text.Trim();
                subcons.Passes2 = txtPasses2.Text.Trim();
                if (!String.IsNullOrEmpty(txtExpiry1.Text.Trim()))
                {
                    subcons.Expiry1 = UtilityController.StringToDate(txtExpiry1.Text.Trim());
                }

                if (!String.IsNullOrEmpty(txtExpiry2.Text.Trim()))
                {
                    subcons.Expiry2 = UtilityController.StringToDate(txtExpiry2.Text.Trim());
                }

                lblMessage.Text = subConPresenter.SaveData(subcons);

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Subcon";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }


        }
        public void SearchData()
        {
            try
            {
                Subcons subcons = new Subcons();
                SubConPresenter subConPresenter = new SubConPresenter();
                switch (ddlCategory.SelectedValue)
                {
                    case "Company":
                        subcons.Company = this.txtSearch.Text.Trim();
                        break;
                    case "Initial":
                        subcons.Initial = this.txtSearch.Text.Trim();
                        break;
                    case "Person":
                        subcons.Person = this.txtSearch.Text.Trim();
                        break;
                    case "HP":
                        subcons.Mobile = this.txtSearch.Text.Trim();
                        break;
                    case "Tel":
                        subcons.Telephone = this.txtSearch.Text.Trim();
                        break;
                    case "Fax":
                        subcons.Fax = this.txtSearch.Text.Trim();
                        break;
                    case "Address":
                        subcons.Address = this.txtSearch.Text.Trim();
                        break;

                }
                gvSubCon.DataSource = subConPresenter.SearchData(subcons);
                gvSubCon.DataBind();

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Subcon";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }
        public void GetData(String loginID)
        {
            subConPresenter = new SubConPresenter();
            DisplayData(subConPresenter.GetUpdateData(loginID));
        }
        public void UpdateData()
        {
            try
            {

                UserPresenter userPresenter = new UserPresenter();
                subConPresenter = new SubConPresenter();
                Subcons subcons = new Subcons();

                subcons.SubconCode = txtEditSubconCode.Text.Trim();
                subcons.Company = txtEditCompany.Text;
                subcons.Initial = txtEditInitial.Text;
                subcons.Person = txtEditPerson.Text;
                subcons.Telephone = txtEditTel.Text.Trim();
                subcons.Mobile = txtEditHP.Text.Trim();
                subcons.Fax = txtEditFax.Text.Trim();
                subcons.Address = txtEditAddress.Text.Trim();
                subcons.Remarks = txtEditRemarks.Text.Trim();
                subcons.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                subcons.CreatedDate = DateTime.Now;
                subcons.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                subcons.UpdatedDate = DateTime.Now;
                subcons.Passes1 = txtEditPasses1.Text;
                subcons.Passes2 = txtEditPasses2.Text;
                if (!String.IsNullOrEmpty(txtEditExpiry1.Text.Trim()))
                {
                    subcons.Expiry1 = UtilityController.StringToDate(txtEditExpiry1.Text.Trim());
                }

                if (!String.IsNullOrEmpty(txtEditExpiry2.Text.Trim()))
                {
                    subcons.Expiry2 = UtilityController.StringToDate(txtEditExpiry2.Text.Trim());
                }
                this.lblEditMessage.Text = subConPresenter.UpdateData(subcons);

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Subcon";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }
        public void DeleteData()
        {
            try
            {

                UserPresenter userPresenter = new UserPresenter();
                subConPresenter = new SubConPresenter();
                Subcons subcons = new Subcons();

                 subcons.SubconCode = txtEditSubconCode.Text.Trim();
                subcons.Company = txtEditCompany.Text;
                subcons.Initial = txtEditInitial.Text;
                subcons.Person = txtEditPerson.Text;
                subcons.Telephone = txtEditTel.Text.Trim();
                subcons.Mobile = txtEditHP.Text.Trim();
                subcons.Fax = txtEditFax.Text.Trim();
                subcons.Address = txtEditAddress.Text.Trim();
                subcons.Remarks = txtEditRemarks.Text.Trim();
                subcons.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                subcons.CreatedDate = DateTime.Now;
                subcons.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                subcons.UpdatedDate = DateTime.Now;
                subcons.Passes1 = txtEditPasses1.Text;
                subcons.Passes2 = txtEditPasses2.Text;
                if (!String.IsNullOrEmpty(txtEditExpiry1.Text.Trim()))
                {
                    subcons.Expiry1 = UtilityController.StringToDate(txtEditExpiry1.Text.Trim());
                }
                else
                {
                    subcons.Expiry1 = UtilityController.StringToDate(Constant.MinimumDate);
                }

                if (!String.IsNullOrEmpty(txtEditExpiry2.Text.Trim()))
                {
                    subcons.Expiry2 = UtilityController.StringToDate(txtEditExpiry2.Text.Trim());
                }
                else
                {
                    subcons.Expiry2 = UtilityController.StringToDate(Constant.MinimumDate);
                }
                this.lblMessage.Text = subConPresenter.DeleteData(subcons);

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Subcon";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }


        }
        public void ResignData()
        {
            try
            {
                //staffPresenter = new StaffPresenter();
                //Staffs staffs = new Staffs();

                //staffs.AccessLevelID = new Guid(ddlEditAccessLevel.SelectedValue);
                //staffs.Address = txtEditAddress.Text.Trim();
                //staffs.NRIC = txtEditNRIC.Text.Trim();
                //staffs.DOB = txtEditDOB.Text.Trim();
                //staffs.Contact = txtEditContact.Text.Trim();
                //staffs.CountryID = new Guid(ddlEditCountry.SelectedValue);
                //staffs.LoginID = txtEditName.Text;
                //staffs.Password = txtEditRePassword.Text.Trim();
                //staffs.CreatedDate = DateTime.Now;
                //staffs.CreatedBy = new Guid(ddlEditAccessLevel.SelectedValue);
                //this.lblEditMessage.Text = staffPresenter.ResignData(staffs);

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Subcon";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }

        #endregion

        #region HouseKeeping
        public void ClearControl()
        {
            this.txtCompany.Text = string.Empty;
            this.txtInitial.Text = string.Empty;
            this.txtPerson.Text = string.Empty;
            this.txtTel.Text = string.Empty;
            this.txtHP.Text = string.Empty;
            this.txtFax.Text = string.Empty;
            this.txtExpiry1.Text = string.Empty;
            this.txtExpiry2.Text = string.Empty;
            this.txtPasses1.Text = string.Empty;
            this.txtPasses2.Text = string.Empty;
            txtSearch.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtRemarks.Text = string.Empty;

        }

        public void DisplayData(Subcons subcons)
        {
            try
            {
                this.txtEditCompany.Text = subcons.Company;
                this.txtEditAddress.Text = subcons.Address;
                this.txtEditRemarks.Text = subcons.Remarks;
                this.txtEditSubconCode.Text = subcons.SubconCode;
                this.txtEditInitial.Text = subcons.Initial;
                this.txtEditPerson.Text = subcons.Person;
                this.txtEditTel.Text = subcons.Telephone;
                this.txtEditHP.Text = subcons.Mobile;
                this.txtEditFax.Text = subcons.Fax;
                this.txtEditAddress.Text = subcons.Address;
                this.txtEditRemarks.Text = subcons.Remarks;
                this.txtEditPasses1.Text = subcons.Passes1;
                this.txtEditPasses2.Text = subcons.Passes2;
                if (DateTime.MinValue != subcons.Expiry1)
                {
                    this.txtEditExpiry1.Text = subcons.Expiry1.ToString(Properties.WebResources.dateformat);
                }
                else
                {
                    this.txtEditExpiry1.Text = string.Empty;
                }
                if (DateTime.MinValue != subcons.Expiry2)
                {

                    this.txtEditExpiry2.Text = subcons.Expiry2.ToString(Properties.WebResources.dateformat);
                }
                else
                {
                    this.txtEditExpiry2.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Subcon";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }

        #endregion







    }
}