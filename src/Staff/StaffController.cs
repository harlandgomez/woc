using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base;
using Woc.Book.Staff.Service;
using Woc.Book.Staff.BusinessEntity;

namespace Woc.Book.Staff
{
    internal class StaffController : IRegistrationController,IStaffController
    {
       public String SaveData(IBusinessEntity iBusinessEntity)
       {
           UtilityController utility = new UtilityController();
           StaffService staffService = new StaffService();
           Staffs staffs = (Staffs)iBusinessEntity;
           byte[] HashOut;
           byte[] SaltOut;

           utility.EncryptSaltPassword(staffs.TextBoxPassword, out HashOut, out SaltOut);
           staffs.Password = HashOut;
           staffs.Salt = SaltOut;
           return staffService.SaveData(staffs);
       }
       public String UpdateData(IBusinessEntity iBusinessEntity)
       {
           StaffService staffService = new StaffService();
           Staffs staffs = (Staffs)iBusinessEntity;

           if (staffs.TextBoxPassword.Trim() != String.Empty)
           {
               UtilityController utility = new UtilityController();

               byte[] HashOut;
               byte[] SaltOut;

               utility.EncryptSaltPassword(staffs.TextBoxPassword, out HashOut, out SaltOut);
               staffs.Password = HashOut;
               staffs.Salt = SaltOut;
           }

           return staffService.UpdateData(staffs);
       }

       public String DeleteData(IBusinessEntity iBusinessEntity)
       {
           StaffService staffService = new StaffService();
           return staffService.DeleteData(iBusinessEntity);
       }

       public String ResignData(IBusinessEntity iBusinessEntity)
       {
           StaffService staffService = new StaffService();
           return staffService.ResignData(iBusinessEntity);
       }
       public List<Staffs> SearchData(IBusinessEntity iBusinessEntity)
       {
           StaffService staffService = new StaffService();
           Staffs staffs = new Staffs();
           staffs = (Staffs)iBusinessEntity;
           string strParemeter = String.Empty;
         if (!String.IsNullOrEmpty(staffs.Address1))
         {
            strParemeter = "Address like '%" + staffs.Address1 + "%'";
         }
         else if (!String.IsNullOrEmpty(staffs.LoginID))
         {
            strParemeter = "LoginID like '%" + staffs.LoginID + "%'";
         }
         else if (!String.IsNullOrEmpty(staffs.NRIC))
         {
             strParemeter = "NRIC like '%" + staffs.NRIC + "%'";
         }
         else if (!String.IsNullOrEmpty(staffs.DOB))
         {
             strParemeter = "DOB like '%" + staffs.DOB + "%'";
         }
         else if (!String.IsNullOrEmpty(staffs.Contact))
         {
             strParemeter = "Contact like '%" + staffs.Contact + "%'";
         }
        
         if (string.IsNullOrEmpty(strParemeter))
          {
                strParemeter = strParemeter + " [Delete] <> 'Y'";
           }
         else
         {
            strParemeter = strParemeter + " and [Delete] <> 'Y'";
         }
           return staffService.SearchData(strParemeter);
       }
       public Staffs GetUpdateData(String loginID)
       {
           String strParemeter = "LoginID = '" + loginID + "'";
           StaffService staffService = new StaffService();
           return staffService.GetData(strParemeter);
       }


    }
}
