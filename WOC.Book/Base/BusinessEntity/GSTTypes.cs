using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Base.BusinessEntity
{
    [Serializable]
    public class GSTtypes : IBusinessEntity
    {
        private Guid m_GSTTypeID;
        private string m_GSTTypeCode;
        private string m_Description;
        private int m_SortOrder;
        private Guid m_CreateBy;
        private DateTime m_CreateDate;

        public Guid GSTTypeID
        {
            get { return m_GSTTypeID; }
            set { m_GSTTypeID = value; }
        }
        public string GSTTypeCode
        {
            get { return m_GSTTypeCode; }
            set { m_GSTTypeCode = value; }
        }
        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }
        public int SortOrder
        {
            get { return m_SortOrder; }
            set { m_SortOrder = value; }
        }
        public Guid CreateBy
        {
            get { return m_CreateBy; }
            set { m_CreateBy = value; }
        }
        public DateTime CreateDate
        {
            get { return m_CreateDate; }
            set { m_CreateDate = value; }
        }

    }

}
