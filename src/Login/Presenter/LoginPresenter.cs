using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Login.Service;
namespace Woc.Book.Login.Presenter
{
    public class LoginPresenter : ILogin
    {
        ILogin iLoginPresenter;
     public LoginPresenter()
    {
    }

     public LoginPresenter( ILogin ilogin)
     {
         iLoginPresenter = ilogin;
        
     }
     public void Logging()
     {

         iLoginPresenter.Logging();
     }
     public String Login(String userID, String password)
     {
         LoginController loginCotroller = new LoginController();
         return loginCotroller.Login(userID, password);
     }

     public String LoginCustomer(String userID, String password)
     {
         LoginController loginCotroller = new LoginController();
         return loginCotroller.LoginCustomer(userID, password);
     }

     public void Authenticate()
     {

     }
    }
}
