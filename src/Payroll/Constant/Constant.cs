using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Payroll.Constant
{
    public class Constant
    {
        public enum GridRuleColumn
        {
            TimeFactor = 0,
            FromDate = 1,
            ToDate = 2,
            Operator = 3,
            Amount = 4,
            CheckDelete = 5

        }
        public enum GridRuleKeys
        {
            RuleID = 0
        }

        public const String TimeFactorList = "ACCOUNTS_TIME_FACTOR_LIST";
        public const String DayOfWeekList = "DAYOFWEEK_LIST";
        public const String OperatorList = "OPERATOR_LIST";

        public enum TransactionMode
        {
            SaveRules = 0
        }

        public const String MessageDeleted = "Rule(s) successfully deleted";
        public const String MessageUndeleted = "Rule(s) unsuccessfully deleted due to error: {0} ";

    }
}
