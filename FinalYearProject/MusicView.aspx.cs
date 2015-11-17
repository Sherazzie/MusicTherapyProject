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
        SqlDataAdapter dadapter;
        DataSet dset;
        PagedDataSource adsource;
        int pos;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                this.ViewState["vs"] = 0;
            }
            pos = (int)this.ViewState["vs"];
            databind();
        }
         
        protected void databind()
        {
            string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connstr);
            string cmdstring = "SELECT AlbumArtPath,ArtistName,Album from MusicFiles ";

            dadapter = new SqlDataAdapter(cmdstring, conn);
            dset = new DataSet();
            adsource = new PagedDataSource();
            conn.Open();
            dadapter.Fill(dset);
            adsource.DataSource = dset.Tables[0].DefaultView;
            adsource.PageSize = 6;
            adsource.AllowPaging = true;
            adsource.CurrentPageIndex = pos;
            btnfirst.Enabled = !adsource.IsFirstPage;
            btnprevious.Enabled = !adsource.IsFirstPage;
            btnlast.Enabled = !adsource.IsLastPage;
            btnnext.Enabled = !adsource.IsLastPage;
            dl_music.DataSource = adsource;
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
            if (tb_query.Text == "")
            {
                lbl_result.Text = "You have not entered a query";
                
            }
            else
            {
                
                if (rb_albums.Checked && !rb_artists.Checked)
                {
                    string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                    SqlConnection conn = new SqlConnection(connstr);
                    string cmdstring = "SELECT AlbumArtPath,ArtistName,Album from MusicFiles where Album=@album";
                    SqlCommand cmd = new SqlCommand(cmdstring, conn);
                    cmd.Parameters.AddWithValue("@album", tb_query.Text);
                    dadapter = new SqlDataAdapter(cmd);
                    dset = new DataSet();
                    adsource = new PagedDataSource();
                    conn.Open();
                    dadapter.Fill(dset);
                    adsource.DataSource = dset.Tables[0].DefaultView;
                    adsource.PageSize = 6;
                    adsource.AllowPaging = true;
                    adsource.CurrentPageIndex = pos;
                    btnfirst.Enabled = !adsource.IsFirstPage;
                    btnprevious.Enabled = !adsource.IsFirstPage;
                    btnlast.Enabled = !adsource.IsLastPage;
                    btnnext.Enabled = !adsource.IsLastPage;
                    dl_music.DataSource = adsource;
                    dl_music.DataBind();
                    conn.Close();
                    lbl_result.Text = "";
                }


                if (rb_artists.Checked && !rb_albums.Checked)
                {
                    string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
                    SqlConnection conn = new SqlConnection(connstr);
                    string cmdstring = "SELECT AlbumArtPath,ArtistName,Album from MusicFiles where ArtistName=@artname";
                    SqlCommand cmd = new SqlCommand(cmdstring, conn);
                    cmd.Parameters.AddWithValue("@artname", tb_query.Text);
                    dadapter = new SqlDataAdapter(cmd);
                    dset = new DataSet();
                    adsource = new PagedDataSource();
                    conn.Open();
                    dadapter.Fill(dset);
                    adsource.DataSource = dset.Tables[0].DefaultView;
                    adsource.PageSize = 6;
                    adsource.AllowPaging = true;
                    adsource.CurrentPageIndex = pos;
                    btnfirst.Enabled = !adsource.IsFirstPage;
                    btnprevious.Enabled = !adsource.IsFirstPage;
                    btnlast.Enabled = !adsource.IsLastPage;
                    btnnext.Enabled = !adsource.IsLastPage;
                    dl_music.DataSource = adsource;
                    dl_music.DataBind();
                    conn.Close();
                    lbl_result.Text = "";
                    
                }

            }
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            databind();
            tb_query.Text = "";
            rb_albums.Checked= false;
            rb_artists.Checked= false;
        }
        protected void btnfirst_Click(object sender, EventArgs e)
        {
            pos = 0;
            databind();
        }

        protected void btnprevious_Click(object sender, EventArgs e)
        {
            pos = (int)this.ViewState["vs"];
            pos -= 1;
            this.ViewState["vs"] = pos;
            databind();
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            pos = (int)this.ViewState["vs"];
            pos += 1;
            this.ViewState["vs"] = pos;
            databind();
        }

        protected void btnlast_Click(object sender, EventArgs e)
        {
            pos = adsource.PageCount - 1;
            databind();
        }

    }

}
