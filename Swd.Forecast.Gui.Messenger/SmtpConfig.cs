using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Swd.Forecast.Gui.Messenger
{
    public class SmtpConfig
    {
        private string _hostname;
        private int _port;
        private string _username;
        private string _password;
        private string _sendername;


        public string Hostname { get { return _hostname; } set { _hostname = value; } }
        public int Port { get { return _port; } set { _port = value; } }
        public string Username { get { return _username; } set { _username = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string Sendername { get { return _sendername; } set { _sendername = value; } }

    }
}
