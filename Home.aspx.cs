using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Web.DynamicData;
using System.Reflection;


namespace ToDoList
{
    public partial class Home : System.Web.UI.Page
    {
        UserListClasses1DataContext db = new UserListClasses1DataContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\hp\\Desktop\\rajiyaP\\.NetProjects\\webApps and sql\\ToDoList\\ToDoList\\App_Data\\UserList.mdf\";Integrated Security=True;Connect Timeout=30");
        private void showdata()
        {
            string currentUser = showname(); // Get the current user's name
            TextBox5.Text = currentUser;
            TextBox6.Text = getSerialNum().ToString();
            // Retrieve the data from the database for the current user only
            var qry = from item in db.UserLists
                      where item.Name == currentUser
                      group item by item.Name into userGroup
                      from userItem in userGroup.OrderBy(x => x.Id)
                      select new
                      {
                          userItem.Id,
                          userItem.Name,
                          userItem.Tasks,
                          userItem.Date,
                          userItem.Description,
                          userItem.Done
                      };

            // Create a dictionary to track the count of items for each user
            Dictionary<string, int> userCounts = new Dictionary<string, int>();

            // Initialize a list to hold the modified items
            List<object> modifiedItems = new List<object>();

            // Iterate over the grouped data to assign serial numbers
            foreach (var item in qry)
            {
                // Check if the user's name is already in the dictionary
                if (!userCounts.ContainsKey(item.Name))
                {
                    // If not, add the user's name to the dictionary with an initial count of 1
                    userCounts[item.Name] = 1;
                }
                else
                {
                    // If the user's name is already in the dictionary, increment the count
                    userCounts[item.Name]++;
                }

                // Create a new anonymous object with the desired properties, including SerialNumber
                var modifiedItem = new
                {
                    item.Id,
                    SerialNumber = userCounts[item.Name], // Assign the calculated serial number
                    item.Name,
                    item.Tasks,
                    item.Date,
                    item.Description,
                    item.Done
                };

                // Add the modified item to the list
                modifiedItems.Add(modifiedItem);
            }

            // Bind the modified data to the GridView
            GridView1.DataSource = modifiedItems;
            GridView1.DataBind();
        }



        public string showname()
        {
            // Initialize the data context
            LoginClasses1DataContext dbl = new LoginClasses1DataContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\hp\\Desktop\\rajiyaP\\.NetProjects\\webApps and sql\\ToDoList\\ToDoList\\App_Data\\Login_Database.mdf\";Integrated Security=True;Connect Timeout=30");

            // Check if the session variable "username" is not null and is of the correct type
            if (Session["username"] != null && Session["username"] is string)
            {
                // Retrieve the username from the session variable
                string username = Session["username"].ToString();
                return username;
            }
            else
            {
                // Handle the case where the session variable "username" is null or not of the correct type
                return "Username not found";
            }
        }




        private int GetMaxIdFromDatabase()
        {
              // Replace Entities and ID with the actual names in your code
                var maxIdEntity = db.UserLists.OrderByDescending(entity => entity.Id).FirstOrDefault();

                int maxId = (maxIdEntity != null) ? maxIdEntity.Id : 0;

                return maxId;
            

        }
        private int getSerialNum()
        {
            var serialNumEntity = db.UserLists.OrderByDescending(entity=> entity.SerialNumber).FirstOrDefault();
            int  serialNum = (serialNumEntity != null) ? serialNumEntity.Id : 0;
            return serialNum;
        }
       

        DateTime currentDateAndTime = DateTime.Now;
        private void PopulateListBox()
        {
            TodoListClasses1DataContext dbc = new TodoListClasses1DataContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\hp\\Documents\\ToDo.mdf;Integrated Security=True;Connect Timeout=30");

            // Assuming TodoClasses1DataContext is your LINQ to SQL data context
            // Retrieve data from the database
            var items = dbc.ToDoLists.ToList(); // Replace YourTableName with the name of your table

                // Clear the existing items in the ListBox
                ListBox1.Items.Clear();

                // Iterate over the items and add them to the ListBox
                foreach (var item in items)
                {
                    // Add each item to the ListBox, specifying the Text and Value properties
                    ListBox1.Items.Add(new ListItem(item.Title.ToString(), item.Id.ToString()));
                }
        }
      


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the maximum serial number for the current user's items
                


                TextBox1.Text = (GetMaxIdFromDatabase() + 1).ToString();
                TextBox6.Text = (getSerialNum() + 1).ToString();
                showdata();
                PopulateListBox();
            }
            string formattedDate = currentDateAndTime.Date.ToString("dd/MM/yyyy");
            TextBox4.Text = formattedDate;
           


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            showdata();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            showdata();
        }


        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            TextBox textId = (TextBox)row.Cells[0].Controls[0];
            TextBox textNumber = (TextBox)row.Cells[6].Controls[0]; // Corrected index
            TextBox textName = (TextBox)row.Cells[1].Controls[0]; // Adjusted index
            TextBox textTasks = (TextBox)row.Cells[2].Controls[0]; // Adjusted index
            //TextBox textDate = (TextBox)row.Cells[3].Controls[0]; // Adjusted index
            //CheckBox chkDone = (CheckBox)row.Cells[5].Controls[0]; 
            //TextBox textlearnt = (TextBox)row.Cells[4].Controls[0];

            CheckBox chkDone = (CheckBox)row.Cells[4].Controls[0]; // Updated index
            TextBox textLearnt = (TextBox)row.Cells[5].Controls[0]; // Updated index
            TextBox textDate = (TextBox)row.Cells[6].Controls[0]; // Updated index

            bool isChecked = chkDone.Checked;
            int id = Convert.ToInt32(textId.Text);
            UserList d = (from res in db.UserLists where (res.Id == id) select res).First();
            d.Name = textName.Text;
            d.Tasks = textTasks.Text;
            d.Date = textDate.Text;
            d.Done = Convert.ToBoolean(chkDone.Checked);
            d.Description = TextBox3.Text;
            //d.SerialNumber = Convert.ToInt32(textNumber.Text);
            db.SubmitChanges();
            GridView1.EditIndex = -1;
            showdata();
        }




        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    string id = GridView1.Rows[e.RowIndex].Cells[0].Text;
        //    var res1 = (from res in db.UserLists where (res.Id == int.Parse(id)) select res).First();
        //    db.UserLists.DeleteOnSubmit(res1);
        //    db.SubmitChanges();

        //    // Reorder the IDs of the remaining items

        //    TextBox1.Text = (GetMaxIdFromDatabase() + 1).ToString();

        //    // Refresh the GridView
        //    showdata();

        //}
        // Step 1: Reorder IDs on Item Deletion

        //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    GridViewRow row = GridView1.Rows[e.RowIndex];
        //    string id = row.Cells[1].Text; // Assuming the ID column is at index 1

        //    int itemId;
        //    if (int.TryParse(id, out itemId))
        //    {
        //        var itemToDelete = db.UserLists.FirstOrDefault(res => res.Id == itemId);
        //        if (itemToDelete != null)
        //        {
        //            db.UserLists.DeleteOnSubmit(itemToDelete);
        //            db.SubmitChanges();

        //            // Refresh the GridView

        //            showdata();

        //        }
        //    }
        //    else
        //    {
        //        // ID parsing failed
        //        // Provide feedback to the user
        //        // You can display an error message here if needed
        //    }
        //}

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int itemId = Convert.ToInt32(GridView1.DataKeys[rowIndex].Value);

            var itemToDelete = db.UserLists.FirstOrDefault(res => res.Id == itemId);
            if (itemToDelete != null)
            {
                db.UserLists.DeleteOnSubmit(itemToDelete);
                db.SubmitChanges();

                // Refresh the GridView
                showdata();
            }
            else
            {
                // Provide feedback to the user indicating that the item to delete was not found
            }
        }



        // Method to reorder IDs of remaining items
        //private void ReorderItemIDs()
        //{
        //    var items = db.UserLists.OrderBy(item => item.Id).ToList();

        //    // Update the IDs for each item to make them contiguous
        //    for (int i = 0; i < items.Count; i++)
        //    {
        //        items[i].Id = i + 1; // Update the ID to be sequential starting from 1
        //    }

        //    // Submit the changes to the database
        //    db.SubmitChanges();
        //}
        //// Step 2: Hide ID Column
        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        // Hide the first cell (ID column) in each row
        //        e.Row.Cells[0].Visible = false;
        //    }
        //}



        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            showdata();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            GridView1.DataSource= null;
            GridView1.DataBind();
            
          
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            PopulateListBox();

            
            UserList st = new UserList();
            st.Id = Convert.ToInt32(TextBox1.Text);
            //st.Name = TextBox1.Text;
            st.SerialNumber = Convert.ToInt32(TextBox6.Text);
            st.Tasks = TextBox2.Text;
            st.Description = TextBox3.Text;
            st.Date = DateTime.Now.Date.ToString("dd/MM/yyy");
            st.Name = TextBox5.Text;
           
            db.UserLists.InsertOnSubmit(st);
            db.SubmitChanges();

            // Hide elements after adding a new item
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox1.Text = "";
            TextBox1.Text = (GetMaxIdFromDatabase() + 1).ToString();
            TextBox6.Text = (getSerialNum() + 1).ToString();

            // Call the client-side function to hide elements
            ScriptManager.RegisterStartupScript(this, GetType(), "HideElementsScript", "showElements();", true);

            // Refresh the GridView
            showdata();
           

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if an item is selected in the ListBox
            if (ListBox1.SelectedItem != null)
            {
                // Set the Text property of the TextBox with the selected item from the ListBox
                TextBox2.Text = ListBox1.SelectedItem.Text; // Assuming ListBox1 is your ListBox and TextBox1 is your TextBox
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "HideElementsScript", "showElements();", true);


        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox4.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            DateTime selectedDate = Calendar1.SelectedDate;
            string currentUser = showname();

            //TodoClasses1DataContext db = new TodoClasses1DataContext("connectionString");
            var todoItems = db.UserLists.ToList(); // Assuming ToDoLists is your table name

            // Filter the data based on the selected date
            // Filter the data based on the selected date
            var filteredItems = todoItems.Where(item => item.Name == currentUser && DateTime.ParseExact(item.Date, "dd/MM/yyyy", null) == selectedDate.Date);
            
            // Bind the filtered data to the GridView
            GridView1.DataSource = filteredItems;
            GridView1.DataBind();
            
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            showdata();
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}