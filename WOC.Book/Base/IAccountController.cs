using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Base
{
    public interface IAccountController
    {
        String SaveData(IAccountEntity iAccountEntity);
    }
}
