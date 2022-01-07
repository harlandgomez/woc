using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Base.BusinessEntity
{
    [Serializable]
    public class Sequences
    {
        private Guid m_SequenceID;
        private int m_SequenceCount;
        private string m_ColumnCode;
        private Guid m_CreatedBy;
        private DateTime m_CreatedDate;


        public Guid SequenceID
        {
            get { return m_SequenceID; }
            set { m_SequenceID = value; }
        }
        public int SequenceCount
        {
            get { return m_SequenceCount; }
            set { m_SequenceCount = value; }
        }
        public string ColumnCode
        {
            get { return m_ColumnCode; }
            set { m_ColumnCode = value; }
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

    }

}
