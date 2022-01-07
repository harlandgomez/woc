using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Agent

using Woc.Book.ReportAgent.Service;
using Woc.Book.ReportAgent.BusinessEntity;
namespace Woc.Book.ReportAgent
{
  public  class ReportAgentController
    {
      public List<ReportAgents> SearchData(DateTime dateAgentReport)
      {
        ReportAgentService reportAgentService = new ReportAgentService();
        return reportAgentService.SearchData(dateAgentReport);
      }

    }
}
