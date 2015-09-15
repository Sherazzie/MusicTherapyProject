using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace FinalYearProject
{
    public partial class music : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            
            

            if (fu_upload.PostedFile != null)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=musicupload;AccountKey=/3oK1KTz3hD8DgtlVODqrr2ZzD3G/roTxqi1XXdWu6c9l2WXe0lXkFkb1bdpigaotEnxWYCkRyacsn5hYq4EkA==");
                CloudBlobClient blobclient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = blobclient.GetContainerReference("musicfiles");
                string filenameUnique = Guid.NewGuid().ToString() + Path.GetExtension(fu_upload.FileName.ToLower());
                CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(filenameUnique);
                blockBlob.Properties.ContentType = fu_upload.PostedFile.ContentType;
                blockBlob.UploadFromStream(fu_upload.FileContent);
               

            }
            else
            {
                lbl_result.Text = "You have not selected a file";
            }

        }
    }
}