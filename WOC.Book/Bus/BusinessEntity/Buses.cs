using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.Bus.BusinessEntity
{
    [Serializable]
    public class Buses:IBusinessEntity
    {
        private Guid m_BusID;
	    private string m_BusNo1;
	    private string m_BusNo2;
	    private string m_BusNo3;
	    private int m_Seater;
        private Guid m_CompanyID;
	    private string m_Brand;
	    private string m_Parking;
	    private string m_Type;
	    private string m_BusNo;
	    private Guid m_CreatedBy;
	    private DateTime m_CreatedDate;
	    private Guid m_UpdatedBy;
	    private DateTime m_UpdatedDate;
	    private string m_BusCode;
	    private string m_Passes1;
	    private string m_Passes2;
	    private string m_Passes3;
	    private DateTime m_Expiry1;
	    private DateTime m_Expiry2;
	    private DateTime m_Expiry3;
	    private string m_Delete;
	    private bool m_Scrapped;
	    private DateTime m_ScrappedDate;
	    private string m_Year;
        private Guid m_SubconID;


	            public Guid BusID
	            {
		            get { return m_BusID; }
		            set { m_BusID = value; }
	            }
	            public string BusNo1
	            {
		            get { return m_BusNo1; }
		            set { m_BusNo1 = value; }
	            }
	            public string BusNo2
	            {
		            get { return m_BusNo2; }
		            set { m_BusNo2 = value; }
	            }
	            public string BusNo3
	            {
		            get { return m_BusNo3; }
		            set { m_BusNo3 = value; }
	            }
	            public int Seater
	            {
		            get { return m_Seater; }
		            set { m_Seater = value; }
	            }
	            public Guid CompanyID
	            {
		            get { return m_CompanyID; }
		            set { m_CompanyID = value; }
	            }
	            public string Brand
	            {
		            get { return m_Brand; }
		            set { m_Brand = value; }
	            }
	            public string Parking
	            {
		            get { return m_Parking; }
		            set { m_Parking = value; }
	            }
	            public string Type
	            {
		            get { return m_Type; }
		            set { m_Type = value; }
	            }
	            public string BusNo
	            {
		            get { return m_BusNo; }
		            set { m_BusNo = value; }
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
	            public string BusCode
	            {
		            get { return m_BusCode; }
		            set { m_BusCode = value; }
	            }
	            public string Passes1
	            {
		            get { return m_Passes1; }
		            set { m_Passes1 = value; }
	            }
	            public string Passes2
	            {
		            get { return m_Passes2; }
		            set { m_Passes2 = value; }
	            }
	            public string Passes3
	            {
		            get { return m_Passes3; }
		            set { m_Passes3 = value; }
	            }
	            public DateTime Expiry1
	            {
		            get { return m_Expiry1; }
		            set { m_Expiry1 = value; }
	            }
	            public DateTime Expiry2
	            {
		            get { return m_Expiry2; }
		            set { m_Expiry2 = value; }
	            }
	            public DateTime Expiry3
	            {
		            get { return m_Expiry3; }
		            set { m_Expiry3 = value; }
	            }
	            public string Delete
	            {
		            get { return m_Delete; }
		            set { m_Delete = value; }
	            }
	            public bool Scrapped
	            {
		            get { return m_Scrapped; }
		            set { m_Scrapped = value; }
	            }
	            public DateTime ScrappedDate
	            {
		            get { return m_ScrappedDate; }
		            set { m_ScrappedDate = value; }
	            }
	            public string Year
	            {
		            get { return m_Year; }
		            set { m_Year = value; }
	            }

                public Guid SubconID
                {
                    get { return m_SubconID; }
                    set { m_SubconID = value; }
                }
                String m_CompanyNameSearch;
                public string CompanyNameSearch
                {
                    get { return m_CompanyNameSearch; }
                    set { m_CompanyNameSearch = value; }
                }
       
    }
}
