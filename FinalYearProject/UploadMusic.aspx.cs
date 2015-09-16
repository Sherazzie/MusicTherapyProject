using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace FinalYearProject
{
    public partial class UploadMusic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_uploadmusic(object sender, EventArgs e)
        {
            if (fu_uploadmusic.HasFile && fu_uploadart.HasFile)
            {
                if (fu_uploadmusic.PostedFile != null && fu_uploadart.PostedFile != null)
                {
                    AzureMusicBLL validatemusic = new AzureMusicBLL();
                    string songname = sname.Value;
                    string artname = artistname.Value;
                    string albname = albumname.Value;

                    string FileName = Path.GetFileName(fu_uploadart.PostedFile.FileName);
                    fu_uploadart.SaveAs(Server.MapPath("MusicAlbumArt//" + FileName));
                    string albumartpath = "MusicAlbumArt//" + FileName;
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=musicupload;AccountKey=/3oK1KTz3hD8DgtlVODqrr2ZzD3G/roTxqi1XXdWu6c9l2WXe0lXkFkb1bdpigaotEnxWYCkRyacsn5hYq4EkA==");
                    CloudBlobClient blobclient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer cloudBlobContainer = blobclient.GetContainerReference("musicfiles");
                    string filenameUnique = songname + "_" + artname + Path.GetExtension(fu_uploadmusic.FileName.ToLower());
                    CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(filenameUnique);
                    blockBlob.Properties.ContentType = fu_uploadmusic.PostedFile.ContentType;
                    blockBlob.UploadFromStream(fu_uploadmusic.FileContent);
                    string azureurl = "https://musicupload.blob.core.windows.net/musicfiles/" + filenameUnique;
                    validatemusic.MusicDetails(songname, artname, albname, azureurl, albumartpath);
                    lbl_result.Text = validatemusic.returnmessage;

                }
                else
                {
                    lbl_result.Text = "You have not uploaded a music file/album art or both";
                } 
            }




        }

    }
}