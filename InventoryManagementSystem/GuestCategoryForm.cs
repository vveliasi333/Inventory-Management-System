using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class GuestCategoryForm : Form
    {
        //context field of the database (DBIMSEntities)
        DBIMSEntities context = new DBIMSEntities();

        //method that initializes the GuestCategoryForm
        public GuestCategoryForm()
        {
            InitializeComponent();
            LoadGuestCategory(); //calling the LoadGuestCategory method at form initialization
        }

        //the implementation of the method that shows category data from the table to the data grid view of the GuestCategoryForm
        public void LoadGuestCategory()
        {
            //entities is a local variable created to use the database as an instance, in order to execute the queries
            DBIMSEntities entities = new DBIMSEntities();

            //query for loading every category data from the table
            var guestCategories = from gc in entities.tbCategories
                                  select new
                                  {
                                      No = gc.CatId, //retreiving the category Id value to show it to the No column of the data grid view
                                      CategoryId = gc.CatId, //retreiving the category Id value to show it to the Category Id column of the data grid view
                                      Name = gc.CatName //retreiving the category name value to show it to the Name column of the data grid view
                                  };
            dgvGuestCategory.DataSource = guestCategories.ToList(); //method that executes the query for showing the users with all their data to the list
        }

        //method that hides the current form when 'X' button is clicked
        private void exitGCF_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}