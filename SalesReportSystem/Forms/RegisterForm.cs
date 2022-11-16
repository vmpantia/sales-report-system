using SalesReportSystem.Controllers;
using SalesReportSystem.Database;
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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtFirstname.Text))
            {
                MessageBox.Show("Please input your firstname", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtLastname.Text))
            {
                MessageBox.Show("Please input your lastname", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Please input your Username", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please input your paswword", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtConfirmPassoword.Text))
            {
                MessageBox.Show("Please confirm your password", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPassword.Text != txtConfirmPassoword.Text)
            {
                MessageBox.Show("You password didn't match", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var inputUser = new User
            { 
                Firstname = txtFirstname.Text.Trim(),
                Lastname = txtLastname.Text.Trim(),
                Middlename = txtMiddlename.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                Status = 0,
                CreatedDate = DateTime.Now
            };

            var validationResult = UserController.ValidateUser(inputUser);
            if (validationResult != UserErrorType.USR_NO_ERROR)
            {
                MessageBox.Show(CommonController.GetErrorMessage(validationResult), "Create User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var creationResult = UserController.CreateUser(inputUser);
            if(creationResult)
            {
                MessageBox.Show("User has been created successfully", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            MessageBox.Show("Failed to create User", "Create User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

        }
    }
}
