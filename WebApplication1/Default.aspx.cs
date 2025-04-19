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
                // member button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)  // if user is logged in, take them to the Member page
            {
                Response.Redirect("/Member.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");        // if the user is not logged in, take them to the Login page
            }
        }

        // staff button
        protected void StaffBtn_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)   // if the user is logged in
            {
                if (Session["Staff"] == null || (bool)Session["Staff"] == false)   // if the user does not have access to the Staff page
                {
                    result1Lbl.Text = "You do not have access to this page.";
                } else      // if the user is Staff, they are redirected to the Staff page
                {
                    Response.Redirect("/Staff.aspx");
                }
            } else          // if the user is not logged in, take them to the Login page
            {
                Response.Redirect("Login.aspx");
            }
        }

        // create account button
        protected void createAccBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateAccount.aspx");    // if the button is clicked, takes the user to the Create Account Page
        }

        // logout button
        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            // if the logout button is clicked, all Session States and Cookies are reset/cleared
            Session.Clear();
            Session.Abandon();

            Response.Cookies.Clear();

            FormsAuthentication.SignOut();
            resultLbl.Text = "Successfully signed out!";
        }

        // login button
        protected void loginBtn_Click(object sender, EventArgs e)
        {
            // redirects the user to the Login page
            Response.Redirect("Login.aspx");
        }

        // weather service button for the TryIt page
        protected void weatherSvcButton_Click(object sender, EventArgs e)
        {
            // redirects the user to the Weather Forecast page
            Response.Redirect("WeatherService.aspx");
        }
    }
}
