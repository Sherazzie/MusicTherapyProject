using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;

namespace BusinessLogicLayer
{
    public class AzurePatientBLL
    {
        public string returnmessage = "";
        public string validatepatientinfo(string patientic,string patientname,string birthdate,string patientimageurl,string gender)
        {
            if (patientic.Length > 9)
                returnmessage += "Patient IC cannot exceed 9 characters (E.g S9642575I) <br/>";
            if (patientic.Length == 0)
                returnmessage += "Patient IC cannot be empty <br/>";
            if (patientname.Length > 200)
                returnmessage += "Patient Name cannot exceed 200 characters <br/>";
            if (patientname.Length == 0)
                returnmessage += "Patient Name cannot be empty <br/>";
            if (birthdate.Length == 0)
                returnmessage += "Birthdate cannot be empty <br/>";

            if(returnmessage.Length  == 0)
            {
                AzurePatientDAL insertpatient = new AzurePatientDAL(patientic, patientname, birthdate, patientimageurl, gender);
                int noofrows = 0;
                noofrows = insertpatient.CreatePatient();
                if (noofrows > 0)
                    returnmessage = "Patient Succuesfully Created";
                else
                    returnmessage = "Error please try again";
               
            }

            return returnmessage;

        }
    }
}
