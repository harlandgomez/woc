using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base;
//Internal
using Woc.Book.SubCon.Service;
using Woc.Book.SubCon.BusinessEntity;

namespace Woc.Book.SubCon
{
 internal  class SubConController:IRegistrationController
    {

        public String SaveData(IBusinessEntity IBusinessEntity)
        {

            SubConService SubConService = new SubConService();
            return SubConService.SaveData(IBusinessEntity);

        }

        public String UpdateData(IBusinessEntity IBusinessEntity)
        {

            SubConService SubConService = new SubConService();
            return SubConService.UpdateData(IBusinessEntity);
        }

        public String DeleteData(IBusinessEntity IBusinessEntity)
        {

            SubConService SubConService = new SubConService();
            return SubConService.DeleteData(IBusinessEntity);

        }
        public List<Subcons> SearchData(IBusinessEntity IBusinessEntity)
        {
            SubConService SubConService = new SubConService();


            Subcons subcons = new Subcons();
            subcons = (Subcons)IBusinessEntity;
            string strParemeter = String.Empty;
            if (!String.IsNullOrEmpty(subcons.Company))
            {
                strParemeter = "Company like '%" + subcons.Company + "%'";
            }
            else if (!String.IsNullOrEmpty(subcons.Initial))
            {
                strParemeter = "Initial like '%" + subcons.Initial + "%'";
            }
            else if (!String.IsNullOrEmpty(subcons.Person))
            {
                strParemeter = "Person like '%" + subcons.Company + "%'";
            }
            else if (!String.IsNullOrEmpty(subcons.Mobile))
            {
                strParemeter = "Mobile like '%" + subcons.Mobile + "%'";
            }
            else if (!String.IsNullOrEmpty(subcons.Telephone))
            {
                strParemeter = "Telephone like '%" + subcons.Telephone + "%'";
            }
            else if (!String.IsNullOrEmpty(subcons.Fax))
            {
                strParemeter = "Fax like '%" + subcons.Fax + "%'";
            }
            else if (!String.IsNullOrEmpty(subcons.Fax))
            {
                strParemeter = "Address like '%" + subcons.Address + "%'";
            }
            else
            {
                strParemeter = "1=1";
            }
            strParemeter = strParemeter + " and [Delete] <> 'Y'";

            return SubConService.SearchData(strParemeter);
        }

        public Subcons GetUpdateData(String subConCode)
        {
            String strParemeter = "SubconCode = '" + subConCode + "'";
            SubConService SubConService = new SubConService();
            return SubConService.GetData(strParemeter);
        }

        public List<Subcons> GetDropdownInfo()
        {
            SubConService SubConService = new SubConService();
            return SubConService.GetDropdownInfo();
        }
    }
}
