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
    
        public string MusicDetails(string songname,string artistname,string albumname,string azureurl,string albumartpath)
        {
            if (songname.Length == 0)
                returnmessage += "Song Name cannot be blank";
            if (songname.Length > 50)
                returnmessage += "Song Name cannot be more than 50 characters!";
            if (artistname.Length == 0)
                returnmessage += "Artist Name cannot be blank";
            if (artistname.Length > 50)
                returnmessage += "Artist Name cannot be more than 50 characters";
            if (albumname.Length == 0)
                returnmessage += "Album Name cannot be blank";
            if (albumname.Length > 50)
                returnmessage += "Album Name cannot be more than 50 characters";

            if(returnmessage.Length == 0)
            {
                AzureMusicDAL insertmusic = new AzureMusicDAL(songname,artistname,albumname,azureurl,albumartpath);
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
