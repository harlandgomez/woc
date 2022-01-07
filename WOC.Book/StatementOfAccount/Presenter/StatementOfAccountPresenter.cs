using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Presenter;

//Woc.Book.StatementOfAccount
using Woc.Book.StatementOfAccount.BusinessEntity;
using Woc.Book.Agent.BusinessEntity;

namespace Woc.Book.StatementOfAccount.Presenter
{
    public class StatementOfAccountPresenter : IAccount
    {
       IAccount iAccountPresenter;
       StatementOfAccountController statementOfAccountController;
       public StatementOfAccountPresenter()
       { 
       
       }
       public StatementOfAccountPresenter(IAccount iAccount)
       {
           iAccountPresenter = iAccount;
       }

       #region Interface

       public void SaveData(Int16 TransactionType)
       {
           iAccountPresenter.SaveData(0);
       }

       public void SearchData()
       {
           iAccountPresenter.SearchData();
       }

       public void DataBindings()
       {
           iAccountPresenter.DataBindings();
       }

       #endregion

       public List<StatementOfAccounts> SearchData(IAccountEntity iAccount)
       {
           statementOfAccountController = new StatementOfAccountController();
           return statementOfAccountController.SearchData(iAccount);
       }

       public List<SalesReportbyCustomers> SearchDataSales(IAccountEntity iAccount)
       {
           statementOfAccountController = new StatementOfAccountController();
           return statementOfAccountController.SearchDataSales(iAccount);
       }
       public List<Agents> GetAgents()
       {
           statementOfAccountController = new StatementOfAccountController();
           return statementOfAccountController.GetAgents();
       }

    }
}
