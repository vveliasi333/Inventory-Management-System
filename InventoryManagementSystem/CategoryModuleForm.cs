using System;
using System.Windows.Forms;
using System.Linq;

namespace InventoryManagementSystem
{
    public partial class CategoryModuleForm : Form
    {
        //context field of the database (DBIMSEntities)
        DBIMSEntities context = new DBIMSEntities();

        //method that initializes the UserModuleForm
        public CategoryModuleForm()
        {
            InitializeComponent();
        }

        //method when Save button is clicked
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DBIMSEntities()) //db is a variable used as an instance of DBIMSEntities, in order to execute queries on the database
                {
                    var insert = new tbCategory(); //insert is a variable used as an instance of tbCategory (Category table)

                    //if condition checks if the textbox of the form is empty, and requires the user to fill the credential out
                    if ((txtCatName.Text.Length == 0 || txtCatName.Text.Trim().Length == 0)) //category name textbox if it is empty
                    {
                        MessageBox.Show("Please, fill out the credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //instance of the CategoryExist method to prevent category duplication
                    bool exist = CategoryExist(); //exist is a variable for the method

                    //if condition to check if a category already exists
                    if (exist == true) //if the answer is true means the category exists
                    {
                        MessageBox.Show("This category already exists!", "Register Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //else block that executes if all the conditions above are passed
                    else
                    {
                        //lines that insert each data from the table to its respective textbox
                        insert.CatId = Guid.NewGuid(); //category Id generated as Guid
                        insert.CatName = txtCatName.Text; //CatName (category name) is the parameter of the table, and txtCatName is the textbox of the form

                        //add method that executes the query(held by the insert variable) for inserting a category to the table
                        db.tbCategories.Add(insert);

                        //method that saves changes to the table
                        db.SaveChanges();

                        MessageBox.Show("Category has been successfully saved.", "Category Created");
                    }
                }
            }

            catch (Exception) //catch block that returns a user-friendly message in case of an error
            {
                MessageBox.Show("An error has occurred!", "Database Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //method for the clear button
        public void Clear()
        {
            //clears every typed info in the textbox
            txtCatName.Clear();
        }

        //method that executes when clear button is clicked
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            UserModuleForm userModule = new UserModuleForm();
            userModule.btnSave.Enabled = true;
            userModule.ShowDialog();
        }

        //method that checks if a category already exists in order to prevent duplication
        public bool CategoryExist()
        {
            //string used to check the inserted category name in the respective textbox
            string category = this.txtCatName.Text;

            //query that selects the category name and checks if exists in the table
            var query = from tr in context.tbCategories //tr is a variable used for the query
                        where tr.CatName == category
                        select tr;

            //if query returns null means that it does not exist in the table
            if (query == null)
            {
                return false;
            }

            else if (query.Count() == 0)
            {
                return false;
            }

            //else would mean that it does exist in the table
            else
            {
                return true;
            }
        }
    }
}