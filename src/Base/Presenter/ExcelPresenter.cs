using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Common;
using Woc.Book.Common.BusinessEntity;
using System.Data;
namespace Woc.Book.Common.Presenter
{
    public class ExcelPresenter
    {
        public DataTable GetExportToExcelData(int queryTypeID)
        {
            ExcelController excelController = new ExcelController();
            return excelController.GetExportToExcelData(queryTypeID);
        }
    }
}
