// Page created by: Manya Mehta
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;

namespace WebApplication1
{
    public partial class HashService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHashIt_Click(object sender, EventArgs e)
        {
            string input = txtHashInput.Text;   // getting user input
            string hashedResult = Class1.ComputeSha256Hash(input);  // hashing the input
            lblHashResult.Text = "Hashed Output: " + hashedResult;  // displays the hashed input to the user
        }
    }
}
