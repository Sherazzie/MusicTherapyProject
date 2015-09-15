﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using BusinessLogicLayer;
using System.IO;
namespace FinalYearProject
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_signup(object sender,EventArgs e)
        {
            string emailinput = email.Value;
            if(emailinput == "")
            {
                lbl_result.Text = "Email cannot be empty";
            }
            string tnameinput = tname.Value;
            string userdob = dob.Value;
            string userpasswordinput = password.Value;
            string cfmpasswordinput = cfmpassword.Value;
            string mobileinput = mobileno.Value;
            bool emailcheck = IsValid(emailinput);
            HttpPostedFile file = Request.Files["profimage"];
            
            if(emailcheck == true )
            {
                
                if (file != null && file.ContentLength > 0)
                {
                    AzureUserBLL validateinput = new AzureUserBLL();
                    string FileName = Path.GetFileName(file.FileName);
                    file.SaveAs(Server.MapPath("ProfileImages//" + FileName));
                    validateinput.CreateDoctorAcccount(emailinput, tnameinput, userpasswordinput, cfmpasswordinput, mobileinput, userdob, "ProfileImages//" + FileName);
                    lbl_result.Text = validateinput.returnMessage;
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
        public bool IsValid(string emailaddress)
        {
            if (emailaddress == "")
            {
                lbl_result.Text = "Your email cannot be empty";
            }
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