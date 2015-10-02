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
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            songname = Session["assignedsongname"].ToString();
            tb_songname.Text = songname;
            binddropdownlist();


        }

        protected void binddropdownlist()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT * FROM PatientDetails";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset
            ddl_patients.DataTextField = ds.Tables[0].Columns["PatientName"].ToString();
            ddl_patients.DataSource = ds.Tables[0];
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

        protected void btn_assign_Click(object sender, EventArgs e)
        {
            getazureurl();


            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT COUNT(*) FROM MusicAssignment WHERE PatientName=@pname and SongName=@sname";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@pname", ddl_patients.SelectedValue.ToString());
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
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@patientname", ddl_patients.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@songname", songname);
                cmd.Parameters.AddWithValue("@azureurl", azureurl);


                conn.Open();
                int noofRow = 0;
                noofRow = cmd2.ExecuteNonQuery();
                conn.Close();
                 if(noofRow >0)
                {
                    lbl_result.Text = "The Song " + songname + "has been assigned to " + ddl_patients.SelectedValue.ToString() + " succuesfully";
                }
            }
        }

        
    }
}