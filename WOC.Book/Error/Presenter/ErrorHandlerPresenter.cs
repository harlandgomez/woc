using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.ErrorHandler.Presenter
{
  public  class ErrorHandlerPresenter
    {
      public ErrorHandlerPresenter()
      {
      }
      public void SaveData(IBusinessEntity iBusinessEntity)
      {
           ErrorHandlerController errorHandlerController = new ErrorHandlerController();
           errorHandlerController.SaveData(iBusinessEntity);
      }

    }
}
