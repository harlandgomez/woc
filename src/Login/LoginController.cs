using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Login.Service;
using Woc.Book.Staff.BusinessEntity;
using Woc.Book.Base;
using Woc.Book.Agent.Service;
using Woc.Book.Agent.BusinessEntity;
namespace Woc.Book.Login
{
    public class LoginController
    {
        public LoginController()
        { 

        }

        public String Login(String userID, String password)
        {
            LoginService loginService = new LoginService();
            UtilityController utility = new UtilityController();

            Staffs staffs = loginService.Login(userID);
            if (utility.VerifySaltPassword(password, staffs.Password, staffs.Salt))
            {
                return Constant.Constant.Valid;
            }
            else
            {
                return Constant.Constant.Invalid;
            }
        }

        public String LoginCustomer(String userID, String password)
        {
            AgentService agentService = new AgentService();
            UtilityController utility = new UtilityController();

            Agents agents = agentService.GetPasswordSaltByUserID(userID);
            if (utility.VerifySaltPassword(password, agents.Password, agents.Salt))
            {
                return Constant.Constant.Valid;
            }
            else
            {
                return Constant.Constant.Invalid;
            }
        }

        public bool CheckUserNameExists(String userID)
        {
            LoginService loginService = new LoginService();
            return loginService.CheckUserNameExists(userID);
        }



    }
}
