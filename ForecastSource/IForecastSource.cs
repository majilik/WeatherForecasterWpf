using ForecastSource.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForecastSource
{
    public interface IForecastSource
    {
        /// <summary>
        /// Get forecast data for a location.
        /// </summary>
        /// <param name="country">Country to get forecast data for</param>
        /// <param name="county">County to get forecast data for</param>
        /// <param name="city">City to get forecast data for</param>
        /// <returns>Forecast data for a location</returns>
        Task<IEnumerable<ForecastDto>> GetForecastAsync(string country, string county, string city);
    }
}
