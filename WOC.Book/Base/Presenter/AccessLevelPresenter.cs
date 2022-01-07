using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Base.Presenter
{
  public class AccessLevelPresenter
    {

      public List<AccessLevels> GetAccessLevel()
      {
          AccessLevelController accessLevelController = new AccessLevelController();
          return accessLevelController.GetData();

      }
    }
}
