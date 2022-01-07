using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Adhoc.Constant
{
   public class Constant
    {
        public const String MessageSaved = "Successfully Saved";
        public const String MessageUnSaved = "Unsuccessfully saved";
        public const String BookingMessageSaved = "Successfully saved booking number {0}";
        public const String AdhocCode = "AdhocCode";

        public enum SearchCategory{
            All = 0,
            Pending = 1,
            Confirm = 2
        }

        public enum gridViewColumn
        {
            DeleteImage = 8,
            EditImage = 9
        }

        public enum gvPendingColumn
        {
            Agent = 0,
            Date = 1,
            PersonInCharge = 2,
            Status = 7,
            RefNo = 8,
            Checkbox = 9
        }

        public enum GvPendingDataKeyNames
        {
            RefNo = 0
        }
    }
}
