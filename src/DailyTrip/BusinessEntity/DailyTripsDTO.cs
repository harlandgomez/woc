using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.DailyTrip.BusinessEntity
{
    public class DailyTripsDTO : IOperation
    {
        string m_RefNumber;
        public string RefNumber
        {
            get { return m_RefNumber; }
            set { m_RefNumber = value; }
        }
        string m_BookingCode;
        public string BookingCode
        {
            get { return m_BookingCode; }
            set { m_BookingCode = value; }
        }
        private DateTime m_OperationDate;
        public DateTime OperationDate
        {
            get { return m_OperationDate; }
            set { m_OperationDate = value; }
        }
        private String m_route;
        public string Route
        {
            get { return m_route; }
            set { m_route = value; }
        }

        private DateTime m_StartTime;
        public DateTime StartTime
        {
            get { return m_StartTime; }
            set { m_StartTime = value; }
        }

        string m_StartBusNo;
        public String StartBusNo
        {
            get { return m_StartBusNo; }
            set { m_StartBusNo = value; }
        }
        private DateTime m_EndTime;
        public DateTime EndTime
        {
            get { return m_EndTime; }
            set { m_EndTime = value; }
        }

        string m_EndBusNo;
        public String EndBusNo
        {
            get { return m_EndBusNo; }
            set { m_EndBusNo = value; }
        }
        string m_RefNo;
        public String RefNo
        {
            get { return m_RefNo; }
            set { m_RefNo = value; }
        }
        string m_Remarks;
        public String Remarks
        {
            get { return m_Remarks; }
            set { m_Remarks = value; }
        }
        string m_BusNo;
        public String BusNo
        {
            get { return m_BusNo; }
            set { m_BusNo = value; }
        }
        string m_Contact;
        public String Contact
        {
            get { return m_Contact; }
            set { m_Contact = value; }
        }
        string m_Driver;
        public String Driver
        {
            get { return m_Driver; }
            set { m_Driver = value; }
        }

        int m_IsSubCon;
        public int IsSubcon
        {
            get { return m_IsSubCon; }
            set { m_IsSubCon = value; }
        }
        string m_Pax;
        public String Pax
        {
            get { return m_Pax; }
            set { m_Pax = value; }
        }
        string m_Status;
        public String Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        string m_BusStatus;
        public String BusStatus
        {
            get { return m_BusStatus; }
            set { m_BusStatus = value; }
        }
        String m_PoNumber;
        public String PoNumber
        {
            get { return m_PoNumber; }
            set { m_PoNumber = value; }
        }

        String m_TripFrom;
        public String TripFrom
        {
            get { return m_TripFrom; }
            set { m_TripFrom = value; }
        }

        String m_TripTo;
        public String TripTo
        {
            get { return m_TripTo; }
            set { m_TripTo = value; }
        }

        String m_TripType;
        public String TripType
        {
            get { return m_TripType; }
            set { m_TripType = value; }
        }

        Guid m_TripID;
        public Guid TripID
        {
            get { return m_TripID; }
            set { m_TripID = value; }
        }

        String m_OperationType;
        public String OperationType
        {
            get { return m_OperationType; }
            set { m_OperationType = value; }
        }
    }
}
