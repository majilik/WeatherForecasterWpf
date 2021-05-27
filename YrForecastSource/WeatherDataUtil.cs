using ForecastSource.Dto;
using System.Collections.Generic;
using System.Linq;
using YrForecastSource.Entities;

namespace YrForecastSource
{
    public static class WeatherDataUtil
    {
        /// <summary>
        /// Extracts icon ids from the deserialized API response
        /// </summary>
        /// <param name="weatherData">Deserialized API response</param>
        /// <returns>List of icon ids, or an empty list if no icon data can be found</returns>
        public static IEnumerable<string> ExtractIconIds(weatherdata weatherData)
        {
            return weatherData?
                .forecast?
                .tabular?
                .Select(forecast => forecast.symbol.var) 
                ?? Enumerable.Empty<string>();
        }

        /// <summary>
        /// Maps the deserialized API response to an enumerable of <see cref="ForecastDto"/>
        /// </summary>
        /// <param name="weatherData">Deserialized API response</param>
        /// <param name="forecastIcons">Dictionary of IconDtos by icon id</param>
        /// <returns>Mapped enumerable of <see cref="ForecastDto"/></returns>
        public static IEnumerable<ForecastDto> MapForecast(weatherdata weatherData, IDictionary<string, IconDto> forecastIcons)
        {
            return weatherData?
                .forecast?
                .tabular?
                .Select(forecast => new ForecastDto()
                {
                    From = forecast.from,
                    Icon = forecastIcons[forecast.symbol.var],
                    Temperature = MapTemperature(forecast.temperature)
                })
                ?? Enumerable.Empty<ForecastDto>();
        }

        /// <summary>
        /// Maps the deserialized API response to <see cref="TemperatureDto"/>
        /// </summary>
        /// <param name="temperatureData">Deserialized API response</param>
        /// <returns>Mapped <see cref="TemperatureDto"/></returns>
        public static TemperatureDto MapTemperature(weatherdataForecastTimeTemperature temperatureData)
        {
            TemperatureDto.TemperatureUnit unit;
            switch (temperatureData.unit.ToLower())
            {
                default:
                case "celsius":
                    unit = TemperatureDto.TemperatureUnit.Celsius;
                    break;
                case "fahrenheit":
                    unit = TemperatureDto.TemperatureUnit.Fahrenheit;
                    break;
            }

            return new TemperatureDto()
            {
                Unit = unit,
                Value = temperatureData.value
            };
        }
    }
}
