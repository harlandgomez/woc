using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;


namespace Woc.Book.Invoice.BusinessEntity
{
    [Serializable]
    public class InvoiceDetails : IAccountEntity
    {
        private Guid m_InvoiceDetailID;
        private Guid m_InvoiceID;
        private DateTime m_ItemDate;
        private Guid m_BookingID;
        private string m_RefNo;
        private DateTime m_StartTime;
        private DateTime m_EndTime;
        private string m_Pax;
        private decimal m_ERP;
        private decimal m_Surcharge;
        private decimal m_UnitPrice;
        private decimal m_TotalPrice;
        private int m_SortOrder;
        private string m_Description;
        private string m_RatesType;

        public Guid InvoiceDetailID
        {
            get { return m_InvoiceDetailID; }
            set { m_InvoiceDetailID = value; }
        }
        public Guid InvoiceID
        {
            get { return m_InvoiceID; }
            set { m_InvoiceID = value; }
        }
        public DateTime ItemDate
        {
            get { return m_ItemDate; }
            set { m_ItemDate = value; }
        }
        public Guid BookingID
        {
            get { return m_BookingID; }
            set { m_BookingID = value; }
        }
        public string RefNo
        {
            get { return m_RefNo; }
            set { m_RefNo = value; }
        }
        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }
        public DateTime StartTime
        {
            get { return m_StartTime; }
            set { m_StartTime = value; }
        }
        public DateTime EndTime
        {
            get { return m_EndTime; }
            set { m_EndTime = value; }
        }
        public string Pax
        {
            get { return m_Pax; }
            set { m_Pax = value; }
        }
        public decimal ERP
        {
            get { return m_ERP; }
            set { m_ERP = value; }
        }
        public decimal Surcharge
        {
            get { return m_Surcharge; }
            set { m_Surcharge = value; }
        }
        public decimal UnitPrice
        {
            get { return m_UnitPrice; }
            set { m_UnitPrice = value; }
        }
        public decimal TotalPrice
        {
            get { return m_TotalPrice; }
            set { m_TotalPrice = value; }
        }
        public int SortOrder
        {
            get { return m_SortOrder; }
            set { m_SortOrder = value; }
        }
        public String RatesType
        {
            get { return m_RatesType; }
            set { m_RatesType = value; }
        }
    }

}
