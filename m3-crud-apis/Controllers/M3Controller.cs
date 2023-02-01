using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace m3_crud_apis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class M3Controller : ControllerBase
    {

        private readonly ILogger<M3Controller> _logger;

        public M3Controller(ILogger<M3Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetData")]
        public string Get()
        {
            DateTime start = DateTime.Now.AddDays(-1);
            DateTime end = DateTime.Now;

            long unixTime_start = ((DateTimeOffset)start).ToUnixTimeSeconds();
            long unixTime_end = ((DateTimeOffset)end).ToUnixTimeSeconds();

            var url = "http://10.64.13.7:7201/api/v1/query_range?query=third_avenue&start=" + unixTime_start + "&end=" + unixTime_end + "&step=60s";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            RestResponse response = client.Execute(request);
            string Output = response.Content.ToString();

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(Output); 
            
            Dictionary<string, string> yay = new Dictionary<string, string>();

            foreach(var i in myDeserializedClass.data.result)
            {
                foreach (var o in i.values) {

                   string date = o[0].ToString();
                   string value = o[1].ToString();

                    yay.Add(date, value);
                }                
            }

            return MyDictionaryToJson(yay);
        }

        string MyDictionaryToJson(Dictionary<string, string> dict)
        {
            var entries = dict.Select(d =>
                string.Format("\"{0}\": [{1}]", d.Key, string.Join(",", d.Value)));
            return "{" + string.Join(",", entries) + "}";
        }

    }
}