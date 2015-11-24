using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;
using System.Web.Script.Serialization;
using System.Globalization;

namespace FinalYearProject
{
    public partial class PatientPersonalProfile : System.Web.UI.Page
    {
        public string patientname = "";
        string imageurl = "";

        public string hclabels = "";
        public string hcdata = "";
        public string dos1 = "";
        public string dos2 = "";
        public string chartmonthname = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            patientname = Session["patientname"].ToString();
            imageurl = Session["imageurl"].ToString();
            string chartcurrentmonth = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
            selectic();

            if (!IsPostBack)
            {
                chartmonthname = chartcurrentmonth;
                sessiondatabind();
                bindonlyinfo();
                assignedmusic();
                binddateselector();
                BindChartData();

                //ddl_month.Items.FindByValue("October 2015").Selected = true;
            }


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

        public DataSet getchartdata()
        {
            string currentmonth = System.DateTime.Today.Month.ToString();
            string currentyear = System.DateTime.Today.Year.ToString();
            string firstday = currentmonth + "/1/" + currentyear;
            int daysincurrentmonth = DateTime.DaysInMonth(System.DateTime.Today.Year, System.DateTime.Today.Month);
            string lastday = currentmonth + "/" + daysincurrentmonth.ToString() + "/" + currentyear;
            lbLineDateRangeView.Text = "1-" + currentmonth + "-" + currentyear + " " + "to" + " " + daysincurrentmonth.ToString() + "-" + currentmonth + "-" + currentyear;
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@pname", patientname);
            cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
            cmd.Parameters.AddWithValue("@dos1", Convert.ToDateTime(firstday));
            cmd.Parameters.AddWithValue("@dos2", Convert.ToDateTime(lastday));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        public void BindChartData()
        {
            DataSet dsSeries = new DataSet();
            dsSeries = getchartdata();

            foreach (DataRow dr in dsSeries.Tables[0].Rows)
            {
                if (dr != dsSeries.Tables[0].Rows[dsSeries.Tables[0].Rows.Count - 1])
                {

                    hcdata = hcdata + dr["Score"].ToString() + ",";

                }
                if (dr == dsSeries.Tables[0].Rows[dsSeries.Tables[0].Rows.Count - 1])
                {

                    hcdata = hcdata + dr["Score"].ToString();

                }


            }

            foreach (DataRow dr1 in dsSeries.Tables[0].Rows)
            {
                if (dr1 != dsSeries.Tables[0].Rows[dsSeries.Tables[0].Rows.Count - 1])
                {

                    hclabels += "'" + dr1["DateOfScore"].ToString() + "'" + ",";

                }
                if (dr1 == dsSeries.Tables[0].Rows[dsSeries.Tables[0].Rows.Count - 1])
                {

                    hclabels += "'" + dr1["DateOfScore"].ToString() + "'";

                }

            }


             
        }

        public void binddateselector()
        {
            string currentmonth = System.DateTime.Today.Month.ToString();
            string currentyear = System.DateTime.Today.Year.ToString();
            int monthcounter = System.DateTime.Today.Month;
            int yearcounter = System.DateTime.Today.Year;
            Session["monthcounter"] = monthcounter;
            Session["yearcounter"] = yearcounter;
            int daysincurrentmonth = DateTime.DaysInMonth(System.DateTime.Today.Year, System.DateTime.Today.Month);
            lbLineDateRangeView.Text = "1-" + currentmonth + "-" + currentyear + " " + "to" + " " + daysincurrentmonth.ToString() + "-" + currentmonth + "-" + currentyear;


        }

        protected void imbPrevious_Click(object sender, ImageClickEventArgs e)
        {
            int monthcounter = Convert.ToInt32(Session["monthcounter"]);
            int yearcounter = Convert.ToInt32(Session["yearcounter"]);
            monthcounter--;

            if (monthcounter == 0)
            {
                monthcounter = 12;
                yearcounter--;
                Session["monthcounter"] = monthcounter;
                Session["yearcounter"] = yearcounter;
                int daysincurrentmonth = DateTime.DaysInMonth(yearcounter, monthcounter);
                dos1 = monthcounter.ToString() + "/" + "1/" + yearcounter.ToString();
                DateTime dt = Convert.ToDateTime(dos1);
                chartmonthname = dt.ToString("MMMM");
                dos2 = monthcounter.ToString() + "/" + daysincurrentmonth.ToString() + "/" + yearcounter.ToString();
                lbLineDateRangeView.Text = dos1 + " " + "to" + " " + dos2;
                BindChartDataothers();

            }
            else if (monthcounter > 0)
            {
                Session["monthcounter"] = monthcounter;
                Session["yearcounter"] = yearcounter;
                int daysincurrentmonth = DateTime.DaysInMonth(yearcounter, monthcounter);
                dos1 = monthcounter.ToString() + "/" + "1/" + yearcounter.ToString();
                DateTime dt = Convert.ToDateTime(dos1);
                chartmonthname = dt.ToString("MMMM");
                dos2 = monthcounter.ToString() + "/" + daysincurrentmonth.ToString() + "/" + yearcounter.ToString();
                lbLineDateRangeView.Text = dos1 + " " + "to" + " " + dos2;
                BindChartDataothers();
            }
        }

        protected void imbNext_Click(object sender, ImageClickEventArgs e)
        {
            int monthcounter = Convert.ToInt32(Session["monthcounter"]);
            int yearcounter = Convert.ToInt32(Session["yearcounter"]);
            monthcounter++;
            if (monthcounter > 12)
            {
                monthcounter = 1;
                yearcounter++;
                Session["monthcounter"] = monthcounter;
                Session["yearcounter"] = yearcounter;
                int daysincurrentmonth = DateTime.DaysInMonth(yearcounter, monthcounter);
                dos1 = monthcounter.ToString() + "/" + "1/" + yearcounter.ToString();
                DateTime dt = Convert.ToDateTime(dos1);
                chartmonthname = dt.ToString("MMMM");
                dos2 = monthcounter.ToString() + "/" + daysincurrentmonth.ToString() + "/" + yearcounter.ToString();
                lbLineDateRangeView.Text = dos1 + " " + "to" + " " + dos2;
                BindChartDataothers();

            }
            else if (monthcounter <= 12)
            {
                Session["monthcounter"] = monthcounter;
                Session["yearcounter"] = yearcounter;
                int daysincurrentmonth = DateTime.DaysInMonth(yearcounter, monthcounter);
                dos1 = monthcounter.ToString() + "/" + "1/" + yearcounter.ToString();
                DateTime dt = Convert.ToDateTime(dos1);
                chartmonthname = dt.ToString("MMMM");
                dos2 = monthcounter.ToString() + "/" + daysincurrentmonth.ToString() + "/" + yearcounter.ToString();
                lbLineDateRangeView.Text = dos1 + " " + "to" + " " + dos2;
                BindChartDataothers();
            }

        }
        public DataSet getchartdataothers()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@pname", patientname);
            cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
            cmd.Parameters.AddWithValue("@dos1", Convert.ToDateTime(dos1));
            cmd.Parameters.AddWithValue("@dos2", Convert.ToDateTime(dos2));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;


        }
        public void BindChartDataothers()
        {
            DataSet dsSeries = new DataSet();
            dsSeries = getchartdataothers();

            foreach (DataRow dr in dsSeries.Tables[0].Rows)
            {
                if (dr != dsSeries.Tables[0].Rows[dsSeries.Tables[0].Rows.Count - 1])
                {

                    hcdata = hcdata + dr["Score"].ToString() + ",";

                }
                if (dr == dsSeries.Tables[0].Rows[dsSeries.Tables[0].Rows.Count - 1])
                {

                    hcdata = hcdata + dr["Score"].ToString();

                }


            }

            foreach (DataRow dr1 in dsSeries.Tables[0].Rows)
            {
                if (dr1 != dsSeries.Tables[0].Rows[dsSeries.Tables[0].Rows.Count - 1])
                {

                    hclabels += "'" + dr1["DateOfScore"].ToString() + "'" + ",";

                }
                if (dr1 == dsSeries.Tables[0].Rows[dsSeries.Tables[0].Rows.Count - 1])
                {

                    hclabels += "'" + dr1["DateOfScore"].ToString() + "'";

                }

            }
        }
    }
}



       
