using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.BusinessEntity;

//Invoice
using Woc.Book.Invoice;
using Woc.Book.Invoice.BusinessEntity;

namespace Woc.Book.DebtorSettlement.BusinessEntity
{
  public class DebtorSettlements:Invoices
    {
      private string m_CNLinkLabel;
      private decimal m_CNAmount;
      private decimal m_AmountDue;
      private decimal m_AllocationForex;


     
      public string CNLinkLabel
      {
          get { return m_CNLinkLabel; }
          set { m_CNLinkLabel = value; }
      }
      public Decimal CNAmount
      {
          get { return m_CNAmount; }
          set { m_CNAmount = value; }
      }

      public decimal AmountDue
      {
          get { return m_AmountDue; }
          set { m_AmountDue = value; }
      }

      public decimal AllocationForex
      {
          get { return m_AllocationForex; }
          set { m_AllocationForex = value; }
      }
    }
}
