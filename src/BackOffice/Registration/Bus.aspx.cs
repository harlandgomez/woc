using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//WOC
using Woc.Book.Bus.Presenter;
using Woc.Book.Bus.BusinessEntity;
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
    public partial class Bus : System.Web.UI.Page,IRegistrationPresenter
    {

        #region Declaration
        
        BusPresenter busPresenter;
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
                    busPresenter = new BusPresenter(this);
                    busPresenter.DataBindings();
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
                busPresenter = new BusPresenter(this);
                busPresenter.SaveData();
                if (!lblMessage.Text.Contains("unsuccessfully"))
                {
                    busPresenter = new BusPresenter(this);
                    busPresenter.ClearControl();
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
            busPresenter = new BusPresenter(this);
            busPresenter.SearchData();
        }

        protected void btnResigned_Click(object sender, EventArgs e)
        {
            busPresenter = new BusPresenter(this);
            busPresenter.ResignData();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            busPresenter = new BusPresenter(this);
            busPresenter.UpdateData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            busPresenter = new BusPresenter(this);
            busPresenter.DeleteData();
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int row = Convert.ToInt16(e.CommandArgument);

                if (e.CommandName.Equals("Select"))
                {
                   
                    string busCode = gv.DataKeys[row].Value.ToString();
                    busPresenter = new BusPresenter(this);
                    busPresenter.GetData(busCode);
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
        
        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;

            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            busPresenter = new BusPresenter(this);
            busPresenter.SearchData();
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbtnSel = (LinkButton)e.Row.Cells[(int)Constant.gridViewIndexBus.linkSelect].Controls[0];
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
                errorHandlers.Module = "Bus";
                errorHandlers.UserID = User.Identity.Name;
                errorHandlerPresenter.SaveData(errorHandlers);
            }
        }

        protected void ibtnListAll_Click(object sender, ImageClickEventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToExcelTypeID.Bus.ToString() + ".xls";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToExcelContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToExcelTypeID.Bus));
        }

        protected void ibtnListAllPDF_Click(object sender, ImageClickEventArgs e)
        {
            exportToFilePresenter = new ExportToFilePresenter();
            GridView gvExportToExcel = new GridView();
            String fileName = Constant.ExportToPDFTypeID.Bus.ToString() + ".pdf";
            exportToFilePresenter.ExportToFile(fileName, Constant.ExportToPDFContentType, gvExportToExcel, Convert.ToInt32(Constant.ExportToPDFTypeID.Bus));
        }

        protected void ddlPagingNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            gv.PageSize = Convert.ToInt32(this.ddlPagingNumber.SelectedValue);
            busPresenter = new BusPresenter(this);
            busPresenter.SearchData();
        }

        protected void chkSubcon_CheckedChanged(object sender, EventArgs e)
        {
            cboSubcon.Enabled = chkSubcon.Checked;
        }

        protected void chkEditSubcon_CheckedChanged(object sender, EventArgs e)
        {
            cboEditSubcon.Enabled = chkEditSubcon.Checked;
        }
        #endregion

        #region interface

        public void DataBindings()
        {
            try
            {
                //chkSubcon.Attributes.Add("OnClick", "ShowHideTextbox('" + txtSubconInitial.ClientID + "', this.checked);");
                //chkEditSubcon.Attributes.Add("OnClick", "ShowHideTextbox('" + txtEditSubconInitial.ClientID + "', this.checked);"); 
                cboSubcon.Enabled = false;
                busPresenter = new BusPresenter(this);
                busPresenter.SearchData();
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

        public void SaveData()
        {
            try
            {
                UserPresenter userPresenter = new UserPresenter();
                busPresenter = new BusPresenter();
                sequencePresenter = new SequencePresenter();
                Buses buses = new Buses();
                buses.Brand = txtBrand.Text;
                buses.BusID =  new Guid();
                buses.BusCode = sequencePresenter.GetNextSequence("BusCode").ToString();
                buses.BusNo = txtBus1.Text.Trim() + txtBus2.Text.Trim() + txtBus3.Text.Trim();
                buses.BusNo1 = txtBus1.Text.Trim();
                buses.BusNo2 = txtBus2.Text.Trim();
                buses.BusNo3 = txtBus3.Text.Trim();
                buses.CompanyID = new Guid(cboCompany.SelectedValue.ToString());
                buses.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                buses.CreatedDate = DateTime.Now;
                buses.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                buses.UpdatedDate = DateTime.Now;
                buses.Parking = txtParking.Text;

                if (chkSubcon.Checked && cboSubcon.SelectedIndex > 0)
                {
                    buses.SubconID = new Guid(cboSubcon.SelectedValue.ToString());
                }

                if (String.IsNullOrEmpty(txtSeater.Text.Trim()))
                {
                     buses.Seater = 0;
                }
                else
                {
                     buses.Seater = Convert.ToInt32(txtSeater.Text.Trim());
                }
                buses.Type = rblType.SelectedValue;
                buses.Passes1 = txtPasses1.Text;
                buses.Passes2 = txtPasses2.Text;
                buses.Passes3 = txtPasses3.Text;
                if (!String.IsNullOrEmpty(txtExpiry1.Text.Trim()))
                {
                    buses.Expiry1 = UtilityController.StringToDate(txtExpiry1.Text.Trim());
                }
               
                if (!String.IsNullOrEmpty(txtExpiry2.Text.Trim()))
                {
                    buses.Expiry2 = UtilityController.StringToDate(txtExpiry2.Text.Trim());
                }
                
                if (!String.IsNullOrEmpty(txtExpiry3.Text.Trim()))
                {
                    buses.Expiry3 = UtilityController.StringToDate(txtExpiry3.Text.Trim());
                }
                buses.Scrapped = false;
                lblMessage.Text = busPresenter.SaveData(buses);

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

        public void SearchData()
        {
            try
            {
                Buses buses = new Buses();
                BusPresenter busPresenter = new BusPresenter();
                switch (ddlCategory.SelectedValue)
                {
                    case "BusNo":
                        buses.BusCode = this.txtSearch.Text.Trim();
                        break;
                    case "Seater":
                        buses.Seater = Convert.ToInt32(this.txtSearch.Text.Trim());
                        break;
                    case "Company":
                        buses.CompanyNameSearch = this.txtSearch.Text.Trim();
                        break;
                    case "Brand":
                        buses.Brand = this.txtSearch.Text.Trim();
                        break;
                    case "Year":
                        buses.Year = this.txtSearch.Text.Trim();
                        break;
                    case "Parking":
                        buses.Parking = this.txtSearch.Text.Trim();
                        break;
                }
                gv.DataSource = busPresenter.SearchData(buses);
                gv.DataBind();

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

        public void GetData(String loginID)
        {
            busPresenter = new BusPresenter();
            DisplayData(busPresenter.GetUpdateData(loginID));
        }

        public void UpdateData()
        {
            try
            {

                UserPresenter userPresenter = new UserPresenter();
                busPresenter = new BusPresenter();
                Buses buses = new Buses();
                buses.BusCode = txtBusCode.Text.Trim();
                buses.Brand = txtEditBrand.Text;
                buses.BusCode = txtBusCode.Text;
                buses.BusNo1 = txtEditBusNo1.Text.Trim();
                buses.BusNo2 = txtEditBusNo2.Text.Trim();
                buses.BusNo3 = txtEditBusNo3.Text.Trim();
                buses.BusNo = txtEditBusNo1.Text.Trim() + txtEditBusNo2.Text.Trim() + txtEditBusNo3.Text.Trim();
                buses.CompanyID = new Guid(cboEditCompany.SelectedValue.ToString());
                buses.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                buses.CreatedDate = DateTime.Now;
                buses.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                buses.UpdatedDate = DateTime.Now;
                buses.Parking = txtEditParking.Text;
                buses.Seater = Convert.ToInt32(txtEditSeater.Text.Trim());
                buses.Type = rblEditType.SelectedValue;
                buses.Year = txtEditYear.Text;
                buses.Passes1 = txtEditPasses1.Text;
                buses.Passes2 = txtEditPasses2.Text;
                buses.Passes3 = txtEditPasses3.Text;
                
                if (chkEditSubcon.Checked && cboEditSubcon.SelectedIndex > 0)
                {
                    buses.SubconID = new Guid(cboEditSubcon.SelectedValue.ToString());
                }

                if (!String.IsNullOrEmpty(txtEditExpiry1.Text.Trim()))
                {
                    buses.Expiry1 = UtilityController.StringToDate(txtEditExpiry1.Text.Trim());
                }

                if (!String.IsNullOrEmpty(txtEditExpiry2.Text.Trim()))
                {
                    buses.Expiry2 = UtilityController.StringToDate(txtEditExpiry2.Text.Trim());
                }

                if (!String.IsNullOrEmpty(txtEditExpiry3.Text.Trim()))
                {
                    buses.Expiry3 = UtilityController.StringToDate(txtEditExpiry3.Text.Trim());
                }
             
                if (!String.IsNullOrEmpty(this.txtScrappedDate.Text.Trim()))
                {
                    buses.ScrappedDate = UtilityController.StringToDate(txtScrappedDate.Text.Trim());
                }
               

                if (rblEditScrapped.SelectedValue == "Yes")
                {
                    buses.Scrapped = true;
                }
                else
                {
                    buses.Scrapped = false;
                }
                this.lblEditMessage.Text = busPresenter.UpdateData(buses);

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

        public void DeleteData()
        {
            try
            {

                UserPresenter userPresenter = new UserPresenter();
                busPresenter = new BusPresenter();
                Buses buses = new Buses();
                buses.BusCode = txtBusCode.Text.Trim();
                buses.Brand = txtEditBrand.Text;
                buses.BusCode = txtBusCode.Text;
                buses.BusNo1 = txtEditBusNo1.Text.Trim();
                buses.BusNo2 = txtEditBusNo2.Text.Trim();
                buses.BusNo3 = txtEditBusNo3.Text.Trim();
                buses.BusNo = txtEditBusNo1.Text.Trim() + txtEditBusNo2.Text.Trim() + txtEditBusNo3.Text.Trim();
                buses.CompanyID = new Guid(cboEditCompany.SelectedValue.ToString());
                buses.CreatedBy = userPresenter.GetLoginID(User.Identity.Name);
                buses.CreatedDate = DateTime.Now;
                buses.UpdatedBy = userPresenter.GetLoginID(User.Identity.Name);
                buses.UpdatedDate = DateTime.Now;
                buses.Parking = txtEditParking.Text;
                buses.Seater = Convert.ToInt32(txtEditSeater.Text.Trim());
                buses.Type = rblEditType.SelectedValue;
                buses.Year = txtEditYear.Text;
                buses.Passes1 = txtEditPasses1.Text;
                buses.Passes2 = txtEditPasses2.Text;
                buses.Passes3 = txtEditPasses3.Text;
                if (!String.IsNullOrEmpty(txtEditExpiry1.Text.Trim()))
                {
                    buses.Expiry1 = UtilityController.StringToDate(txtEditExpiry1.Text.Trim());
                }

                if (!String.IsNullOrEmpty(txtEditExpiry2.Text.Trim()))
                {
                    buses.Expiry2 = UtilityController.StringToDate(txtEditExpiry2.Text.Trim());
                }
                
                if (!String.IsNullOrEmpty(txtEditExpiry3.Text.Trim()))
                {
                    buses.Expiry3 = UtilityController.StringToDate(txtEditExpiry3.Text.Trim());
                }
                
                if (!String.IsNullOrEmpty(this.txtScrappedDate.Text.Trim()))
                {
                    buses.ScrappedDate = UtilityController.StringToDate(txtScrappedDate.Text.Trim());
                }
                

                if (rblEditScrapped.SelectedValue == "Yes")
                {
                    buses.Scrapped = true;
                }
                else
                {
                    buses.Scrapped = false;
                }
                this.lblMessage.Text = busPresenter.DeleteData(buses);

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

        public void ResignData()
        {
            // bus has no resignation/retirement
        }

        #endregion

        #region HouseKeeping
        public void ClearControl()
        {
            this.txtBrand.Text = string.Empty;
            this.txtBus1.Text = string.Empty;
            this.txtBus2.Text = string.Empty;
            this.txtBus3.Text = string.Empty;
            this.cboCompany.SelectedIndex = 0;
            this.txtExpiry1.Text = string.Empty;
            this.txtExpiry2.Text = string.Empty;
            this.txtExpiry3.Text = string.Empty;
            this.txtParking.Text = string.Empty;
            this.txtPasses1.Text = string.Empty;
            this.txtPasses2.Text = string.Empty;
            this.txtPasses3.Text = string.Empty;
            this.txtYear.Text = string.Empty;
            txtSearch.Text = string.Empty;
            txtSeater.Text = string.Empty;
            this.rblType.SelectedIndex = 0;

        }

        public void DisplayData(Buses buses)
        {
            try
            {
                this.txtEditBrand.Text = buses.Brand;
                this.txtBusCode.Text = buses.BusCode;
                this.txtEditBusNo1.Text = buses.BusNo1;
                this.txtEditBusNo2.Text = buses.BusNo2;
                this.txtEditBusNo3.Text = buses.BusNo3;
                this.txtEditParking.Text =  buses.Parking;
                this.txtEditSeater.Text = buses.Seater.ToString();
                this.rblEditType.SelectedValue = buses.Type;
                this.txtEditParking.Text = buses.Parking;
                this.txtEditPasses1.Text = buses.Passes1;
                this.txtEditPasses2.Text = buses.Passes2;
                this.txtEditPasses3.Text = buses.Passes3;

                this.cboEditCompany.FindItemByValue(buses.CompanyID.ToString());

                if (buses.SubconID != Guid.Empty)
                {
                    cboEditSubcon.FindItemByValue(buses.SubconID.ToString());
                    this.chkEditSubcon.Checked = true;
                    this.cboEditSubcon.Enabled = true;
                }
                else
                {
                    this.cboEditSubcon.Enabled = false;
                    this.chkEditSubcon.Checked = false;
                    this.cboEditSubcon.UnSelectData();
                }


                if (DateTime.MinValue != buses.Expiry1)
                {
                    this.txtEditExpiry1.Text = buses.Expiry1.ToString(Properties.WebResources.dateformat);
                }
                else
                {
                    this.txtEditExpiry1.Text = string.Empty;
                }

                if (DateTime.MinValue != buses.Expiry2)
                {
                    this.txtEditExpiry2.Text = buses.Expiry2.ToString(Properties.WebResources.dateformat);
                }
                else
                {
                    this.txtEditExpiry2.Text = string.Empty;
                }


                if (DateTime.MinValue != buses.Expiry3)
                {
                    this.txtEditExpiry3.Text = buses.Expiry3.ToString(Properties.WebResources.dateformat);
                }
                else
                {
                    this.txtEditExpiry3.Text = string.Empty;
                }

                if (DateTime.MinValue != buses.ScrappedDate)
                {
                    this.txtScrappedDate.Text = buses.ScrappedDate.ToString(Properties.WebResources.dateformat);
                }
                else
                {
                    this.txtScrappedDate.Text = string.Empty;
                }

                this.txtEditYear.Text = buses.Year;
                if (buses.Scrapped)
                {
                    rblEditScrapped.SelectedIndex = 0;
                }
                else
                {
                    rblEditScrapped.SelectedIndex = 1;
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
        #endregion

        #region Properties
            private BusPresenter BusPresenter
            { 
                get
                {
                    if (busPresenter != null)
                    {
                        return busPresenter;
                    }
                    else
                    {
                        busPresenter = new BusPresenter(this);
                        return busPresenter;
                    }
                }
                set
                {
                    busPresenter = value;
                }
            }
        #endregion

    }
}