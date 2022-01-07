using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.Base
{
  public interface IOperationController
    {
      void SaveData(IOperation iOperation);

      String UpdateData(IOperation iOperation);

      String DeleteData(IOperation iOperation);
    }
}
