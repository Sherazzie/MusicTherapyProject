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
            selectic();
       
            if (!IsPostBack)
            {
                sessiondatabind();
                bindonlyinfo();
                assignedmusic();
               
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

 
      /*  protected void chrt_score_DataBound(object sender, EventArgs e)
        {
            if (chrt_score.Series[0].Points.Count == 0)
            {
                System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                    new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                annotation.Text = "Chart empty ,no games scores recorded yet for this month yet!";
                annotation.X = 10;
                annotation.Y = 10;
                annotation.Font = new System.Drawing.Font("Arial", 12);
                annotation.ForeColor = System.Drawing.Color.Red;
                chrt_score.Annotations.Add(annotation);
            }
        }

        protected void chrt_score_Load(object sender, EventArgs e)
        {

            chrt_score.ChartAreas[0].AxisX.Title = "Date Played";
            chrt_score.ChartAreas[0].AxisY.Title = "Scores";
            chrt_score.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Red;
            chrt_score.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Red;
            chrt_score.ChartAreas[0].AxisY.Interval = 5.0;
          ;
            
        }
        protected void loadononthermonth()
        {
            chrt_score.ChartAreas[0].AxisX.Title = "Date Played";
            chrt_score.ChartAreas[0].AxisY.Title = "Scores";
            chrt_score.ChartAreas[0].AxisX.TitleForeColor = System.Drawing.Color.Red;
            chrt_score.ChartAreas[0].AxisY.TitleForeColor = System.Drawing.Color.Red;
            chrt_score.ChartAreas[0].AxisY.Interval = 5.0;
          
        }

        protected void btn_monthlyscores_Click(object sender, EventArgs e)
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            

            string value = ddl_month.SelectedValue;
            switch (value)
            {
                case "January 2015":

                    chrt_score.Series.RemoveAt(0);

                    SqlConnection conn = new SqlConnection(connstr);
                    string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                    SqlCommand cmd = new SqlCommand(cmdstring, conn);
                    cmd.Parameters.AddWithValue("@pname", patientname);
                    cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                    cmd.Parameters.AddWithValue("@dos1", Convert.ToDateTime("1/1/2015"));
                    cmd.Parameters.AddWithValue("@dos2", Convert.ToDateTime("1/31/2015"));
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    chrt_score.DataBindTable(reader, "DateOfScore");
                    chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                    chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                    loadononthermonth();
                    if (chrt_score.Series[0].Points.Count == 0)
                    {
                        chrt_score.Series[0].Points.Add(0, 0);
                    }


                    conn.Close();
                    break;

                case "February 2015":
                     chrt_score.Series.RemoveAt(0);
                    SqlConnection conn2 = new SqlConnection(connstr);

                    string cmdstring2 = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                    SqlCommand cmd2 = new SqlCommand(cmdstring2, conn2);
                    cmd2.Parameters.AddWithValue("@pname", patientname);
                    cmd2.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                    cmd2.Parameters.AddWithValue("@dos1", Convert.ToDateTime("2/1/2015"));
                    cmd2.Parameters.AddWithValue("@dos2", Convert.ToDateTime("2/28/2015"));
                    conn2.Open();
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    chrt_score.DataBindTable(reader2, "DateOfScore");
                    chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                    chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                    loadononthermonth();
                    if (chrt_score.Series[0].Points.Count == 0)
                    {
                        chrt_score.Series[0].Points.Add(0, 0);
                    }


                    conn2.Close();
                    break;

                case "March 2015":
                    chrt_score.Series.RemoveAt(0);
                    SqlConnection conn3 = new SqlConnection(connstr);

                    string cmdstring3 = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                    SqlCommand cmd3 = new SqlCommand(cmdstring3, conn3);
                    cmd3.Parameters.AddWithValue("@pname", patientname);
                    cmd3.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                    cmd3.Parameters.AddWithValue("@dos1", Convert.ToDateTime("3/1/2015"));
                    cmd3.Parameters.AddWithValue("@dos2", Convert.ToDateTime("3/31/2015"));
                    conn3.Open();
                    SqlDataReader reader3 = cmd3.ExecuteReader();
                    chrt_score.DataBindTable(reader3, "DateOfScore");
                    chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                    chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                    loadononthermonth();
                    if (chrt_score.Series[0].Points.Count == 0)
                    {
                        chrt_score.Series[0].Points.Add(0, 0);
                    }


                    conn3.Close();
                    break;

                case "April 2015":
                    chrt_score.Series.RemoveAt(0);
                    SqlConnection conn4 = new SqlConnection(connstr);

                    string cmdstring4 = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                    SqlCommand cmd4 = new SqlCommand(cmdstring4, conn4);
                    cmd4.Parameters.AddWithValue("@pname", patientname);
                    cmd4.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                    cmd4.Parameters.AddWithValue("@dos1", Convert.ToDateTime("4/1/2015"));
                    cmd4.Parameters.AddWithValue("@dos2", Convert.ToDateTime("4/30/2015"));
                    conn4.Open();
                    SqlDataReader reader4 = cmd4.ExecuteReader();
                    chrt_score.DataBindTable(reader4, "DateOfScore");
                    chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                    chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                    loadononthermonth();
                    if (chrt_score.Series[0].Points.Count == 0)
                    {
                        chrt_score.Series[0].Points.Add(0, 0);
                    }


                    conn4.Close();
                    break;

                case "May 2015":
                    chrt_score.Series.RemoveAt(0);
                
                    SqlConnection conn5 = new SqlConnection(connstr);
                    string cmdstring5 = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                    SqlCommand cmd5 = new SqlCommand(cmdstring5, conn5);
                    cmd5.Parameters.AddWithValue("@pname", patientname);
                    cmd5.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                    cmd5.Parameters.AddWithValue("@dos1", Convert.ToDateTime("5/1/2015"));
                    cmd5.Parameters.AddWithValue("@dos2", Convert.ToDateTime("5/30/2015"));
                    conn5.Open();
                    SqlDataReader reader5 = cmd5.ExecuteReader();
                    chrt_score.DataBindTable(reader5, "DateOfScore");
                    chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                    chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                    loadononthermonth();
                    if (chrt_score.Series[0].Points.Count == 0)
                    {
                        chrt_score.Series[0].Points.Add(0, 0);
                    }


                    conn5.Close();
                    break;

                case "June 2015":
                    chrt_score.Series.RemoveAt(0);
                    SqlConnection conn6 = new SqlConnection(connstr);
                    string cmdstring6 = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                    SqlCommand cmd6 = new SqlCommand(cmdstring6, conn6);
                    cmd6.Parameters.AddWithValue("@pname", patientname);
                    cmd6.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                    cmd6.Parameters.AddWithValue("@dos1", Convert.ToDateTime("6/1/2015"));
                    cmd6.Parameters.AddWithValue("@dos2", Convert.ToDateTime("6/30/2015"));
                    conn6.Open();
                    SqlDataReader reader6 = cmd6.ExecuteReader();
                    chrt_score.DataBindTable(reader6, "DateOfScore");
                    chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                    chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                    loadononthermonth();
                    if (chrt_score.Series[0].Points.Count == 0)
                    {
                        chrt_score.Series[0].Points.Add(0, 0);
                    }


                    conn6.Close();

                    break;

                case "July 2015":
                    chrt_score.Series.RemoveAt(0);
                    SqlConnection conn7 = new SqlConnection(connstr);
                    string cmdstring7 = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                    SqlCommand cmd7 = new SqlCommand(cmdstring7, conn7);
                    cmd7.Parameters.AddWithValue("@pname", patientname);
                    cmd7.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                    cmd7.Parameters.AddWithValue("@dos1", Convert.ToDateTime("6/1/2015"));
                    cmd7.Parameters.AddWithValue("@dos2", Convert.ToDateTime("6/30/2015"));
                    conn7.Open();
                    SqlDataReader reader7 = cmd7.ExecuteReader();
                    chrt_score.DataBindTable(reader7, "DateOfScore");
                    chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                    chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                    loadononthermonth();
                    if (chrt_score.Series[0].Points.Count == 0)
                    {
                        chrt_score.Series[0].Points.Add(0, 0);
                    }


                    conn7.Close();
                    break;

                case "August 2015":
                    chrt_score.Series.RemoveAt(0);
                    SqlConnection conn8 = new SqlConnection(connstr);
                    string cmdstring8 = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                    SqlCommand cmd8 = new SqlCommand(cmdstring8, conn8);
                    cmd8.Parameters.AddWithValue("@pname", patientname);
                    cmd8.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                    cmd8.Parameters.AddWithValue("@dos1", Convert.ToDateTime("8/1/2015"));
                    cmd8.Parameters.AddWithValue("@dos2", Convert.ToDateTime("8/31/2015"));
                    conn8.Open();
                    SqlDataReader reader8 = cmd8.ExecuteReader();
                    chrt_score.DataBindTable(reader8, "DateOfScore");
                    chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                    chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                    loadononthermonth();
                    if (chrt_score.Series[0].Points.Count == 0)
                    {
                        chrt_score.Series[0].Points.Add(0, 0);
                    }


                    conn8.Close();
                    break;

                case "September 2015":

                    chrt_score.Series.RemoveAt(0);
                    SqlConnection conn9 = new SqlConnection(connstr);
                    string cmdstring9 = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                    SqlCommand cmd9 = new SqlCommand(cmdstring9, conn9);
                    cmd9.Parameters.AddWithValue("@pname", patientname);
                    cmd9.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                    cmd9.Parameters.AddWithValue("@dos1", Convert.ToDateTime("9/1/2015"));
                    cmd9.Parameters.AddWithValue("@dos2", Convert.ToDateTime("9/30/2015"));
                    conn9.Open();
                    SqlDataReader reader9 = cmd9.ExecuteReader();
                    chrt_score.DataBindTable(reader9, "DateOfScore");
                    chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                    chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                    loadononthermonth();

                    if (chrt_score.Series[0].Points.Count == 0)
                    {
                        chrt_score.Series[0].Points.Add(0, 0);
                    }

                    conn9.Close();

                    break;

                case "October 2015":
                    chrt_score.Series.RemoveAt(0);
                    SqlConnection conn10 = new SqlConnection(connstr);
                    string cmdstring10 = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                    SqlCommand cmd10 = new SqlCommand(cmdstring10, conn10);
                    cmd10.Parameters.AddWithValue("@pname", patientname);
                    cmd10.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                    cmd10.Parameters.AddWithValue("@dos1", Convert.ToDateTime("10/1/2015"));
                    cmd10.Parameters.AddWithValue("@dos2", Convert.ToDateTime("10/31/2015"));
                    conn10.Open();
                    SqlDataReader reader10 = cmd10.ExecuteReader();
                    chrt_score.DataBindTable(reader10, "DateOfScore");
                    chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                    chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                    loadononthermonth();
                    if (chrt_score.Series[0].Points.Count == 0)
                    {
                        chrt_score.Series[0].Points.Add(0, 0);
                    }


                    conn10.Close();
                    break;

                case "November 2015":

                    chrt_score.Series.RemoveAt(0);
                    SqlConnection conn11 = new SqlConnection(connstr);
                    string cmdstring11 = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                    SqlCommand cmd11 = new SqlCommand(cmdstring11, conn11);
                    cmd11.Parameters.AddWithValue("@pname", patientname);
                    cmd11.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                    cmd11.Parameters.AddWithValue("@dos1", Convert.ToDateTime("11/1/2015"));
                    cmd11.Parameters.AddWithValue("@dos2", Convert.ToDateTime("11/30/2015"));
                    conn11.Open();
                    SqlDataReader reader11 = cmd11.ExecuteReader();
                    chrt_score.DataBindTable(reader11, "DateOfScore");
                    chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                    chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                    loadononthermonth();
                    if (chrt_score.Series[0].Points.Count == 0)
                    {
                        chrt_score.Series[0].Points.Add(0, 0);
                    }


                    conn11.Close();
                    break;

                case "December 2015":

                    chrt_score.Series.RemoveAt(0);
                    SqlConnection conn12 = new SqlConnection(connstr);
                    string cmdstring12 = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                    SqlCommand cmd12 = new SqlCommand(cmdstring12, conn12);
                    cmd12.Parameters.AddWithValue("@pname", patientname);
                    cmd12.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                    cmd12.Parameters.AddWithValue("@dos1", Convert.ToDateTime("12/1/2015"));
                    cmd12.Parameters.AddWithValue("@dos2", Convert.ToDateTime("12/31/2015"));
                    conn12.Open();
                    SqlDataReader reader12 = cmd12.ExecuteReader();
                    chrt_score.DataBindTable(reader12, "DateOfScore");
                    chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                    chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                    loadononthermonth();


                    conn12.Close();
                    break;
            }

           /* if(ddl_month.SelectedValue=="January 2015")
            {
                chrt_score.Series.RemoveAt(0);
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@pname", patientname);
                cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                cmd.Parameters.AddWithValue("@dos1",Convert.ToDateTime("1/1/2015"));
                cmd.Parameters.AddWithValue("@dos2",Convert.ToDateTime("1/31/2015"));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                chrt_score.DataBindTable(reader, "DateOfScore");
                chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                loadononthermonth();
                if (chrt_score.Series[0].Points.Count == 0)
                {
                    chrt_score.Series[0].Points.Add(0, 0);
                }


                conn.Close();

            }
            
            if (ddl_month.SelectedValue == "February 2015")
            {
                chrt_score.Series.RemoveAt(0);
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@pname", patientname);
                cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                cmd.Parameters.AddWithValue("@dos1", Convert.ToDateTime("2/1/2015"));
                cmd.Parameters.AddWithValue("@dos2", Convert.ToDateTime("2/28/2015"));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                chrt_score.DataBindTable(reader, "DateOfScore");
                chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                loadononthermonth();
                if (chrt_score.Series[0].Points.Count == 0)
                {
                    chrt_score.Series[0].Points.Add(0, 0);
                }


                conn.Close();

            }

            if (ddl_month.SelectedValue == "March 2015")
            {
                chrt_score.Series.RemoveAt(0);
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@pname", patientname);
                cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                cmd.Parameters.AddWithValue("@dos1", Convert.ToDateTime("3/1/2015"));
                cmd.Parameters.AddWithValue("@dos2", Convert.ToDateTime("3/31/2015"));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                chrt_score.DataBindTable(reader, "DateOfScore");
                chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                loadononthermonth();
                if (chrt_score.Series[0].Points.Count == 0)
                {
                    chrt_score.Series[0].Points.Add(0, 0);
                }


                conn.Close();

            }

            if (ddl_month.SelectedValue == "April 2015")
            {
                chrt_score.Series.RemoveAt(0);
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@pname", patientname);
                cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                cmd.Parameters.AddWithValue("@dos1", Convert.ToDateTime("4/1/2015"));
                cmd.Parameters.AddWithValue("@dos2", Convert.ToDateTime("4/30/2015"));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                chrt_score.DataBindTable(reader, "DateOfScore");
                chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                loadononthermonth();
                if (chrt_score.Series[0].Points.Count == 0)
                {
                    chrt_score.Series[0].Points.Add(0, 0);
                }


                conn.Close();

            }
            if (ddl_month.SelectedValue == "May 2015")
            {
                chrt_score.Series.RemoveAt(0);
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@pname", patientname);
                cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                cmd.Parameters.AddWithValue("@dos1", Convert.ToDateTime("5/1/2015"));
                cmd.Parameters.AddWithValue("@dos2", Convert.ToDateTime("5/30/2015"));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                chrt_score.DataBindTable(reader, "DateOfScore");
                chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                loadononthermonth();
                if (chrt_score.Series[0].Points.Count == 0)
                {
                    chrt_score.Series[0].Points.Add(0, 0);
                }


                conn.Close();

            }

            if (ddl_month.SelectedValue == "June 2015")
            {
                chrt_score.Series.RemoveAt(0);
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@pname", patientname);
                cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                cmd.Parameters.AddWithValue("@dos1", Convert.ToDateTime("6/1/2015"));
                cmd.Parameters.AddWithValue("@dos2", Convert.ToDateTime("6/30/2015"));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                chrt_score.DataBindTable(reader, "DateOfScore");
                chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                loadononthermonth();
                if (chrt_score.Series[0].Points.Count == 0)
                {
                    chrt_score.Series[0].Points.Add(0, 0);
                }


                conn.Close();

            }
            if (ddl_month.SelectedValue == "July 2015")
            {
                chrt_score.Series.RemoveAt(0);
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@pname", patientname);
                cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                cmd.Parameters.AddWithValue("@dos1", Convert.ToDateTime("7/1/2015"));
                cmd.Parameters.AddWithValue("@dos2", Convert.ToDateTime("7/31/2015"));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                chrt_score.DataBindTable(reader, "DateOfScore");
                chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                loadononthermonth();
                if (chrt_score.Series[0].Points.Count == 0)
                {
                    chrt_score.Series[0].Points.Add(0, 0);
                }


                conn.Close();

            }

            if (ddl_month.SelectedValue == "August 2015")
            {
                chrt_score.Series.RemoveAt(0);
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@pname", patientname);
                cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                cmd.Parameters.AddWithValue("@dos1", Convert.ToDateTime("8/1/2015"));
                cmd.Parameters.AddWithValue("@dos2", Convert.ToDateTime("8/31/2015"));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                chrt_score.DataBindTable(reader, "DateOfScore");
                chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                loadononthermonth();
                if (chrt_score.Series[0].Points.Count == 0)
                {
                    chrt_score.Series[0].Points.Add(0, 0);
                }


                conn.Close();

            }

            if (ddl_month.SelectedValue == "September 2015")
            {
                chrt_score.Series.RemoveAt(0);
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@pname", patientname);
                cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                cmd.Parameters.AddWithValue("@dos1", Convert.ToDateTime("9/1/2015"));
                cmd.Parameters.AddWithValue("@dos2", Convert.ToDateTime("9/30/2015"));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                chrt_score.DataBindTable(reader, "DateOfScore");
                chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                loadononthermonth();

                if (chrt_score.Series[0].Points.Count == 0)
                {
                    chrt_score.Series[0].Points.Add(0, 0);
                }

                conn.Close();

            }
            if (ddl_month.SelectedValue == "October 2015")
            {
                chrt_score.Series.RemoveAt(0);
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@pname", patientname);
                cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                cmd.Parameters.AddWithValue("@dos1", Convert.ToDateTime("10/1/2015"));
                cmd.Parameters.AddWithValue("@dos2", Convert.ToDateTime("10/31/2015"));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                chrt_score.DataBindTable(reader, "DateOfScore");
                chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                loadononthermonth();
                if (chrt_score.Series[0].Points.Count == 0)
                {
                    chrt_score.Series[0].Points.Add(0, 0);
                }


                conn.Close();

            }

            if (ddl_month.SelectedValue == "November 2015")
            {
                chrt_score.Series.RemoveAt(0);
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@pname", patientname);
                cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                cmd.Parameters.AddWithValue("@dos1", Convert.ToDateTime("11/1/2015"));
                cmd.Parameters.AddWithValue("@dos2", Convert.ToDateTime("11/30/2015"));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                chrt_score.DataBindTable(reader, "DateOfScore");
                chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                loadononthermonth();
                if (chrt_score.Series[0].Points.Count == 0)
                {
                    chrt_score.Series[0].Points.Add(0, 0);
                }


                conn.Close();

            }

            if (ddl_month.SelectedValue == "December 2015")
            {
                chrt_score.Series.RemoveAt(0);
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT  Score,DateOfScore from Scores where PatientName=@pname and PatientIC=@ic and DateOfScore >=@dos1 and DateOfScore <=@dos2";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@pname", patientname);
                cmd.Parameters.AddWithValue("@ic", Session["patientic"].ToString());
                cmd.Parameters.AddWithValue("@dos1", Convert.ToDateTime("12/1/2015"));
                cmd.Parameters.AddWithValue("@dos2", Convert.ToDateTime("12/31/2015"));
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                chrt_score.DataBindTable(reader, "DateOfScore");
                chrt_score.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;
                chrt_score.Series[0].ToolTip = "#VALX: Your Score is #VAL .";
                loadononthermonth();
               

                conn.Close();

            }
            */
            

        }
    }

        /*System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
            new System.Web.UI.DataVisualization.Charting.TextAnnotation();
        annotation.Text = "Chart empty ,no games scores recorded yet for this empty!";
                    annotation.X = 10;
                    annotation.Y = 10;
                    annotation.Font = new System.Drawing.Font("Arial", 12);
                    annotation.ForeColor = System.Drawing.Color.Red;
                    chrt_score.Annotations.Add(annotation);*/
  
