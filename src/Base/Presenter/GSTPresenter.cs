using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Base.Presenter
{
    public class GSTPresenter
    {
        public List<GSTtypes> GetGSTTypes()
        {
            GSTController GSTController = new GSTController();
            return GSTController.GetGSTTypes();
        }
    }
}
