using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAcessLayer;
using BusinessLogicLayer;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace FinalYearProject
{
    public partial class CreatePatient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string gender = "";
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            
            if (fu_patientimage.HasFile)
            {
                if(fu_patientimage.PostedFile != null)
                {
                    AzurePatientBLL validatepatient = new AzurePatientBLL();
                    if(ddl_gender.SelectedIndex == 0)
                    {
                        gender = "M";   
                    }
                    if (ddl_gender.SelectedIndex == 1)
                    {
                        gender = "F";
                    }
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=fypimages;AccountKey=3tWZD9BJjMmclYNesfJnQYSo+RFZIu6DK6WSj3sR11FU9SeyQv7D4Tzw0HrcLnu3o/lHZYXBoFAyEG4hJm0A8w==");
                    CloudBlobClient blobclient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer cloudBlobContainer = blobclient.GetContainerReference("patientimages");
                    string filenameUnique = tb_patientname.Text + "_" + tb_patientic.Text + Path.GetExtension(fu_patientimage.FileName.ToLower());
                    CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(filenameUnique);
                    blockBlob.Properties.ContentType = fu_patientimage.PostedFile.ContentType;
                    blockBlob.UploadFromStream(fu_patientimage.FileContent);
                    string azureurl = "https://fypimages.blob.core.windows.net/patientimages/" + filenameUnique;
                    validatepatient.validatepatientinfo(tb_patientic.Text, tb_patientname.Text, tb_birthdate.Text, azureurl, gender);
                    lbl_result.Text = validatepatient.returnmessage;
                }
            }
            else
            {
                lbl_result.Text = "You have not selected a profile image for the patient";
            }
        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {
            tb_patientname.Text = "";
            tb_patientic.Text = "";
            tb_birthdate.Text = "";
            fu_patientimage.Dispose();
            lbl_result.Text = "";

        }
    }
}