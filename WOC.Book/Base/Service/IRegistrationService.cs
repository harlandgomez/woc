using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.Base.Service
{
    public interface IRegistrationService
    {
        String SaveData(IBusinessEntity iBusinessEntity);
        String UpdateData(IBusinessEntity iBusinessEntity);
        String DeleteData(IBusinessEntity iBusinessEntity);

    }
}
