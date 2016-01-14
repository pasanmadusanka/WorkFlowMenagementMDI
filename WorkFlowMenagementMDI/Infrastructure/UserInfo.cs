using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkFlowMenagementMDI.Infrastructure
{
    class UserInfo
    {
        private string _id;
        private string _userName;
        private string _password;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public UserInfo(string id, string userName, string password)
        {
            _id = id;
            _userName = userName;
            _password = Password;
        }

        public UserInfo(string id)
        {
            _id = id;
        }
    }
}
