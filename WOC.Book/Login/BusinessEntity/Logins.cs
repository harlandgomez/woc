using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Woc.Book.Login.BusinessEntity
{
   [Serializable]
    public class Logins
    {
        public Logins()
        { 
        }
        #region PrivateVariable
        private byte[] _password;
        private byte[] _salt;
        private String _userID;
        private String _userName;
        private Boolean _userStatus;
        private DateTime _dateLogin;
        private String _logingMessage;
        private String _userDescription;

          
        #endregion

        #region Properties
        /// <summary>
        /// Password Property
        /// </summary>
        public byte[] Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        /// <summary>
        /// Salt
        /// </summary>
        public byte[] Salt
        {
            get
            {
                return _salt;
            }
            set
            {
                _salt = value;
            }
        }
        /// <summary>
        /// UserId Property
        /// </summary>
        public string UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
            }
        }
        /// <summary>
        /// UserName Property
        /// </summary>
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }

        /// <summary>
        /// UserStatus Property
        /// </summary>
        public Boolean UserStatus
        {
            get
            {
                return _userStatus;
            }
            set
            {
                _userStatus = value;
            }
        }

        /// <summary>
        /// UserStatus Property
        /// </summary>
        public DateTime DateLogin
        {
            get
            {
                return _dateLogin;
            }
            set
            {
                _dateLogin = value;
            }
        }

        public String LogingMessage
        {
            get
            {
                return _logingMessage;
            }
            set
            {
                _logingMessage = value;
            }
        }
        public string UserDescription
        {
            get
            {
                return _userDescription;
            }
            set
            {
                _userDescription = value;
            }

        }
             



        #endregion
     }
}
