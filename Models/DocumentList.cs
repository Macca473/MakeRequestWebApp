using MakeRequestWebApp.Controllers;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeRequestWebApp.Models
{
    public class DocumentList
    {
        public List<Document> documents { get; set; }
        private ObjectKey objectKey { get; set; }

        public DocumentList(string _objectType, int Val)
        {
            DocumentController DC = new DocumentController();

            objectKey = new ObjectKey(_objectType, Val);

            DC.GetDocuments(objectKey);
        }

        public void AddDocument(IBrowserFile file)
        {
            DocumentController DC = new DocumentController();

            DocumentResponse documentResponse = DC.AddDocument(new AddDocumentClass(objectKey, file));

            documentResponse.UploadDoc(file);
        }

    }

    public class Document
    {
        public ObjectKey ObjectKey { get; set; }
        public int DocumentID { get; set; }
        public int Order { get; set; }
        public string DocumentDescription { get; set; }
        public string ContentType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateTime { get; set; }
        public string UploadStatus { get; set; }
        public bool FileShouldBeAccessible { get; set; }

        public DocumentLink documentLink { get; set; }

        public DocumentLink MakeDocumentLink()
        {
            DocumentController DC = new DocumentController();

            return DC.MakeDocumentLink(new DocumentLinkReq(DocumentID, ObjectKey));
        }
    }

    public class DocumentLink
    {
        public string LinkExpireTime { get; set; }
        public string Link { get; set; }
        public int DocumentID { get; set; }

    }

    public class DocumentLinkReq
    {
        public int DocumentID { get; set; }
        public ObjectKey ObjectKey { get; set; }
        public string X_thumbnail_parameter { get; set; } = "medium";

        public DocumentLinkReq(int _DocumentID, ObjectKey _ObjectKey)
        {
            DocumentID = _DocumentID;

            ObjectKey = _ObjectKey;
        }
    }

    public class AddDocumentClass
    {
        public string Address { get; set; }
        public DateTime CreateTime { get; set; }
        public string ContentType { get; set; }
        public ObjectKey ObjectKey { get; set; }

        public AddDocumentClass(ObjectKey objectKey, IBrowserFile file)
        {
            Address = $"Asset/{objectKey.int32Value}/{file.Name}";

            CreateTime = DateTime.Now;

            ContentType = file.ContentType;

            ObjectKey = objectKey;
        }
    }
}
