using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

using Woc.Book.Adhoc;
using Woc.Book.Adhoc.BusinessEntity;

using Woc.Book.Contract;
using Woc.Book.Contract.BusinessEntity;


namespace Woc.Book.Invoice.BusinessEntity
{
    public  class InvoiceDTO: Woc.Book.Adhoc.BusinessEntity.Adhocs, IAccountEntity
    {

        public List<Adhocs> ListAdhoc = new List<Adhocs>();
        public List<Contracts> ListContract = new List<Contracts>();

        private DateTime m_StartDate;
        public DateTime StartDate
        {
            get { return m_StartDate; }
            set { m_StartDate = value; }
        }

        private DateTime m_EndDate;
        public DateTime EndDate
        {
            get { return m_EndDate; }
            set { m_EndDate = value; }
        }

        private bool m_AdhocChecked;
        public bool AdhocChecked
        {
            get { return m_AdhocChecked; }
            set { m_AdhocChecked = value; }
        }

        private bool m_ContractChecked;
        public bool ContractChecked
        {
            get { return m_ContractChecked; }
            set { m_ContractChecked = value; }
        }

        private Int32 m_TransactionMode;
        public Int32 TransactionMode
        {
            get { return m_TransactionMode; }
            set { m_TransactionMode = value; }
        }

        private String m_Description;
        public String Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }

        private String m_RateType;
        public String RateType
        {
            get { return m_RateType; }
            set { m_RateType = value; }
        }

        private String m_Time;
        public String Time
        {
            get { return m_Time; }
            set { m_Time = value; }
        }

        private Double m_Rates;
        public Double Rates
        {
            get { return m_Rates; }
            set { m_Rates = value; }
        }

        private int m_SortBy;
        public int SortBy
        {
            get { return m_SortBy; }
            set { m_SortBy = value; }
        }

        private Double m_ERP;
        public Double ERP
        {
            get { return m_ERP; }
            set { m_ERP = value; }
        }

        private Double m_Surcharge;
        public Double Surcharge
        {
            get { return m_Surcharge; }
            set { m_Surcharge = value; }
        }

        private Double m_UnitPrice;
        public Double UnitPrice
        {
            get { return m_UnitPrice; }
            set { m_UnitPrice = value; }
        }

        private Double m_TotalPrice;
        public Double TotalPrice
        {
            get { return m_TotalPrice; }
            set { m_TotalPrice = value; }
        }

        private String m_ContractIDs;
        public String ContractIDs
        {
            get { return m_ContractIDs; }
            set { m_ContractIDs = value; }
        }
    }
}
