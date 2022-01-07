﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Woc.Book.Base.BusinessEntity;
namespace Woc.Book.Staff.BusinessEntity
{
    [Serializable]
    public class Staffs : IBusinessEntity
    {
        private Guid m_UserID;
    private byte[] m_Password;
    private byte[] m_Salt;

 

	    public Guid UserID

        public byte[] Salt
        {
            get { return m_Salt; }
            set { m_Salt = value; }
        }

        private string _textboxPassword;
        public string TextBoxPassword
        {
            get { return _textboxPassword; }
            set { _textboxPassword = value; }
        }
    }
}