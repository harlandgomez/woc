using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Woc.Book.Setting.Service;
using Woc.Book.Setting.BusinessEntity;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base;

namespace Woc.Book.Setting
{
    internal class SettingController: IAdminController
    {
        public String GetSettingValue(String settingCode)
        {
            SettingService settingService = new SettingService();
            return settingService.GetSettingValue(settingCode);
        }

        public List<DropDowns> GetDropdownValues(String settingCode)
        {
            List<DropDowns> ListDropDown = new List<DropDowns>();
            DropDowns dropDowns = new DropDowns();
          

            SettingService settingService = new SettingService();
            string value = settingService.GetSettingValue(settingCode);
            
            if (value.IndexOf(",") > 0 && value.IndexOf("|") > 0)
            {
                string[] values = value.Split(new Char [] {','});

                foreach (String v in values)
                {
                    string[] split = v.Split(new Char [] {'|'});

                    dropDowns.Text = split[0];
                    dropDowns.Value = split[1];
                    ListDropDown.Add(dropDowns);
                    dropDowns = new DropDowns();
                }
            }
           
            return ListDropDown;
        }

        public String SaveData(IAdminEntity iAdminEntity)
        {
            SettingService settingService = new SettingService();
            return settingService.SaveData(iAdminEntity);
        }

        public List<Settings> SearchData(IAdminEntity iAdminEntity)
        {
            SettingService settingService = new SettingService();
            Settings settings = new Settings();
            settings = (Settings)iAdminEntity;
            string strParemeter = String.Empty;
            if (!String.IsNullOrEmpty(settings.SettingCode))
            {
                strParemeter = "SettingCode like '%" + settings.SettingCode + "%'";
            }
            else if (!String.IsNullOrEmpty(settings.Value))
            {
                strParemeter = "Value like '%" + settings.Value + "%'";
            }
            else if (!String.IsNullOrEmpty(settings.DefaultValue))
            {
                strParemeter = "DefaultValue like '%" + settings.DefaultValue + "%'";
            }
            else if (!String.IsNullOrEmpty(settings.Description))
            {
                strParemeter = "Description like '%" + settings.Description + "%'";
            }
            else
            {
                strParemeter = "1=1";
            }
            return settingService.SearchData(strParemeter);
        }

        public string DeleteData(IAdminEntity iAdminEntity)
        {
            return "";
        }
        public String UpdateData(IAdminEntity iAdminEntity)
        {
            SettingService settingService  = new SettingService();
            return settingService.UpdateData(iAdminEntity);
        }

        public Settings GetUpdateData(Guid id)
        {
            String strParemeter = "SettingID = '" + id.ToString() + "'";
            SettingService settingService = new SettingService();
            return settingService.GetData(strParemeter);
        }
    }
}
