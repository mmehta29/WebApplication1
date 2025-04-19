// Page created by: Carissa Moore (1224352909)
// to be udpated for Assingment 6
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }
    }
}
