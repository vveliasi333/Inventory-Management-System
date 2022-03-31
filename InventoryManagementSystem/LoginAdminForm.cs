using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class LoginAdminForm : Form
    {
        //context field of the database (DBIMSEntities)
        DBIMSEntities context = new DBIMSEntities();

        //method that initializes the LoginGuestForm
        public LoginAdminForm()
        {
            InitializeComponent();
        }

        //method for when clear button is clicked
        private void lblClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPass.Clear();
        }

        //method for when show password checkbox is checked
        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked == false) //if the show password checkbox is not checked
                txtPass.UseSystemPasswordChar = true; //shows password as system password characters
            else
                txtPass.UseSystemPasswordChar = false; //else would mean that it is checked, so it shows characters
        }

        //method for when login button is clicked
        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            //the following if conditions check if any textbox of the form is empty, and requires the user to fill the credentials out
            if ((txtName.Text.Length == 0 || txtName.Text.Trim().Length == 0)) //username textbox if it is empty
            {
                MessageBox.Show("Please, insert username and password!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((txtPass.Text.Length == 0 || txtPass.Text.Trim().Length == 0)) //password textbox if it is empty
            {
                MessageBox.Show("Please, insert username and password!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //declaring a string as name, and using it to store the username inserted in its textbox
            string name = this.txtName.Text;

            //query for selecting the user's username from the table
            var query = from i in context.tbUsers //context is the variable selecting data from tbUsers (User Table)
                        where i.Username == name //storing the username value to the name variable
                        select i;

            //foreach loop that checks through items selected by the query
            foreach (var itm in query)
            {
                tbUser obj = new tbUser(); //instance of tbUser (User Table)
                obj.Type = itm.Type; //selecting the type value of the user

                //if condition to check if the user is not an administrator type, and does not allow it to login in the administrator form if condition is true
                if (obj.Type != "Administrator")
                {
                    MessageBox.Show("You are not an administrator!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //instance of the CheckPassword method to check if password is correct
            bool response = CheckPassword();

            //if condition that executes if the password is incorrect
            if (response == false)
            {
                MessageBox.Show("Incorrect username or password!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //instance of the UserExist method to check if a user exists
            bool exist = UserExist();

            //if condition that executes if the user does not exist, returns a message to the user
            if (exist == false)
            {
                MessageBox.Show("This user does not exist, please register!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //else block that executes if all the conditions above are passed
            else
            {
                AdministratorPanelForm ap = new AdministratorPanelForm(); //the AdministratorPanelForm that shows the administrator panel, this is an instance of the form
                ap.Show(); //shows the form
                this.Hide(); //hides the current form
            }
        }

        //method that checks if the password is correct
        public bool CheckPassword()
        {
            bool correct = true; //boolean variable used for the if conditions
            string user1 = this.txtName.Text; //string that stores the inserted value in the username textbox
            string pass1 = this.txtPass.Text; //string that stores the inserted value in the password textbox

            //query that selects the logged in user's username and password
            var query = from tr in context.tbUsers
                        where
                        (tr.Username == user1
                         &&
                        tr.Password == pass1)
                        select tr;

            //if the query returns empty it means it is incorrect
            if (query == null || query.Count() == 0)
            {
                return false;
            }

            //else would mean that it is correct
            else
            {
                return correct;
            }
        }

        //method that checks if a user exists
        public bool UserExist()
        {
            //string used to check the inserted username in the respective textbox
            string user = this.txtName.Text;

            //query that selects the username and checks if exists in the table
            var query = from tr in context.tbUsers //tr is a variable used for the query
                        where tr.Username == user
                        select tr;

            //if query returns null means that it does not exist in the table
            if (query == null)
            {
                return false;
            }

            else if (query.Count() == 0)
            {
                return false;
            }

            //else would mean that it does exist in the table
            else
            {
                return true;
            }
        }

        //method when logout button is clicked
        private void btnReturnLogin_Click(object sender, EventArgs e)
        {
            LoginForm l = new LoginForm(); //the LoginForm that logs in users based on three different roles, this is an instance of the form
            l.Show(); //shows the form
            this.Hide(); //hides the current form
        }
    }
}