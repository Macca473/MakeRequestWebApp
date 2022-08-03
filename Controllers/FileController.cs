using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MakeRequestWebApp.Controllers
{
    public class FileController : ControllerBase
    {
        public readonly IWebHostEnvironment webHostEnviroment;

        public FileController(IWebHostEnvironment _webHostEnviroment)
        {
            webHostEnviroment = _webHostEnviroment;

            Console.WriteLine("FileController:" + _webHostEnviroment.ContentRootPath + "//---------------------------------------------- <--");
        }

        public void AddFile(InputFileChangeEventArgs e)
        {
            
            string path = Path.Combine(webHostEnviroment.ContentRootPath, "wwwroot", "Documents", e.File.Name);

            using FileStream fs = new(path, FileMode.Create);

            e.File.OpenReadStream().CopyToAsync(fs);
        }
    }
}
