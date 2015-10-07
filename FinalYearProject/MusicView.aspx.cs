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
    public partial class MusicView : System.Web.UI.Page
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
            string cmdstring = "SELECT AlbumArtPath,ArtistName,Album from MusicFiles ";
            SqlCommand cmd = new SqlCommand(cmdstring, conn);
            conn.Open();
            dl_music.DataSource = cmd.ExecuteReader();
            dl_music.DataBind();
            conn.Close();


        }
      

        

        protected void dl_music_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "SongInfo")
            {
                foreach (DataListItem dli in dl_music.Items)
                {
                    Label albname = (Label)dl_music.Items[e.Item.ItemIndex].FindControl("lbl_albumname");
                    Label artname = (Label)dl_music.Items[e.Item.ItemIndex].FindControl("lbl_artistname");
                    Image img = (Image)dl_music.Items[e.Item.ItemIndex].FindControl("img_albumart");
                    String imgurl = img.ImageUrl.ToString(); 

                    Session["albumname"] = albname.Text;
                    Session["artistname"] = artname.Text;
                    Session["imageurl"] = imgurl;

                    Response.Redirect("FilterSongsByAlbum.aspx");

                }
            }
        }

        protected void btn_queries_Click(object sender, EventArgs e)
        {
            if(tb_query.Text == "")
            {
                lbl_result.Text = "You have not entered a query";
                databind();
            }
            
            if(rb_albums.Checked == true)   
            {
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT AlbumArtPath,ArtistName,Album from MusicFiles where Album=@album";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@album", tb_query.Text);
                conn.Open(); 
                dl_music.DataSource = cmd.ExecuteReader();
                dl_music.DataBind();
                conn.Close();
            }

            if(rb_artists.Checked == true)
            {
                string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                SqlConnection conn = new SqlConnection(connstr);
                string cmdstring = "SELECT AlbumArtPath,ArtistName,Album from MusicFiles where ArtistName=@artname";
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@artname", tb_query.Text);
                conn.Open();
                dl_music.DataSource = cmd.ExecuteReader();
                dl_music.DataBind();
                conn.Close();
            }
            else
            {
                lbl_result.Text= "None of the checkboxes has been selected";
            }
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            databind();
        }

       
    }
}