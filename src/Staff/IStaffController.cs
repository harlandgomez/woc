using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Staff.BusinessEntity;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Staff
{
 internal   interface IStaffController
    {
     Staffs GetUpdateData(String loginID);
     List<Staffs> SearchData(IBusinessEntity iBusinessEntity);
    }
}
