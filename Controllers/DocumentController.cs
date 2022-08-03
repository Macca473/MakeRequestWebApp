using MakeRequestWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MakeRequestWebApp.Controllers
{
    public class DocumentController : RootController
    {
        public DocumentList MakeDocuments(ObjectKey OK)
        {
            Console.WriteLine($"MakeRequest: {JsonSerializer.Serialize<ObjectKey>(OK)}");

            if (PostAPI("/api/documents/list", JsonSerializer.Serialize<ObjectKey>(OK), out string Res))
            {
                try
                {
                    return JsonSerializer.Deserialize<DocumentList>(Res);

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
            Console.WriteLine($"MakeRequest: {JsonSerializer.Serialize<DocumentLinkReq>(DR)}");

            if (PostAPI("/api/documents/list", JsonSerializer.Serialize<DocumentLinkReq>(DR), out string Res))
            {
                try
                {
                    return JsonSerializer.Deserialize<DocumentLink>(Res);

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
