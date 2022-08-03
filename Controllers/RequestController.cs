using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using MakeRequestWebApp.Models;

namespace MakeRequestWebApp.Controllers
{
    public class RequestController : RootController
    {
        public Request GetRequest(int ID)
        {
            if (GetAPI($"/api/requests/{ID}", out string Res))
            {
                return JsonSerializer.Deserialize<Request>(Res);
            }
            else
            {
                Console.WriteLine($"Find Find Request: {ID}");

                return null;
            }
        }

        public int MakeRequest(MakeRequest req)
        {
            Console.WriteLine($"MakeRequest: {JsonSerializer.Serialize<MakeRequest>(req)}");

            if (PostAPI("/api/requests/create_request", JsonSerializer.Serialize<MakeRequest>(req), out string Res))
            {
                try
                {
                  return Int32.Parse(Res);

                } catch (Exception e) { return 0; }

            } else
            {
                return 0;
            }
        }
    }
}
