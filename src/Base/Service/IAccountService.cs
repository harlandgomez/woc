using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.Base.Service
{
    public interface IAccountService
    {
        String SaveData(IAccountEntity iAccountEntity);
    }
}
