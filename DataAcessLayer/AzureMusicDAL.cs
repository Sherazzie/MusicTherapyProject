using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DataAcessLayer
{
    public class AzureMusicDAL
    {
        //  static CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=musicupload;AccountKey=/3oK1KTz3hD8DgtlVODqrr2ZzD3G/roTxqi1XXdWu6c9l2WXe0lXkFkb1bdpigaotEnxWYCkRyacsn5hYq4EkA==" );
        //   static CloudBlobClient blobclient = storageAccount.CreateCloudBlobClient();
        //  CloudBlobContainer cloudBlobContainer = blobclient.GetContainerReference("musicupload");

        string connstr = "Server=tcp:o18y8i1qfe.database.windows.net,1433;Database=FypjDB;User ID=sherazzie@o18y8i1qfe;Password=Zulamibinsalami21;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
        string _songname = "";
        string _artistname = "";
        string _album = "";
        string _azureurl = "";
        string _albumartpath = "";


        public AzureMusicDAL()
        {

        }

        public AzureMusicDAL(string songname, string artistname, string album, string azureurl, string albumartpath)
        {
            _songname = songname;
            _artistname = artistname;
            _album = album;
            _azureurl = azureurl;
            _albumartpath = albumartpath;
        }

        public AzureMusicDAL(string artistname, string album, string azureurl, string albumartpath)
        : this("", artistname, album, azureurl, albumartpath)
        {

        }

        public AzureMusicDAL(string songname)
        : this(songname, "", "", "", "")
        {

        }

        public string Songname
        {
            get { return _songname; }
            set { _songname = value; }

        }

        public string ArtistName
        {
            get { return _artistname; }
            set { _artistname = value; }
        }
        public string Album
        {
            get { return _album; }
            set { _album = value; }
        }

        public string AzureUrl
        {
            get { return _azureurl; }
            set { _azureurl = value; }
        }

        public string AlbumArtPath
        {
            get { return _albumartpath; }
            set { _albumartpath = value; }
        }

        public int CreateMusicFile()
        {
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand("MusicInformation", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@songname", _songname);
            cmd.Parameters.AddWithValue("@artistname", _artistname);
            cmd.Parameters.AddWithValue("@albumname", _album);
            cmd.Parameters.AddWithValue("@azureurl", _azureurl);
            cmd.Parameters.AddWithValue("@alumartpath", _albumartpath);

            conn.Open();
            int noofRow = 0;
            noofRow = cmd.ExecuteNonQuery();
            conn.Close();
            return noofRow;


        }
    }
}
