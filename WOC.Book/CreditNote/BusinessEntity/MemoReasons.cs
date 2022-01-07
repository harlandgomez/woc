using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.CreditNote.BusinessEntity
{
    [Serializable]
    public class MemoReasons: IAccountEntity
    {
        private Guid m_ReasonID;
        private string m_ReasonCode;
        private string m_Description;


        public Guid ReasonID
        {
            get { return m_ReasonID; }
            set { m_ReasonID = value; }
        }
        public string ReasonCode
        {
            get { return m_ReasonCode; }
            set { m_ReasonCode = value; }
        }
        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }

    }

}
