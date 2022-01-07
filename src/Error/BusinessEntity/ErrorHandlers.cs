using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.ErrorHandler.BusinessEntity
{
    [Serializable]
    public class ErrorHandlers : IBusinessEntity
    {
        private  Guid m_ErrorHandlerID;
        private string m_StackTrace;
        private string m_Message;
        private string m_Source;
        private string m_Module;
        private DateTime m_ErrorDate;
        private string m_UserID;


        public ErrorHandlers()
        {
          
        }

        public Guid ErrorHandlerID
        {
            get { return m_ErrorHandlerID; }
            set { m_ErrorHandlerID = value; }
        }
        public string StackTrace
        {
            get { return m_StackTrace; }
            set { m_StackTrace = value; }
        }
        public string Message
        {
            get { return m_Message; }
            set { m_Message = value; }
        }
        public string Source
        {
            get { return m_Source; }
            set { m_Source = value; }
        }
        public string Module
        {
            get { return m_Module; }
            set { m_Module = value; }
        }
        public DateTime ErrorDate
        {
            get { return m_ErrorDate; }
            set { m_ErrorDate = value; }
        }
        public string UserID
        {
            get { return m_UserID; }
            set { m_UserID = value; }
        }

    }

}
