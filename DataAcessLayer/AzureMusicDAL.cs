using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace DataAcessLayer
{
    public class AzureMusicDAL
    {
       static CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=musicupload;AccountKey=/3oK1KTz3hD8DgtlVODqrr2ZzD3G/roTxqi1XXdWu6c9l2WXe0lXkFkb1bdpigaotEnxWYCkRyacsn5hYq4EkA==" );
        static CloudBlobClient blobclient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer cloudBlobContainer = blobclient.GetContainerReference("musicupload");

    }
}
