using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.Base
{
    public interface IAdminController
    {
        String SaveData(IAdminEntity iAdminEntity);

        String UpdateData(IAdminEntity iAdminEntity);

        String DeleteData(IAdminEntity iAdminEntity);
    }
}
