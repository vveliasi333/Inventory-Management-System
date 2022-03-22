using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

//the namespace with the same name as the solution
namespace InventoryManagementSystem
{
    //the class of Home Form derived from the Form class of Windows Forms
    public partial class HomeForm : Form
    {
        //initializes the Home Form
        public HomeForm()
        {
            InitializeComponent();
        }

        //method for when we click the users button
        private void usersPicture_Click(object sender, EventArgs e)
        {
            //converting the role combobox to string and storing it as a variable named role
            string role = comboRole.Text.ToString();

            //if condition that blocks user and guest from clicking the users button
            if (role != "Administrator")
            {
                usersPicture.Enabled = false;
                MessageBox.Show("You're not an administrator!");
            }

            //else if condition that returns the user form if administrator clicks the users button
            else if (role == "Administrator")
            {
                UserForm u = new UserForm();
                u.Show();
            }
        }

        //method for when the products button is clicked, returns the product form
        private void productsPicture_Click(object sender, EventArgs e)
        {
                ProductForm p = new ProductForm();
                p.Show();
        }

        //method for when the categories button is clicked, returns the category form
        private void categoriesPicture_Click(object sender, EventArgs e)
        {
                CategoryForm c = new CategoryForm();
                c.Show();
        }

        //method for when the add users button is clicked
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //converting the role combobox to string and storing it as a variable named role
            string role = comboRole.Text.ToString();

            //if condition that blocks user and guest from clicking the add users button
            if (role != "Administrator")
            {
                pictureBox4.Enabled = false;
                MessageBox.Show("You're not an administrator!");
            }

            //else if condition that returns the user module form if administrator clicks the add users button
            else if (role == "Administrator")
            {
                UserModuleForm um = new UserModuleForm();
                um.Show();
            }
        }

        //method for when the add products button is clicked
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //converting the role combobox to string and storing it as a variable named role
            string role = comboRole.Text.ToString();

            //if condition that blocks guest from clicking the add products button
            if (role == "Guest")
            {
                pictureBox5.Enabled = false;
                MessageBox.Show("You don't have permission for that!");
            }

            /*else if condition that returns the product module form
              if administrator or user clicks the add products button*/
            else if (role != "Guest")
            {
                ProductModuleForm pm = new ProductModuleForm();
                pm.Show();
            }
        }

        //method for when the add categories button is clicked
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //converting the role combobox to string and storing it as a variable named role
            string role = comboRole.Text.ToString();

            //if condition that blocks guest from clicking the add categories button
            if (role == "Guest")
            {
                pictureBox6.Enabled = false;
                MessageBox.Show("You don't have permission for that!");
            }

            /*else if condition that returns the category module form
              if administrator or user clicks the add categories button*/
            else if (role != "Guest")
            {
                CategoryModuleForm cm = new CategoryModuleForm();
                cm.Show();
            }
        }

        //method for when logout button is clicked, logouts the user and returns the login form
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LoginForm relogin = new LoginForm();
            relogin.Show();
            this.Hide();
        }
    }
}