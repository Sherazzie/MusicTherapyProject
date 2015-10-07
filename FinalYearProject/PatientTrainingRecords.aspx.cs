using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace FinalYearProject
{
    public partial class PatientTrainingRecords : System.Web.UI.Page
    {
        string patientname = "";
        string patientic = "";
        DataTable appts;
        protected void Page_Load(object sender, EventArgs e)
        {
           patientname= Session["patientname"].ToString();
           patientic= Session["patientic"].ToString();
            getevents();
        }

        protected void cal_records_DayRender(object sender, DayRenderEventArgs e)
        {
            DataRow[] rows = appts.Select(
                String.Format(
                   "ApptDate >= #{0}# AND ApptDate < #{1}#",
                   e.Day.Date.ToShortDateString(),
                   e.Day.Date.AddDays(1).ToShortDateString()
                )
             );

            foreach (DataRow row in rows)
            {
                System.Web.UI.WebControls.Image image;
                image = new System.Web.UI.WebControls.Image();
                image.ImageUrl = this.ResolveUrl("Dot.jpg");
                image.ToolTip = row["ApptSummary"].ToString();
                e.Cell.BackColor = Color.Wheat;
            }
        }

        protected void getevents()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT ApptDate,ApptSummary from Appointments where PatientName=@pname and PatientIC=@ic";
           // SqlCommand cmd = new SqlCommand(cmdstring, conn);
         //   cmd.Parameters.AddWithValue("@pname", patientname);
           // cmd.Parameters.AddWithValue("@ic", patientic);
            SqlDataAdapter sda = new SqlDataAdapter(cmdstring,conn);
            sda.SelectCommand.Parameters.AddWithValue("@pname", patientname);
            sda.SelectCommand.Parameters.AddWithValue("@ic", patientic);
            

            DataSet ds = new DataSet();
            sda.Fill(ds);
             appts = ds.Tables[0];
        }

        protected void cal_records_SelectionChanged(object sender, EventArgs e)
        {
            System.Data.DataView view = appts.DefaultView;
            view.RowFilter = String.Format(
                              "ApptDate >= #{0}# AND ApptDate < #{1}#",
                              cal_records.SelectedDate.ToShortDateString(),
                              cal_records.SelectedDate.AddDays(1).ToShortDateString()
                           );

            if (view.Count > 0)
            {
                gv_apptinfo.Visible = true;
                gv_apptinfo.DataSource = view;
                gv_apptinfo.DataBind();
            }
            else
            {
                gv_apptinfo.Visible = false;
            }
        }
    }
}