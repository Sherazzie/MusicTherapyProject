using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer;

namespace BusinessLogicLayer
{
   public class AzureMusicBLL
    {
       public  string returnmessage = "";
    
        public string MusicDetails(string songname,string artistname,string albumname,string azureurl,string albumartpath,string lyrics)
        {
            if (songname.Length == 0)
                returnmessage += "Song Name cannot be blank<br/>";
            if (songname.Length > 50)
                returnmessage += "Song Name cannot be more than 50 characters!<br/>";
            if (artistname.Length == 0)
                returnmessage += "Artist Name cannot be blank<br/>";
            if (artistname.Length > 50)
                returnmessage += "Artist Name cannot be more than 50 characters<br/>";
            if (albumname.Length == 0)
                returnmessage += "Album Name cannot be blank<br/>";
            if (albumname.Length > 50)
                returnmessage += "Album Name cannot be more than 50 characters<br/>";
            if (lyrics.Length == 0)
                returnmessage += "Song lyrics cannot be empty <br/>";
            if(returnmessage.Length == 0)
            {
                AzureMusicDAL insertmusic = new AzureMusicDAL(songname,artistname,albumname,azureurl,albumartpath,lyrics);
                int noofRows = 0;
                noofRows = insertmusic.CreateMusicFile();

                if (noofRows > 0)
                    returnmessage = "Music Uploaded Succuess.";
                else
                    returnmessage = "Error,Please try again";

            }

            return returnmessage;
        }
    }
}
