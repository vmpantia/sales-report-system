using System;
using System.Windows.Forms;

namespace SalesReportSystem.Forms
{
    public partial class MainForm : Form
    {
        LoginForm currentLoginForm; 
        public MainForm(LoginForm loginForm)
        {
            InitializeComponent();
            currentLoginForm = loginForm;   
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            currentLoginForm.Show();
        }
    }
}
