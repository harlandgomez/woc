using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.DailyTrip.Constant
{
    public class Constant
    {
        public const String recordFoundMessage = "{0} record(s) found for this date.";
        public const String revisionDelimiter = "-R";
        public const Int16 DriverRowCount = 20;
        public const Int16 SubConRowCount = 50;

        public enum GvDailyTripKeys
        {
            TripID = 0,
            OperationType = 1,
            TripFrom = 2,
            TripTo = 3,
            TripType = 4,
            RefNo = 5
        }
    }
}
