using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.DailyTrip.BusinessEntity;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Payroll.BusinessEntity
{
    [Serializable]
    public class PayrollDTO : DriverDetailDTO, IAccountEntity
    {
        private Decimal m_Claim;

        public Decimal Claim 
        {
            get { return m_Claim; }
            set { m_Claim = value; }
        }

        public PayrollRules payrollRules = new PayrollRules();

    }
}
