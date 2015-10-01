using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataAcessLayer
{
    public class AzurePatientDAL
    {
        string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
        string _patientic = "";
        string _patientname = "";
        string  _birthdate = "";
        string _patientimageurl = "";
        string _gender = "";


        public AzurePatientDAL()
        {

        }

        public AzurePatientDAL(string patientic,string patientname,string birthdate,string patientimageurl,string gender)
        {
            _patientic = patientic;
            _patientname = patientname;
            _birthdate = birthdate;
            _patientimageurl = patientimageurl;
            _gender = gender;
        }

        public AzurePatientDAL(string patientname, string birthdate, string patientimageurl, string gender)
         :this("",patientname,birthdate,patientimageurl,gender)
        {

        }

        public AzurePatientDAL(string patientic)
        :this(patientic,"","","","")
        {

        }

        public string PatientIC
        {
            get { return _patientic; }
            set { _patientic = value; }
        }

        public string PatientName
        {
            get { return _patientname; }
            set { _patientname = value;}
        }

        public string Birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }

        public string PatientImageUrl
        {
            get { return _patientimageurl; }
            set { _patientimageurl = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public int CreatePatient()
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand("CreatePatient", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@patientic", _patientic);
            cmd.Parameters.AddWithValue("@patientname", _patientname);
            cmd.Parameters.AddWithValue("@birthdate", _birthdate);
            cmd.Parameters.AddWithValue("@patientimageurl", _patientimageurl);
            cmd.Parameters.AddWithValue("@gender", _gender);

            conn.Open();
            int noofRow = 0;
            noofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return noofRow;


        }
    }
}
