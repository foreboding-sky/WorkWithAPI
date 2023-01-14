using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Services
{
    public class MarketApiHandler
    {
        public HttpClient Client { get; set; }  
        public MarketApiHandler()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<DataModel> GetCoins(int count = 100) 
        {
            //api.coincap.io/v2/assets?limit=20
            DataModel coin = new DataModel();
            using (HttpResponseMessage response = await Client.GetAsync("http://api.coincap.io/v2/assets?limit=" + count))
            {
                if(response.IsSuccessStatusCode)
                {
                    coin = await response.Content.ReadAsAsync<DataModel>();

                    return coin;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
            throw new Exception("Http response instance not created");
        }
    }
}
