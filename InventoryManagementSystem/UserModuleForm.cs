using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class UserModuleForm : Form
    {
        //context field of the database (DBIMSEntities)
        DBIMSEntities context = new DBIMSEntities();

        //method that initializes the UserModuleForm
        public UserModuleForm()
        {
            InitializeComponent();
        }

        //method when Save button is clicked
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if condition to check if both passwords match when saving a user
                if (txtPass.Text != txtRepass.Text) //txtPass and txtRepass are textboxes of Password and Re-password respectively
                {
                    MessageBox.Show("Passwords do not match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var db = new DBIMSEntities()) //db is a variable used as an instance of DBIMSEntities, in order to execute queries on the database
                {
                    var insert = new tbUser(); //insert is a variable used as an instance of tbUser (User table)

                    //the following if conditions check if any textbox of the form is empty, and requires the user to fill the credentials out
                    if ((txtUserName.Text.Length == 0 || txtUserName.Text.Trim().Length == 0)) //username textbox if it is empty
                    {
                        MessageBox.Show("Please, fill out the credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if ((txtFullName.Text.Length == 0 || txtFullName.Text.Trim().Length == 0)) //fullname textbox if it is empty
                    {
                        MessageBox.Show("Please, fill out the credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if ((txtPass.Text.Length == 0 || txtPass.Text.Trim().Length == 0)) //password textbox if it is empty
                    {
                        MessageBox.Show("Please, fill out the credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if ((txtRepass.Text.Length == 0 || txtRepass.Text.Trim().Length == 0)) //re-password textbox if it is empty
                    {
                        MessageBox.Show("Please, fill out the credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if ((txtPhone.Text.Length == 0 || txtPhone.Text.Trim().Length == 0)) //phone textbox if it is empty
                    {
                        MessageBox.Show("Please, fill out the credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if ((comboType.Text.Length == 0 || comboType.Text.Trim().Length == 0)) //category combobox if it is empty
                    {
                        MessageBox.Show("Please, fill out the credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //instance of the UserExist method to prevent user duplication
                    bool exist = UserExist(); //exist is a variable for the method

                    //if condition to check if a user already exists
                    if (exist == true) //if the answer is true means the user exists
                    {
                        MessageBox.Show("A user with the same username already exists!", "Register Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //else block that executes if all the conditions above are passed
                    else
                    {
                        //lines that insert each data from the table to its respective textbox, and/or combobox
                        insert.Id = Guid.NewGuid(); //user Id generated as Guid
                        insert.Username = txtUserName.Text; //Username is the parameter of the table, and txtUserName is the textbox of the form
                        insert.Fullname = txtFullName.Text; //Fullname is the parameter of the table, and txtFullName is the textbox of the form
                        insert.Password = txtPass.Text; //Password is the parameter of the table, and txtPassword is the textbox of the form
                        insert.Password = txtRepass.Text; //Password is the parameter of the table, and txtRepass is the textbox of the form
                        insert.Phone = txtPhone.Text; //Phone is the parameter of the table, and txtPhone is the textbox of the form
                        insert.Type = comboType.Text; //Type is the parameter of the table, and comboType is the combobox of the form

                        //add method that executes the query(held by the insert variable) for inserting a user to the table
                        db.tbUsers.Add(insert);

                        //method that saves changes to the table
                        db.SaveChanges();

                        MessageBox.Show("User has been successfully saved.", "User Created");
                    }
                }
            }

            catch (Exception) //catch block that returns a user-friendly message in case of an error
            {
                MessageBox.Show("An error has occurred!", "Database Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //method for the clear button
        public void Clear()
        {
            //clears every typed info in the textboxes
            txtUserName.Clear();
            txtFullName.Clear();
            txtPass.Clear();
            txtRepass.Clear();
            txtPhone.Clear();
        }

        //method that executes when clear button is clicked
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
        }

        //method that checks if a user already exists in order to prevent duplication
        public bool UserExist()
        {
            //string used to check the inserted username in the respective textbox
            string user = this.txtUserName.Text;

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
    }
}