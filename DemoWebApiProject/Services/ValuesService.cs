using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace DemoWebApiProject.Services
{
    public class ValuesService
    {
        public HttpResponseMessage GetCoins()
        {
            HttpResponseMessage response = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.coingecko.com");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync("api/v3/coins/list").Result;
            }

            return response;
        }
    }
}