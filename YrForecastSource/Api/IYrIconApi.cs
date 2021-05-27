using ForecastSource.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YrForecastSource.Api
{
    public interface IYrIconApi
    {

        /// <summary>
        /// Get forecast icon for an icon id from the YR Icon API
        /// </summary>
        /// <param name="iconId">Icon ID to fetch icon data for</param>
        /// <returns>Icon data</returns>
        Task<IconDto> RequestForecastIcon(string iconId);
    }
}
