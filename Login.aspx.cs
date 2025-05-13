using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoList
{

    public partial class Login : System.Web.UI.Page
    {
        LoginClasses1DataContext db = new LoginClasses1DataContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\hp\\Desktop\\rajiyaP\\.NetProjects\\webApps and sql\\ToDoList\\ToDoList\\App_Data\\Login_Database.mdf\";Integrated Security=True;Connect Timeout=30");
        private bool AuthenticateUser(int userID, string password)
        {
            // Find user in the database based on the entered username
            var user = db.Logins.SingleOrDefault(u => u.User_ID == userID);


            // Check if the entered password matches the stored password
            if (user != null)
                {
                    // Check if the entered password matches the stored password
                    if (user.Password == password && user.User_ID == userID)
                    {
                        // Authentication successful
                        // Now, we can access user properties like user.User_ID, user.Role, etc.

                        // Set the user role in a session variable for further use
                        Session["UserRole"] = user.Role;
                        Session["username"] = user.User_Name;
                        
                    return true;
                    }
                }
            // Authentication failed
            return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string user = TextBox1.Text;


            // Try to convert the string to an integer
            if (int.TryParse(user, out int userID))
            {
                // The conversion was successful, and userID now holds the integer value
                // Now we can use userID in your authentication logic
            }
            else
            {
                // The conversion failed, TextBox1.Text is not a valid integer
                // Handle the error or display a message to the user
                Label1.Text = "Invalid user ID format. Please enter a valid integer.";
            }

            string password = TextBox2.Text;

                if (AuthenticateUser(userID, password))
                {
                    // Redirect based on the user's role
                    string userRole = Session["UserRole"] as string;
              
                    if (userRole == "Admin")
                    {
                        Response.Redirect("Admin.aspx");
                    }
                    else
                    {
                        Response.Redirect("Home.aspx");
                    }
                }
                else
                {
                    // Display login failed message or take appropriate action
                }
            

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    


 