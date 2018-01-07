using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegSide
{
    public class NewAccount
    {
        private string _account;
        public string Account
        {
            set { _account = value; } 
            get { return _account; }
        }

        private string _password;
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }

        private string _safeCode;
        public string SafeCode
        {
            set { _safeCode = value; }
            get { return _safeCode; }
        }

        private int _dpSequenceIndex;
        public int DpSequenceIndex
        {
            set { _dpSequenceIndex = value; }
            get { return _dpSequenceIndex; }
        }

        private int _dpServerIndex;
        public int DpServerIndex
        {
            set { _dpServerIndex = value; }
            get { return _dpServerIndex; }
        }

        private int _xzServerIndex;
        public int XZServerIndex
        {
            set { _xzServerIndex = value; }
            get { return _xzServerIndex; }
        }

        private string _dpScript;
        public string DPScript
        {
            set { _dpScript = value; }
            get { return _dpScript; }
        }

        private string _dpServer;
        public string DPServer
        {
            set { _dpServer = value; }
            get { return _dpServer; }
        }

        private string _xzServerInfo;
        public string XZServerInfo
        {
            set { _xzServerInfo = value; }
            get { return _xzServerInfo; }
        }

        private int _breakFlag;
        public int BreakFlag
        {
            set { _breakFlag = value; }
            get { return _breakFlag; }
        }
    }
}
