using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI.Models
{
    public class DataModel
    {
        [JsonProperty("data")]
        public List<CoinModel> Coins { get; set; }
    }
}
