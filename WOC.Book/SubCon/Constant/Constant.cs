using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.SubCon.Constant
{
  internal static  class Constant
    {
      public const String MessageSaved = "Successfully Saved!";
      public const String MessageUnSaved = "Unsuccessfully Saved!";
      public enum gridViewIndex
      {
          Company = 0,
          Initial = 1,
          Person = 2,
          Mobile = 3,
          Telephone = 4,
          Fax = 5,
          Address = 6,
          linkSelect = 7
      }
    }
}
