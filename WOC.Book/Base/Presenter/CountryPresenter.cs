using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Base.Presenter
{
  public class CountryPresenter
    {
        public List<Countries> GetCountryDropdownInfo()
        {
            CountryController countryController = new CountryController();
            return countryController.GetCountryDropdownInfo();

        }

        public Guid GetDefaultCountryID()
        {
            CountryController countryController = new CountryController();
            return countryController.GetDefaultCountryID();
        }
    }
}
