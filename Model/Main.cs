using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
namespace Account_MVVM.Model
{
    public class Main
    {
        #region Constructors
        public Main(string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
        }
        public Main() { }
        #endregion
        #region Login
        private string _login;
        public string Login
        {
            get { return _login; }
            set 
            {
                if (_login != value) _login = value;
            }
        }
        #endregion
        #region Password
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value) _password = value;
            }
        }
        #endregion
    }
}