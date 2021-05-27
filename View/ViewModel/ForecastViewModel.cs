using ForecastSource;
using ForecastSource.Dto;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace View.ViewModel
{
    internal class ForecastViewModel : INotifyPropertyChanged
    {
        private IForecastSource _forecastSource;

        /// <summary>
        /// Observable property for the forecast data
        /// </summary>
        public ObservableCollection<ForecastDto> Forecast { get; set; }

        /// <summary>
        /// Observable property for the current city
        /// </summary>
        public string CurrentCity
        {
            get { return currentCity; }
            set { 
                currentCity = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentCity))); 
            }
        }
        private string currentCity;

        internal ForecastViewModel() : this(new YrForecastSource.YrForecastSource())
        {
        }

        internal ForecastViewModel(IForecastSource forecastSource)
        {
            Forecast = new ObservableCollection<ForecastDto>();
            _forecastSource = forecastSource;
        }

        /// <summary>
        /// Request forecast and updates observables with the response.
        /// </summary>
        /// <param name="country">Country to get forecast data for</param>
        /// <param name="county">County to get forecast data for</param>
        /// <param name="city">City to get forecast data for</param>
        internal async Task RequestForecast(string country, string county, string city)
        {
            Forecast.Clear();
            CurrentCity = city;
            IEnumerable<ForecastDto> forecast = await _forecastSource.GetForecastAsync(country, county, city);
            foreach (ForecastDto forecastDto in forecast)
            {
                Forecast.Add(forecastDto);
            }
        }

        /// <summary>
        /// Handler to notify observers of changes to properties.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
