using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MakeRequestWebApp.Models
{


    public class DocumentResponse
    {
        public Document Document { get; set; }
        public string UploadUri { get; set; }
        public string UploadMethod { get; set; }
        public string UploadExpireTime { get; set; }
        public UploadHeaders UploadHeaders { get; set; }

        public async void UploadDoc(IBrowserFile file)
        {
            BlobContainerClient BlobClient = new BlobContainerClient(new Uri(UploadUri), new BlobClientOptions());

            BlockBlobClient blockBlobClient = BlobClient.GetBlockBlobClient(file.Name);

            //blockBlobClient.Hea

            Response<BlobContentInfo> response = await blockBlobClient.UploadAsync(file.OpenReadStream(), new BlobHttpHeaders());

            Console.WriteLine("UploadDoc: " + response);

            //BlobServiceClient BlobClient = new BlobServiceClient(UploadUri, new DefaultAzureCredential());

            //Uri blobUri, Azure.Storage.Blobs.BlobClientOptions options = default

            //await BlobClient.UploadBlobAsync(file.Name, file.OpenReadStream());

            //var blobUri = 'https://xxx.blob.core.windows.net/';
            //const blobServiceClient = new BlobServiceClient(`${ sas["uri"] }`);
            //const containerClient = blobServiceClient.getContainerClient(params["container");
            //const blockBlobClient = containerClient.getBlockBlobClient(filename);

            //const uploadBlobResponse = await blockBlobClient.upload(file, file.size);
            //console.log(`Upload block blob successfully`, uploadBlobResponse.requestId);

        }
    }

    public class UploadHeaders
    {
        [JsonProperty("x-ms-blob-type")]
        public string XMsBlobType { get; set; }
    }
}
