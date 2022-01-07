using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Woc.Book.Base.Service
{
    public static class UtilityService
    {

        public static string Connection()
        {
            String conn = ConfigurationManager.ConnectionStrings["MainConnString"].ConnectionString;
           // string conn = @"Data Source=Napster-PC;Initial Catalog=ANS;Integrated Security=True";
            return conn;
        }

       
    }
}
