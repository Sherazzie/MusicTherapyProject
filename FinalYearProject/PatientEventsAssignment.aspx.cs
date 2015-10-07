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
    public partial class PatientEventsAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tb_patientname.Text = Session["patientname"].ToString();
            tb_patientic.Text = Session["patientic"].ToString();
        }
        int count = 0;
        protected void cal_patient_SelectionChanged(object sender, EventArgs e)
        {
            string date = cal_patient.SelectedDate.ToShortDateString();
            tb_date.Text = date;
    }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT COUNT(*) FROM Appointments WHERE PatientName=@pname and PatientIC=@ic and ApptDate=@apptdate";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@pname", tb_patientname.Text);
            cmd.Parameters.AddWithValue("@ic",tb_patientic.Text );
            cmd.Parameters.AddWithValue("@apptdate", tb_date.Text);

            conn.Open();
            count = (int)cmd.ExecuteScalar();
            conn.Close();
            if (count > 0)
            {
                lbl_result.Text = "An appointment summary has already been added on this date";

            }
            else if (count == 0)
            {


                SqlCommand cmd2 = new SqlCommand("MakeAppt", conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@patientname", tb_patientname.Text);
                cmd2.Parameters.AddWithValue("@patientic",tb_patientic.Text);
                cmd2.Parameters.AddWithValue("@apptdate", tb_date.Text);
                cmd2.Parameters.AddWithValue("@apptsummary", tb_summary.Text);
                


                conn.Open();
                int noofRow = 0;
                noofRow = cmd2.ExecuteNonQuery();
                conn.Close();
                if (noofRow > 0)
                {
                    lbl_result.Text = "An appointment summary has been added!";
                   

                }
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientTrainingRecords.aspx");
        }
    }
}