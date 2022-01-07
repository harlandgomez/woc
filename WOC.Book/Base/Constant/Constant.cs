using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Base.Constant
{
    public static class Constant
    {
        public const String MessageSaved = "Successfully Saved";
        public const String MessageUnSaved = "Unsuccessfully saved";
        public const String MinimumDate = "1/1/1753 12:00:00 AM";
        public const String ExportToExcelContentType = "application/ms-excel";
        public const String ExportToPDFContentType = "application/pdf";
        public const String CompanyCode = "CompanyCode";
        public const String BookingCode = "BookingCode";
        public const String AdhocCode = "AdhocCode";
        public const String DropdownPageSize = "DROPDOWN_PAGESIZE";
        public const String DropdownSeater = "DROPDOWN_SEATER";
        public const String DataTextField = "Text";
        public const String DataValueField = "Value";
        public const String DateFormat = "MM/dd/yyyy";
        public const String CultureCode = "en-SG";

        public enum ExportToExcelTypeID{
            Driver = 1,
            Bus = 2,
            Agent = 3,
            SubCon = 4,
            Staff=5,
            Company=6,
            Contract = 7,
            Adhoc = 8,
            Payroll = 9,
            AgentDetails =10
        }
        public enum ExportToPDFTypeID
        {
            Driver = 1,
            Bus = 2,
            Agent = 3,
            SubCon = 4,
            Staff = 5,
            Company = 6,
            Contract = 7,
            Adhoc = 8,
            AgentDetails = 9
        }
        public enum gridViewIndexStaff
        {

            linkSelect = 3
        }
        public enum gridViewIndexAgent
        {

            linkSelect = 5
        }
        public enum gridViewIndexSubcon
        {

            linkSelect = 7
        }
        public enum gridViewIndexDriver
        {

            linkSelect = 4
        }
        public enum gridViewIndexBus
        {

            linkSelect = 4
        }
        public enum gridViewIndexCompany
        {
            Company = 0,
            Address = 1,
            Telephone = 2,
            Fax = 3,
            Email = 4,
            Website = 5,
            ROC = 6,
            Prefix = 7,
            linkSelect = 8 
        }
        public enum gridViewIndexSetting
        {
            linkSelect = 3
        }

        public enum gridViewIndexContract
        {
            linkSelect = 7
        }

        public enum gridViewIndexAdhoc
        {
            linkSelect = 10,
            Voided = 11
        }
        public enum gridViewIndexOperationDetail
        {
            TripTime = 0,
            Route = 1,
            Agent = 2,
            Person = 3,
            Contact = 4
        }
        public enum GridViewSalesReport
        {
            InvoiceCode = 0,
            Description = 1,
            InvoiceDate = 2,
            Remarks = 3
        }

        public enum GridViewStatementOfAccount
        {
            InvoiceDate = 0,
            InvoiceNo = 1,
            Description = 2,
            Debit = 3,
            Credit = 4,
            Balance = 5
        }
    }
}
