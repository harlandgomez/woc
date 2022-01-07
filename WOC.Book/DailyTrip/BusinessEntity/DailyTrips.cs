using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Adhoc;
using Woc.Book.Adhoc.BusinessEntity;

using Woc.Book.Contract;
using Woc.Book.Contract.BusinessEntity;

using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.DailyTrip.BusinessEntity
{
    public class DailyTrips : DailyTripsDTO, IOperation
    {
       public List<Adhocs> ListAdhoc = new List<Adhocs>();

       public List<DriverDetailDTO> ListDriverDetailDTO = new List<DriverDetailDTO>();

    }
}
