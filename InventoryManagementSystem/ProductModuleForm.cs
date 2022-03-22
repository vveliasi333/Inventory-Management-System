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
    //the class of Product Module Form derived from the Form class of Windows Forms
    public partial class ProductModuleForm : Form
    {
        /*the SqlConnection command where we paste the connection string
          in order to link the SQL database of the project*/
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leonard\Documents\InventoryManagementSystem\Database\DB_Inventory.mdf;Integrated Security=True;Connect Timeout=30");

        //declaring the SqlCommand in order to use it for queries executed on tables
        SqlCommand cm = new SqlCommand();

        //declaring the SqlDataReader in order to read data from the database tables
        SqlDataReader dr;

        //initializes the Product Module Form
        public ProductModuleForm()
        {
            InitializeComponent();
            LoadCategory();
        }

        //method for loading every category and their respective details to the data grid view
        public void LoadCategory()
        {
            //code block for selecting the category name from the category table
            comboCat.Items.Clear();
            cm = new SqlCommand("SELECT catname FROM tbCategory", con);
            con.Open();
            dr = cm.ExecuteReader();

            //while loop to fill out the row of the data grid view with category details
            while (dr.Read())
            {
                comboCat.Items.Add(dr[0].ToString());
            }
            dr.Close();
            con.Close();
        }

        //method that executes when save button is clicked
        private void btnSave_Click(object sender, EventArgs e)
        {
            //declaring an object in order to use buttons from User Module Form
            UserModuleForm userModule = new UserModuleForm();
            userModule.btnSave.Enabled = true;
            userModule.btnUpdate.Enabled = false;
            userModule.ShowDialog();

            /*try block: firstly, outputs a message if user is sure of saving the product,
                         and secondly, the function for inserting products to the product table*/
            try
            {
               
                if (MessageBox.Show("Are you sure you want to save this product?", "Saving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //the sql command query for inserting products in the table
                    cm = new SqlCommand("INSERT INTO tbProduct(pname,pqty,pprice,pdescription,pcategory)VALUES(@pname, @pqty, @pprice, @pdescription, @pcategory)", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtPQty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtPPrice.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboCat.Text);

                    //opening the sql connection
                    con.Open();

                    //executing the query
                    cm.ExecuteNonQuery();

                    //closing the sql connection
                    con.Close();
                    MessageBox.Show("Product has been successfully saved.");
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
            txtPName.Clear();
            txtPQty.Clear();
            txtPPrice.Clear();
            txtPDes.Clear();
            comboCat.Text = "";
        }

        //the clear button event when is clicked
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }


        //method for the update button when is clicked
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            /*try block: firstly, outputs a message if user is sure of updating the product,
             and secondly, the function for updating products of the product table*/
            try
            {

                if (MessageBox.Show("Are you sure you want to update this product?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //the sql command query for updating products of the table
                    cm = new SqlCommand("UPDATE tbProduct SET pname = @pname, pqty=@pqty, pprice=@pprice, pdescription=@pdescription, pcategory=@pcategory WHERE pid LIKE '" + lblPid.Text + "' ", con);
                    cm.Parameters.AddWithValue("@pname", txtPName.Text);
                    cm.Parameters.AddWithValue("@pqty", Convert.ToInt16(txtPQty.Text));
                    cm.Parameters.AddWithValue("@pprice", Convert.ToInt16(txtPPrice.Text));
                    cm.Parameters.AddWithValue("@pdescription", txtPDes.Text);
                    cm.Parameters.AddWithValue("@pcategory", comboCat.Text);
                    con.Open();
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product has been successfully updated!");
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