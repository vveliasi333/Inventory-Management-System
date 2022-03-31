using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class GuestProductForm : Form
    {
        //context field of the database (DBIMSEntities)
        DBIMSEntities context = new DBIMSEntities();

        //method that initializes the GuestProductForm
        public GuestProductForm()
        {
            InitializeComponent();
            LoadGuestProduct(); //calling the LoadGuestProduct method at form initialization
        }

        //the implementation of the method that shows product data from the table to the data grid view of the GuestProductForm
        public void LoadGuestProduct()
        {
            //entities is a local variable created to use the database as an instance, in order to execute the queries
            DBIMSEntities entities = new DBIMSEntities();

            //query for loading every user data from the table
            var guestProducts = from gp in entities.tbProducts
                                select new
                                {
                                    No = gp.pid, //retreiving the product Id value to show it to the No column of the data grid view
                                    ProductId = gp.pid, //retreiving the product Id value to show it to the Product Id column of the data grid view
                                    Name = gp.pname, //retreiving the product name value to show it to the Name column of the data grid view
                                    Qty = gp.pqty, //retreiving the product quantity value to show it to the Qty column of the data grid view
                                    Price = gp.pprice, //retreiving the product price value to show it to the Price column of the data grid view
                                    Description = gp.pdescription, //retreiving the product description value to show it to the Description column of the data grid view
                                    Category = gp.pcategory //retreiving the product category value to show it to the Category column of the data grid view
                                };

            dgvGuestProduct.DataSource = guestProducts.ToList(); //method that executes the query for showing the users with all their data to the list
        }

        //method that hides the current form when 'X' button is clicked
        private void exitGPF_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}