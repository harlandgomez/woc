using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Base.Presenter
{
    public interface IAdminPresenter
    {
        void DataBindings();
        void SaveData();
        void ClearControl();
        void SearchData();
        void GetData(Guid Id);
        void UpdateData();
        void DeleteData();
    }
}
