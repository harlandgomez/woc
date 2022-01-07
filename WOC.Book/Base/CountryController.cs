using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;
using System.Data;

namespace Woc.Book.Base
{
   public class CountryController
    {
       public List<Countries> GetCountryDropdownInfo()
       {
           CountryService countryService = new CountryService();
           List<Countries> ListCountries = new List<Countries>();
           DataTable table = new DataTable();
           table = countryService.GetCountryDropdownInfo();
           Countries countries;
           foreach (DataRow row in table.Rows)
           {
               countries = new Countries();
               countries.CountryID = (Guid)row["CountryID"];
               countries.Country = row["Country"].ToString();
               ListCountries.Add(countries);
           }
           return ListCountries;
       }
     
       public Guid GetDefaultCountryID()
       {
           CountryService countryService = new CountryService();
           return countryService.GetDefaultCountryID("DEFAULT_COUNTRY");
       }
    }
}
