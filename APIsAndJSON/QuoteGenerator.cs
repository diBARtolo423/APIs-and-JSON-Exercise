using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class QuoteGenerator
    {
        private HttpClient _client;

        public QuoteGenerator(HttpClient client)
        {
            _client = client;
        }

        public string Kanye()
        {
            var kanyeURL = "https://api.kanye.rest";            
            var kanyeResponse = _client.GetStringAsync(kanyeURL).Result;            
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

            return kanyeQuote;
        }

        public string Swanson()
        {
            
            var swansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var swansonResponse = _client.GetStringAsync(swansonURL).Result;
            var swansonQuote = JArray.Parse(swansonResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();

            return swansonQuote;
        }
    }
}
