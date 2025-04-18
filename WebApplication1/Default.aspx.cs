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
    }
}