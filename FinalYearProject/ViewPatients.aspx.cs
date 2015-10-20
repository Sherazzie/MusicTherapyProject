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
    public partial class ViewPatients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT PatientName,PatientImageUrl from PatientDetails ";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            conn.Open();
            dl_patients.DataSource = cmd.ExecuteReader();
            dl_patients.DataBind();
            conn.Close();
        }
        protected void dl_patient_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "PatientInfo")
            {
                foreach (DataListItem dli in dl_patients.Items)
                {
                    Label patientname = (Label)dl_patients.Items[e.Item.ItemIndex].FindControl("lbl_patientname");
                    Image img = (Image)dl_patients.Items[e.Item.ItemIndex].FindControl("img_profileimage");
                    String imgurl = img.ImageUrl.ToString();

                    Session["patientname"] = patientname.Text;
                    
                    Session["imageurl"] = imgurl;

                    Response.Redirect("PatientPersonalProfile.aspx");

                }
            }
        }

        protected void btn_az_Click(object sender, ImageClickEventArgs e)
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT PatientName,PatientImageUrl from PatientDetails ORDER BY PatientName ASC ";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            conn.Open();
            dl_patients.DataSource = cmd.ExecuteReader();
            dl_patients.DataBind();
            conn.Close();
        }

        protected void btn_sortbymale_Click(object sender, ImageClickEventArgs e)
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT PatientName,PatientImageUrl from PatientDetails where Gender=@gender ORDER BY PatientName ASC";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@gender", "M");
            conn.Open();
            dl_patients.DataSource = cmd.ExecuteReader();
            dl_patients.DataBind();
            conn.Close();
        }

        protected void btn_sortbyfemale_Click(object sender, ImageClickEventArgs e)
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT PatientName,PatientImageUrl from PatientDetails where Gender=@gender ORDER BY PatientName ASC";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@gender", "F");
            conn.Open();
            dl_patients.DataSource = cmd.ExecuteReader();
            dl_patients.DataBind();
            conn.Close();
        }
    }
}