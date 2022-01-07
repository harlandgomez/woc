using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;
using System.Data;


namespace Woc.Book.Base
{
    public class GSTController
    {
        public List<GSTtypes> GetGSTTypes()
        {
            GSTService gstService = new GSTService();
            List<GSTtypes> ListGSTTypes = new List<GSTtypes>();
            DataTable table = new DataTable();
            table = gstService.GetGSTTypes();
            GSTtypes gstTypes;
            foreach (DataRow row in table.Rows)
            {
                gstTypes = new GSTtypes();
                gstTypes.GSTTypeCode = row["GSTTypeCode"].ToString();
                gstTypes.Description = row["Description"].ToString();
                ListGSTTypes.Add(gstTypes);
            }
            return ListGSTTypes;
        }

        public Decimal GetTotalAmount(Decimal SubTotal, String Type)
        {
            GSTService gstService = new GSTService();
            Decimal gstPercent = gstService.GetGSTPercentage();
            Decimal totalAmount = Type.ToUpper() == "EXC" ? ((SubTotal * gstPercent) + SubTotal) : SubTotal;
            return totalAmount;
        }


        public Decimal GetGSTAmount(Decimal SubTotal, String Type)
        {
            GSTService gstService = new GSTService();
            Decimal gstPercent = gstService.GetGSTPercentage();
            Decimal gstAmount = Type.ToUpper() == "NO" ? 0 : (SubTotal * gstPercent);
            return gstAmount;
        }
    }
}
