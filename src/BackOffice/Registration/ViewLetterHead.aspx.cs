using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

//WOC
using Woc.Book.Base.Presenter; 
 using Woc.Book.Base;
using Woc.Book.Base.BusinessEntity;

//ErrorHandler
using Woc.Book.ErrorHandler;
using Woc.Book.ErrorHandler.Presenter;
using Woc.Book.ErrorHandler.BusinessEntity;
using System.IO;

namespace WOC.Book
{
    public partial class ViewLetterHead : System.Web.UI.Page
    {
        #region Declaration
        ImagePresenter imagePresenter;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["ID"] != String.Empty)
                {
                    imagePresenter = new ImagePresenter();
                    Guid companyID = new Guid(Request.QueryString["ID"]);
                
                    DataTable imgData = imagePresenter.GetImage(companyID);

                    if (imgData.Rows.Count > 0)
                    {
                        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", imgData.Rows[0]["FileName"].ToString()));
                        byte[] imgFile = (byte[])imgData.Rows[0]["ImageFile"];
                        Response.ContentType = imgData.Rows[0]["ContentType"].ToString();
                        Response.BinaryWrite(imgFile);
                    }
                }
            }
        }
    }
}
