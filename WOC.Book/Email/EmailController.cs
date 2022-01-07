using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

using Woc.Book.Email.BusinessEntity;

namespace Woc.Book.Email
{
    public class EmailController
    {
        public Emails GetEmail()
        {
            Emails emails = new Emails();
            return emails;
        }
    }
}
