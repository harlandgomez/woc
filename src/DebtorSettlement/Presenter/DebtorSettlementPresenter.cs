using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Presenter;

//Invoice
using Woc.Book.Invoice;
using Woc.Book.Invoice.BusinessEntity;

//DebtorSettlement
using Woc.Book.DebtorSettlement.BusinessEntity;

//Agent 
using Woc.Book.Agent.BusinessEntity;

namespace Woc.Book.DebtorSettlement.Presenter
{
    public class DebtorSettlementPresenter : IAccount
    {
        #region Declaration 
        IAccount iAccountPresenter;
        DebtorSettlementController debtorSettlementController;
        #endregion

          public DebtorSettlementPresenter()
        { 
        
        }
          public DebtorSettlementPresenter(IAccount iAccount)
        {
            iAccountPresenter = iAccount;
        }

          public List<DebtorSettlements> SearchData(IAccountEntity iAccount)
          {
              debtorSettlementController = new DebtorSettlementController();
              return debtorSettlementController.SearchData(iAccount);
          }
          public String SaveData(IAccountEntity iAccount)
          {

              debtorSettlementController = new DebtorSettlementController();
              return debtorSettlementController.SaveData(iAccount);
          }
          public List<Agents> GetAgent()
          {
              try
              {
                  debtorSettlementController = new DebtorSettlementController();
                  return debtorSettlementController.GetAgent();
              
              }

              catch
              
              {
                  throw;
              }
          
          }
        #region Interface

        public void SaveData(Int16 TransactionType)
        {
          
            iAccountPresenter.SaveData(1);
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
    }
}