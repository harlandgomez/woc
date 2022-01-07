using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

using Woc.Book.Base.Service;

using Woc.Book.CreditNote.Presenter;
using Woc.Book.CreditNote.BusinessEntity;

namespace WOC.Book.Accounts
{
    public partial class AccountsAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String returnToClient = string.Empty;
            String action = Request.QueryString["action"].ToString().ToLower();
            if (Request.QueryString["module"].ToString().ToLower() == "accounts")
            {
                switch (action)
                {
                    case "updatecreditnote":
                        returnToClient = UpdateData();
                        break;
                    default:
                        returnToClient = DateTime.Now.ToString();
                        break;
                }
            }

            Response.Expires = -1;
            Response.ContentType = "text/plain";
            Response.Write(returnToClient);
            Response.End();
        }

        private String UpdateData()
        {
            try
            {
                string category = Request.QueryString["category"].Replace("'", "`");
                string value = Request.QueryString["value"].Replace("'", "`");
                string id = Request.QueryString["creditnoteid"].Replace("'", "`");
                SQLHelper helper = new SQLHelper();

                string sql;

                sql = String.Format("Update CreditNote Set {0} = '{1}' Where CreditNoteID = '{2}' ", category, value, id);
                helper.GetExecuteNonQueryBySQL(sql);

                //if (category == "CreditNoteAmount")
                //{
                //    CreditNotePresenter creditNotePresenter = new CreditNotePresenter();
                //    CreditNotes creditNotes = new CreditNotes();
                //    creditNotes.CreditNoteAmount = Convert.ToDecimal(value);
                //    creditNotes.CreditNoteID = new Guid(id);
                //    creditNotePresenter.AutoComputeCreditNote(creditNotes);
                //}
            }
            catch
            {
                return Woc.Book.Base.Constant.Constant.MessageUnSaved;
            }
            return Woc.Book.Base.Constant.Constant.MessageSaved;
        }
    }

    
}