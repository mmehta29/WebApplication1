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
            string username = usernameTb.Text;
            string password = passwordTb.Text;
            string repass = repassTb.Text;
            if (repass != password)
            {
                resultLbl.Text = "Passwords do not match!";
            } else
            {
                bool result = addUser(username, password);
                if (result)
                {
                    HttpCookie userCookie = new HttpCookie("UserLogin");
                    userCookie["UserID"] = username;
                    userCookie["Password"] = password;  // add hash?

                    Response.Cookies.Add(userCookie);
                    Response.Redirect("Login.aspx");
                }
            }
        }

        bool addUser(string username, string password)
        {
            string path = Server.MapPath("~/App_Data/Users.xml");
            XmlDocument doc = new XmlDocument();
            
            if (File.Exists(path))
            {
                doc.Load(path);
            } else
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

            if (doc.SelectSingleNode($"/Users/User[Username='{username}']") != null)
            {
                resultLbl.Text = "Username already exists";
                return false;
            }

            XmlElement userElement = doc.CreateElement("User");

            XmlElement userNode = doc.CreateElement("Username");
            userNode.InnerText = username;

            XmlElement passNode = doc.CreateElement("Password");
            passNode.InnerText = password;

            userElement.AppendChild(userNode);
            userElement.AppendChild(passNode);

            doc.DocumentElement.AppendChild(userElement);
            doc.Save(path);

            return true;
        }
    }
}
