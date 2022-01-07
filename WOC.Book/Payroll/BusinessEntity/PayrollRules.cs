using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Payroll.BusinessEntity
{
[Serializable]
public class PayrollRules: IAccountEntity
{
	private Guid m_RuleID;
	private int m_TimeFactorID;
	private DateTime m_StartDate;
	private DateTime m_EndDate;
	private string m_StartTime;
	private string m_EndTime;
	private string m_StartDay;
	private string m_EndDay;
	private string m_Operator;
	private decimal m_Amount;
    private int m_SortOrder;
 
	public Guid RuleID
	{
		get { return m_RuleID; }
		set { m_RuleID = value; }
	}
	public int TimeFactorID
	{
		get { return m_TimeFactorID; }
		set { m_TimeFactorID = value; }
	}
    public int SortOrder
    {
        get { return m_SortOrder; }
        set { m_SortOrder = value; }
    }
	public DateTime StartDate
	{
		get { return m_StartDate; }
		set { m_StartDate = value; }
	}
	public DateTime EndDate
	{
		get { return m_EndDate; }
		set { m_EndDate = value; }
	}
	public string StartTime
	{
		get { return m_StartTime; }
		set { m_StartTime = value; }
	}
	public string EndTime
	{
		get { return m_EndTime; }
		set { m_EndTime = value; }
	}
	public string StartDay
	{
		get { return m_StartDay; }
		set { m_StartDay = value; }
	}
	public string EndDay
	{
		get { return m_EndDay; }
		set { m_EndDay = value; }
	}
	public string Operator
	{
		get { return m_Operator; }
		set { m_Operator = value; }
	}
	public decimal Amount
	{
		get { return m_Amount; }
		set { m_Amount = value; }
	}

}


}
