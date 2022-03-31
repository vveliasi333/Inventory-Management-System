using System;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class LoginForm : Form
    {
        //method that initializes the LoginForm
        public LoginForm()
        {
            InitializeComponent();
        }

        //method when Administrator button is clicked
        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            LoginAdminForm la = new LoginAdminForm(); //the LoginAdminForm that logs in users that hold full access rights, this is an instance of the form
            la.Show(); //shows the form
            this.Hide(); //hides the current form
        }

        //method when User button is clicked
        private void btnLoginUser_Click(object sender, EventArgs e)
        {
            LoginUserForm lu = new LoginUserForm(); //the LoginUserForm that logs in users that hold only RW rights, this is an instance of the form
            lu.Show(); //shows the form
            this.Hide(); //hides the current form
        }

        //method when Guest button is clicked
        private void btnLoginGuest_Click(object sender, EventArgs e)
        {
            LoginGuestForm lg = new LoginGuestForm(); //the LoginGuestForm that logs in users that hold only R rights, this is an instance of the form
            lg.Show(); //shows the form
            this.Hide(); //hides the current form
        }

        private void labelCreateAcc_Click(object sender, EventArgs e)
        {
            UserModuleForm um = new UserModuleForm(); //the UserModuleForm that registers new users to the database, this is an instance of the form
            um.Show(); //shows the form
        }
    }
}