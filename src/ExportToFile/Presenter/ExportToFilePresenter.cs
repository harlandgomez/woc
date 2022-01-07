using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

using Woc.Book.ExportToFile.Controller;
using System.Data;
namespace Woc.Book.ExportToFile.Presenter
{
    public class ExportToFilePresenter
    {
        public void ExportToFile(string fileName, string contentType, GridView gv, int queryTypeID)
        {
            ExportToFileController exportToFileController = new ExportToFileController();
            exportToFileController.ExportToFile(fileName,contentType, gv, queryTypeID);
        }

        public void ExportToFile(string fileName, string contentType, GridView gv)
        {
            ExportToFileController exportToFileController = new ExportToFileController();
            exportToFileController.ExportToFile(fileName, contentType, gv);
        }
    }
}
