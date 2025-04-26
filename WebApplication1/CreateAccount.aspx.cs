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
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if this is the first time the page is loaded, a captcha is created
            if (!IsPostBack)
            {
                createCaptcha();
            }
        }

        // the button to create an account
        protected void createAccountBtn_Click(object sender, EventArgs e)
        {
            // getting entered information
            string username = usernameTb.Text;
            string password = passwordTb.Text;
            string repass = repassTb.Text;
            string enteredCaptcha = captchaTb.Text;

            // checking captcha. if the captcha is incorrect, a new image is created
            if (Session["captcha"] == null || enteredCaptcha != Session["captcha"].ToString())
            {
                captchaResult.Text = "Incorrect captcha!";  
                createCaptcha();
                return;
            }

            // if the two passwords don't match, the user is notified
            if (repass != password)
            {
                resultLbl.Text = "Passwords do not match!";
            }
            else
            {
                bool result = addUser(username, password);  // adds the user to Users.xml if they do not exist
                if (result)                                 // if the user was successfully added
                {
                    HttpCookie userCookie = new HttpCookie("UserLogin");    // creates a new cookie with the username and password
                    userCookie["UserID"] = username;
                    userCookie["Password"] = password;  

                    Response.Cookies.Add(userCookie);
                    Response.Redirect("Login.aspx");                       // takes the user to the login page
                }
            }
        }

        // method to add the new user to Member.xml
        bool addUser(string username, string password)
        {
            password = Class1.ComputeSha256Hash(password);
            string path = Server.MapPath("~/App_Data/Member.xml");   // path to Member.xml
            XmlDocument doc = new XmlDocument();

            if (File.Exists(path))      // if Member.xml exists, it is opened
            {
                doc.Load(path);
            }
            else                     // if Member.xml was deleted, create a new one
            {
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.CreateElement("Members");
                doc.AppendChild(xmlDeclaration);
                doc.AppendChild(root);
            }

            if (doc.SelectSingleNode($"/Members/Member[Username='{username}']") != null)    // if the username already exists, the user must pick a new one
            {
                resultLbl.Text = "Username already exists";
                return false;
            }

            XmlElement userElement = doc.CreateElement("Member");     // Member element for xml

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

        // method to create the Captcha image. Used example from textbook for this service.
        private void createCaptcha()
        {
            ServiceReference2.ServiceClient client = new ServiceReference2.ServiceClient();

            string verifierString = client.GetVerifierString("5");  // getting verifier string
            Session["captcha"] = verifierString;    // global variable for the captcha string so it can be used in other methods

            // getting image
            Stream imageStream = client.GetImage(verifierString);
            byte[] abc;

            using (MemoryStream ms = new MemoryStream())
            {
                imageStream.CopyTo(ms);
                abc = ms.ToArray();
            }

            string image = Convert.ToBase64String(abc);
            captchaImage.ImageUrl = "data:image/png;base64," + image;   // displaying the captcha to the user

            client.Close();
        }
    }
}
