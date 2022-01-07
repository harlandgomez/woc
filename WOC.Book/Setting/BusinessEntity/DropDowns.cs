using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Setting.BusinessEntity
{
    [Serializable]
    public  class DropDowns
    {
        private String m_Text;
        private String m_Value;

        public String Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }
        public String Text
        {
            get { return m_Text; }
            set { m_Text = value; }
        }
    }
}
