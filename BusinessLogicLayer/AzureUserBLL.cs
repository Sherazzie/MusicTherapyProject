using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using DataAcessLayer;

namespace BusinessLogicLayer
{
    public class AzureUserBLL
    {
        public string returnMessage = "";

        public string CreateDoctorAcccount(string email, string dname, string pwd, string cfmpwd, string mobileno, string dob, string pip)
        {
            if (dname.Length == 0)
                returnMessage += "Therapist Name cannot be blank <br />";
            if (pwd.Length == 0)
                returnMessage += "Password cannot be blank <br/>";
            if (cfmpwd.Length == 0)
                returnMessage += "Cofirm Passowrd cannot be blank <br/>";
            if (mobileno.Length == 0)
                returnMessage += "Mobile Number cannot be blank <br/>";
            if (dob.Length == 0)
                returnMessage += "Date of Birth cannnot be blank <br/>";
            if (pip.Length == 0)
                returnMessage += "Please Upload an image <br/>";
            if (pwd != cfmpwd)
                returnMessage += "Your passwords dont match <br/>";


            if (returnMessage.Length == 0)
            {
                SHA256 sha = new SHA256CryptoServiceProvider();
                byte[] data = Encoding.ASCII.GetBytes(pwd);
                byte[] result = sha.ComputeHash(data);
                string hashedpwd = Convert.ToBase64String(result);
                AzureUserDAL doc = new AzureUserDAL(email, dname, pwd, mobileno, dob, pip);
                int noofRows = 0;
                noofRows = doc.CreateDoctorProfile();

                if (noofRows > 0)
                    returnMessage = "You Signed Up Succuesfully.";
                else
                    returnMessage = "Error,Please try again";


            }
            return returnMessage;

        }
    }
}
