using MakeRequestWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeRequestWebApp.Models
{
    public class DocumentList
    {
        public List<Document> documents { get; set; }

        public DocumentList(string _objectType, int Val)
        {
            DocumentController DC = new DocumentController();

            DC.MakeDocuments(new ObjectKey(_objectType, Val));
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

        private int DocumentID { get; set; }

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
}
