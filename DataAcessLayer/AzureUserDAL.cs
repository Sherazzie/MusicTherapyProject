using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DataAcessLayer
{
    public class AzureUserDAL
    {
        string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
        string _email = "";
        string _dname = "";
        string _pwd = "";
        string _mobileno = "";
        string _dob = "";
        string _imgpath = "";


        public AzureUserDAL()
        {

        }

        public AzureUserDAL(string email,string dname,string pwd,string mobileno,string dob,string imgpath)
        {
            _email = email;
            _dname = dname;
            _pwd = pwd;
            _mobileno = mobileno;
            _dob = dob;
            _imgpath = imgpath;
        }

        public AzureUserDAL(string email,string pwd)
        {
            _email = email;
            _pwd = pwd;
        }
        public AzureUserDAL(string dname,string pwd,string mobileno,string dob,string imgpath)
        :this("",dname,pwd,mobileno,dob,imgpath)
        {

        }

        public AzureUserDAL(string email)
        :this(email,"","","","","")
        {

        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Dname
        {
            get { return _dname; }
            set { _dname = value; }
        }

        public string Pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }

        public string Mobileno
        {
            get { return _mobileno; }
            set { _mobileno = value; }
        }

        public string Dob
        {
            get { return _dob; }
            set { _dob = value; }
        }
        public string Imgpath
        {
            get { return _imgpath; }
            set { _imgpath = value; }
        }

        public int CreateDoctorProfile()
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand("CreateDoc", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", _email);
            cmd.Parameters.AddWithValue("@doctorname", _dname);
            cmd.Parameters.AddWithValue("@pwd", _pwd);
            cmd.Parameters.AddWithValue("@mobileno", _mobileno);
            cmd.Parameters.AddWithValue("@dob", _dob);
            cmd.Parameters.AddWithValue("@pip", _imgpath);

            
                conn.Open();
                int noofRow = 0;
                noofRow = cmd.ExecuteNonQuery();
                conn.Close();
                return noofRow;
           
            

        }

        public string CheckDoctorLogin()
        {
            string pwd = "";
            SqlConnection conn=new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand("DocLogin", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", _email);
            conn.Open();
            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                pwd = read["Password"].ToString();
            }
            read.Close();

            return pwd;


        }

    }
}
