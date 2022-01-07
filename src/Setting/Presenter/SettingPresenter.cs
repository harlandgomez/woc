using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

//WOC
using Woc.Book.Setting;
using Woc.Book.Setting.BusinessEntity;
using Woc.Book.Base.Presenter;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Setting.Presenter
{
    public class SettingPresenter: IAdminPresenter
    {
        IAdminPresenter iAdminPresenter;
        SettingController settingController;

        public SettingPresenter()
        {
        }

        public SettingPresenter(IAdminPresenter iAdmin)
        {
            iAdminPresenter = iAdmin;
        }
        public String GetSettingValue(String settingCode)
        {
            settingController = new SettingController();
            return settingController.GetSettingValue(settingCode);
        }

        public List<DropDowns> GetDropdownValues(String settingCode)
        {
            settingController = new SettingController();
            return settingController.GetDropdownValues(settingCode);
        }

        public String SaveData(IAdminEntity iAdminEntity)
        {
            settingController = new SettingController();
            return settingController.SaveData(iAdminEntity);
        }

        public List<Settings> SearchData(IAdminEntity iAdminEntity)
        {
            settingController = new SettingController();
            return settingController.SearchData(iAdminEntity);
        }

        public Settings GetUpdateData(Guid id)
        {
            settingController = new SettingController();
            return settingController.GetUpdateData(id);
        }
        public string UpdateData(IAdminEntity iAdminEntity)
        {
            settingController = new SettingController();
            return settingController.UpdateData(iAdminEntity);
        }

        public void DataBindings()
        {
            iAdminPresenter.DataBindings();
        }

        public void SaveData()
        {
            iAdminPresenter.SaveData();
        }

        public void ClearControl()
        {
            iAdminPresenter.ClearControl();
        }

        public void SearchData()
        {
            iAdminPresenter.SearchData();
        }

        public void GetData(Guid Id)
        {
            iAdminPresenter.GetData(Id);
        }

        public void UpdateData()
        {
            iAdminPresenter.UpdateData();
        }

        public void DeleteData()
        {
            iAdminPresenter.DeleteData();
        }
       

    }
}
