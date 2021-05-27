using RestSharp;
using System.Threading.Tasks;
using ForecastSource.Dto;

namespace YrForecastSource.Api
{
    internal class YrIconApi : IYrIconApi
    {
        const string BaseUrl = "http://symbol.yr.no/grafikk/sym/";
        readonly IRestClient _client;

        internal YrIconApi()
        {
            _client = new RestClient(BaseUrl);
        }

        public async Task<IconDto> RequestForecastIcon(string iconId)
        {
            RestRequest request = new RestRequest($"b100/{iconId}.png");
            IRestResponse response = await _client.ExecuteGetAsync(request);

            if (response.IsSuccessful)
            {
                return new IconDto() {
                    ContentType = response.ContentType,
                    ContentData = response.RawBytes
                };
            }

            return null;
        }
    }
}
