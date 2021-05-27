using System;
using System.Globalization;
using System.Windows.Data;

namespace View.Converters
{
    /// <summary>
    /// Converts <see cref="DateTime"/> to a displayable string.
    /// e.g. "Idag kl. 16:00", "I morgon kl. 23:00", "Måndag 2/2 kl. 10:00"
    /// </summary>
    internal class DateTimeValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                DateTime castValue = (DateTime)value;

                if (castValue.Date == DateTime.Today)
                {
                    return $"Idag kl. {castValue:t}";
                }
                else if (castValue.Date == DateTime.Today.AddDays(1))
                {
                    return $"I morgon kl. {castValue:t}";
                }

                return $"{castValue:dddd d'/'M} kl. {castValue:t}";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
