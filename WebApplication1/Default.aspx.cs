// Page Created by: Carissa Moore (1224352909)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;
namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string hashedValue = Class1.ComputeSha256Hash("MySecretPassword123");
            System.Diagnostics.Debug.WriteLine("Hashed Password: " + hashedValue);
        }
        
        // member button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Member.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        // staff button
        protected void StaffBtn_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (Session["Staff"] == null || (bool)Session["Staff"] == false)
                {
                    result1Lbl.Text = "You do not have access to this page.";
                } else
                {
                    Response.Redirect("/Staff.aspx");
                }
            } else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void createAccBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateAccount.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Cookies.Clear();

            FormsAuthentication.SignOut();
            resultLbl.Text = "Successfully signed out!";
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void weatherSvcButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("WeatherService.aspx");
        }
    }
}
