using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base;
//Internal
using Woc.Book.Bus.Service;
using Woc.Book.Bus.BusinessEntity;
namespace Woc.Book.Bus
{
  internal  class BusController:IRegistrationController
    {
        public String SaveData(IBusinessEntity iBusinessEntity)
        {

            BusService busService = new BusService();
            return busService.SaveData(iBusinessEntity);

        }

        public String UpdateData(IBusinessEntity iBusinessEntity)
        {

            BusService busService = new BusService();
            return busService.UpdateData(iBusinessEntity);
        }

        public String DeleteData(IBusinessEntity iBusinessEntity)
        {

            BusService busService = new BusService();
            return busService.DeleteData(iBusinessEntity);

        }
        public List<Buses> SearchData(IBusinessEntity iBusinessEntity)
        {
            BusService busService = new BusService();


            Buses buses = new Buses();
            buses = (Buses)iBusinessEntity;
            string strParemeter = String.Empty;
            if (!String.IsNullOrEmpty(buses.BusCode))
            {
                strParemeter = "BusNo like '%" + buses.BusCode + "%'";
            }

            else if (!String.IsNullOrEmpty(buses.Seater.ToString()))
            {
                if (Convert.ToInt32(buses.Seater) > 0)
                {
                    strParemeter = "Seater like '%" + buses.Seater + "%'";
                }
            }

            else if (!String.IsNullOrEmpty(buses.CompanyNameSearch))
            {
                strParemeter = "CompanyID in (SELECT CompanyID FROM Company WHERE Company like '%" + buses.CompanyNameSearch + "%') ";
            }

            else if (!String.IsNullOrEmpty(buses.Brand))
            {
                strParemeter = "Brand like '%" + buses.Brand + "%'";
            }

            else if (!String.IsNullOrEmpty(buses.Year))
            {
                strParemeter = "Year like '%" + buses.Year + "%'";
            }

            else if (!String.IsNullOrEmpty(buses.Parking))
            {
                strParemeter = "Parking like '%" + buses.Parking + "%'";
            }


            if (string.IsNullOrEmpty(strParemeter))
            {
                strParemeter = strParemeter + " Bus.[Delete] <> 'Y'";
            }
            else
            {
                strParemeter = strParemeter + " and Bus.[Delete] <> 'Y'";
            }

            return busService.SearchData(strParemeter);
        }

        public Buses GetUpdateData(String driverCode)
        {
            String strParemeter = "BusCode = '" + driverCode + "'";
            BusService busService = new BusService();
            return busService.GetData(strParemeter);
        }
        public List<Buses> GetAllBuses()
        {
            BusService busService = new BusService();
            return busService.GetData();
        }
    }
}
