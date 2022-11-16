using SalesReportSystem.Controllers;
using SalesReportSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesReportSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            CommonController.ResetInput(txtUsername, txtPassword);
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Please input your Username", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please input your Password", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!UserController.IsUsernameExist(txtUsername.Text))
            {
                MessageBox.Show("Username is NOT exist in the system", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var userInfo = UserController.GetUserByCredentials(txtUsername.Text, txtPassword.Text);
            if (userInfo == null)
            {
                MessageBox.Show("Invalid Username and Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Global.UserInfo = userInfo;

            this.Hide();
            var mainForm = new MainForm(this);
            mainForm.ShowDialog();

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var regForm = new RegisterForm();
            regForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
