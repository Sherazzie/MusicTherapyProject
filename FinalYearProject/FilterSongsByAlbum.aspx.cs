using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace FinalYearProject
{
    public partial class FilterSongsByAlbum : System.Web.UI.Page
    {
        string artistname;
      public string albumname;

        protected void Page_Load(object sender, EventArgs e)
        {
            artistname = Session["artistname"].ToString();
            albumname = Session["albumname"].ToString();


            sessiondatabind();

            databind();
        }


        private void databind()
        {

            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT SongName,AzureUrl from MusicFiles where ArtistName=@aname and Album=@album ";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@aname", artistname);
            cmd.Parameters.AddWithValue("@album", albumname);
            conn.Open();
            gv_musicfiles.DataSource = cmd.ExecuteReader();
            gv_musicfiles.DataBind();
            conn.Close();
        }
        protected void sessiondatabind()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT AlbumArtPath,ArtistName,Album from MusicFiles where ArtistName=@aname and Album=@album";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            cmd.Parameters.AddWithValue("@aname", artistname);
            cmd.Parameters.AddWithValue("@album", albumname);

            conn.Open();
            dl_music.DataSource = cmd.ExecuteReader();
            dl_music.DataBind();
            conn.Close();


        }
        protected void dl_music_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "SongInfo")
            {
                Response.Redirect("MusicView.aspx");
            }

        }

        protected void gv_musicfiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                Label songname = (Label)gv_musicfiles.Rows[index].FindControl("lbl_songname");
                Session["assignedsongname"] = songname.Text;
                Response.Redirect("AssignMusic.aspx");
            }
        }
    }


}
