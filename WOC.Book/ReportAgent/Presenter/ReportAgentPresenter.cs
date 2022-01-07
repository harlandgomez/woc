using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Presenter;

//Internal
using Woc.Book.ReportAgent;
using Woc.Book.ReportAgent.BusinessEntity;


namespace Woc.Book.ReportAgent.Presenter
{
   public class ReportAgentPresenter:IReportPresenter
    {
       IReportPresenter iReportPresenter;
       public ReportAgentPresenter()
        { 
        
        }
       public ReportAgentPresenter(IReportPresenter iReport)
        {
            iReportPresenter = iReport;
        }
       public void SearchData()
       {
           iReportPresenter.SearchData();
       }
       public List<ReportAgents>  SearchData(DateTime dateAgentReport)
       {
           ReportAgentController reportAgentController = new ReportAgentController();
           return reportAgentController.SearchData(dateAgentReport);

       
       }
    }
}
