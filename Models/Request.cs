using MakeRequestWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace MakeRequestWebApp.Models
{

    public class Request
    {
        public int ArqID { get; set; }
        public Record Record { get; set; }
        public DocumentList DocumentList { get; set; }

        public void MakeDocumentList()
        {
            DocumentList = new DocumentList($"ObjectType_Request", ArqID);
        }

        public Request()
        {
            Record = new Record();
        }
    }

    public class Record
    {
        public string Account { get; set; }
        public string Address { get; set; }
        public int OrganisationUnitID { get; set; }
        public string Email { get; set; }
        public DateTime EntryDate { get; set; }
        public string Fax { get; set; }
        public string HomePhone { get; set; }
        public string Location { get; set; }
        public string MobilePhone { get; set; }
        public string PostCode { get; set; }
        public string ReceivedBy { get; set; }
        public string RequestDetail { get; set; }
        public string Suburb { get; set; }
        public string WorkPhone { get; set; }
        public string RequestorName { get; set; }
    }



}
