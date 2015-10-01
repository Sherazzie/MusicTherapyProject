using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace FinalYearProject
{
    public partial class PatientPersonalProfile : System.Web.UI.Page
    {
        string patientname = "";
        string imageurl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            patientname = Session["patientname"].ToString();
            imageurl = Session["imageurl"].ToString();


            sessiondatabind();
        }

        protected void sessiondatabind()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT * FROM PatientDetails where PatientName=@patientname and PatientImageUrl=@imageurl ";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@patientname", patientname);
            cmd.Parameters.AddWithValue("@imageurl", imageurl);
            conn.Open();
            dl_patients.DataSource = cmd.ExecuteReader();
            dl_patients.DataBind();
            conn.Close();
        }
    }
}