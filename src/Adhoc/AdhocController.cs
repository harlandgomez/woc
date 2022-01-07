using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base;
//Internal
using Woc.Book.Adhoc.Service;
using Woc.Book.Adhoc.BusinessEntity;
using Woc.Book.Adhoc.Constant;
using Woc.Book.Setting;

namespace Woc.Book.Adhoc
{
   internal class AdhocController
    {
       public String SaveData(List<Adhocs> listAdhoc)
        {
            AdhocService adhocService = new AdhocService();
            return adhocService.SaveData(listAdhoc);
            
        }
       public String UpdateData(List<Adhocs> listAdhoc)
        {
            AdhocService adhocService = new AdhocService();
            adhocService.UpdateData(listAdhoc);
            return adhocService.SaveData(listAdhoc);
           
        }

        public String DeleteData(INewBookEntity  iBusinessEntity)
        {
            //AdhocService adhocService = new AdhocService();
            //return adhocService.DeleteData(iBusinessEntity);
            return "";
        }

        public String ResignData(INewBookEntity  iBusinessEntity)
        {
        //    AdhocService adhocService = new AdhocService();
        //    return adhocService.ResignData(iBusinessEntity);

            return "";
        }
        public List<Adhocs> SearchData(INewBookEntity iNewBookEntity)
        {
            
            AdhocService adhocService = new AdhocService();
            Adhocs adhocs = new Adhocs();
            adhocs = (Adhocs)iNewBookEntity;
            string strParemeter = String.Empty;
            const string sqlDateFormat = "yyyy-MM-dd";

            if (!String.IsNullOrEmpty(adhocs.Agent))
            {
                strParemeter = "Agent.Agent like'%" + adhocs.Agent + "%'";
            }
            else if (!String.IsNullOrEmpty(adhocs.AdhocCode))
            {
                strParemeter = "Adhoc.AdhocCode like '%" + adhocs.AdhocCode + "%'";
            }
            else if (adhocs.AdhocBookDateTo != DateTime.MinValue && adhocs.AdhocBookDateFrom != DateTime.MinValue)
            {
                strParemeter = "AdhocBookDate>='" + adhocs.AdhocBookDateFrom.ToString(sqlDateFormat) +
                               "' AND AdhocBookDate <= '" + adhocs.AdhocBookDateTo.ToString(sqlDateFormat) + "'";
            }

            if (string.IsNullOrEmpty(strParemeter))
            {
                strParemeter = strParemeter + " Adhoc.[Delete] <> 'Y'";
            }
            else
            {
                strParemeter = strParemeter + " and Adhoc.[Delete] <> 'Y'";
            }
            return adhocService.SearchData(strParemeter);

        }

        public List<Adhocs> GetUpdateData(String adhocCode)
        {
            String strParemeter = "AdhocCode = '" + adhocCode + "'";
            AdhocService adhocService = new AdhocService();
            return adhocService.GetData(strParemeter);
        }

        public List<Adhocs> GetTempData(List<Adhocs> adhocStaff)
        {
            
            AdhocService adhocService = new AdhocService();
            return adhocService.GetTempData(adhocStaff);

        }

        public String VoidData(INewBookEntity iNewBookEntity)
        {
            AdhocService adhocService = new AdhocService();
            return adhocService.VoidData(iNewBookEntity);
        }

        public List<Adhocs> SearchPendingData(INewBookEntity iNewBookEntity)
        {
            Adhocs adhocs = new Adhocs();
            adhocs = (Adhocs)iNewBookEntity;

            if (adhocs.IsFromAdhoc == true)
            {
                return SearchAdhocData(adhocs);
            }
            else
            {
                return SearchCustomerData(adhocs);
            }
        }

        public List<Adhocs> SearchAdhocData(INewBookEntity iNewBookEntity)
        {

            AdhocService adhocService = new AdhocService();
            Adhocs adhocs = new Adhocs();
            adhocs = (Adhocs)iNewBookEntity;
            StringBuilder sqlParam = new StringBuilder();

            sqlParam.AppendLine("AND Adhoc.[Delete] <> 'Y'");

            if (adhocs.AgentID != Guid.Empty)
            {
                sqlParam.AppendLine("AND Agent.AgentID = '" + adhocs.AgentID + "' ");
            }
            
            if (adhocs.IsPending == true)
            {
                sqlParam.AppendLine("AND IsPending = 1 ");
            }
            else if (adhocs.IsPending == false)
            {
                sqlParam.AppendLine("AND IsPending = 0");
            }

            if (adhocs.AdhocBookDate != DateTime.MinValue)
            {
                sqlParam.AppendLine("AND dateadd(dd, datediff(dd,0, AdhocBookDate), 0) = '" + adhocs.AdhocBookDate.ToString("yyyy-MM-dd") + "'  ");
            }

            if (adhocs.Destination != String.Empty)
            {
                sqlParam.AppendLine("AND (Adhoc.TripFrom like '%" + adhocs.Destination + "%' ");
                sqlParam.AppendLine("OR Adhoc.TripTo like '%" + adhocs.Destination + "%')");
            }

            return adhocService.SearchPendingData(sqlParam.ToString());
        }

        public List<Adhocs> SearchCustomerData(INewBookEntity iNewBookEntity)
        {

            AdhocService adhocService = new AdhocService();
            Adhocs adhocs = new Adhocs();
            adhocs = (Adhocs)iNewBookEntity;
            StringBuilder sqlParam = new StringBuilder();

            sqlParam.AppendLine("AND Adhoc.[Delete] <> 'Y'");
            sqlParam.AppendLine("AND Adhoc.AgentID = '" + adhocs.AgentID.ToString() + "' ");
            sqlParam.AppendLine("AND (Adhoc.TripFrom like '%" + adhocs.Destination + "%' ");
            sqlParam.AppendLine("OR Adhoc.TripTo like '%" + adhocs.Destination + "%')");

            if (adhocs.Item == ((int) Constant.Constant.SearchCategory.Pending))
            {
                sqlParam.AppendLine(" AND IsPending = 1 ");
            }
            else if (adhocs.Item == ((int)Constant.Constant.SearchCategory.Confirm))
            {
                sqlParam.AppendLine(" AND IsPending = 0");
            }

            return adhocService.SearchPendingData(sqlParam.ToString());
        }
       

        public List<Adhocs> GetPendingDataByAgentID(Guid agentID)
        {
            AdhocService adhocService = new AdhocService();
            String stringParam = " Adhoc.AgentID = '" + agentID.ToString() + "' AND Adhoc.IsPending = 1 ";

            return adhocService.SearchData(stringParam);
        }

        public String ConfirmRejectBooking(List<Adhocs> listAdhoc)
        {
            AdhocService adhocService = new AdhocService();
            return adhocService.ConfirmRejectBooking(listAdhoc);
        }
    }
}
