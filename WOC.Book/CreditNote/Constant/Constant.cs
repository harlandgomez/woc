using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.CreditNote.Constant
{
    public class Constant
    {
        public enum TransactionType
        {
            SaveCreditNote = 1,
            UpdateCreditNote = 2
        }

        public enum InvoiceTransactionType
        {
            GetAliasNotInCreditNote = 8,
            GetAliasInCreditNote = 9
        }

        public enum GVDataKeyNames
        {
            CreditNoteID = 0,
            AgentID = 1,
            ReasonCode = 2,
            GSTTypeCode =3
        }

        public enum LoadingType
        {
            None = 0,
            Show = 1,
            Edit = 2,
            Create = 3
        }

        public const String MessageDeleted = "Successfully deleted selected credit note(s).";
        public const String MessageUndeleted = "Unsuccessfully deleted selected credit note(s).";
        public const String MessageNoRecordFound = "No record found. Please ensure the criteria are correct.";
        public const String SequenceCode = "CreditNoteCode";
    }
}
