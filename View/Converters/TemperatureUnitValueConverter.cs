using ForecastSource.Dto;
using System;
using System.Globalization;
using System.Windows.Data;

namespace View.Converters
{
    /// <summary>
    /// Converts <see cref="TemperatureDto.TemperatureUnit"/> to a displayable string.
    /// e.g. "°C", "°F"
    /// </summary>
    internal class TemperatureUnitValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TemperatureDto.TemperatureUnit)
            {
                switch ((TemperatureDto.TemperatureUnit)value)
                {
                    case TemperatureDto.TemperatureUnit.Celsius:
                        return "°C";
                    case TemperatureDto.TemperatureUnit.Fahrenheit:
                        return "°F";
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
