using ForecastSource;
using ForecastSource.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using YrForecastSource.Entities;
using YrForecastSource.Api;

namespace YrForecastSource
{
    public class YrForecastSource : IForecastSource
    {
        readonly IYrForecastApi _forecastApi;
        readonly IYrIconApi _iconApi;
        readonly IDictionary<string, IconDto> _iconsById;

        public YrForecastSource() : this(new YrForecastApi(), new YrIconApi())
        {
        }

        public YrForecastSource(IYrForecastApi yrForecastApi, IYrIconApi yrIconApi)
        {
            _forecastApi = yrForecastApi;
            _iconApi = yrIconApi;
            _iconsById = new Dictionary<string, IconDto>();
        }

        public async Task<IEnumerable<ForecastDto>> GetForecastAsync(string country, string county, string city)
        {
            weatherdata response = await _forecastApi.RequestForecastAsync(country, county, city);
            await FillForecastIcons(WeatherDataUtil.ExtractIconIds(response));

            return WeatherDataUtil.MapForecast(response, _iconsById);
        }

        /// <summary>
        /// Fill the local dictionary of forecast icons for a list of icon ids
        /// </summary>
        /// <param name="iconIds">List of icon ids</param>
        internal async Task FillForecastIcons(IEnumerable<string> iconIds)
        {
            foreach (string iconId in iconIds)
            {
                if (_iconsById.ContainsKey(iconId))
                {
                    continue;
                }

                _iconsById[iconId] = await _iconApi.RequestForecastIcon(iconId);
            }
        }

    }
}
