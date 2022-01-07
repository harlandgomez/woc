using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;

namespace Woc.Book.Setting.BusinessEntity
{
    [Serializable]
    public class Settings : IAdminEntity
    {
        private Guid m_SettingID;
        private string m_SettingCode;
        private string m_Value;
        private string m_DefaultValue;
        private string m_Description;
        private bool m_LocaleAware;

        public Guid SettingID
        {
            get { return m_SettingID; }
            set { m_SettingID = value; }
        }
        public string SettingCode
        {
            get { return m_SettingCode; }
            set { m_SettingCode = value; }
        }
        public string Value
        {
            get { return m_Value; }
            set { m_Value = value; }
        }
        public string DefaultValue
        {
            get { return m_DefaultValue; }
            set { m_DefaultValue = value; }
        }
        public string Description
        {
            get { return m_Description; }
            set { m_Description = value; }
        }
        public bool LocaleAware
        {
            get { return m_LocaleAware; }
            set { m_LocaleAware = value; }
        }

    }


}
