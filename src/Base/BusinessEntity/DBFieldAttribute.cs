using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Base.BusinessEntity
{

    [AttributeUsage(AttributeTargets.Property,
        Inherited = true,
        AllowMultiple = false)]
    public class IsNotReportParamAttrib : System.Attribute
    {
        private bool _isNotDBField;

        public bool IsNotDBField
        {
            get { return _isNotDBField; }
            set { _isNotDBField = value; }
        }

        public IsNotReportParamAttrib(bool isTrue)
        {
            IsNotDBField = isTrue;
        }
    }
}
