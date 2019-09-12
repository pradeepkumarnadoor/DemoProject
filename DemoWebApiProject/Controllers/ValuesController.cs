using DemoWebApiProject.Models;
using DemoWebApiProject.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace DemoWebApiProject.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("api/GetCoins")]
        public DataResponse GetCoins()
        {
            ValuesService valuesService = new ValuesService();
            List<Coin> CoinInfo = new List<Coin>();

            var response = valuesService.GetCoins();
            if (response.IsSuccessStatusCode)
            {
                var CoinResponse = response.Content.ReadAsStringAsync().Result;
                CoinInfo = response.Content.ReadAsAsync<List<Coin>>().Result;
            }

            DataResponse output = new DataResponse
            {
                recordsTotal = CoinInfo.Count(),
                data = CoinInfo.ToArray()
            };
            return output;
        }


        //public IEnumerable<Coin> GetCoins()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        List<Coin> CoinInfo = new List<Coin>();
        //        client.BaseAddress = new Uri("https://api.coingecko.com/api/v3/coins/list");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        var response = client.GetAsync("api/values/10").Result;
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string responseString = response.Content.ReadAsStringAsync().Result;
        //            var modelObject = response.Content.ReadAsAsync<Coin>().Result;
        //            CoinInfo = JsonConvert.DeserializeObject<List<Coin>>(modelObject);
        //            return modelObject;
        //        }

        //    }
        //}
    }
}
