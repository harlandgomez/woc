using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Base.BusinessEntity
{
   public class AccessLevels : IBusinessEntity
    {
      
            private Guid m_AccessLevelID;
            private String m_AccessLevel;
            private Guid m_CreatedBy;
            private DateTime m_CreatedDate;
            private Guid m_UpdatedBy;
            private DateTime m_UpdatedDate;


            public Guid AccessLevelID
            {
                get { return m_AccessLevelID; }
                set { m_AccessLevelID = value; }
            }
            public string AccessLevel
            {
                get { return m_AccessLevel; }
                set { m_AccessLevel = value; }
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

        }

    }

