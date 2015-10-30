using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;



namespace FinalYearProject
{
    public partial class patientprogress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            bindpatientprogress();

        }


        protected void bindpatientprogress()

        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT TOP 3 PatientName,PatientIC,PatientProfileImage,ApptDate,ApptSummary FROM Appointments ORDER BY ApptDate DESC";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            conn.Open();
            dl_progress.DataSource = cmd.ExecuteReader();
            dl_progress.DataBind();
            conn.Close();
            
            
        }
        
    }
}