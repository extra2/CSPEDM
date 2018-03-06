using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSPEDM
{
    public partial class Form1 : Form
    {
        private LoginController loginController = new LoginController();
        public event EventHandler<LoginEventArgs> OnLoginClicked;
        public Form1()
        {
            InitializeComponent();
            OnLoginClicked += loginController.Login;
        }

        private void buttonLogin_Click(object sender, EventArgs e) => OnLoginClicked?.Invoke(this,
                new LoginEventArgs { Login = textBoxLogin.Text, Password = textBoxPassword.Text });
    }
}
