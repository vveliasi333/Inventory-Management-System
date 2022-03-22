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
    //the class of Product Form derived from the Form class of Windows Forms
    public partial class ProductForm : Form
    {
        /*the SqlConnection command where we paste the connection string
          in order to link the SQL database of the project*/
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leonard\Documents\InventoryManagementSystem\Database\DB_Inventory.mdf;Integrated Security=True;Connect Timeout=30");

        //declaring the SqlCommand in order to use it for queries executed on tables
        SqlCommand cm = new SqlCommand();

        //declaring the SqlDataReader in order to read data from the database tables
        SqlDataReader dr;

        //initializes the Product Form
        public ProductForm()
        {
            InitializeComponent();
            LoadProduct();
        }

        //method for loading every product and their respective details to the data grid view
        public void LoadProduct()
        {
            //code block for selecting every product of the table
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbProduct WHERE CONCAT(pid, pname, pprice, pdescription, pcategory) LIKE '%"+txtSearch.Text+"%'", con);
            con.Open();
            dr = cm.ExecuteReader();

            //while loop to fill out the rows of the data grid view with products' details
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
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
            ProductModuleForm formModule = new ProductModuleForm();
            formModule.btnSave.Enabled = true;
            formModule.btnUpdate.Enabled = false;
            formModule.ShowDialog();

            //calling the method of product loading
            LoadProduct();
            
        }

        //method for the data grid view of products
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //converting the role combobox to string and storing it as a variable named role
            string role = comboRole.Text.ToString();

            //if condition block that hides the delete and edit columns when logged in as a guest
            if (role == "Guest")
            {
                dgvProduct.Columns["Edit"].Visible = false;
                dgvProduct.Columns["Delete"].Visible = false;
            }

            //declaring the column name as a string
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;

            //if else if condition loop in order to give the edit and delete columns their respective functions
            if (colName == "Edit")
            {
                //showing the product details on their own cells of the data grid view
                ProductModuleForm productModule = new ProductModuleForm();
                productModule.lblPid.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                productModule.txtPName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                productModule.txtPQty.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                productModule.txtPPrice.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                productModule.txtPDes.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                productModule.comboCat.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();

                productModule.btnSave.Enabled = false;
                productModule.btnUpdate.Enabled = true;                
                productModule.ShowDialog();
            }

            //else if block that gives the delete column the function of deleting a product from the table
            else if (colName == "Delete")
            {
                //shows a message box when clicking the delete column
                if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();

                    //sql command that executes the query for deleting a product
                    cm = new SqlCommand("DELETE FROM tbProduct WHERE pid LIKE '" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted!");
                }
            }

            //calling the product loading method
            LoadProduct();
        }

        //method for the search box included in the Product Form
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        //'X' button that closes this form
        private void exitPF_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}