using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Presenter;

//Internal
using Woc.Book.SubCon;
using Woc.Book.SubCon.BusinessEntity;

namespace Woc.Book.SubCon.Presenter
{
   public class SubConPresenter: IRegistrationPresenter
    {
       IRegistrationPresenter iRegistrationPresenter;
       SubConController subConController;
       
        public SubConPresenter()
        { 
        
        }

        public SubConPresenter(IRegistrationPresenter iRegistration)
        {
            iRegistrationPresenter = iRegistration;
        }

        public void DataBindings()
        {
            iRegistrationPresenter.DataBindings();

        }

        public void SaveData()
        {
            iRegistrationPresenter.SaveData();
        }

       public void SearchData()
       {
           iRegistrationPresenter.SearchData();
       }
       public void GetData(String Id)
       {
           iRegistrationPresenter.GetData(Id);
       }
       public void UpdateData()
       {
           iRegistrationPresenter.UpdateData();
       }
       public void DeleteData()
       {
           iRegistrationPresenter.DeleteData();
       }
       public void ResignData()
       {

       }

       public String SaveData(IBusinessEntity iBusinessEntity)
       {
           subConController = new SubConController();
           return subConController.SaveData(iBusinessEntity);
       }

       public String UpdateData(IBusinessEntity iBusinessEntity)
       {
           subConController = new SubConController();
           return subConController.UpdateData(iBusinessEntity);

       }
       public List<Subcons> SearchData(IBusinessEntity iBusinessEntity)
       {
           subConController = new SubConController();
           return subConController.SearchData(iBusinessEntity);
       }

       public void ClearControl()
       {
           iRegistrationPresenter.ClearControl();
       }

       public Subcons GetUpdateData(String loginID)
       {
           subConController = new SubConController();
           return subConController.GetUpdateData(loginID);

       }
       public String DeleteData(IBusinessEntity iBusinessEntity)
       {

           subConController = new SubConController();
           return subConController.DeleteData(iBusinessEntity);
       }

       public List<Subcons> GetDropdownInfo()
       {
           subConController = new SubConController();
           return subConController.GetDropdownInfo();
       }

    }
}
