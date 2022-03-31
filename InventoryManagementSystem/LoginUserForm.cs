﻿using System;
            //the following if conditions check if any textbox of the form is empty, and requires the user to fill the credentials out
            if ((txtName.Text.Length == 0 || txtName.Text.Trim().Length == 0)) //username textbox if it is empty
            {
            {

            //declaring a string as name, and using it to store the username inserted in its textbox
            string name = this.txtName.Text;
            //string used to check the inserted username in the respective textbox
            string user = this.txtName.Text;

            //query that selects the username and checks if exists in the table
            var query = from tr in context.tbUsers //tr is a variable used for the query
                        where tr.Username == user

            //if query returns null means that it does not exist in the table
            if (query == null)

            //else would mean that it does exist in the table
            else

        //method when logout button is clicked
        private void btnReturnLogin_Click(object sender, EventArgs e)
            l.Show(); //shows the form
            this.Hide(); //hides the current form
        }