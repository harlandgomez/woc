using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Reports

using Woc.Book.ReportAgent.Presenter;
using Woc.Book.Bus.BusinessEntity;
//Woc Common
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



namespace WOC.Book.Operation
{
    public partial class AgentReport : System.Web.UI.Page, IReportPresenter
    {
        #region Declaration
        ReportAgentPresenter reportAgentPresenter;
        ExportToFilePresenter exportToFilePresenter;
        #endregion
        #region ControlEvents
              protected void Page_Load(object sender, EventArgs e)
                {
                    try
                    {
                        if (!IsPostBack)
                        {

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

              protected void btnSearch_Click(object sender, EventArgs e)
                {
                    reportAgentPresenter = new ReportAgentPresenter(this);
                    reportAgentPresenter.SearchData();
                    
                }
              protected void ibtnListAll_Click(object sender, ImageClickEventArgs e)
              {
                  exportToFilePresenter = new ExportToFilePresenter();
                  GridView gvExportToExcel = new GridView();
                  String fileName = Constant.ExportToExcelTypeID.AgentDetails.ToString() + ".xls";
                  exportToFilePresenter.ExportToFile(fileName,Constant.ExportToExcelContentType, gv);
              }

              protected void ibtnListAllPDF_Click(object sender, ImageClickEventArgs e)
              {
                  exportToFilePresenter = new ExportToFilePresenter();
                  GridView gvExportToExcel = new GridView();
                  String fileName = Constant.ExportToPDFTypeID.AgentDetails.ToString() + ".pdf";
                  exportToFilePresenter.ExportToFile(fileName, Constant.ExportToPDFContentType, gv);
              }
        #endregion
        #region interface
              public void SearchData()
              {
                  try
                  {
                      reportAgentPresenter = new ReportAgentPresenter();


                      gv.DataSource = reportAgentPresenter.SearchData(UtilityController.StringToDate(txtSearch.Text));
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
        #endregion

             

             
    }
}