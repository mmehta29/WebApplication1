// Page created by: Carissa Moore (1224352909)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using ClassLibrary1;

namespace WebApplication1
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if the user does not have Staff access, they are redirected back to the Default page
            if (Session["Staff"] == null || (bool)Session["Staff"] == false)
            {
                Response.Redirect("~/Default.aspx");
            }

            // sets a Welcome textbox with the user's username
            if (Context.User.Identity.IsAuthenticated)
            {
                welcomeLbl.Text = "Welcome, " + Context.User.Identity.Name + "!";
            }
        }

        // button to add a new Staff member
        protected void addStaffBtn_Click(object sender, EventArgs e)
        {
            // getting entered information
            string username = usernameTb.Text;
            string password = passwordTb.Text;

            // checking whether the username exists and adding the new Staff if it does not
            bool result = addUser(username, password);

            // if the new Staff was added, the user is informed
            if (result)
            {
                resultLbl.Text = "New Staff Member " + username + " added!";
            }
        }

        // button to list all Staff members
        protected void listStaffBtn_Click(object sender, EventArgs e)
        {
            staffLb.Items.Clear();  // clearing the previous listed Staff, if applicable

            string path = Server.MapPath("~/App_Data/Staff.xml"); // path to Staff.xml

            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            XmlNodeList staffList = doc.SelectNodes("/StaffMembers/Staff"); // getting a list of all Staff

            // iterating through the list of Staff and adding each username to the list box
            foreach (XmlNode staff in staffList)
            {
                string username = staff["Username"]?.InnerText;

                staffLb.Items.Add($"Username: {username}");
            }
        }

        // method to add the new user to Staff.xml
        bool addUser(string username, string password)
        {
            password = Class1.ComputeSha256Hash(password);
            string path = Server.MapPath("~/App_Data/Staff.xml"); // path to Staff.xml
            XmlDocument doc = new XmlDocument();

            doc.Load(path);

            // if the username is already in use, the user is informed
            if (doc.SelectSingleNode($"/StaffMembers/Staff[Username='{username}']") != null)
            {
                resultLbl.Text = "Username already exists";
                return false;
            }

            XmlElement userElement = doc.CreateElement("Staff");     // Member element for xml

            XmlElement userNode = doc.CreateElement("Username");    // username node with given username
            userNode.InnerText = username;

            XmlElement passNode = doc.CreateElement("Password");    // password node with given password
            passNode.InnerText = password;

            userElement.AppendChild(userNode);                      // adding the usernname and password to the User element
            userElement.AppendChild(passNode);

            doc.DocumentElement.AppendChild(userElement);           // adding the new Member to Member.xml
            doc.Save(path);

            return true;
        }
    }
}
