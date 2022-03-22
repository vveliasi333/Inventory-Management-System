using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//the namespace with the same name as the solution
namespace InventoryManagementSystem
{
    //the class of Login Form derived from the Form class of Windows Forms
    public partial class LoginForm : Form
    {
        /*the SqlConnection command where we paste the connection string
          in order to link the SQL database of the project*/
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leonard\Documents\InventoryManagementSystem\Database\DB_Inventory.mdf;Integrated Security=True;Connect Timeout=30");

        //declaring the SqlCommand in order to use it for queries executed on tables
        SqlCommand cm = new SqlCommand();

        //declaring the SqlDataReader in order to read data from the database tables
        SqlDataReader dr;

        //initializes the Login Form
        public LoginForm()
        {
            InitializeComponent();
        }

        //checkbox method that is placed in the login form in order to show password when checked
        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked == false)
                txtPass.UseSystemPasswordChar = true;
            else
                txtPass.UseSystemPasswordChar = false;
        }

        //method that clears any input of the user in the text boxes
        private void lblClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtPass.Clear();
        }

        //method that executes when clicking the login button
        private void btnLogin_Click(object sender, EventArgs e)
        {

            /*try block: firstly, selects the username and password of the user that is trying to login
                         secondly, outputs a message box welcoming the logged in user with their respective name,
                         and thirdly, shows an error in case the username or password is invalid*/
            try
            {
                //sql command that selects username and password from the user table
                cm = new SqlCommand("SELECT * FROM tbUser WHERE username=@username AND password=@password", con);
                cm.Parameters.AddWithValue("@username", txtName.Text);
                cm.Parameters.AddWithValue("@password", txtPass.Text);
                con.Open();
                dr = cm.ExecuteReader();
                dr.Read();

                //if condition that returns the welcome message
                if (dr.HasRows)
                {
                    MessageBox.Show("Welcome, " + dr["fullname"].ToString() + "!", "\nACCESS GRANTED!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HomeForm home = new HomeForm();
                    home.Show();
                    this.Hide();
                    
                }

                //else part of the condition that returns error message in case username or password is invalid
                else
                {
                    MessageBox.Show("Invalid username or password!", "\nACCESS DENIED!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
            }

            //catch block: executes when an error happens, and shows a message box to the user
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}