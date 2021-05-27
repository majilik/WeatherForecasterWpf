namespace ForecastSource.Dto
{
    public class TemperatureDto
    {
        /// <summary>
        /// Temperature unit, e.g. °C
        /// </summary>
        public TemperatureUnit Unit { get; set; }

        /// <summary>
        /// Temperature value, e.g. 23.5
        /// </summary>
        public double Value { get; set; }

        public enum TemperatureUnit
        {
            /// <summary>
            /// °C
            /// </summary>
            Celsius,
            /// <summary>
            /// °F
            /// </summary>
            Fahrenheit
        }
    }
}
