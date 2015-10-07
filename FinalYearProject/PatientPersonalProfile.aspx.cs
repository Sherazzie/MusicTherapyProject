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

            if (!IsPostBack)
            {
                sessiondatabind();
                bindonlyinfo();
                assignedmusic();
            }
            selectic();
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

        protected void bindonlyinfo()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT * FROM PatientDetails where PatientName=@patientname and PatientImageUrl=@imageurl ";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@patientname", patientname);
            cmd.Parameters.AddWithValue("@imageurl", imageurl);
            conn.Open();
            dl_info.DataSource = cmd.ExecuteReader();
            dl_info.DataBind();
            conn.Close();
        }

        protected void assignedmusic()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT SongName,AzureUrl from MusicAssignment where PatientName=@aname";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@aname", patientname);
            

            conn.Open();
            gv_musicfiles.DataSource = cmd.ExecuteReader();
            gv_musicfiles.DataBind();
            conn.Close();


        }

        protected void gv_musicfiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "DeleteSong")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label songname = (Label)gv_musicfiles.Rows[index].FindControl("lbl_songname");
                string sname = songname.Text;

                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "Delete FROM MusicAssignment where PatientName=@aname AND SongName=@songname";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@aname", patientname);
                cmd.Parameters.AddWithValue("@songname", sname);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                assignedmusic();
                
            }
           
        }
        
        protected void selectic()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT PatientIC from PatientDetails where PatientName=@pname";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@pname", patientname);


            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Session["patientic"] = (reader["PatientIC"].ToString());
                    



                }

            }


            conn.Close();
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {
            chrt_score.ChartAreas[0].AxisX.Title = "Date Played";
            chrt_score.ChartAreas[0].AxisY.Title = "Scores";
            chrt_score.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Red;
            chrt_score.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Red;
            chrt_score.ChartAreas[0].AxisY.Interval = 5.0;
            chrt_score.ChartAreas[0].AxisX.Interval = 1.0;
        }

        protected void chrt_score_DataBound(object sender, EventArgs e)
        {
            if (chrt_score.Series[0].Points.Count == 0)
            {
                System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                    new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                annotation.Text = "Chart empty ,no games scores recorded yet!";
                annotation.X = 10;
                annotation.Y = 10;
                annotation.Font = new System.Drawing.Font("Arial", 12);
                annotation.ForeColor = System.Drawing.Color.Red;
                chrt_score.Annotations.Add(annotation);
            }
        }
    }
    }
