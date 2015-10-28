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
        string pimage = "";
        string ic = "";

        public string albumname;

        public int endcount;
        public int begincount = 0;
   
        public int ncount = 0;
        

        List<string> allpatientlist = new List<string>();
        List<string> uniquelist = new List<string>();
        Dictionary<string, string> patientassigndl = new Dictionary<string, string>();
        Dictionary<string, string> patientnext = new Dictionary<string, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            songname = Session["assignedsongname"].ToString();
            albumname = Session["albumname"].ToString();
            tb_songname.Text = songname;
            if (!IsPostBack)
            {
                removeduplicates();
                databind();
                Session["begincountnext"] = 0;
                Session["endcountnext"] = 0;

            }
          
         


        }

        public static int count = 0;


        protected List<string> getallpatients()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT * FROM PatientDetails";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            conn.Open();
            using (IDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    allpatientlist.Add(Convert.ToString(dataReader["PatientName"]));
                }

            }
            return allpatientlist;
        }

        protected List<string> getassignedpatients()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT PatientName FROM MusicAssignment WHERE SongName=@sname ";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@sname", songname);
            conn.Open();
            using (IDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {

                    allpatientlist.Add(Convert.ToString(dataReader["PatientName"]));
                    
                }

            }
            return allpatientlist;
        }

        public void removeduplicates()
        {
            patientassigndl.Clear();
            getallpatients();
            getassignedpatients();
            string pname = "";
            string purl = "";
            
           var newvalues= allpatientlist.GroupBy(x => x).Where(group => group.Count() == 1).Select(group => group.Key);
            uniquelist = newvalues.ToList();
            foreach(string  patient in uniquelist)
            {
               
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT PatientName,PatientImageUrl from PatientDetails where PatientName=@pname";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@pname", patient);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                     pname = dr["PatientName"].ToString();
                     purl=dr["PatientImageUrl"].ToString();
                }
                patientassigndl.Add(pname, purl);
                Session["patientdict"] = patientassigndl;
                if(patientassigndl.Count > 3)
                {
                    imbNext.Enabled = true;
                }
                
                
            }
            PagedDataSource pdsunassigned = new PagedDataSource();
            pdsunassigned.DataSource = patientassigndl;
            pdsunassigned.AllowPaging = true;
            pdsunassigned.PageSize = 3;
            dl_un.DataSource = pdsunassigned;
            dl_un.DataBind();

            
            //lb_patients.DataSource = uniquelist;
          // lb_patients.DataBind();
           // ddl_patients.DataSource = uniquelist;
            //ddl_patients.DataBind();
           
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

        protected void getpatientinfo(string name)
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT PatientIC,PatientImageUrl from PatientDetails where PatientName=@pname";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@pname", name);


            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ic = (reader["PatientIC"].ToString());
                    pimage = (reader["PatientImageUrl"].ToString());



                }

            }


            conn.Close();
        }
        protected void btn_assign_Click(object sender, EventArgs e)
        {
           
            foreach (DataListItem item in dl_un.Items)
            {
                CheckBox myCheckBox = (CheckBox)item.FindControl("cb_ifassigned");
                {
                    if (myCheckBox.Checked)
                    {
                        Label selectedpatient = (Label)item.FindControl("lbl_patientname");
                        
                        getazureurl();
                        getpatientinfo(selectedpatient.Text);
                        string patientname = selectedpatient.Text;

                        string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                        SqlConnection conn = new SqlConnection(connstr);
                        string cmdstring = "SELECT COUNT(*) FROM MusicAssignment WHERE PatientName=@pname and SongName=@sname";
                        SqlCommand cmd = new SqlCommand(cmdstring, conn);
                        cmd.Parameters.AddWithValue("@pname", patientname);
                        cmd.Parameters.AddWithValue("@sname", songname);

                        conn.Open();
                        ncount = (int)cmd.ExecuteScalar();
                        conn.Close();
                        if (ncount > 0)
                        {
                            lbl_result.Text = "The song has been assigned to the patient already";

                        }
                        else if (ncount == 0)
                        {


                            SqlCommand cmd2 = new SqlCommand("AssignMusicToPatient", conn);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@patientname", patientname);
                            cmd2.Parameters.AddWithValue("@songname", songname);
                            cmd2.Parameters.AddWithValue("@azureurl", azureurl);
                            cmd2.Parameters.AddWithValue("@patientic", ic);
                            cmd2.Parameters.AddWithValue("@profileimage", pimage);


                            conn.Open();
                            int noofRow = 0;
                            noofRow = cmd2.ExecuteNonQuery();
                            conn.Close();
                            if (noofRow > 0)
                            {
                                lbl_result.Text = "The Songs has been assigned";
                               

                            }
                        }

                    }

                }
               
                
            }
            removeduplicates();
            databind();
            Session["begincountnext"] = 0;
            Session["endcountnext"] = 0;
            count = 0;

        }
        protected void databind()
        {
            
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT PatientName,PatientImageUrl from MusicAssignment WHERE SongName=@sname ";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@sname", songname);
            conn.Open();
            dl_patients.DataSource = cmd.ExecuteReader();
            dl_patients.DataBind();
            conn.Close();
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilterSongsByAlbum.aspx");
        }

        protected void imbPrevious_Click(object sender, ImageClickEventArgs e)
        {
            Dictionary<string, string> wowdict = (Dictionary<string, string>)Session["patientdict"];
            int begincount = Convert.ToInt32(Session["begincountnext"]) - 3;
            int endcount = begincount + 2;
            if(endcount < 4)
            {
                imbPrevious.Enabled = false;
            }
            Session["begincountnext"] = begincount;
            Session["endcountnext"] = endcount;
            int dictcount = 0;
            foreach (KeyValuePair<string, string> x in wowdict)
            {
                dictcount++;
                if (dictcount >= begincount && dictcount <= endcount)
                {
                    patientnext.Add(x.Key, x.Value);
                }
            }

            PagedDataSource newpatient = new PagedDataSource();
            newpatient.DataSource = patientnext;
            newpatient.AllowPaging = true;
            newpatient.PageSize = 3;
            dl_un.DataSource = newpatient;
            dl_un.DataBind();
            
            
        }

        protected void imbNext_Click(object sender, ImageClickEventArgs e)
        {
 
            if (count < 1)
            {
                
                Dictionary<string, string> wowdict = (Dictionary<string, string>)Session["patientdict"];
                begincount = 1 + 3;
                endcount = begincount + 2;
                if (begincount > 3)
                {
                    imbPrevious.Enabled = true;
                }
                

                Session["begincountnext"] = begincount;
                Session["endcountnext"] = endcount;
               
              
                int dictcount = 0;
                foreach (KeyValuePair<string, string> x in wowdict)
                {
                    dictcount++;
                    if (dictcount >= begincount && dictcount <= endcount)
                    {
                        patientnext.Add(x.Key, x.Value);
                    }                                                                
                }

                PagedDataSource newpatient = new PagedDataSource();
                newpatient.DataSource = patientnext;
                newpatient.AllowPaging = true;
                newpatient.PageSize = 3;
                dl_un.DataSource = newpatient;
                dl_un.DataBind();
              

            }
            else if (count > 0)
            {
                Dictionary<string, string> wowdict = (Dictionary<string, string>)Session["patientdict"];
                begincount = Convert.ToInt32(Session["endcountnext"]) + 1;
                if (begincount > 3)
                {
                    imbPrevious.Enabled = true;
                }

                Session["begincountnext"] = begincount;
                endcount = begincount + 2;
                Session["endcountnext"] = endcount;
                int dictcount = 0;
                foreach (KeyValuePair<string, string> x in wowdict)
                {
                    dictcount++;
                    if (dictcount >= begincount && dictcount <= endcount)
                    {
                        patientnext.Add(x.Key, x.Value);
                    }
                }

                PagedDataSource newpatient = new PagedDataSource();
                newpatient.DataSource = patientnext;
                newpatient.AllowPaging = true;
                newpatient.PageSize = 3;
                dl_un.DataSource = newpatient;
                dl_un.DataBind();
            }
            count++;
        }

        
    }
}
            