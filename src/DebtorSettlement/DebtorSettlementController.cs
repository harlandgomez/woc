using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Common
using Woc.Book.Base.Presenter;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base;


//DebtorSettlement
using Woc.Book.DebtorSettlement.BusinessEntity;
using Woc.Book.DebtorSettlement.Service;

//Agent 
using Woc.Book.Agent.BusinessEntity;

namespace Woc.Book.DebtorSettlement
{
    internal class DebtorSettlementController
    {
        public List<DebtorSettlements> SearchData(IAccountEntity iAccount)
        {
            try
            {
                DebtorSettlementService debtorSettlementService = new DebtorSettlementService();
                DebtorSettlementDTO debtorSettlementDTO = new DebtorSettlementDTO();
                debtorSettlementDTO = (DebtorSettlementDTO)iAccount;
                return debtorSettlementService.SearchData(debtorSettlementDTO.AgentID.ToString(),debtorSettlementDTO.InvoiceCode);
            }

            catch
            {
                throw;
            }
        }

        public String SaveData(IAccountEntity iAccount)
        {
            try
            {
                DebtorSettlementService debtorSettlementService = new DebtorSettlementService();

                return debtorSettlementService.SaveData(iAccount);
            }

            catch 
            {
                throw;
            }
        }
        public List<Agents> GetAgent()
        {
            try
            {
              DebtorSettlementService debtorSettlementService = new DebtorSettlementService();
              return debtorSettlementService.GetAgent();

            }

            catch
            
            {
                return null;
                throw;
            
            }
        }
    }
}
