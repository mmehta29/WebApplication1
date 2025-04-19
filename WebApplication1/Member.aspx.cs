// Page created by: Carissa Moore (1224352909)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
       public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["Staff"] == true)     // if user is Staff they can access the page
            {

            } else
            {
                // if the User is not a member, they are redirected back to the default page
                if ((bool)Session["Member"] == false || Session["Member"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
           
        }

        // button to access the Weather Service
        protected void weatherServiceBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WeatherService.aspx");
        }
    }
}
