using System;
using System.Windows.Forms;
using System.Data;
using System.Linq;

namespace InventoryManagementSystem
{
    public partial class UserForm : Form
    {
        //context field of the database (DBIMSEntities)
        DBIMSEntities context = new DBIMSEntities();

        //method that initializes the UserForm
        public UserForm()
        {
            InitializeComponent();
            LoadUser(); //calling the LoadUser method at form initialization
        }

        //the implementation of the method that shows user data from the table to the data grid view of the UserForm
        public void LoadUser()
        {
            //entities is a local variable created to use the database as an instance, in order to execute the queries
            DBIMSEntities entities = new DBIMSEntities();

            //query for loading every user data from the table
            var users = from u in entities.tbUsers
                        select new
                        {
                            No = u.Id, //retreiving the Id value to show it to the No column of the data grid view
                            Id = u.Id, //retreiving the Id value to show it to the User Id column of the data grid view
                            Username = u.Username, //retreiving the Username value to show it to the Username column of the data grid view
                            Fullname = u.Fullname, //retreiving the Fullname value to show it to the Fullname column of the data grid view
                            Password = u.Password, //retreiving the Password value to show it to the Password column of the data grid view
                            Phone = u.Phone, //retreiving the Phone value to show it to the Phone column of the data grid view
                            Type = u.Type //retreiving the Type value to show it to the Type column of the data grid view
                        };

            dgvUser.DataSource = users.ToList(); //method that executes the query for showing the users with all their data to the list
        }

        //method for when clicking a cell of the data grid view, specifically used for the Delete column
        public void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //declaring a string as colName, and assigning it to the column index in order to implement a function for the Delete column
            string colName = dgvUser.Columns[e.ColumnIndex].Name;

            //if condition to locate the Delete column
            if (colName == "Delete")
            {
                //if condition to check if the Delete column cell is clicked
                if (MessageBox.Show("Are you sure you want to delete this user?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Guid userid = new Guid(dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString()); //converting the Guid datatype of the user Id to string

                    var deleteuser = (from u in context.tbUsers where u.Id == userid select u).First(); //query to select the user Id from tbUser (User Table)
                    context.tbUsers.Remove(deleteuser); //remove method that executes the query (held by the deleteuser variable) for deleting a user from the table
                    context.SaveChanges(); //method that saves changes to the table

                    MessageBox.Show("User has been successfully deleted.", "User Deleted");
                }
                //calling the LoadUser method to refresh the table data after changes are made
                LoadUser();
            }
        }

        //method that hides the current form when 'X' button is clicked
        private void exitUF_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}