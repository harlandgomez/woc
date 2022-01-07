using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.DailyTrip.BusinessEntity;
namespace Woc.Book.BusDriverStatus.BusinessEntity
{
    public class DriverBuses : DailyTripsDTO
    {
        private Guid m_CreatedBy;
        private DateTime m_CreatedDate;
        private Guid m_UpdatedBy;
        private DateTime m_UpdatedDate;
        private DateTime m_FromDate;
        private DateTime m_ToDate;
        private String m_TypeMode;
        private Guid m_DriverStatusID;
        private Guid m_BusStatusID;
        private DateTime m_BusDateStatus;
        private String m_PO;
        private String m_Customer;
        private String m_Amount;

        public String Amount
        {
            get { return m_Amount; }
            set { m_Amount = value; }
        }
      
        public String Customer
        {
            get { return m_Customer; }
            set { m_Customer = value; }
        }
        public Guid DriverStatusID
        {
            get { return m_DriverStatusID; }
            set { m_DriverStatusID = value; }
        }
        
        public Guid CreatedBy
        {
            get { return m_CreatedBy; }
            set { m_CreatedBy = value; }
        }
        public DateTime CreatedDate
        {
            get { return m_CreatedDate; }
            set { m_CreatedDate = value; }
        }
        public Guid UpdatedBy
        {
            get { return m_UpdatedBy; }
            set { m_UpdatedBy = value; }
        }
        public DateTime UpdatedDate
        {
            get { return m_UpdatedDate; }
            set { m_UpdatedDate = value; }
        }
        public DateTime FromDate
        {
            get { return m_FromDate; }
            set { m_FromDate = value; }
        }
        public DateTime ToDate
        {
            get { return m_ToDate; }
            set { m_ToDate = value; }
        }
        public String TypeMode
        {

            get { return m_TypeMode; }
            set { m_TypeMode = value; }
        }

        public Guid BusStatusID
        {
            get { return m_BusStatusID; }
            set { m_BusStatusID = value; }
        }
        public DateTime BusDateStatus
        {
            get { return m_BusDateStatus; }
            set { m_BusDateStatus = value; }
        }

      
        public string PO
        {
            get { return m_PO; }
            set { m_PO = value; }
        }
    }
}
