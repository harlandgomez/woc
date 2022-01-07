using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Base.Presenter
{
    public class SequencePresenter
    {
        public String GetNextSequence(String columnCode)
        {
            SequenceController sequenceController = new SequenceController();
            return sequenceController.GetNextSequence(columnCode);

        }
    }
}
