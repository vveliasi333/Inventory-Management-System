using System;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class GuestPanelForm : Form
    {
        //method that initializes the GuestPanelForm
        public GuestPanelForm()
        {
            InitializeComponent();
        }

        //method when the products button is clicked
        private void productsPicture_Click(object sender, EventArgs e)
        {
            GuestProductForm gp = new GuestProductForm(); //the GuestProductForm that shows the list of the products of the table, this is an instance of the form
            gp.Show(); //shows the form
        }

        //method when the category button is clicked
        private void categoriesPicture_Click(object sender, EventArgs e)
        {
            GuestCategoryForm gc = new GuestCategoryForm(); //the GuestCategoryForm that shows the list of the categories of the table, this is an instance of the form
            gc.Show(); //shows the form
        }

        //method when logout button is clicked
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LoginGuestForm lg = new LoginGuestForm(); //the LoginGuestForm that logs in users that hold only R rights, this is an instance of the form
            lg.Show(); //shows the form
            this.Hide(); //hides the current form
        }
    }
}