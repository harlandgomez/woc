using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base;
using Woc.Book.Company.Service;
using Woc.Book.Company.BusinessEntity;
namespace Woc.Book.Company
{
    public class CompanyController : IRegistrationController
    {
       public String SaveData(IBusinessEntity iBusinessEntity)
       {
           CompanyService CompanyService = new CompanyService();
           return CompanyService.SaveData(iBusinessEntity);
       }
       public String UpdateData(IBusinessEntity iBusinessEntity)
       {
           CompanyService CompanyService = new CompanyService();
           return CompanyService.UpdateData(iBusinessEntity);
       }

       public String DeleteData(IBusinessEntity iBusinessEntity)
       {
           CompanyService CompanyService = new CompanyService();
           return CompanyService.DeleteData(iBusinessEntity);
       }

       public List<Companies> SearchData(IBusinessEntity iBusinessEntity)
       {
           CompanyService CompanyService = new CompanyService();
           Companies Companies = new Companies();
           Companies = (Companies)iBusinessEntity;
           string strParemeter = String.Empty;
         if (!String.IsNullOrEmpty(Companies.Company))
         {
            strParemeter = "Company like '%" + Companies.Company + "%'";
         }
         else if (!String.IsNullOrEmpty(Companies.Address))
         {
            strParemeter = "Address like '%" + Companies.Address + "%'";
         }
         else if (!String.IsNullOrEmpty(Companies.Telephone))
         {
             strParemeter = "Telephone like '%" + Companies.Telephone + "%'";
         }
         else if (!String.IsNullOrEmpty(Companies.Fax))
         {
             strParemeter = "Fax like '%" + Companies.Fax + "%'";
         }
         else if (!String.IsNullOrEmpty(Companies.Email))
         {
             strParemeter = "Email like '%" + Companies.Email + "%'";
         }
         else if (!String.IsNullOrEmpty(Companies.Website))
         {
             strParemeter = "Website like '%" + Companies.Website + "%'";
         }
         else if (!String.IsNullOrEmpty(Companies.ROC))
         {
             strParemeter = "ROC like '%" + Companies.ROC + "%'";
         }
         else if (!String.IsNullOrEmpty(Companies.Prefix))
         {
             strParemeter = "CompanyID IN (Select CompanyID FROM CompanyPrefix WHERE Prefix like '%" + Companies.Prefix + "%') ";
         }
         else
         {
             strParemeter = "1=1";
         }
         strParemeter = strParemeter + " and [Delete] <> 'Y'";
           
           return CompanyService.SearchData(strParemeter);
       }
       public Companies GetUpdateData(String CompanyCode)
       {
           String strParemeter = "CompanyCode = '" + CompanyCode + "'";
           CompanyService CompanyService = new CompanyService();
           return CompanyService.GetData(strParemeter);
       }
       public List<Prefixes> GetPrefixes(Guid companyID)
       {
           CompanyService companyService = new CompanyService();
           return companyService.GetPrefixes(companyID);
       }
       public List<Companies> GetCompanyDropdownInfo()
       {
           CompanyService companyService = new CompanyService();
           return companyService.GetCompanyDropdownInfo();
       }
    }
}
