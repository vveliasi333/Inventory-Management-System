using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class CategoryForm : Form
    {
        //context field of the database (DBIMSEntities)
        DBIMSEntities context = new DBIMSEntities();

        //method that initializes the CategoryForm
        public CategoryForm()
        {
            InitializeComponent();
            LoadCategory(); //calling the LoadCategory method at form initialization
        }

        //the implementation of the method that shows category data from the table to the data grid view of the CategoryForm
        public void LoadCategory()
        {
            //entities is a local variable created to use the database as an instance, in order to execute the queries
            DBIMSEntities entities = new DBIMSEntities();

            //query for loading every category data from the table
            var categories = from c in entities.tbCategories
                             select new
                             {
                                 No = c.CatId, //retreiving the category Id value to show it to the No column of the data grid view
                                 CategoryId = c.CatId, //retreiving the category Id value to show it to the Category Id column of the data grid view
                                 Name = c.CatName //retreiving the category name value to show it to the Name column of the data grid view
                             };

            dgvCategory.DataSource = categories.ToList(); //method that executes the query for showing the categories with all their data to the list
        }

        //method for when clicking a cell of the data grid view, specifically used for the Delete column
        public void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //declaring a string as colName, and assigning it to the column index in order to implement a function for the Delete column
            string colName = dgvCategory.Columns[e.ColumnIndex].Name;

            //if condition to locate the Delete column
            if (colName == "Delete")
            {
                //if condition to check if the Delete column cell is clicked
                if (MessageBox.Show("Are you sure you want to delete this category?", "Delete Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid categoryid = new Guid(dgvCategory.Rows[e.RowIndex].Cells[1].Value.ToString()); //converting the Guid datatype of the category Id to string

                    var deletecategory = (from c in context.tbCategories where c.CatId == categoryid select c).First(); //query to select the category Id from tbCategory (Category Table)
                    context.tbCategories.Remove(deletecategory); //remove method that executes the query (held by the deletecategory variable) for deleting a category from the table
                    context.SaveChanges(); //method that saves changes to the table

                    MessageBox.Show("Category has been successfully deleted.", "Category Deleted");
                }
                //calling the LoadCategory method to refresh the table data after changes are made
                LoadCategory();
            }
        }

        //method that hides the current form when 'X' button is clicked
        private void exitCF_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}