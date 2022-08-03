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
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace MakeRequestWebApp.Pages.RequestForm
{
    public partial class RequestForm
    {
        [ParameterAttribute]
        public Request ThisReq { get; set; }

        [ParameterAttribute]
        public string RequestID { get; set; } = "";

        public HashSet<FormProp> EditedProps { get; set; } = new HashSet<FormProp>();

        RequestController RC = new RequestController();

        FormUtil DF = new FormUtil();

        protected override void OnInitialized()
        {
            ThisReq = new Request();

            //ThisReq = RC.GetRequest(87);

            PropertyInfo propertyInfo = ThisReq.GetType().GetProperty("ArqID");

            Console.WriteLine("ThisReq 1: " + ThisReq.ArqID.ToString());

            Console.WriteLine("ThisReq: " + propertyInfo.GetValue(ThisReq));

            Console.WriteLine("ThisReq: " + propertyInfo.GetValue(ThisReq));
        }

        public FormProp MkProp(string inp, object obj)
        {
            return DF.GetProperty(inp, obj);
        }

        protected void isEdited(FormProp prop)
        {
            EditedProps.Add(prop);
        }

        protected void SubReqID()
        {
            if(DF.ReqIDSub(RequestID, EditedProps, out Request _ThisReq))
            {
                ThisReq = _ThisReq;
            }
        }

        public void AddFile(InputFileChangeEventArgs e)
        {
            Console.WriteLine("AddFile: " + e.ToString() + " | " + e.File.Name);



            //string path = Path.Combine(_webHostEnviroment.ContentRootPath, "wwwroot", "Documents", e.File.Name);

            //using FileStream fs = new(path, FileMode.Create);

            

            //e.File.OpenReadStream().CopyToAsync(fs);
        }


    }
}
