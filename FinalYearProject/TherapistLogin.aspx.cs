using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Security.Cryptography;
using System.Text;

namespace FinalYearProject
{
    public partial class TherapistLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SHA256 sha = new SHA256CryptoServiceProvider(); 
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string useremail = email.Value;
            string userpassword = password.Value;
            if(useremail == "" || userpassword =="")
            {
                lbl_result.Text = "You have not entered your email or password";
            }
            else
            {
                AzureUserBLL login = new AzureUserBLL();
                string dbpwd=login.CheckLogin(useremail);
                byte[] userpwd = Encoding.ASCII.GetBytes(userpassword);
                byte[] uphash = sha.ComputeHash(userpwd);
                string pwdhashbase64 = Convert.ToBase64String(uphash);
                Session["email"] = useremail;

                if (dbpwd == pwdhashbase64)
                
                    Response.Redirect("patientprogress.aspx");
                
                else
                    lbl_result.Text = "Error,Your Email or Password might be wrong"; 
            }
        }
    }
}