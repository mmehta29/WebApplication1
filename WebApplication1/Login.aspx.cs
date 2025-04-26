// Page created by: Carissa Moore (1224352909)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using ClassLibrary1;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)  // if the user is already logged in, redirects them back to the Default page
            {
                Response.Redirect("Default.aspx");
            }

            // if the user has just created their account, their username and password is automatically filled in
            if (!IsPostBack && Request.Cookies["UserLogin"] != null)
            {
                usernameTb.Text = Request.Cookies["UserLogin"]["UserId"];
                passwordTb.Text = Request.Cookies["UserLogin"]["Password"];
            }
        }

        // login button
        protected void loginBtn_Click(object sender, EventArgs e)
        {
            // getting entered information
            string username = usernameTb.Text;
            string password = passwordTb.Text;
            

            bool member = CheckUser(username, password);    // checking if the entered information is in Member.xml
            bool staff = isStaff(username, password);

            if (!member && !staff)        // if the username and password isn't in Member.xml
            {
                resultLbl.Text = "Invalid username or password";
            }
            else
            {
                if (staff)  // if the User entered the Staff login
                {
                    FormsAuthentication.SetAuthCookie(username, false);             // creates a cookie with their login information
                    Session["Staff"] = true;                                        // sets the Session State of Staff to true
                    FormsAuthentication.RedirectFromLoginPage(username, false);
                }
                else        // if the User is a Member
                {
                    FormsAuthentication.SetAuthCookie(username, false);         // creates a cookie with their login information
                    Session["Staff"] = false;                                   // sets the Session State of Staff to false
                    Session["Member"] = true;                                   // sets the Sesion State of Memeber to true
                    FormsAuthentication.RedirectFromLoginPage(username, false);
                }
            }
        }

        // method to check whether the entered username and password match for a verified account in Member.xml
        bool CheckUser(string username, string password)
        {
            password = Class1.ComputeSha256Hash(password);
            string path = Server.MapPath("~/App_Data/Member.xml");   // path to Member.xml
            if (!File.Exists(path))             // if the file doesn't exist, there are no users and nobody can login
            {
                return false;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(path);                     // loading Member.xml to be read

            // checking if a node is returned with the given username and password combination
            XmlNode user = doc.SelectSingleNode($"/Members/Member[Username='{username}' and Password='{password}']");

            if (user != null)   // if the user exists, return true
            {
                return true;
            }
            else               // if the user doesn't exist, return false
            {
                return false;
            }
        }

        // method to check if the user is in Staff.xml
        bool isStaff(string username, string password)
        {
            password = Class1.ComputeSha256Hash(password);
            string path = Server.MapPath("~/App_Data/Staff.xml");   // path to Staff.xml
            
            if (!File.Exists(path))   // if Staff.xml does not exist, then there are no Staff
            {
                return false;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(path);                     // loading Staff.xml to be read

            // check if hashed

            // checking if a node is returned with the given username and password combination
            XmlNode user = doc.SelectSingleNode($"/StaffMembers/Staff[Username='{username}' and Password='{password}']");

            if (user != null)   // if the user exists, return true
            {
                return true;
            }
            else               // if the user doesn't exist, return false
            {
                return false;
            }
        }
    }
}
