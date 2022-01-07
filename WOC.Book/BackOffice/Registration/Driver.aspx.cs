using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//WOC
using Woc.Book.Driver.Presenter;
using Woc.Book.Driver.BusinessEntity;
using Woc.Book.Base.Constant;
using Woc.Book.Base.Presenter; 
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base;

//Bus
using Woc.Book.Bus.Presenter;
using Woc.Book.Bus.BusinessEntity;

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
    public partial class Driver : System.Web.UI.Page, IRegistrationPresenter
    {
        #region Declaration
        CountryPresenter countryPresenter;
        DriverPresenter driverPresenter;
        SequencePresenter sequencePresenter;
        ExportToFilePresenter exportToFilePresenter;
        BusPresenter busPresenter; 
        #endregion

        #region ControlEvents
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    driverPresenter = new DriverPresenter(this);
                    driverPresenter.DataBindings();
                }

            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Driver";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                driverPresenter = new DriverPresenter(this);
                driverPresenter.SaveData();
                if (lblMessage.Text.Contains(Constant.MessageSaved))
                {
                    driverPresenter = new DriverPresenter(this);
                    driverPresenter.ClearControl();
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
            driverPresenter = new DriverPresenter(this);
            driverPresenter.SearchData();
        }

        protected void btnResigned_Click(object sender, EventArgs e)
        {
            driverPresenter = new DriverPresenter(this);
            driverPresenter.ResignData();
            driverPresenter = new DriverPresenter(this);
            driverPresenter.ClearControl();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            driverPresenter = new DriverPresenter(this);
            driverPresenter.UpdateData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            driverPresenter = new DriverPresenter(this);
            driverPresenter.DeleteData();
            driverPresenter = new DriverPresenter(this);
            driverPresenter.ClearControl();
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row = Convert.ToInt16(e.CommandArgument);

                if (e.CommandName.Equals("Select"))
                {
                    string driverCode = gv.DataKeys[row].Value.ToString();
                    driverPresenter = new DriverPresenter(this);
                    driverPresenter.GetData(driverCode);
                }
            }

            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Driver";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }

        protected void ibtnListAll_Click(object sender, ImageClickEventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToExcelTypeID.Driver.ToString() + ".xls";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToExcelContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToExcelTypeID.Driver));
        }

        protected void ibtnListAllPDF_Click(object sender, ImageClickEventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToPDFTypeID.Driver.ToString() + ".pdf";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToPDFContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToPDFTypeID.Driver));
        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;

            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            driverPresenter = new DriverPresenter(this);
            driverPresenter.SearchData();
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbtnSel = (LinkButton)e.Row.Cells[(int)Constant.gridViewIndexDriver.linkSelect].Controls[0];
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
                errorHandlers.Module = "Driver";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }

        protected void ddlPagingNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            driverPresenter = new DriverPresenter(this);
            driverPresenter.SearchData();
        }
        #endregion

        #region interface

        public void DataBindings()
        {
            try
            {
                List<Countries> ListCountry = new List<Countries>();
                countryPresenter = new CountryPresenter();
                ListCountry = countryPresenter.GetCountryDropdownInfo();
                cboCountry.Items.Clear();
                cboCountry.DataSource = ListCountry;
                cboCountry.DataValueField = "CountryID";
                cboCountry.DataTextField = "Country";
                cboCountry.DataBind();
                cboCountry.SelectedItem.Selected = false;
                cboCountry.Items.FindItemByValue(Convert.ToString(countryPresenter.GetDefaultCountryID())).Selected = true;

                cboEditCountry.Items.Clear();
                cboEditCountry.DataSource = ListCountry;
                cboEditCountry.DataValueField = "CountryID";
                cboEditCountry.DataTextField = "Country";
                cboEditCountry.DataBind();
                
                List<Bus> ListBus = new List<Bus>();
                busPresenter = new BusPresenter();
               
                ddlBusNumber.Items.Clear();
                ddlBusNumber.DataSource = busPresenter.GetData();
                ddlBusNumber.DataValueField = "BusNo";
                ddlBusNumber.DataTextField = "BusNo";
                ddlBusNumber.DataBind();
                ddlBusNumber.Items.Insert(0, "Select");
                ddlBusNumber.SelectedIndex = 0;

                ddlEditBusNumber.Items.Clear();
                ddlEditBusNumber.DataSource = busPresenter.GetData();
                ddlEditBusNumber.DataValueField = "BusNo";
                ddlEditBusNumber.DataTextField = "BusNo";
                ddlEditBusNumber.DataBind();
                ddlEditBusNumber.Items.Insert(0, "Select");
                ddlEditBusNumber.SelectedIndex = 0;

                driverPresenter = new DriverPresenter(this);
                driverPresenter.SearchData();
                btnDelete.Attributes.Add("onclick", "SelectTab(2);");
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace  = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Driver";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }
        public void SaveData()
        {
            try
            {
                UserPresenter userPresenter = new UserPresenter();
                driverPresenter = new DriverPresenter();
                sequencePresenter = new SequencePresenter();
                Drivers drivers = new Drivers();

                drivers.DriverCode = sequencePresenter.GetNextSequence("DriverCode").ToString();
                drivers.DriverName = txtName.Text.Trim();
                drivers.FIN = txtFIN.Text.Trim();
                drivers.Address1 = txtAddress1.Text.Trim();
                drivers.Address2 = txtAddress2.Text.Trim();
                drivers.Address3 = txtAddress3.Text.Trim();
                drivers.Contact = txtContact.Text;
                if (!String.IsNullOrEmpty(txtDateJoin.Text.Trim()))
                {
                    drivers.DateJoin = UtilityController.StringToDate(txtDateJoin.Text.Trim());
                }
                
                drivers.DOB = txtDOB.Text.Trim();

                if (cboCountry.SelectedValue != "Select")
                {
                    drivers.CountryID = new Guid(cboCountry.SelectedValue);
                }
                drivers.BusNo = this.ddlBusNumber.SelectedValue;
                drivers.Passes1 = txtPasses1.Text;
                drivers.Passes2 = txtPasses2.Text;
                drivers.Passes3 = txtPasses3.Text;
                if (!String.IsNullOrEmpty(txtExpiry1.Text.Trim()))
                {
                    drivers.Expiry1 = UtilityController.StringToDate(txtExpiry1.Text.Trim());
                }

                if (!String.IsNullOrEmpty(txtExpiry2.Text.Trim()))
                {
                    drivers.Expiry2 = UtilityController.StringToDate(txtExpiry2.Text.Trim());
                }

                if (!String.IsNullOrEmpty(txtExpiry3.Text.Trim()))
                {
                    drivers.Expiry3 = UtilityController.StringToDate(txtExpiry3.Text.Trim());
                }
                drivers.Resigned = false;
                drivers.ResignedDate = DateTime.Now; 

                drivers.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                drivers.CreatedDate = DateTime.Now;
                drivers.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                drivers.UpdatedDate = DateTime.Now;
                this.lblMessage.Text = driverPresenter.SaveData(drivers);
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Driver";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }


        }
        public void SearchData()
        {
            try
            {
                Drivers drivers = new Drivers();
                DriverPresenter driverPresenter = new DriverPresenter();
                switch (ddlCategory.SelectedValue)
                {
                    case "DriverName":
                        drivers.DriverName = this.txtSearch.Text.Trim();
                        break;
                    case "Address":
                        drivers.Address1 = this.txtSearch.Text.Trim();
                        break;
                    case "FIN":
                        drivers.FIN = this.txtSearch.Text.Trim();
                        break;
                    case "DOB":
                        drivers.DOB = this.txtSearch.Text.Trim();
                        break;
                    case "Contact":
                        drivers.Contact = this.txtSearch.Text.Trim();
                        break;

                }
                gv.DataSource = driverPresenter.SearchData(drivers);
                gv.DataBind();

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Driver";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }
        public void GetData(String loginID)
        {
            driverPresenter = new DriverPresenter();

            DisplayData(driverPresenter.GetUpdateData(loginID));
        }
        public void UpdateData()
        {
            try
            {

                UserPresenter userPresenter = new UserPresenter();
                driverPresenter = new DriverPresenter();
                sequencePresenter = new SequencePresenter();
                Drivers drivers = new Drivers();

                drivers.DriverCode = txtEditCode.Text;
                drivers.DriverName = txtEditName.Text.Trim();
                drivers.FIN = txtEditFIN.Text.Trim();
                drivers.Address1 = txtEditAddress1.Text.Trim();
                drivers.Address2 = txtEditAddress2.Text.Trim();
                drivers.Address3 = txtEditAddress3.Text.Trim();
                drivers.Contact = txtEditContact.Text;
                if (!String.IsNullOrEmpty(txtEditDateJoin.Text.Trim()))
                {
                    drivers.DateJoin = UtilityController.StringToDate(txtEditDateJoin.Text.Trim());
                }
                else
                {
                    drivers.DateJoin = UtilityController.StringToDate(Constant.MinimumDate);
                }

                drivers.DOB = txtEditDOB.Text.Trim();

                if (cboEditCountry.SelectedValue != "Select")
                {
                    drivers.CountryID = new Guid(cboEditCountry.SelectedValue);
                }
                drivers.BusNo = this.ddlEditBusNumber.SelectedValue;
                drivers.Passes1 = txtEditPasses1.Text;
                drivers.Passes2 = txtEditPasses2.Text;
                drivers.Passes3 = txtEditPasses3.Text;
                if (!String.IsNullOrEmpty(txtEditExpiry1.Text.Trim()))
                {
                    drivers.Expiry1 = UtilityController.StringToDate(txtEditExpiry1.Text.Trim());
                }
                

                if (!String.IsNullOrEmpty(txtEditExpiry2.Text.Trim()))
                {
                    drivers.Expiry2 = UtilityController.StringToDate(txtEditExpiry2.Text.Trim());
                }
                
                if (!String.IsNullOrEmpty(txtEditExpiry3.Text.Trim()))
                {
                    drivers.Expiry3 = UtilityController.StringToDate(txtEditExpiry3.Text.Trim());
                }
                
                if (!String.IsNullOrEmpty(this.txtResignedDate.Text.Trim()))
                {
                    drivers.ResignedDate = UtilityController.StringToDate(txtResignedDate.Text.Trim());
                }
               
                if (rdlResigned.SelectedValue == "Yes")
                {
                    drivers.Resigned = true;
                }
                else
                {
                    drivers.Resigned= false;
                }
                drivers.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                drivers.CreatedDate = DateTime.Now;
                drivers.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                drivers.UpdatedDate = DateTime.Now;
                this.lblEditMessage.Text = driverPresenter.UpdateData(drivers);
                

            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Driver";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }
        public void DeleteData()
        {
            try
            {

                UserPresenter userPresenter = new UserPresenter();
                driverPresenter = new DriverPresenter();
                sequencePresenter = new SequencePresenter();
                Drivers drivers = new Drivers();

                drivers.DriverCode = txtEditCode.Text;
                drivers.DriverName = txtEditName.Text.Trim();
                drivers.FIN = txtEditFIN.Text.Trim();
                drivers.Address1 = txtEditAddress1.Text.Trim();
                drivers.Address2 = txtEditAddress2.Text.Trim();
                drivers.Address3 = txtEditAddress3.Text.Trim();
                drivers.Contact = txtEditContact.Text;
                if (!String.IsNullOrEmpty(txtEditDateJoin.Text.Trim()))
                {
                    drivers.DateJoin = UtilityController.StringToDate(txtEditDateJoin.Text.Trim());
                }
                else
                {
                    drivers.DateJoin = UtilityController.StringToDate(Constant.MinimumDate);
                }
                drivers.DOB = txtDOB.Text.Trim();

                if (cboEditCountry.SelectedValue != "Select")
                {
                    drivers.CountryID = new Guid(cboEditCountry.SelectedValue);
                }
                drivers.BusNo = this.ddlEditBusNumber.SelectedValue;
                drivers.Passes1 = txtEditPasses1.Text;
                drivers.Passes2 = txtEditPasses2.Text;
                drivers.Passes3 = txtEditPasses3.Text;
                if (!String.IsNullOrEmpty(txtEditExpiry1.Text.Trim()))
                {
                    drivers.Expiry1 = UtilityController.StringToDate(txtEditExpiry1.Text.Trim());
                }
                

                if (!String.IsNullOrEmpty(txtEditExpiry2.Text.Trim()))
                {
                    drivers.Expiry2 = UtilityController.StringToDate(txtEditExpiry2.Text.Trim());
                }
                
                if (!String.IsNullOrEmpty(txtEditExpiry3.Text.Trim()))
                {
                    drivers.Expiry3 = UtilityController.StringToDate(txtEditExpiry3.Text.Trim());
                }
                
                if (!String.IsNullOrEmpty(this.txtResignedDate.Text.Trim()))
                {
                    drivers.ResignedDate = UtilityController.StringToDate(txtResignedDate.Text.Trim());
                }
                

                if (rdlResigned.SelectedValue == "Yes")
                {
                    drivers.Resigned = true;
                }
                else
                {
                    drivers.Resigned = false;
                }
                drivers.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                drivers.CreatedDate = DateTime.Now;
                drivers.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                drivers.UpdatedDate = DateTime.Now;
                this.lblMessage.Text = driverPresenter.DeleteData(drivers);
                driverPresenter = new DriverPresenter(this);
                driverPresenter.SearchData();
                
            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Driver";
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
                //staffs.CountryID = new Guid(cboEditCountry.SelectedValue);
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
                errorHandlers.Module = "Driver";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }

        #endregion

        #region HouseKeeping
        public void ClearControl()
        {
            txtName.Text = string.Empty;
            txtFIN.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtDateJoin.Text = string.Empty;
            txtDOB.Text = string.Empty;
            cboCountry.SelectedIndex = 0;
            txtAddress1.Text = string.Empty;
            txtAddress2.Text = string.Empty;
            txtAddress3.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtDateJoin.Text = string.Empty;
            cboCountry.SelectedIndex = 0;
            ddlBusNumber.SelectedIndex = 0;
            txtPasses1.Text = string.Empty;
            txtPasses2.Text = string.Empty;
            txtPasses3.Text = string.Empty;
            txtExpiry1.Text = string.Empty;
            txtExpiry2.Text = string.Empty;
            txtExpiry3.Text = string.Empty;

            //Update

            txtEditCode.Text = string.Empty;
            txtEditName.Text = string.Empty;
            txtEditFIN.Text = string.Empty;
            txtEditAddress1.Text = string.Empty;
            txtEditAddress2.Text = string.Empty;
            txtEditAddress3.Text = string.Empty;
            txtEditContact.Text = string.Empty;
            txtEditDateJoin.Text = string.Empty;
            txtEditDOB.Text = string.Empty;
            cboEditCountry.SelectedIndex = 0;
            ddlEditBusNumber.SelectedIndex = 0;
            txtEditPasses1.Text = string.Empty;
            txtEditPasses2.Text = string.Empty;
            txtEditPasses3.Text = string.Empty;
            txtEditExpiry1.Text = string.Empty;
            txtEditExpiry2.Text = string.Empty;
            txtEditExpiry3.Text = string.Empty;
            txtResignedDate.Text = string.Empty;

        }

        public void DisplayData(Drivers drivers)
        {
            try
            {

                txtEditCode.Text = drivers.DriverCode;
                txtEditName.Text = drivers.DriverName;
                txtEditFIN.Text = drivers.FIN;
                txtEditAddress1.Text = drivers.Address1;
                txtEditAddress2.Text = drivers.Address2;
                txtEditAddress3.Text = drivers.Address3;
                txtEditContact.Text = drivers.Contact;
                if (!String.IsNullOrEmpty(drivers.DateJoin.ToString()))
                {
                    txtEditDateJoin.Text = drivers.DateJoin.ToString(Properties.WebResources.dateformat); 
                }
                txtEditDOB.Text = drivers.DOB;
                cboEditCountry.SelectedItem.Selected = false;
                cboEditCountry.Items.FindItemByValue(drivers.CountryID.ToString()).Selected = true;
                ddlEditBusNumber.SelectedIndex = ddlEditBusNumber.Items.IndexOf(ddlEditBusNumber.Items.FindByText(drivers.BusNo));
                txtEditPasses1.Text = drivers.Passes1;
                txtEditPasses2.Text = drivers.Passes2;
                txtEditPasses3.Text = drivers.Passes3;
                if (DateTime.MinValue != drivers.Expiry1)
                {
                    this.txtEditExpiry1.Text =  drivers.Expiry1.ToString(Properties.WebResources.dateformat);
                }
                else
                {
                    this.txtEditExpiry1.Text = string.Empty;
                }
                if (DateTime.MinValue != drivers.Expiry2)
                {

                    this.txtEditExpiry2.Text = drivers.Expiry2.ToString(Properties.WebResources.dateformat); 
                }
                else
                {
                    this.txtEditExpiry2.Text = string.Empty;
                }
                if (DateTime.MinValue != drivers.Expiry3)
                {
                    this.txtEditExpiry3.Text = drivers.Expiry3.ToString(Properties.WebResources.dateformat);
                }
                else
                {
                    this.txtEditExpiry3.Text = string.Empty;
                }

                if (DateTime.MinValue != drivers.ResignedDate)
                {
                    this.txtResignedDate.Text = drivers.ResignedDate.ToString(Properties.WebResources.dateformat);
                }
                else
                {
                    this.txtResignedDate.Text = string.Empty;
                }


                if (drivers.Resigned)
                {
                    rdlResigned.SelectedIndex = 0;
                }
                else
                {
                    rdlResigned.SelectedIndex = 1;
                }
               


            }
            catch (Exception ex)
            {
                ErrorHandlers errorHandlers = new ErrorHandlers();
                ErrorHandlerPresenter errorHandlerPresenter = new ErrorHandlerPresenter();
                errorHandlers.StackTrace = ex.StackTrace.ToString();
                errorHandlers.Message = ex.Message.ToString();
                errorHandlers.Source = ex.Source.ToString();
                errorHandlers.Module = "Driver";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }

        }
        #endregion




        

       

       

        
    }
}