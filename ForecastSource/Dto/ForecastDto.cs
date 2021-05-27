using System;

namespace ForecastSource.Dto
{
    public class ForecastDto
    {
        /// <summary>
        /// Icon depicting the weather forecasted
        /// </summary>
        public IconDto Icon { get; set; }
        /// <summary>
        /// The date and time of the forecast
        /// </summary>
        public DateTime From { get; set; }
        /// <summary>
        /// Temperature data for the forecast
        /// </summary>
        public TemperatureDto Temperature { get; set; }
    }
}
