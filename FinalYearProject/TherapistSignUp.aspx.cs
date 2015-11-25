using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.IO;
using System.Net.Mail;

namespace FinalYearProject
{
    public partial class TherapistSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        bool emailcheck;
        protected void btn_signup(object sender, EventArgs e)
        {
            string emailinput = email.Value;
            if (emailinput == "")
            {
                lbl_result.Text = "Email cannot be empty";
            }
            else
            {
                 emailcheck = EmailIsValid(emailinput);
            }

            string tnameinput = tname.Value;
            string userdob = dob.Value;
            string userpasswordinput = password.Value;
            string cfmpasswordinput = cfmpassword.Value;
            string mobileinput = mobileno.Value;

           


            if (emailcheck == true)
            {
                if (fu_upload.HasFile)
                {
                    if (fu_upload.PostedFile != null)
                    {
                        AzureUserBLL validateinput = new AzureUserBLL();
                        string FileName = Path.GetFileName(fu_upload.PostedFile.FileName);
                        fu_upload.SaveAs(Server.MapPath("PImages//" + FileName));
                        validateinput.CreateDoctorAcccount(emailinput, tnameinput, userpasswordinput, cfmpasswordinput, mobileinput, userdob, "PImages//" + FileName);
                        lbl_result.Text = validateinput.returnMessage;
                    }
                   
                }
                else
                {
                    lbl_result.Text = "You did not upload a profile image";
                }



            }
            else
            {
                lbl_result.Text = "Email is Invalid";
            }
        }
        public bool EmailIsValid(string emailaddress)
        {
           
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}