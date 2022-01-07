using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.DailyTrip.BusinessEntity
{
    public class DriverDetailDTO : IOperation
    {
        string m_DriverCode;
        public string DriverCode
        {
            get { return m_DriverCode; }
            set { m_DriverCode = value; }
        }
        string m_DriverName;
        public string DriverName
        {
            get { return m_DriverName; }
            set { m_DriverName = value; }
        }

        string m_Contact;
        public string Contact
        {
            get { return m_Contact; }
            set { m_Contact = value; }
        }

        string m_SMS;
        public string SMS
        {
            get { return m_SMS; }
            set { m_SMS = value; }
        }
        string m_Customer;
        public string Customer
        {
            get { return m_Customer; }
            set { m_Customer = value; }
        }
        string m_Person;
        public string Person
        {
            get { return m_Person; }
            set { m_Person = value; }
        }

        string m_DriverRoute;
        public string DriverRoute
        {
            get { return m_DriverRoute; }
            set { m_DriverRoute = value; }
        }

        DateTime m_TripTime;
        public DateTime TripTime
        {
            get { return m_TripTime; }
            set { m_TripTime = value; }
        }
        Guid m_OperationDetailID;
        public Guid OperationDetailID
        {
            get { return m_OperationDetailID; }
            set { m_OperationDetailID = value; }
        }
        Guid m_OperationID;
        public Guid OperationID
        {
            get { return m_OperationID; }
            set { m_OperationID = value; }
        }
        int m_fieldID;
        public int FieldID
        {
            get { return m_fieldID; }
            set { m_fieldID = value; }
        }

        string m_BusNo;
        public string BusNo
        {
            get { return m_BusNo; }
            set { m_BusNo = value; }
        }

        string m_DriverContact;
        public string DriverContact
        {
            get { return m_DriverContact; }
            set { m_DriverContact = value; }
        }

        string m_SegmentType;
        public string SegmentType
        {
            get { return m_SegmentType; }
            set { m_SegmentType = value; }
        }
    }
}
