using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Common
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Presenter;
//Internal
using Woc.Book.Staff;
using Woc.Book.Staff.BusinessEntity;
namespace Woc.Book.Staff.Presenter

{
    public class StaffPresenter : IRegistrationPresenter
    {
        IRegistrationPresenter iRegistrationPresenter;
        StaffController staffController;
        public StaffPresenter()
        { 
        
        }
        public StaffPresenter(IRegistrationPresenter iRegistration)
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
            iRegistrationPresenter.ResignData();

        }
        public String SaveData(IBusinessEntity iBusinessEntity)
        {
           staffController = new StaffController();
           return staffController.SaveData(iBusinessEntity);    
        }
        public String UpdateData(IBusinessEntity iBusinessEntity)
        {
            staffController = new StaffController();
            return staffController.UpdateData(iBusinessEntity);
        }
        public String DeleteData(IBusinessEntity iBusinessEntity)
        {
            staffController = new StaffController();
            return staffController.DeleteData(iBusinessEntity);
        }
        public String ResignData(IBusinessEntity iBusinessEntity)
        {
            staffController = new StaffController();
            return staffController.ResignData(iBusinessEntity);
        }

        public void SearchData()
        {
            iRegistrationPresenter.SearchData();
        }

        public void GetData(String Id)
        {
            iRegistrationPresenter.GetData(Id);

        }

        public List<Staffs> SearchData(IBusinessEntity iBusinessEntity)
        {
            staffController = new StaffController();
            return staffController.SearchData(iBusinessEntity);
        }
        public void ClearControl()
        {
            iRegistrationPresenter.ClearControl();  
        }

        public Staffs GetUpdateData(String loginID)
        {
             staffController = new StaffController();
            return staffController.GetUpdateData(loginID);

        }
    }
}
