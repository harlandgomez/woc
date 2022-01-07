using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;
using System.Data;
namespace Woc.Book.Base
{
    public class SequenceController
    {
        public String GetNextSequence(String columnCode)
        {
            SequenceService sequenceService = new SequenceService();
            String nextSequence = sequenceService.GetNextSequence(columnCode);
            return nextSequence;
        }
    }
}
