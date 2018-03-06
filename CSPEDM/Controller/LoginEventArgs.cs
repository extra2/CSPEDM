using System;

namespace CSPEDM
{
    public class LoginEventArgs : EventArgs
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}