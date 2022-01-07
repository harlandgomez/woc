using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Woc.Book.Base.Service;
using Woc.Book.Base;

namespace Woc.Book.Base
{
    public class UserController
    {
        public Guid GetLoginID(String userID)
        {
            UserService userService = new UserService();
            return userService.GetLoginID(userID);
        }
    }
}
