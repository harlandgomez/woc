using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base;
//Internal
using Woc.Book.Driver.Service;
using Woc.Book.Driver.BusinessEntity;

namespace Woc.Book.Driver
{
   public class DriverController:IRegistrationController
    {
        public String SaveData(IBusinessEntity iBusinessEntity)
        {

            DriverService driverService = new DriverService();
            return driverService.SaveData(iBusinessEntity);

        }

        public String UpdateData(IBusinessEntity iBusinessEntity)
        {

            DriverService driverService = new DriverService();
            return driverService.UpdateData(iBusinessEntity);
        }

        public String DeleteData(IBusinessEntity iBusinessEntity)
        {

            DriverService driverService = new DriverService();
            return driverService.DeleteData(iBusinessEntity);

        }
        public List<Drivers> SearchData(IBusinessEntity iBusinessEntity)
        {
            DriverService driverService = new DriverService();


            Drivers drivers = new Drivers();
            drivers = (Drivers)iBusinessEntity;
            string strParemeter = String.Empty;
            if (!String.IsNullOrEmpty(drivers.Address1))
            {
                strParemeter = "Address like '%" + drivers.Address1 + "%'";
            }
            
            else  if (!String.IsNullOrEmpty(drivers.DriverName))
            {
                strParemeter = "DriverName like '%" + drivers.DriverName + "%'";
            } 

            else  if (!String.IsNullOrEmpty(drivers.FIN))
            {
                strParemeter = "FIN like '%" + drivers.FIN + "%'";
            } 

             else  if (!String.IsNullOrEmpty(drivers.DOB))
            {
                strParemeter = "DOB like '%" + drivers.DOB + "%'";
            } 

             else  if (!String.IsNullOrEmpty(drivers.Contact))
            {
                strParemeter = "Contact like '%" + drivers.Contact + "%'";
            }
            else
            {
                strParemeter = "1=1";
            }
            strParemeter = strParemeter + " and [Delete] <> 'Y'";

            return driverService.SearchData(strParemeter);
        }

        public Drivers GetUpdateData(String driverCode)
        {
            String strParemeter = "driverCode = '" + driverCode + "'";
            DriverService driverService = new DriverService();
            return driverService.GetData(strParemeter);
        }
    }
}
