using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Company;
using Woc.Book.Company.BusinessEntity;
using Woc.Book.Base.Presenter;

namespace Woc.Book.Company.Presenter

{
    public class CompanyPresenter: IRegistrationPresenter
    {
        IRegistrationPresenter IRegistrationPresenterPresenter;
        CompanyController companyController;
        public CompanyPresenter()
        { 
        
        }
        public CompanyPresenter(IRegistrationPresenter IRegistrationPresenter)
        {
            IRegistrationPresenterPresenter = IRegistrationPresenter;
        }
        public void DataBindings()
        {
            IRegistrationPresenterPresenter.DataBindings();
        }

        public void SaveData()
           {
                IRegistrationPresenterPresenter.SaveData();
    
           }
        public void UpdateData()
        {
            IRegistrationPresenterPresenter.UpdateData();

        }
        public void ResignData()
        {

        }

        public void DeleteData()
        {
            IRegistrationPresenterPresenter.DeleteData();

        }
        public String SaveData(IBusinessEntity iBusinessEntity)
        {
           companyController = new CompanyController();
           return companyController.SaveData(iBusinessEntity);    
        }
        public String UpdateData(IBusinessEntity iBusinessEntity)
        {
            companyController = new CompanyController();
            return companyController.UpdateData(iBusinessEntity);
        }
        public String DeleteData(IBusinessEntity iBusinessEntity)
        {
            companyController = new CompanyController();
            return companyController.DeleteData(iBusinessEntity);
        }


        public void SearchData()
        {
            IRegistrationPresenterPresenter.SearchData();
        }

        public void GetData(String loginID)
        {
            IRegistrationPresenterPresenter.GetData(loginID);

        }

        public List<Companies> SearchData(IBusinessEntity iBusinessEntity)
        {
            companyController = new CompanyController();
            return companyController.SearchData(iBusinessEntity);
        }
        public void ClearControl()
        {
            IRegistrationPresenterPresenter.ClearControl();  
        }

        public Companies GetUpdateData(String loginID)
        {
             companyController = new CompanyController();
            return companyController.GetUpdateData(loginID);

        }

        public List<Prefixes> GetPrefixes(Guid companyID)
        {
            companyController = new CompanyController();
            return companyController.GetPrefixes(companyID);
        }

        public List<Companies> GetCompanyDropdownInfo()
        {
            companyController = new CompanyController();
            return companyController.GetCompanyDropdownInfo();
        }
    }
}
