using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.Base
{
   public interface INewBookingController
    {
       String SaveData(INewBookEntity iBusinessEntity);

       String UpdateData(INewBookEntity iBusinessEntity);

       String DeleteData(INewBookEntity iBusinessEntity);
    }
}
