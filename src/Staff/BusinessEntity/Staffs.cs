using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.Staff.BusinessEntity
{
    [Serializable]
    public class Staffs : IBusinessEntity
    {
        private Guid m_UserID;	private string m_LoginID;	private string m_FirstName;	private string m_LastName;	private string m_MiddleName;	private string m_NRIC;	private string m_Address1;	private string m_Contact;	private string m_DOB;	private Guid m_CountryID;	private Guid m_AccessLevelID;	private Guid m_CreatedBy;	private DateTime m_CreatedDate;	private Guid m_UpdatedBy;	private DateTime m_UpdatedDate;	private string m_Resigned;	private string m_Delete;	private string m_Address2;	private string m_Address3;
    private byte[] m_Password;
    private byte[] m_Salt;

 

	    public Guid UserID	    {		    get { return m_UserID; }		    set { m_UserID = value; }	    }	    public string LoginID	    {		    get { return m_LoginID; }		    set { m_LoginID = value; }	    }	    public string FirstName	    {		    get { return m_FirstName; }		    set { m_FirstName = value; }	    }	    public string LastName	    {		    get { return m_LastName; }		    set { m_LastName = value; }	    }	    public string MiddleName	    {		    get { return m_MiddleName; }		    set { m_MiddleName = value; }	    }	    public string NRIC	    {		    get { return m_NRIC; }		    set { m_NRIC = value; }	    }	    public string Address1	    {		    get { return m_Address1; }		    set { m_Address1 = value; }	    }	    public string Contact	    {		    get { return m_Contact; }		    set { m_Contact = value; }	    }	    public string DOB	    {		    get { return m_DOB; }		    set { m_DOB = value; }	    }	    public Guid CountryID	    {		    get { return m_CountryID; }		    set { m_CountryID = value; }	    }	    public Guid AccessLevelID	    {		    get { return m_AccessLevelID; }		    set { m_AccessLevelID = value; }	    }	    public byte[] Password	    {		    get { return m_Password; }		    set { m_Password = value; }	    }

        public byte[] Salt
        {
            get { return m_Salt; }
            set { m_Salt = value; }
        }	    public Guid CreatedBy	    {		    get { return m_CreatedBy; }		    set { m_CreatedBy = value; }	    }	    public DateTime CreatedDate	    {		    get { return m_CreatedDate; }		    set { m_CreatedDate = value; }	    }	    public Guid UpdatedBy	    {		    get { return m_UpdatedBy; }		    set { m_UpdatedBy = value; }	    }	    public DateTime UpdatedDate	    {		    get { return m_UpdatedDate; }		    set { m_UpdatedDate = value; }	    }	    public string Resigned	    {		    get { return m_Resigned; }		    set { m_Resigned = value; }	    }	    public string Delete	    {		    get { return m_Delete; }		    set { m_Delete = value; }	    }	    public string Address2	    {		    get { return m_Address2; }		    set { m_Address2 = value; }	    }	    public string Address3	    {		    get { return m_Address3; }		    set { m_Address3 = value; }	    }

        private string _textboxPassword;
        public string TextBoxPassword
        {
            get { return _textboxPassword; }
            set { _textboxPassword = value; }
        }
    }
}
