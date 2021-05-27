using System.Windows;
using View.ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal ForecastViewModel ForecastViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ForecastViewModel = new ForecastViewModel();
            DataContext = ForecastViewModel;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await ForecastViewModel.RequestForecast("Sweden", "Dalarna", "Smedjebacken");
        }
    }
}
