using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace FinalYearProject
{
    public partial class patientprogress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {

            if (!this.IsPostBack)
            {
                bindpatientprogress();
                bindtopscores();
                this.bindallscores(); 

            }

        }


        protected void bindpatientprogress()

        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT TOP 4 PatientName,PatientIC,PatientProfileImage,ApptDate,ApptSummary FROM Appointments ORDER BY ApptDate DESC";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            conn.Open();
            dl_progress.DataSource = cmd.ExecuteReader();
            dl_progress.DataBind();
            conn.Close();
            
            
        }

        protected void bindtopscores()
        {

            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT TOP 5 PatientName,PatientIC,Score,DateOfScore FROM Scores ORDER BY Score DESC";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            conn.Open();
            gv_highscores.DataSource = cmd.ExecuteReader();
            gv_highscores.DataBind();
            conn.Close();
        }

        protected void bindallscores()
        {
          
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
           
           

            
            using (SqlConnection con = new SqlConnection(connstr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT PatientName,PatientIC,Score,DateOfScore FROM Scores ORDER BY PatientName ASC"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                           gv_allscores.DataSource = dt;
                            gv_allscores.DataBind();
                        }
                    }
                }
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gv_allscores.PageIndex = e.NewPageIndex;
            this.bindallscores();

            
        }



    }
}