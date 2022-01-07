using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Invoice.Constant
{
    public class Constant
    {
        public enum GridViewColumns
        {
            BookID = 0,
            BookDate = 1,
            RefNo = 2,
            Time = 3,
            Description = 4,
            Pax = 5,
            RateType = 6,
            Rates = 7,
            SelCheck = 8,
            StartTime = 9,
            EndTime = 10
        }

        public enum GridViewKeys
        {
            BookID = 0,
            StartTime = 1,
            EndTime =2
        }

        public enum GVImportedKeys
        {
            InvoiceDetailID = 0,
            StartTime = 1,
            EndTime = 2
        }

        public enum GVImportedColumns
        {
            BookID = 0,
            StartTime = 1,
            EndTime = 2,
            RateType = 3,
            BookDate = 4,
            RefNo = 5,
            Time = 6,
            Description = 7,
            Pax = 8,
            ERP = 9,
            Surcharge = 10,
            UnitPrice = 11,
            Total = 12,
            SortBy = 13,
            CheckBox =14

        }

        public enum TransType
        {
            GenerateInvoice = 0,
            RegenerateInvoice = 1
        }

        public enum LoadType
        {
            Imported = 0,
            Additional = 1,
            ReUseInvoice = 2,
            Reprint = 3
        }

        public const string NoDataToGenerate = "No data to generate";
        public const string NoRecordFound = "No record found. Please make sure the date range is correct.";
        public const String VoidInvoiceMessage = "Invoice {0} has been successfully voided";
        public const String UnVoidInvoiceMessage = "Failed to void invoice {0} - {1} ";
        public const String ReGenerateInvoiceCaption = "Regenerate Invoice";
        public const String GenerateInvoiceCaption = "Generate Invoice";
    }
}
