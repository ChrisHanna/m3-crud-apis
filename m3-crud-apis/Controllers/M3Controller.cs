using Microsoft.AspNetCore.Mvc;
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

            return Output;
        }

        [HttpGet(Name = "GetData2")]
        public string GetData2()
        {
            DateTime start = DateTime.Now.AddDays(-1);
            DateTime end = DateTime.Now;

            long unixTime_start = ((DateTimeOffset)start).ToUnixTimeSeconds();
            long unixTime_end = ((DateTimeOffset)end).ToUnixTimeSeconds();

            var url = "http://10.0.0.16:7201/api/v1/query_range?query=third_avenue&start=" + unixTime_start + "&end=" + unixTime_end + "&step=60s";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            RestResponse response = client.Execute(request);
            string Output = response.Content.ToString();

            return Output;
        }

        [HttpGet(Name = "GetTest")]
        public string GetTest()
        {
            var url = "https://reqres.in/api/users?page=2";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            RestResponse response = client.Execute(request);
            string Output = response.Content.ToString();

            return Output;
        }
    }
}