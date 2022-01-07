using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.Base
{
    public interface IRegistrationController
    {
         String SaveData(IBusinessEntity iBusinessEntity);
        
         String UpdateData(IBusinessEntity iBusinessEntity);

         String DeleteData(IBusinessEntity iBusinessEntity);
    }
}
