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

  

        protected void chrt_score_DataBound(object sender, EventArgs e)
        {
            if (chrt_score.Series[0].Points.Count == 0)
            {
                System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                    new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                annotation.Text = "Chart empty ,no games scores recorded yet for this empty!";
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
            
            if(ddl_month.SelectedValue=="January 2015")
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
                    System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                        new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                    annotation.Text = "Chart empty ,no games scores recorded yet for this empty!";
                    annotation.X = 10;
                    annotation.Y = 10;
                    annotation.Font = new System.Drawing.Font("Arial", 12);
                    annotation.ForeColor = System.Drawing.Color.Red;
                    chrt_score.Annotations.Add(annotation);
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
                    System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                        new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                    annotation.Text = "Chart empty ,no games scores recorded yet for this empty!";
                    annotation.X = 10;
                    annotation.Y = 10;
                    annotation.Font = new System.Drawing.Font("Arial", 12);
                    annotation.ForeColor = System.Drawing.Color.Red;
                    chrt_score.Annotations.Add(annotation);
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
                    System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                        new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                    annotation.Text = "Chart empty ,no games scores recorded yet for this empty!";
                    annotation.X = 10;
                    annotation.Y = 10;
                    annotation.Font = new System.Drawing.Font("Arial", 12);
                    annotation.ForeColor = System.Drawing.Color.Red;
                    chrt_score.Annotations.Add(annotation);
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
                    System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                        new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                    annotation.Text = "Chart empty ,no games scores recorded yet for this empty!";
                    annotation.X = 10;
                    annotation.Y = 10;
                    annotation.Font = new System.Drawing.Font("Arial", 12);
                    annotation.ForeColor = System.Drawing.Color.Red;
                    chrt_score.Annotations.Add(annotation);
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
                    System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                        new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                    annotation.Text = "Chart empty ,no games scores recorded yet for this empty!";
                    annotation.X = 10;
                    annotation.Y = 10;
                    annotation.Font = new System.Drawing.Font("Arial", 12);
                    annotation.ForeColor = System.Drawing.Color.Red;
                    chrt_score.Annotations.Add(annotation);
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
                    System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                        new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                    annotation.Text = "Chart empty ,no games scores recorded yet for this empty!";
                    annotation.X = 10;
                    annotation.Y = 10;
                    annotation.Font = new System.Drawing.Font("Arial", 12);
                    annotation.ForeColor = System.Drawing.Color.Red;
                    chrt_score.Annotations.Add(annotation);
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
                    System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                        new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                    annotation.Text = "Chart empty ,no games scores recorded yet for this empty!";
                    annotation.X = 10;
                    annotation.Y = 10;
                    annotation.Font = new System.Drawing.Font("Arial", 12);
                    annotation.ForeColor = System.Drawing.Color.Red;
                    chrt_score.Annotations.Add(annotation);
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
                    System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                        new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                    annotation.Text = "Chart empty ,no games scores recorded yet for this empty!";
                    annotation.X = 10;
                    annotation.Y = 10;
                    annotation.Font = new System.Drawing.Font("Arial", 12);
                    annotation.ForeColor = System.Drawing.Color.Red;
                    chrt_score.Annotations.Add(annotation);
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
                    System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                        new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                    annotation.Text = "Chart empty ,no games scores recorded yet for this empty!";
                    annotation.X = 10;
                    annotation.Y = 10;
                    annotation.Font = new System.Drawing.Font("Arial", 12);
                    annotation.ForeColor = System.Drawing.Color.Red;
                    chrt_score.Annotations.Add(annotation);
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
                    System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                        new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                    annotation.Text = "Chart empty ,no games scores recorded yet for this empty!";
                    annotation.X = 10;
                    annotation.Y = 10;
                    annotation.Font = new System.Drawing.Font("Arial", 12);
                    annotation.ForeColor = System.Drawing.Color.Red;
                    chrt_score.Annotations.Add(annotation);
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
                    System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                        new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                    annotation.Text = "Chart empty ,no games scores recorded yet for this empty!";
                    annotation.X = 10;
                    annotation.Y = 10;
                    annotation.Font = new System.Drawing.Font("Arial", 12);
                    annotation.ForeColor = System.Drawing.Color.Red;
                    chrt_score.Annotations.Add(annotation);
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
                if (chrt_score.Series[0].Points.Count == 0)
                {
                    System.Web.UI.DataVisualization.Charting.TextAnnotation annotation =
                        new System.Web.UI.DataVisualization.Charting.TextAnnotation();
                    annotation.Text = "Chart empty ,no games scores recorded yet for this empty!";
                    annotation.X = 10;
                    annotation.Y = 10;
                    annotation.Font = new System.Drawing.Font("Arial", 12);
                    annotation.ForeColor = System.Drawing.Color.Red;
                    chrt_score.Annotations.Add(annotation);
                }


                conn.Close();

            }
        }
    }
    }
