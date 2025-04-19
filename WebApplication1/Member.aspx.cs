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
            if ((bool)Session["Staff"] == true)
            {

            } else
            {
                if ((bool)Session["Member"] == false || Session["Member"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
           
        }
    }
}
