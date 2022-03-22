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
    //the class of User Form derived from the Form class of Windows Forms
    public partial class UserForm : Form
    {
        /*the SqlConnection command where we paste the connection string
          in order to link the SQL database of the project*/
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leonard\Documents\InventoryManagementSystem\Database\DB_Inventory.mdf;Integrated Security=True;Connect Timeout=30");

        //declaring the SqlCommand in order to use it for queries executed on tables
        SqlCommand cm = new SqlCommand();

        //declaring the SqlDataReader in order to read data from the database tables
        SqlDataReader dr;

        //initializes the User Form
        public UserForm()
        {
            InitializeComponent();
            LoadUser();
        }

        //method for loading every user and their respective details to the data grid view
        public void LoadUser()
        {
            //code block for selecting every user of the table
            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbUser", con);
            con.Open();
            dr = cm.ExecuteReader();

            //while loop to fill out the rows of the data grid view with users' details
            while (dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();
        }

        //method that executes when add button is clicked
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //declaring an object in order to use buttons from User Module Form
            UserModuleForm userModule = new UserModuleForm();
            userModule.btnSave.Enabled = true;
            userModule.btnUpdate.Enabled = false;
            ShowDialog();

            //calling the user loading method
            LoadUser();
        }

        //method for the data grid view of users
        public void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //declaring an object from User Module Form in order to access them later
            UserModuleForm userModule = new UserModuleForm();

            //declaring the column name as a string
            string colName = dgvUser.Columns[e.ColumnIndex].Name;

            //if else if condition loop in order to give the edit and delete columns their respective functions
            if (colName == "Edit")
            {
                //showing the user details on their own cells of the data grid view
                userModule.txtUserName.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                userModule.txtFullName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                userModule.txtPass.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                userModule.txtPhone.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();
            }

            //else if block that gives the delete column the function of deleting a user from the table
            else if (colName == "Delete")
            {
                //shows a message box when clicking the delete column
                if (MessageBox.Show("Are you sure you want to delete this user?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();

                    //sql command that executes the query for deleting a user
                    cm = new SqlCommand("DELETE FROM tbUser WHERE username LIKE '" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }

            //calling the user loading method
            LoadUser();
        }

        //'X' button that closes this form
        private void exitUF_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}