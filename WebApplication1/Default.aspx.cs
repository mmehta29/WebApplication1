using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;
using WebApplication1.ServiceReference1;
namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // string hashedValue = Class1.ComputeSha256Hash("MySecretPassword123");
            // System.Diagnostics.Debug.WriteLine("Hashed Password: " + hashedValue);
        }
        protected void btnHashIt_Click(object sender, EventArgs e)
        {
            // Hash the user input text using DLL library
            string input = txtHashInput.Text;
            string hashedResult = Class1.ComputeSha256Hash(input);
            lblHashResult.Text = "Hashed Output: " + hashedResult;
        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            // Encrypt user input text using Encryption Web Service from my assignment 3
            Service1Client client = new Service1Client();  
            string inputText = txtEncryptInput.Text;
            string key = "yourEncryptionKey";
            string method = "AES";
            string encrypted = client.Encrypt(inputText, key, method);

            lblEncryptResult.Text = "Encrypted Output: " + encrypted;

            client.Close();
        }

        protected void btnMemberPage_Click(object sender, EventArgs e)
        {
            // Redirect to Member Page (we will be implemented in Assignment 6)
            Response.Redirect("Member.aspx");
        }

        protected void btnStaffPage_Click(object sender, EventArgs e)
        {
            // Redirect to Staff Page (we will be implemented in Assignment 6)
            Response.Redirect("Staff.aspx");
        }
        protected void btnTryHash_Click(object sender, EventArgs e)
        {
            // TryIt: Hash a sample test string automatically
            string testInput = "TestHash123";
            string hashedResult = Class1.ComputeSha256Hash(testInput);
            lblHashResult.Text = "Hashed Output: " + hashedResult;
        }

        protected void btnTryEncrypt_Click(object sender, EventArgs e)
        {
            // TryIt: Encrypt a sample test string automatically
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            string testInput = "EncryptThis123";
            string key = "key123"; 
            string method = "AES";
            string encryptedResult = client.Encrypt(testInput, key, method);
            lblEncryptResult.Text = "Encrypted Output: " + encryptedResult;
            client.Close();
        }



    }
}