using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MakeRequestWebApp.Controllers
{
    public class RootController : Controller
    {
        private const string URL = "https://Developolis.conquest.live:444";

        private const string AUTH = "Bearer Nkjs3ufHQMeZ8NhaAd0fXq+We6I=";

        public HttpClient APIClient()
        {
            Console.WriteLine("Running RootController"); 

            HttpClient ConAPI = new HttpClient();

            ConAPI.BaseAddress = new Uri(URL);

            ConAPI.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            ConAPI.DefaultRequestHeaders.Add("Authorization", AUTH);

            return ConAPI;
        }

        public bool GetAPI(string ReqURI, out string Res)
        {
            HttpClient Client = APIClient();

            try
            {
                HttpResponseMessage response = Client.GetAsync(ReqURI).Result;

                string Response = response.Content.ReadAsStringAsync().Result;

                Client.Dispose();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.StatusCode);

                    Res = Response;

                    return true;
                }
                else
                {
                    Console.WriteLine(response.StatusCode);

                    Res = Response;

                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't Get Response: " + e);

                Res = null;

                return false;
            }
        }

        public bool PostAPI(string ReqURI, string ReqJSON, out string Res)
        {
            HttpClient Client = APIClient();

            try
            {
                HttpResponseMessage response = Client.PostAsync(ReqURI, new StringContent(ReqJSON)).Result;

                string Response = response.Content.ReadAsStringAsync().Result;

                Client.Dispose();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(response.StatusCode);

                    Res = Response;

                    return true;
                }
                else
                {
                    Console.WriteLine(response.StatusCode);

                    Res = Response;

                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Couldn't Get Response: " + e);

                Res = null;

                return false;
            }
        }

    }
}
