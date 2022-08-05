using Azure.Storage.Blobs;
using MakeRequestWebApp.Controllers;
using MakeRequestWebApp.Models;
using MakeRequestWebApp.Utilitys;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MakeRequestWebApp.Pages.RequestForm
{
    public partial class RequestForm
    {
        [ParameterAttribute]
        public Request ThisReq { get; set; }

        public bool ShowDocs { get; set; } = false;

        public HashSet<FormProp> EditedProps { get; set; } = new HashSet<FormProp>();

        RequestController RC = new RequestController();

        FormUtil DF = new FormUtil();

        protected override void OnInitialized()
        {
            ThisReq = new Request();

            //ThisReq = RC.GetRequest(87);
        }

        // Make Property
        public FormProp MkProp(string inp, object obj)
        {
            return DF.GetProperty(inp, obj);
        }

        // is edited (from form input)
        protected void isEdited(FormProp prop)
        {
            EditedProps.Add(prop);
        }

        // Submit Request ID: Runs Request ID Submission and changes the show docks condition 
        public void SubReqID()
        {
            Console.WriteLine("SubReqID: " + ThisReq.ArqID);

            if (DF.ReqIDSub(ThisReq.ArqID, EditedProps, out Request _ThisReq)) 
            {
                ThisReq = _ThisReq;

                ShowDocs = true;

                Console.WriteLine("ShowDocs: " + ShowDocs);
            } else
            {
                ShowDocs = false;
            }
        }

        // Runs the Add document in the selected Request
        public async void AddFile(InputFileChangeEventArgs e)
        {
            Console.WriteLine("AddFile: " + e.ToString() + " | " + e.File.Name + " -----------------------------------------//  <=");

            Console.WriteLine(ThisReq.ArqID);

            ThisReq.AddDocument(e.File);

            //string path = Path.Combine("http://localhost:64169", "Documents", e.File.Name);

            //await using FileStream fs = new(path, FileMode.Create);

            //await e.File.OpenReadStream(e.File.Size).CopyToAsync(fs);

            //using var content = new MultipartFormDataContent();

            //bool upload = false;

            //foreach (IBrowserFile file in e.GetMultipleFiles(10))
            //{
            //    try
            //    {
            //        StreamContent fileContent = new StreamContent(file.OpenReadStream(1024 * 15));

            //        fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            //        content.Add(
            //            content: fileContent,
            //            name: "\"files\"",
            //            fileName: file.Name
            //            );

            //        upload = true;
            //    } catch (Exception x)
            //    {

            //    }
            //}



            //HttpClientHandler clientHandler = new HttpClientHandler();

            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            //// Pass the handler to httpclient(from you are calling api)
            //HttpClient client = new HttpClient(clientHandler);

            //if(upload)
            //{
            //    HttpClient client = ClientFactory.CreateClient();

            //    HttpResponseMessage response = await client.PostAsync("http://localhost:64169/Filesave", content);

            //    using var responseStream = await response.Content.ReadAsStreamAsync();

            //    Console.WriteLine("Upload: " + response.Content.ReadAsStringAsync() + " -----------------------------------------//  <=");
            //}



            //await BlobContainerClient.UploadBlobAsync("test", e.File.OpenReadStream(e.File.Size));


        }


    }
}
