using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

//the namespace with the same name as the solution
namespace InventoryManagementSystem
{
    //the class of User Module Form derived from the Form class of Windows Forms
    public partial class UserModuleForm : Form
    {
        /*the SqlConnection command where we paste the connection string
          in order to link the SQL database of the project*/
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leonard\Documents\InventoryManagementSystem\Database\DB_Inventory.mdf;Integrated Security=True;Connect Timeout=30");
        
        //declaring the SqlCommand in order to use it for queries executed on tables
        SqlCommand cm = new SqlCommand();

        //initializes the User Model Form
        public UserModuleForm()
        {
            InitializeComponent();
        }

        //the method that gets executed when we click the save button
        private void btnSave_Click(object sender, EventArgs e)
        {
            /*try block: firstly, outputs an error if passwords don't match,
              and secondly, the function for inserting users to the user table*/
            try
            {
                if (txtPass.Text != txtRepass.Text)
                {
                    //message that pops up when passwords don't match
                    MessageBox.Show("Password did not Match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to save this user?", "Saving Record",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    //code block for inserting users into user table
                    cm = new SqlCommand("INSERT INTO tbUser(username, fullname, password, phone)VALUES(@username, @fullname, @password, @phone)", con);
                    cm.Parameters.AddWithValue("@username", txtUserName.Text);
                    cm.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cm.Parameters.AddWithValue("@password", txtPass.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);

                    //opening the database connection
                    con.Open();

                    //exectuing the query written above
                    cm.ExecuteNonQuery();

                    //closing the database connection
                    con.Close();

                    MessageBox.Show("User has been successfully saved.");

                    //calling the clear method
                    Clear();
                }

            //catch block: executes when an error happens, and shows a message box to the user
            }catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //the method that gets executed when we click the clear button
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        //the clear method for clearing the entered strings in respective text boxes
        public void Clear()
        {
            txtUserName.Clear();
            txtFullName.Clear();
            txtPass.Clear();
            txtRepass.Clear();
            txtPhone.Clear();
        }

        //the method that gets executed when we click the update button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*try block: firstly, outputs an error if passwords don't match,
              and secondly, the function for updating users of the user table*/
            try
            {
                if (txtPass.Text != txtRepass.Text)
                {
                    //message that pops up when passwords don't match
                    MessageBox.Show("Password did not Match!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Are you sure you want to update this user?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //code block for updating users of the user table
                    cm = new SqlCommand("UPDATE tbUser SET fullname = @fullname, password=@password, phone=@phone WHERE username LIKE '"+txtUserName.Text +"' ", con);                    
                    cm.Parameters.AddWithValue("@fullname", txtFullName.Text);
                    cm.Parameters.AddWithValue("@password", txtPass.Text);
                    cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User has been successfully updated!");
                    this.Dispose();
                }

            }

            //catch block: executes when an error happens, and shows a message box to the user
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}