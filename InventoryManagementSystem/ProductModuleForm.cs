using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class ProductModuleForm : Form
    {
        //context field of the database (DBIMSEntities)
        DBIMSEntities context = new DBIMSEntities();

        //method that initializes the UserModuleForm
        public ProductModuleForm()
        {
            InitializeComponent();
            LoadCategory(); //calling the LoadCategory method at form initialization
        }

        //the implementation of the method that shows category data from the table to the data grid view of the CategoryForm
        public void LoadCategory()
        {
            //query for loading every category data from the table
            List<tbCategory> categories = (from ctg in context.tbCategories //ctg is a variable used for the query, and context is the field to access the tbCategories (Category Table)
                                           select ctg).ToList(); //ToList method lists every category to combobox of the ProductModuleForm

            comboCat.DataSource = categories; //comboCat is the combobox of the form where the category of the registered product can be selected
            comboCat.DisplayMember = "CatName"; //CatName is the name of the parameter for the category name in the table
        }

        //method when Save button is clicked
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DBIMSEntities()) //db is a variable used as an instance of DBIMSEntities, in order to execute queries on the database
                {
                    var insert = new tbProduct(); //insert is a variable used as an instance of tbProduct (Product table)

                    //the following if conditions check if any textbox of the form is empty, and requires the user to fill the credentials out
                    if ((txtPName.Text.Length == 0 || txtPName.Text.Trim().Length == 0)) //product name textbox if it is empty
                    {
                        MessageBox.Show("Please, fill out the credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if ((txtPQty.Text.Length == 0 || txtPQty.Text.Trim().Length == 0)) //product quantity textbox if it is empty
                    {
                        MessageBox.Show("Please, fill out the credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if ((txtPPrice.Text.Length == 0 || txtPPrice.Text.Trim().Length == 0)) //product price textbox if it is empty
                    {
                        MessageBox.Show("Please, fill out the credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if ((txtPDes.Text.Length == 0 || txtPDes.Text.Trim().Length == 0)) //product description textbox if it is empty
                    {
                        MessageBox.Show("Please, fill out the credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if ((comboCat.Text.Length == 0 || comboCat.Text.Trim().Length == 0)) //category combobox if it is empty
                    {
                        MessageBox.Show("Please, fill out the credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //instance of the ProductExist method to prevent product duplication
                    bool exist = ProductExist(); //exist is a variable for the method

                    //if condition to check if a user already exists
                    if (exist == true) //if the answer is true means the user exists
                    {
                        MessageBox.Show("This product already exists!", "Register Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //else block that executes if all the conditions above are passed
                    else
                    {
                        //lines that insert each data from the table to its respective textbox, and/or combobox
                        insert.pid = Guid.NewGuid(); //product Id generated as Guid
                        insert.pname = txtPName.Text; //pname (product name) is the parameter of the table, and txtPName is the textbox of the form
                        insert.pqty = Convert.ToInt16(txtPQty.Text); //pqty (product quantity) is the parameter of the table, and txtPQty is the textbox of the form
                        insert.pprice = Convert.ToInt16(txtPPrice.Text); //pprice (product price) is the parameter of the table, and txtPPrice is the textbox of the form
                        insert.pdescription = txtPDes.Text; //pdescription (product description) is the parameter of the table, and txtPDes is the textbox of the form
                        insert.pcategory = comboCat.Text; //pcategory (product category) is the parameter of the table, and comboCat is the category combobox of the form

                        //add method that executes the query(held by the insert variable) for inserting a product to the table
                        db.tbProducts.Add(insert);

                        //method that saves changes to the table
                        db.SaveChanges();

                        MessageBox.Show("Product has been successfully saved.", "Product Created");
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
            //clears every typed info in the textboxes
            txtPName.Clear();
            txtPQty.Clear();
            txtPPrice.Clear();
            txtPDes.Clear();
            comboCat.Text = "";
        }

        //method that executes when clear button is clicked
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            btnSave.Enabled = true;
        }

        //method that checks if a product already exists in order to prevent duplication
        public bool ProductExist()
        {
            //string used to check the inserted product name in the respective textbox
            string product = this.txtPName.Text;

            //query that selects the product name and checks if exists in the table
            var query = from tr in context.tbProducts //tr is a variable used for the query
                        where tr.pname == product
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