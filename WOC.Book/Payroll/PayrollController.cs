using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Payroll.Service;
using Woc.Book.Payroll.BusinessEntity;
using Woc.Book.Base;

namespace Woc.Book.Payroll
{
    public class PayrollController: IAccountController
    {
        PayrollService payrollService;

        public List<PayrollRules> GetRules()
        {
            payrollService = new PayrollService();
            return payrollService.GetRules();
        }

        public string SaveData(Base.BusinessEntity.IAccountEntity iAccountEntity)
        {
            return string.Empty;
        }
        public String SaveRules(List<PayrollRules> listPayrollRule)
        {
            payrollService = new PayrollService();
            return payrollService.SaveRules(listPayrollRule);
        }

        public List<PayrollDTO> SearchData(Base.BusinessEntity.IAccountEntity iAccountEntity)
        {
            payrollService = new PayrollService();
            return payrollService.SearchData(iAccountEntity);
        }

        public String DeleteRules(List<PayrollRules> listPayrollRule)
        {
            payrollService = new PayrollService();
            return payrollService.DeleteRules(listPayrollRule);
        }
    }

}
