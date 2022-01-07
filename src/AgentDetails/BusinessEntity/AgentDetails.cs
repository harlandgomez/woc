using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.AgentDetails.BusinessEntity
{
  public class AgentDetails
    {
        string m_RefNumber;
        public string RefNumber
        {
            get { return m_RefNumber; }
            set { m_RefNumber = value; }
        }
    }
}
