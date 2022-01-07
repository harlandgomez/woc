using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base;

namespace Woc.Book.Base.Presenter
{
   public class UserPresenter
    {
       public Guid GetLoginID(String userID)
       {
           UserController userController = new UserController();
           return userController.GetLoginID(userID);
       }

    }
}
