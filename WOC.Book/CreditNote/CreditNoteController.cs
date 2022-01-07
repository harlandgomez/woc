using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Woc.Book.Base.Service;
using Woc.Book.Base;
using Woc.Book.Base.BusinessEntity;

using Woc.Book.CreditNote.Service;
using Woc.Book.CreditNote.BusinessEntity;
using Woc.Book.Setting.Service;

namespace Woc.Book.CreditNote
{
    internal class CreditNoteController : IAccountController
    {
        CreditNoteService creditNoteService;
        SettingService settingService;
        GSTService gstService;
        Decimal gstPercent;


        public String SaveData(IAccountEntity iAccountEntity)
        {
            creditNoteService = new CreditNoteService();
            settingService = new SettingService();
            gstService = new GSTService();

            CreditNotes creditNotes = (CreditNotes)iAccountEntity;
            gstPercent = gstService.GetGSTPercentage();


            return creditNoteService.SaveData(creditNotes);
        }
        
        public String UpdateData(IAccountEntity iAccountEntity)
        {
            creditNoteService = new CreditNoteService();
            settingService = new SettingService();
            gstService = new GSTService();

            CreditNotes creditNotes = (CreditNotes)iAccountEntity;
            gstPercent = gstService.GetGSTPercentage();

            return creditNoteService.UpdateData(iAccountEntity);
        }

        public List<CreditNotes> SearchData(IAccountEntity iAccount)
        {
            creditNoteService = new CreditNoteService();

            CreditNotes CreditNotes = new CreditNotes();
            CreditNotes = (CreditNotes)iAccount;

            string strParemeter = String.Empty;
            if (!String.IsNullOrEmpty(CreditNotes.CreditNoteCode))
            {
                strParemeter += " AND CreditNoteCode like '%" + CreditNotes.CreditNoteCode + "%'";
            }

            if (CreditNotes.AgentID != Guid.Empty)
            {
                strParemeter += " AND AgentID like '%" + CreditNotes.AgentID.ToString() + "%'";
            }

            if (CreditNotes.CreditNoteDate != DateTime.MinValue)
            {
                strParemeter += " AND CreditNoteDate = '" + CreditNotes.CreditNoteDate.ToString("MM/dd/yyyy") + "'";
            }

            if (!String.IsNullOrEmpty(CreditNotes.InvoiceCode))
            {
                strParemeter += "AND InvoiceCode like '%" + CreditNotes.InvoiceCode + "%'";
            }

            if (!String.IsNullOrEmpty(CreditNotes.ReasonCode))
            {
                strParemeter += " AND ReasonCode like '%" + CreditNotes.ReasonCode + "%'";
            }

            if (!String.IsNullOrEmpty(CreditNotes.Description))
            {
                strParemeter += " AND Description like '%" + CreditNotes.Description + "%'";
            }

            strParemeter = " 1 = 1 " + strParemeter;


            return creditNoteService.SearchData(strParemeter);
        }

        public List<MemoReasons> GetAllReason()
        {
            creditNoteService = new CreditNoteService(); 
            return creditNoteService.GetAllReason();
        }

        public String BatchDeleteCreditNote(List<CreditNotes> listCrediteNote)
        {
            creditNoteService = new CreditNoteService();
            return creditNoteService.BatchDeleteCreditNote(listCrediteNote);
        }

        public void AutoComputeCreditNote(IAccountEntity iAccount)
        {
            creditNoteService = new CreditNoteService();
            CreditNotes creditNotes = (CreditNotes)iAccount;
            creditNotes.CreditNoteCode = creditNoteService.GetCreditNoteCodeByID(creditNotes.CreditNoteID);
            creditNoteService.AutoComputeCreditNote(creditNotes);
        }
    }
}
