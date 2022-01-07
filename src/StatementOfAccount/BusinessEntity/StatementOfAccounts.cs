using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.StatementOfAccount.BusinessEntity
{
    public class StatementOfAccounts : IAccountEntity
    {
       private String m_InvoiceNo;

        [IsNotReportParamAttrib(true)]
       public String InvoiceNo
       {
           get { return m_InvoiceNo; }
           set { m_InvoiceNo = value; }
       }

        private Guid m_AgentID;
        
        public Guid AgentID
        {
            get { return m_AgentID; }
            set { m_AgentID = value; }
        }

       private DateTime m_InvoiceDate;
       [IsNotReportParamAttrib(true)]
       public DateTime InvoiceDate
       {
           get { return m_InvoiceDate; }
           set { m_InvoiceDate = value; }
       }
       private DateTime m_InvoiceDateFrom;
       public DateTime InvoiceDateFrom
       {
           get { return m_InvoiceDateFrom; }
           set { m_InvoiceDateFrom = value; }
       }
       private DateTime m_InvoiceDateTo;
       public DateTime InvoiceDateTo
       {
           get { return m_InvoiceDateTo; }
           set { m_InvoiceDateTo = value; }
       }

       public Decimal m_Debit;
       [IsNotReportParamAttrib(true)]
       public  Decimal Debit
       {
           get { return m_Debit; }
           set { m_Debit = value; }
       }
       
       public Decimal m_Credit;
       [IsNotReportParamAttrib(true)]
       public Decimal Credit
       {
           get { return m_Credit; }
           set { m_Credit = value; }
       }
       public Decimal m_Balance;

       [IsNotReportParamAttrib(true)]
       public Decimal Balance
       {
           get { return m_Balance; }
           set { m_Balance = value; }
       }
       private string m_Description;
       [IsNotReportParamAttrib(true)]
       public String Description
       {
           get { return m_Description; }
           set { m_Description = value; }
       }

       private string m_Payment;
       [IsNotReportParamAttrib(true)]
       public String Payment
       {
           get { return m_Payment; }
           set { m_Payment = value; }
       }

    }
}
