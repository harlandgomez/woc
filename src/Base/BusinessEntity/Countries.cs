using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Base.BusinessEntity
{
    [Serializable]
    public class Countries : IBusinessEntity
    {
        private Guid countryID;
        public Guid CountryID
        {
            get
            {
                return countryID;
            }
            set
            {
                countryID = value;
            }
        }

        private String country;
        public String Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }
    }
}
