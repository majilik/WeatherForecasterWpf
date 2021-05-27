using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YrForecastSource.Entities;

namespace YrForecastSource.Api
{
    public interface IYrForecastApi
    {
        /// <summary>
        /// Get forecast data for a location from the YR Forecast XML API
        /// </summary>
        /// <param name="country">Country to get forecast data for</param>
        /// <param name="county">County to get forecast data for</param>
        /// <param name="city">City to get forecast data for</param>
        /// <returns>Deserialized API response of forecast XML data</returns>
        Task<weatherdata> RequestForecastAsync(string country, string county, string city);
    }
}
