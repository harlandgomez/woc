using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Common.BusinessEntity;
using Woc.Book.Common;

namespace Woc.Book.Common
{
  public  interface ICommonController
    {
        String SaveData(IBusinessEntity iBusinessEntity);
       
    }
}
