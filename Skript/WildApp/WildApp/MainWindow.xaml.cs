using System.Diagnostics.Tracing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WildApp.Data;
using WildApp.Domain;

namespace WildApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controllers controller = new Controllers();

        Dictionary<string, (double lat, double lon)> cities =
        new Dictionary<string, (double, double)>()
        {
            { "Dornbirn", (47.41, 9.74) },
            { "Wien", (48.21, 16.37) },
            { "Graz", (47.07, 15.43) },
            { "Linz", (48.31, 14.29) },
            { "Salzburg", (47.80, 13.04) },
            { "Innsbruck", (47.27, 11.40) },
            { "Bregenz", (47.50, 9.75) },
            { "Klagenfurt", (46.62, 14.31) },
            { "St. Pölten", (48.21, 15.62) },
            { "Villach", (46.61, 13.85) },
            { "Wiener Neustadt", (47.81, 16.24) },
            { "Feldkirch", (47.24, 9.60) },
            { "Eisenstadt", (47.85, 16.52) }
        };


        WeatherService service = new WeatherService();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string city = Stadt.Text.Trim();

            if (cities.ContainsKey(city))
            {
                double lat = cities[city].lat;
                double lon = cities[city].lon;

                await service.LoadFromAPI(lat, lon);

                Temperatur.Content = $"{service.GetTemperature()} °C";
            }
            else
            {
                Temperatur.Content = "Stadt nicht gefunden";
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WeatherService service = new WeatherService();

            

            string City = Stadt.Text.Trim();
            if (cities.ContainsKey(City))
            {
                // City exists in the dictionary.
                // You can access coordinates via: cities[City].lat and cities[City].lon
                double lat = cities[City].lat;
                double lon = cities[City].lon;

                await service.LoadFromAPI(lat, lon);

                Wind.Content = $"{service.GetWind()} km/h";
            }
            else
            {
                Wind.Content = "Stadt nicht gefunden";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string City = Stadt.Text.Trim();
            if (cities.ContainsKey(City))
            {
                // City exists in the dictionary.
                // You can access coordinates via: cities[City].lat and cities[City].lon
                double lat = cities[City].lat;
                double lon = cities[City].lon;

                var result = await controller.UpdateWeather(lat, lon);

                Temperatur.Content = $"{result.temp} °C";
                Wind.Content = $"{result.wind} km/h";
            }
            else
            {
                Wind.Content = "Stadt nicht gefunden";
                Temperatur.Content = "Stadt nicht gefunden";
            }
        }
    }
}