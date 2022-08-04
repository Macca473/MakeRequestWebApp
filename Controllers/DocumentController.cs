using MakeRequestWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MakeRequestWebApp.Controllers
{
    public class DocumentController : RootController
    {
        public DocumentResponse AddDocument(AddDocumentClass AD)
        {
            Console.WriteLine($"AddDocument: {JsonConvert.SerializeObject(AD)}");

            if (PostAPI("/api/documents/add_document", JsonConvert.SerializeObject(AD), out string Res))
            {
                try
                {
                    Console.WriteLine($"AddDocument responce: {Res}");

                    DocumentResponse TestDoc = JsonConvert.DeserializeObject<DocumentResponse>(Res);

                    Console.WriteLine($"AddDocument Uri: {TestDoc.UploadUri}");

                    return JsonConvert.DeserializeObject<DocumentResponse>(Res);
                }
                catch (Exception e) {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }

        public DocumentList GetDocuments(ObjectKey OK)
        {
            if (PostAPI("/api/documents/list", JsonConvert.SerializeObject(OK), out string Res))
            {
                try
                {
                    return JsonConvert.DeserializeObject<DocumentList>(Res);

                }
                catch (Exception e) { return null; }

            }
            else
            {
                return null;
            }
        }

        public DocumentLink MakeDocumentLink(DocumentLinkReq DR)
        {
            Console.WriteLine($"MakeRequest: {JsonConvert.SerializeObject(DR)}");

            if (PostAPI("/api/documents/list", JsonConvert.SerializeObject(DR), out string Res))
            {
                try
                {
                    return JsonConvert.DeserializeObject<DocumentLink>(Res);

                }
                catch (Exception e) { return null; }

            }
            else
            {
                return null;
            }
        }
    }
}
