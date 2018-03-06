using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPEDM
{
    class LoginController
    {
        private Credentials _credentials;
        public void Login(object sender, LoginEventArgs e)
        {
            var credentials = new Login().GetCredentials(e.Login, e.Password);
            while (credentials.Status != TaskStatus.RanToCompletion) Thread.Sleep(100);
            _credentials = credentials.Result;
            MessageBox.Show(_credentials.AccessToken + "\n" + _credentials.ExpirationDate);
        }
    }
}
