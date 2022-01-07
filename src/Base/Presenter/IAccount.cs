using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Base.Presenter
{
    public interface IAccount
    {
        void SaveData(Int16 TransactionType);
        void DataBindings();
        void SearchData();
    }
}
