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
    //the class of Category Module Form derived from the Form class of Windows Forms
    public partial class CategoryModuleForm : Form
    {
        /*the SqlConnection command where we paste the connection string
          in order to link the SQL database of the project*/
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leonard\Documents\InventoryManagementSystem\Database\DB_Inventory.mdf;Integrated Security=True;Connect Timeout=30");

        //declaring the SqlCommand in order to use it for queries executed on tables
        SqlCommand cm = new SqlCommand();

        //initializes the Category Module Form
        public CategoryModuleForm()
        {
            InitializeComponent();
        }

        //method that executes when save button is clicked
        private void btnSave_Click(object sender, EventArgs e)
        {
            /*try block: firstly, outputs a message if user is sure of saving the category,
             and secondly, the function for inserting categories to the category table*/
            try
            {
                if (MessageBox.Show("Are you sure you want to save this category?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //the sql command query for inserting categories in the table
                    cm = new SqlCommand("INSERT INTO tbCategory(catname)VALUES(@catname)", con);
                    cm.Parameters.AddWithValue("@catname", txtCatName.Text);

                    //opening the sql connection
                    con.Open();

                    //executing the query
                    cm.ExecuteNonQuery();

                    //closing the sql connection
                    con.Close();
                    MessageBox.Show("Category has been successfully saved.");
                    Clear();
                }

            }

            //catch block: executes when an error happens, and shows a message box to the user
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //the clear method for clearing the entered strings in respective text boxes
        public void Clear()
        {
            txtCatName.Clear();
        }

        //the clear button event when is clicked
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            UserModuleForm userModule = new UserModuleForm();
            userModule.btnSave.Enabled = true;
            userModule.btnUpdate.Enabled = false;
            userModule.ShowDialog();
        }

        //method for the update button when is clicked
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*try block: firstly, outputs a message if user is sure of updating the category,
              and secondly, the function for updating categories of the category table*/
            try
            {
                if (MessageBox.Show("Are you sure you want to update this Category?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //the sql command query for updating categories of the table
                    cm = new SqlCommand("UPDATE tbCategory SET catname = @catname WHERE catid LIKE '" + lblCatId.Text + "' ", con);
                    cm.Parameters.AddWithValue("@catname", txtCatName.Text);                    
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Category has been successfully updated!");
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