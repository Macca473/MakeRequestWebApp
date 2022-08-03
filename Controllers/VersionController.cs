using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeRequestWebApp.Controllers
{
    public class VersionController : RootController
    {
        public bool GetRequest()
        {
            return GetAPI($"/api/system/version", out string Res);
        }
    }
}
