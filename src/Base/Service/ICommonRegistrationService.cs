using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Common.BusinessEntity;
namespace Woc.Book.Common.Service
{
 public   interface ICommonRegistrationService
    {
     String SaveData(IBusinessEntity iBusinessEntity);
    }
}
