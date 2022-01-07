using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//WOC
using Woc.Book.Staff.Presenter;
using Woc.Book.Staff.BusinessEntity;
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
    public partial class Staff : System.Web.UI.Page, IRegistrationPresenter
    {
        #region Declaration
        AccessLevelPresenter accessLevelPresenter;
        StaffPresenter staffPresenter;
        ExportToFilePresenter exportToFilePresenter;

        #endregion

        #region ControlEvents
           protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    staffPresenter = new StaffPresenter(this);
                    staffPresenter.DataBindings();
                }

            }

            catch(Exception ex)
            
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Staff";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }

              
           }
           protected void btnAdd_Click(object sender, EventArgs e)
           {
              try
               {
                   staffPresenter = new StaffPresenter(this);
                   staffPresenter.SaveData();
                   if (!lblMessage.Text.Contains("unsuccessfully"))
                   {
                       staffPresenter = new StaffPresenter(this);
                       staffPresenter.ClearControl();
                   }

                }

            catch(Exception ex)
            
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source;
                errorHandlers.Module = ex.TargetSite.Module.ToString();
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
                lblSystemError.Text = "System Error: " + ex.Message.ToString();
            }
           }
           protected void btnSearch_Click(object sender, EventArgs e)
           {
                gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
                staffPresenter = new StaffPresenter(this);
                staffPresenter.SearchData();
           }

           protected void btnResigned_Click(object sender, EventArgs e)
           {
               staffPresenter = new StaffPresenter(this);
               staffPresenter.ResignData();
           }

           protected void btnConfirm_Click(object sender, EventArgs e)
           {
               staffPresenter = new StaffPresenter(this);
               staffPresenter.UpdateData();
           }

           protected void btnDelete_Click(object sender, EventArgs e)
           {
               staffPresenter = new StaffPresenter(this);
               staffPresenter.DeleteData();
           }

           protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
           {
               try
               {
                   int row = Convert.ToInt16(e.CommandArgument);

                   if (e.CommandName.Equals("Select"))
                   {
                       string loginID = gv.DataKeys[row].Value.ToString();
                       staffPresenter = new StaffPresenter(this);
                       staffPresenter.GetData(loginID);
                   }
               }

                catch(Exception ex)
            
                {
                    ErrorHandlers errorHandlers = new ErrorHandlers();
                    ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                    errorHandlers.StackTrace = ex.StackTrace.ToString();
                    errorHandlers.Message = ex.Message.ToString();
                    errorHandlers.Source = ex.Source.ToString();
                    errorHandlers.Module = "Staff";
                    errorHandlers.UserID = User.Identity.Name;
                    errorHandlerPresenter.SaveData(errorHandlers);
                    lblSystemError.Text = "System Error: " + ex.Message.ToString();
                }

           }

           protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
           {
               gv.PageIndex = e.NewPageIndex;

               gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
               staffPresenter = new StaffPresenter(this);
               staffPresenter.SearchData();

           }

           protected void ddlPagingNumber_SelectedIndexChanged(object sender, EventArgs e)
           {
               gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
               staffPresenter = new StaffPresenter(this);
               staffPresenter.SearchData();
           }

           protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
           {

               try
               {

                   if (e.Row.RowType == DataControlRowType.DataRow)
                   {
                       LinkButton lbtnSel = (LinkButton)e.Row.Cells[(int)Constant.gridViewIndexStaff.linkSelect].Controls[0];
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

           protected void ibtnListAllPDF_Click(object sender, ImageClickEventArgs e)
           {
               exportToFilePresenter = new ExportToFilePresenter();
               GridView gvExportToExcel = new GridView();
               String fileName = Constant.ExportToPDFTypeID.Staff.ToString() + ".pdf";
               exportToFilePresenter.ExportToFile(fileName, Constant.ExportToPDFContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToPDFTypeID.Staff));
           }

           protected void ibtnListAll_Click(object sender, ImageClickEventArgs e)
           {
               exportToFilePresenter = new ExportToFilePresenter();
               GridView gvExportToExcel = new GridView();
               String fileName = Constant.ExportToExcelTypeID.Staff.ToString() + ".xls";
               exportToFilePresenter.ExportToFile(fileName, Constant.ExportToExcelContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToExcelTypeID.Staff));
           }
        #endregion

        #region interface

           public void DataBindings()
            {
                try
                {
                    cboCountry.LoadDataWithDefaultCountry();
                    cboEditCountry.LoadDataWithDefaultCountry();                    

                    List<AccessLevels> ListAccessLevel = new List<AccessLevels>();
                    accessLevelPresenter = new AccessLevelPresenter();
                    ListAccessLevel = accessLevelPresenter.GetAccessLevel();

                    ddlEditAccessLevel.Items.Clear();
                    ddlEditAccessLevel.DataSource = ListAccessLevel;
                    ddlEditAccessLevel.DataValueField = "AccessLevelID";
                    ddlEditAccessLevel.DataTextField = "AccessLevel";
                    ddlEditAccessLevel.DataBind();
                    ddlEditAccessLevel.Items.Insert(0, "Select");
                    ddlEditAccessLevel.SelectedIndex = 0;

                    ddlAccessLevel.Items.Clear();
                    ddlAccessLevel.DataSource = ListAccessLevel;
                    ddlAccessLevel.DataValueField = "AccessLevelID";
                    ddlAccessLevel.DataTextField = "AccessLevel";
                    ddlAccessLevel.DataBind();
                    ddlAccessLevel.Items.Insert(0, "Select");
                    ddlAccessLevel.SelectedIndex = 0;
                    
                    staffPresenter = new StaffPresenter(this);
                    staffPresenter.SearchData();

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
                    lblSystemError.Text = "System Error: " + ex.Message.ToString();
                }

            }
           public void SaveData()
           {
               try
               {
                   staffPresenter = new StaffPresenter();
                   Staffs staffs = new Staffs();

                   staffs.AccessLevelID = new Guid(ddlAccessLevel.SelectedValue);
                   staffs.Address1 = txtAddress1.Text.Trim();
                   staffs.Address2 = txtAddress2.Text.Trim();
                   staffs.Address3 = txtAddress3.Text.Trim();
                   staffs.NRIC = txtNRIC.Text.Trim();
                   staffs.DOB = txtDOB.Text.Trim();
                   staffs.Contact = txtContact.Text.Trim();
                   staffs.CountryID = new Guid(cboCountry.SelectedValue.ToString());
                   staffs.LoginID = txtName.Text;

                   if (txtPassword.Text == txtRePassword.Text)
                   {
                       staffs.TextBoxPassword = txtPassword.Text.Trim();
                   }
                   else
                   {
                       lblMessage.Text = Woc.Book.Staff.Constant.Constant.MessageReEnteredNotMatch;
                       return;
                   }
                   
                   staffs.CreatedDate = DateTime.Now;
                   staffs.CreatedBy = new Guid(ddlAccessLevel.SelectedValue);
                   lblMessage.Text = staffPresenter.SaveData(staffs);
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
                   lblSystemError.Text = "System Error: " + ex.Message.ToString();
               }


           }
           public void SearchData()
           {
               try
               {
                     Staffs staffs = new Staffs();
                     staffPresenter = new StaffPresenter();
                     switch (ddlCategory.SelectedValue)
                     {
                         case "LoginID":
                             staffs.LoginID = this.txtSearch.Text.Trim();
                             break;
                         case "Address":
                             staffs.Address1 = this.txtSearch.Text.Trim();
                             break;
                         case "FIN":
                             staffs.NRIC = this.txtSearch.Text.Trim();
                             break;
                         case "DOB":
                             staffs.DOB = this.txtSearch.Text.Trim();
                             break;
                         case "Contact":
                             staffs.Contact = this.txtSearch.Text.Trim();
                             break;

                         case "Select":
                             break;
                     
                     }
                     gv.DataSource =  staffPresenter.SearchData(staffs);
                     gv.DataBind();

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
                   lblSystemError.Text = "System Error: " + ex.Message.ToString();
               }
           
           }
           public void GetData(String loginID)
           {
               staffPresenter = new StaffPresenter();
               DisplayData(staffPresenter.GetUpdateData(loginID));
           }
           public void UpdateData()
           {
               try
               {
                   staffPresenter = new StaffPresenter();
                   Staffs staffs = new Staffs();

                   staffs.AccessLevelID = new Guid(ddlEditAccessLevel.SelectedValue);
                   staffs.Address1 = txtEditAddress1.Text.Trim();
                   staffs.Address2 = txtEditAddress2.Text.Trim();
                   staffs.Address3 = txtEditAddress3.Text.Trim();
                   staffs.NRIC = txtEditNRIC.Text.Trim();
                   staffs.DOB = txtEditDOB.Text.Trim();
                   staffs.Contact = txtEditContact.Text.Trim();
                   staffs.CountryID = new Guid(cboEditCountry.SelectedValue.ToString());
                   staffs.LoginID = txtEditName.Text;

                   if (txtEditPassword.Text.Trim() != String.Empty && txtEditRePassword.Text.Trim() !=  String.Empty)
                   {
                        staffs.TextBoxPassword = txtEditPassword.Text.Trim();
                   }

                   staffs.CreatedDate = DateTime.Now;
                   staffs.CreatedBy = new Guid(ddlEditAccessLevel.SelectedValue);
                   this.lblEditMessage.Text = staffPresenter.UpdateData(staffs);

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
                   lblSystemError.Text = "System Error: " + ex.Message.ToString();
               }

           }
           public void DeleteData()
           {
               try 
               {
                   staffPresenter = new StaffPresenter();
                   Staffs staffs = new Staffs();

                   staffs.AccessLevelID = new Guid(ddlEditAccessLevel.SelectedValue);
                   staffs.Address1 = txtEditAddress1.Text.Trim();
                   staffs.Address2 = txtEditAddress2.Text.Trim();
                   staffs.Address3 = txtEditAddress3.Text.Trim();
                   staffs.NRIC = txtEditNRIC.Text.Trim();
                   staffs.DOB = txtEditDOB.Text.Trim();
                   staffs.Contact = txtEditContact.Text.Trim();
                   staffs.CountryID = new Guid(cboEditCountry.SelectedValue.ToString());
                   staffs.LoginID = txtEditName.Text;
                   staffs.TextBoxPassword = txtEditRePassword.Text.Trim();
                   staffs.CreatedDate = DateTime.Now;
                   staffs.CreatedBy = new Guid(ddlEditAccessLevel.SelectedValue);
                   this.lblEditMessage.Text = staffPresenter.DeleteData(staffs);
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
           public void ResignData()
           {
               try
               { 
                   staffPresenter = new StaffPresenter();
                   Staffs staffs = new Staffs();

                   staffs.AccessLevelID = new Guid(ddlEditAccessLevel.SelectedValue);
                   staffs.Address1 = txtEditAddress1.Text.Trim();
                   staffs.NRIC = txtEditNRIC.Text.Trim();
                   staffs.DOB = txtEditDOB.Text.Trim();
                   staffs.Contact = txtEditContact.Text.Trim();
                   staffs.CountryID = new Guid(cboEditCountry.SelectedValue.ToString());
                   staffs.LoginID = txtEditName.Text;
                   staffs.TextBoxPassword = txtEditRePassword.Text.Trim();
                   staffs.CreatedDate = DateTime.Now;
                   staffs.CreatedBy = new Guid(ddlEditAccessLevel.SelectedValue);
                   this.lblEditMessage.Text = staffPresenter.ResignData(staffs);

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

        #region HouseKeeping
           public void ClearControl()
           {
               txtAddress1.Text = String.Empty;
               txtAddress2.Text = String.Empty;
               txtAddress3.Text = String.Empty;
               txtContact.Text = String.Empty;
               txtDOB.Text = String.Empty;
               txtName.Text = String.Empty;
               txtNRIC.Text = String.Empty;
               txtPassword.Text = String.Empty;
               txtRePassword.Text = String.Empty;
               ddlAccessLevel.SelectedIndex = 0;
               cboCountry.LoadDataWithDefaultCountry();
           }

           public void DisplayData(Staffs staffs)
           {
               try
               {
                ddlEditAccessLevel.SelectedValue = ddlEditAccessLevel.Items.FindByValue(staffs.AccessLevelID.ToString()).Value; 
                txtEditAddress1.Text =  staffs.Address1;
                txtEditAddress2.Text = staffs.Address2;
                txtEditAddress3.Text = staffs.Address3;
                txtEditNRIC.Text = staffs.NRIC;
                txtEditDOB.Text = staffs.DOB;
                txtEditContact.Text = staffs.Contact;
                cboEditCountry.FindItemByValue(staffs.CountryID.ToString());
                txtEditName.Text = staffs.LoginID;
                hdnPassword.Value = staffs.TextBoxPassword;
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
                   lblSystemError.Text = "System Error: " + ex.Message.ToString();
               }

           }

        #endregion
        
    }
}