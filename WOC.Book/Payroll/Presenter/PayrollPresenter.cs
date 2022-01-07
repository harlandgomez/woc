using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.Presenter;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Payroll.BusinessEntity;

namespace Woc.Book.Payroll.Presenter
{
    public class PayrollPresenter: IAccount
    {
        IAccount iAccount;
        PayrollController payrollController;

        public PayrollPresenter()
        { 
        
        }
        public PayrollPresenter(IAccount iAccountPresenter)
        {
            iAccount = iAccountPresenter;
        }

        public void SaveData(short TransactionType)
        {
            iAccount.SaveData(TransactionType);
        }

        public void DataBindings()
        {
            iAccount.DataBindings();
        }

        public void SearchData()
        {
            iAccount.SearchData();
        }

        public List<PayrollRules> GetRules()
        {
            payrollController = new PayrollController();
            return payrollController.GetRules();
        }

        public String SaveRules(List<PayrollRules> listPayrollRule)
        {
            payrollController = new PayrollController();
            return payrollController.SaveRules(listPayrollRule);
        }

        public List<PayrollDTO> SearchData(Base.BusinessEntity.IAccountEntity iAccountEntity)
        {
            payrollController = new PayrollController();
            return payrollController.SearchData(iAccountEntity);
        }

        public String DeleteRules(List<PayrollRules> listPayrollRule)
        {
            payrollController = new PayrollController();
            return payrollController.DeleteRules(listPayrollRule);
        }
    }
}
