using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearProject
{
    public partial class PatientEventsAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tb_patientname.Text = Session["patientname"].ToString();
            tb_patientic.Text = Session["patientic"].ToString();
        }

        protected void cal_patient_SelectionChanged(object sender, EventArgs e)
        {
            string date = cal_patient.SelectedDate.ToShortDateString();
            tb_date.Text = date;
    }

        protected void btn_submit_Click(object sender, EventArgs e)
        {

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("PatientTrainingRecords.aspx");
        }
    }
}