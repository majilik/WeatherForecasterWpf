using System;
using RestSharp;
using System.Threading.Tasks;
using RestSharp.Serialization.Xml;
using YrForecastSource.Entities;

namespace YrForecastSource.Api
{
    internal class YrForecastApi : IYrForecastApi
    {
        const string BaseUrl = "https://www.yr.no/place/";
        readonly IRestClient _client;

        internal YrForecastApi()
        {
            _client = new RestClient(BaseUrl);
            _client.UseDotNetXmlSerializer();
        }

        public async Task<weatherdata> RequestForecastAsync(string country, string county, string city)
        {
            RestRequest request = new RestRequest($"{country}/{county}/{city}/forecast.xml");
            IRestResponse<weatherdata> response = await _client.ExecuteGetAsync<weatherdata>(request);

            if (response.IsSuccessful)
            {
                return response.Data;
            }

            return null;
        }
    }
}
