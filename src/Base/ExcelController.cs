using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Common.BusinessEntity;
using Woc.Book.Common.Service;
using System.Data;
namespace Woc.Book.Common
{
    public class ExcelController
    {

        public DataTable GetExportToExcelData(int queryTypeID)
        {
            ExcelService excelService = new ExcelService();
            return excelService.GetExportToExcelData(queryTypeID);
        }
    }
}
