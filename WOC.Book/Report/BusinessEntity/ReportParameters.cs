using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Report.BusinessEntity
{
    [Serializable]
    public class ReportParameters
    {
        private Guid m_ReportParameterID;
        private Guid m_ReportID;
        private string m_ParameterName;
        private string m_ParameterCaption;
        private string m_ControlType;
        private bool m_IsChecked;
        private string m_SQL;
        private string m_DataTextField;
        private string m_DataValueField;
        private string m_ParameterCode;

        public Guid ReportParameterID
        {
            get { return m_ReportParameterID; }
            set { m_ReportParameterID = value; }
        }
        public Guid ReportID
        {
            get { return m_ReportID; }
            set { m_ReportID = value; }
        }
        public string ParameterName
        {
            get { return m_ParameterName; }
            set { m_ParameterName = value; }
        }
        public string ParameterCode
        {
            get { return m_ParameterCode; }
            set { m_ParameterCode = value; }
        }
        public string ParameterCaption
        {
            get { return m_ParameterCaption; }
            set { m_ParameterCaption = value; }
        }
        public string ControlType
        {
            get { return m_ControlType; }
            set { m_ControlType = value; }
        }
        public bool IsChecked
        {
            get { return m_IsChecked; }
            set { m_IsChecked = value; }
        }
        public string SQL
        {
            get { return m_SQL; }
            set { m_SQL = value; }
        }
        public string DataTextField
        {
            get { return m_DataTextField; }
            set { m_DataTextField = value; }
        }
        public string DataValueField
        {
            get { return m_DataValueField; }
            set { m_DataValueField = value; }
        }

    }

}
