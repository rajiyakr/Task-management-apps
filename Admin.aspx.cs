using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoList
{
    public partial class Admin : System.Web.UI.Page
    {
        TodoListClasses1DataContext db = new TodoListClasses1DataContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\hp\\Documents\\ToDo.mdf;Integrated Security=True;Connect Timeout=30");
        UserListClasses1DataContext dbu = new UserListClasses1DataContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\hp\\Desktop\\rajiyaP\\.NetProjects\\webApps and sql\\ToDoList\\ToDoList\\App_Data\\UserList.mdf\";Integrated Security=True;Connect Timeout=30");
       
        private void getData()
        {
            var qry = from res in db.ToDoLists select res;

            GridView1.DataSource = qry.ToList();
            GridView1.DataBind();
        }
        private void showAnotherData()
        {
            var qeryy = from res in dbu.UserLists select res;
            GridView2.DataSource = qeryy.ToList();
            GridView2.DataBind();
        }
      
        private void showStatus()
        {
            bool allDone = dbu.UserLists.All(u => u.Done == true);
            if (allDone)
            {
                Label1.Text = "Project has completed.";
            }
            else
            {
                Label1.Text = "Project is incomplete.";
            }
        }

        private int GetMaxIdFromDatabase()
        {
                var maxIdEntity = db.ToDoLists.OrderByDescending(entity => entity.Id).FirstOrDefault();

                int maxId = (maxIdEntity != null) ? maxIdEntity.Id : 0;

                return maxId;

        }
        DateTime currentDateAndTime = DateTime.Now;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View2);
            if (!IsPostBack) { 
             getData();
             TextBox1.Text = (GetMaxIdFromDatabase() + 1).ToString();
             showAnotherData();
                showStatus();
            }
            string formattedDate = currentDateAndTime.Date.ToString("dd/MM/yyyy");
            TextBox3.Text = formattedDate;
            Session["projuctStatus"] = dbu.UserLists.SingleOrDefault(u => u.Done == true);




        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            getData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            TextBox textId = (TextBox)row.Cells[0].Controls[0];
            TextBox textTitle = (TextBox)row.Cells[1].Controls[0];
            TextBox textdate = (TextBox)row.Cells[2].Controls[0];
            int id = Convert.ToInt32(textId.Text);
            ToDoList d = (from res in db.ToDoLists where (res.Id == id) select res).First();

            d.Title = textTitle.Text;
            db.SubmitChanges();
            GridView1.EditIndex = -1;
            getData();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.Rows[e.RowIndex].Cells[0].Text;

            var res1 = (from res in db.ToDoLists where (res.Id == int.Parse(id)) select res).First();
            db.ToDoLists.DeleteOnSubmit(res1);
            db.SubmitChanges();
            TextBox1.Text = (GetMaxIdFromDatabase() + 1).ToString();
            getData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            getData();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            ToDoList st = new ToDoList();
            st.Id = Convert.ToInt32(TextBox1.Text);
            st.Title = TextBox2.Text;

            st.Date = DateTime.Today;

            db.ToDoLists.InsertOnSubmit(st);
            db.SubmitChanges();

            // Hide elements after adding a new item
            TextBox2.Text = "";
            TextBox1.Text = (GetMaxIdFromDatabase() + 1).ToString();
            getData();
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox3.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");

            // Get the selected date
            DateTime selectedDate = Calendar1.SelectedDate.Date;

            // Filter the data based on the selected date
            var filteredItems = db.ToDoLists.Where(item => item.Date.HasValue && item.Date.Value.Date == selectedDate).ToList();

            // Bind the filtered data to the GridView
            GridView1.DataSource = filteredItems;
            GridView1.DataBind();
        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            getData();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View3);
        }
    }
}