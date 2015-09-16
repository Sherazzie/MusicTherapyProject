using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearProject
{
    public partial class FilterSongsByAlbum : System.Web.UI.Page
    {
        string artistname;
        string albumname;
        protected void Page_Load(object sender, EventArgs e)
        {
             artistname = Session["artistname"].ToString();
             albumname = Session["albumname"].ToString();
            databind();
        }

        private void databind()
        {
            
        }
    }
}