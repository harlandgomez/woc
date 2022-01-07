using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Common.BusinessEntity;
namespace Woc.Book.Company.Presenter
{
   public interface ICompany
    {
       void DataBindings();
       void SaveData();
       void ClearControl();
       void SearchData();
       void GetData(String loginID);
       void UpdateData();
       void DeleteData();
       void ResignData();

    }
}
