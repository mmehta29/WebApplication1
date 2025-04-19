using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack && Request.Cookies["UserLogin"] != null)
            {
                usernameTb.Text = Request.Cookies["UserLogin"]["UserId"];
                passwordTb.Text = Request.Cookies["UserLogin"]["Password"];
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTb.Text;
            string password = passwordTb.Text;

            bool result = CheckUser(username, password);

            if (!result)
            {
                resultLbl.Text = "Invalid username or password";
            } else
            {
                if (username == "TA" && password == "Cse445!")
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    Session["Staff"] = true;
                    FormsAuthentication.RedirectFromLoginPage(username, false);
                } else
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    Session["Staff"] = false;
                    Session["Member"] = true;
                    FormsAuthentication.RedirectFromLoginPage(username, false);
                }
            }
        }

        bool CheckUser(string username, string password)
        {
            string path = Server.MapPath("~/App_Data/Users.xml");
            if (!File.Exists(path))
            {
                return false;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            // check if hashed

            XmlNode user = doc.SelectSingleNode($"/Users/User[Username='{username}' and Password='{password}']");
            
            if (user != null)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
