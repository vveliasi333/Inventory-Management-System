using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementSystem
{

    public partial class ProductForm : Form
    {
        //context field of the database (DBIMSEntities)
        DBIMSEntities context = new DBIMSEntities();

        //method that initializes the ProductForm
        public ProductForm()
        {
            InitializeComponent();
            LoadProduct(); //calling the LoadProduct method at form initialization
        }

        //the implementation of the method that shows product data from the table to the data grid view of the ProductForm
        public void LoadProduct()
        {
            //entities is a local variable created to use the database as an instance, in order to execute the queries
            DBIMSEntities entities = new DBIMSEntities();

            //query for loading every product data from the table
            var products = from p in entities.tbProducts
                           select new
                           {
                               No = p.pid, //retreiving the product Id value to show it to the No column of the data grid view
                               ProductId = p.pid, //retreiving the product Id value to show it to the Product Id column of the data grid view
                               Name = p.pname, //retreiving the product name value to show it to the Name column of the data grid view
                               Qty = p.pqty, //retreiving the product quantity value to show it to the Qty column of the data grid view
                               Price = p.pprice, //retreiving the product price value to show it to the Price column of the data grid view
                               Description = p.pdescription, //retreiving the product description value to show it to the Description column of the data grid view
                               Category = p.pcategory //retreiving the product category value to show it to the Category column of the data grid view
                           };

            dgvProduct.DataSource = products.ToList(); //method that executes the query for showing the products with all their data to the list
        }

        //method for when clicking a cell of the data grid view, specifically used for the Delete column
        public void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //declaring a string as colName, and assigning it to the column index in order to implement a function for the Delete column
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;

            //if condition to locate the Delete column
            if (colName == "Delete")
            {
                //if condition to check if the Delete column cell is clicked
                if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid productid = new Guid(dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString()); //converting the Guid datatype of the product Id to string

                    var deleteproduct = (from p in context.tbProducts where p.pid == productid select p).First(); //query to select the product Id from tbProduct (Product Table)
                    context.tbProducts.Remove(deleteproduct); //remove method that executes the query (held by the deleteproduct variable) for deleting a product from the table
                    context.SaveChanges(); //method that saves changes to the table

                    MessageBox.Show("Product has been successfully deleted.", "Product Deleted");
                }
                //calling the LoadProduct method to refresh the table data after changes are made
                LoadProduct();
            }
        }

        //method that hides the current form when 'X' button is clicked
        private void exitPF_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}