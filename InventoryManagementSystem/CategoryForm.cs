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
    //the class of Category Form derived from the Form class of Windows Forms
    public partial class CategoryForm : Form
    {
        /*the SqlConnection command where we paste the connection string
          in order to link the SQL database of the project*/
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leonard\Documents\InventoryManagementSystem\Database\DB_Inventory.mdf;Integrated Security=True;Connect Timeout=30");

        //declaring the SqlCommand in order to use it for queries executed on tables
        SqlCommand cm = new SqlCommand();

        //declaring the SqlDataReader in order to read data from the database tables
        SqlDataReader dr;

        //initializes the Category Form
        public CategoryForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        //method for loading every category and their respective details to the data grid view
        public void LoadCategory()
        {
            //code block for selecting every product of the table
            int i = 0;
            dgvCategory.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbCategory", con);
            con.Open();
            dr = cm.ExecuteReader();

            //while loop to fill out the rows of the data grid view with categories' details
            while (dr.Read())
            {
                i++;
                dgvCategory.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
            }

            //closing the data reader
            dr.Close();

            //closing the sql connection
            con.Close();
        }

        //method that executes when add button is clicked
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //declaring an object in order to use buttons from User Module Form
            UserModuleForm userModule = new UserModuleForm();
            userModule.btnSave.Enabled = true;
            userModule.btnUpdate.Enabled = false;
            userModule.ShowDialog();

            //declaring an object in order to use buttons from Category Module Form
            CategoryModuleForm formModule = new CategoryModuleForm();
            formModule.btnSave.Enabled = true;
            formModule.btnUpdate.Enabled = false;
            formModule.ShowDialog();

            //calling the method of product loading
            LoadCategory();
        }

        //method for the data grid view of categories
        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //declaring the object of the form as string
            string role = comboRole.Text.ToString();

            //if condition block that hides the delete and edit columns when logged in as a guest
            if (role == "Guest")
            {
                dgvCategory.Columns["Edit"].Visible = false;
                dgvCategory.Columns["Delete"].Visible = false;
            }

            //declaring the column name as a string
            string colName = dgvCategory.Columns[e.ColumnIndex].Name;

            //if else if condition loop in order to give the edit and delete columns their respective functions
            if (colName == "Edit")
            {
                //showing the category details on their own cells of the data grid view
                CategoryModuleForm formModule = new CategoryModuleForm();
                formModule.lblCatId.Text = dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString();
                formModule.txtCatName.Text = dgvCategory.Rows[e.RowIndex].Cells[2].Value.ToString();

                formModule.btnSave.Enabled = false;
                formModule.btnUpdate.Enabled = true;
                formModule.ShowDialog();
            }

            //else if block that gives the delete column the function of deleting a category from the table
            else if (colName == "Delete")
            {
                //shows a message box when clicking the delete column
                if (MessageBox.Show("Are you sure you want to delete this category?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();

                    //sql command that executes the query for deleting a category
                    cm = new SqlCommand("DELETE FROM tbCategory WHERE catid LIKE '" + dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }

            //calling the category loading method
            LoadCategory();
        }

        //'X' button that closes this form
        private void exitCF_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}