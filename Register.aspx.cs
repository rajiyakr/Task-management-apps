using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoList
{
    public partial class Register : System.Web.UI.Page
    {
        LoginClasses1DataContext db = new LoginClasses1DataContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\hp\\Desktop\\rajiyaP\\.NetProjects\\webApps and sql\\ToDoList\\ToDoList\\App_Data\\Login_Database.mdf\";Integrated Security=True;Connect Timeout=30");

        private int GetMaxIdFromDatabase()
        {

            // Replace Entities and ID with the actual names 
            var maxId = db.Logins.Max(login => (int?)login.User_ID) ?? 0;


            return maxId;


        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set TextBox1 text to the next available ID
                TextBox1.Text = (GetMaxIdFromDatabase() + 1).ToString();
            }
        }
        
        protected void Button3_Click(object sender, EventArgs e)
        {

            Login ln = new Login();
            ln.User_ID = Convert.ToInt32(TextBox1.Text);
            ln.User_Name = TextBox2.Text;
            ln.Password = TextBox3.Text;
            ln.Role = TextBox4.Text;
            db.Logins.InsertOnSubmit(ln);
            db.SubmitChanges();

            TextBox1.Text = (GetMaxIdFromDatabase() + 1).ToString();
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";

        }

        
    }
}