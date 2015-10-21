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
    public partial class AssignMusic : System.Web.UI.Page
    {
        string songname = "";
        string azureurl = "";
        string pimage = "";
        string ic = "";
        public string albumname;
        int count = 0;
        List<string> allpatientlist = new List<string>();
        List<string> uniquelist = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            songname = Session["assignedsongname"].ToString();
            albumname = Session["albumname"].ToString();
            tb_songname.Text = songname;
            if (!IsPostBack)
            {
                removeduplicates();
                databind();
            }
         


        }

       

        protected List<string> getallpatients()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT * FROM PatientDetails";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            conn.Open();
            using (IDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    allpatientlist.Add(Convert.ToString(dataReader["PatientName"]));
                }

            }
            return allpatientlist;
        }

        protected List<string> getassignedpatients()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT PatientName FROM MusicAssignment WHERE SongName=@sname ";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@sname", songname);
            conn.Open();
            using (IDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {

                    allpatientlist.Add(Convert.ToString(dataReader["PatientName"]));
                    
                }

            }
            return allpatientlist;
        }

        public void removeduplicates()
        {
            getallpatients();
            getassignedpatients();

            
           var newvalues= allpatientlist.GroupBy(x => x).Where(group => group.Count() == 1).Select(group => group.Key);
            uniquelist = newvalues.ToList();
            ddl_patients.DataSource = uniquelist;
            ddl_patients.DataBind();
           
        }
        protected void getazureurl()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT AzureUrl from MusicFiles where SongName=@sname";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@sname", songname);


            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    azureurl = (reader["AzureUrl"].ToString());
                   


                }

            }


            conn.Close();
        }

        protected void getpatientinfo()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT PatientIC,PatientImageUrl from PatientDetails where PatientName=@pname";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@pname", ddl_patients.SelectedValue);


            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ic = (reader["PatientIC"].ToString());
                    pimage = (reader["PatientImageUrl"].ToString());



                }

            }


            conn.Close();
        }
        protected void btn_assign_Click(object sender, EventArgs e)
        {
            getazureurl();
            getpatientinfo();
            string patientname = ddl_patients.SelectedValue;

            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT COUNT(*) FROM MusicAssignment WHERE PatientName=@pname and SongName=@sname";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@pname", patientname);
            cmd.Parameters.AddWithValue("@sname", songname);

            conn.Open();
            count = (int)cmd.ExecuteScalar();
            conn.Close();
            if (count > 0)
            {
                lbl_result.Text = "The song has been assigned to the patient already";
                
            }
            else if (count == 0)
            {
               
                
                SqlCommand cmd2 = new SqlCommand("AssignMusicToPatient", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@patientname", patientname);
                cmd2.Parameters.AddWithValue("@songname", songname);
                cmd2.Parameters.AddWithValue("@azureurl", azureurl);
                cmd2.Parameters.AddWithValue("@patientic", ic);
                cmd2.Parameters.AddWithValue("@profileimage", pimage);


                conn.Open();
                int noofRow = 0;
                noofRow = cmd2.ExecuteNonQuery();
                conn.Close();
                 if(noofRow >0)
                {
                    lbl_result.Text = "The Song " + songname + "has been assigned to  " + patientname + " succuesfully";
                    removeduplicates();
                    databind();

                }
            }
        }
        protected void databind()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT PatientName,PatientImageUrl from MusicAssignment WHERE SongName=@sname ";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@sname", songname);
            conn.Open();
            dl_patients.DataSource = cmd.ExecuteReader();
            dl_patients.DataBind();
            conn.Close();
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilterSongsByAlbum.aspx");
        }
    }
}