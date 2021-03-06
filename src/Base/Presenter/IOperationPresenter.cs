using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Base.Presenter
{
   public interface IOperationPresenter
    {
        void DataBindings();
        void SaveData();
        void ClearControl();
        void SearchData();
        void GetData(String Id);
        void UpdateData();
        void DeleteData();
    }
}
