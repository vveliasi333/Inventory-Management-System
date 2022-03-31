using System;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class UserPanelForm : Form
    {
        //method that initializes the UserPanelForm
        public UserPanelForm()
        {
            InitializeComponent();
        }

        //method when the products button is clicked
        private void productsPicture_Click(object sender, EventArgs e)
        {
            ProductForm p = new ProductForm(); //the ProductForm that shows the list of the products of the table, this is an instance of the form
            p.Show(); //shows the form
        }

        //method when the category button is clicked
        private void categoriesPicture_Click(object sender, EventArgs e)
        {
            CategoryForm c = new CategoryForm(); //the CategoryForm that shows the list of the categories of the table, this is an instance of the form
            c.Show(); //shows the form
        }

        //method when the add products button is clicked
        private void addProducts_Click(object sender, EventArgs e)
        {
            ProductModuleForm pm = new ProductModuleForm(); //the ProductModuleForm that adds products to the table, this is an instance of the form
            pm.Show(); //shows the form
        }

        //method when the add categories button is clicked
        private void addCategories_Click(object sender, EventArgs e)
        {
            CategoryModuleForm cm = new CategoryModuleForm(); //the CategoryModuleForm that adds categories to the table, this is an instance of the form
            cm.Show(); //shows the form
        }

        //method when logout button is clicked
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LoginUserForm lu = new LoginUserForm(); //the LoginUserForm that logs in users that hold only RW rights, this is an instance of the form
            lu.Show(); //shows the form
            this.Hide(); //hides the current form
        }
    }
}