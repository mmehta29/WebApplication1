// Page created by: Carissa Moore (1224352909)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;

namespace WebApplication1
{
        public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void createAccountBtn_Click(object sender, EventArgs e)
        {
            // getting entered information
            string username = usernameTb.Text;
            string password = passwordTb.Text;
            string repass = repassTb.Text;
            // if the two passwords don't match, the user is notified
            if (repass != password)
            {
                resultLbl.Text = "Passwords do not match!";
            } else
            {
                bool result = addUser(username, password);  // adds the user to Users.xml if they do not exist
                if (result)                                 // if the user was successfully added
                {
                    HttpCookie userCookie = new HttpCookie("UserLogin");    // creates a new cookie with the username and password
                    userCookie["UserID"] = username;
                    userCookie["Password"] = password;  // add hash?

                    Response.Cookies.Add(userCookie);           
                    Response.Redirect("Login.aspx");                       // takes the user to the login page
                }
            }
        }
        
        // method to add the new user to Users.xml
        bool addUser(string username, string password)
        {
            string path = Server.MapPath("~/App_Data/Users.xml");   // path to Users.xml
            XmlDocument doc = new XmlDocument();
            
            if (File.Exists(path))      // if Users.xml exists, it is opened
            {
                doc.Load(path);
            } else                     // if Users.xml was deleted, create a new one
            {
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.CreateElement("Users");
                doc.AppendChild(xmlDeclaration);
                doc.AppendChild(root);

                XmlElement staffElement = doc.CreateElement("User");
                XmlElement staffUNameNode = doc.CreateElement("Username");
                staffUNameNode.InnerText = "TA";
                XmlElement staffPassNode = doc.CreateElement("Password");
                staffPassNode.InnerText = "Cse445!";
                staffElement.AppendChild(staffUNameNode);
                staffElement.AppendChild(staffPassNode);

                doc.DocumentElement.AppendChild(staffElement);
                doc.Save(path);
            }

            if (doc.SelectSingleNode($"/Users/User[Username='{username}']") != null)    // if the username already exists, the user must pick a new one
            {
                resultLbl.Text = "Username already exists";
                return false;
            }

            XmlElement userElement = doc.CreateElement("User");     // User element for xml

            XmlElement userNode = doc.CreateElement("Username");    // username node with given username
            userNode.InnerText = username;

            XmlElement passNode = doc.CreateElement("Password");    // password node with given password
            passNode.InnerText = password;

            userElement.AppendChild(userNode);                      // adding the usernname and password to the User element
            userElement.AppendChild(passNode);

            doc.DocumentElement.AppendChild(userElement);           // adding the new User to Users.xml
            doc.Save(path);

            return true;
        }
    }
}
