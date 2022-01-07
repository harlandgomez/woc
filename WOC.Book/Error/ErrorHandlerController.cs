using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.ErrorHandler.Service;
namespace Woc.Book.ErrorHandler
{
  public class ErrorHandlerController
    {
      public void SaveData(IBusinessEntity iBusinessEntity)
      {
          ErrorHandlerService errorHandlerService = new ErrorHandlerService();
          errorHandlerService.SaveData(iBusinessEntity);
      }
    }
}
