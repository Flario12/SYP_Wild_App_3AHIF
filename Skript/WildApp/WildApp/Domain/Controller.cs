using System.Collections.Generic;
using System.Threading.Tasks;
using WildApp.Data;
using WildApp.Models;
using System.Net.Http;
using System.Text.Json;
using System.Globalization;

namespace WildApp.Domain
{
    public class Controllers
    {
        private readonly WeatherService weatherService;
        private readonly FakeAPI fakeApi;
        private readonly AppDatabase database;

        public string DatabasePath => database.GetDatabasePath();

        public Controllers()
        {
            weatherService = new WeatherService();
            fakeApi = new FakeAPI();
            database = new AppDatabase();
        }

        public async Task<(double temp, double wind)> UpdateWeather(double lat, double lon)
        {
            await weatherService.LoadFromAPI(lat, lon);

            return (
                weatherService.GetTemperature(),
                weatherService.GetWind()
            );
        }

        public async Task<WaterTest> GetRandomWaterTest()
        {
            WaterTest result = await fakeApi.GetRandomWaterData();
            database.AddHistory(
                "WaterTest",
                $"Qualität: {result.WaterQuality} %, Temp: {result.Temperature} °C, pH: {result.PhValue}, O2: {result.OxygenLevel} mg/L",
                result.GetQualityStatus());

            return result;
        }

        public async Task<AirTest> GetRandomAirTest()
        {
            AirTest result = await fakeApi.GetRandomAirData();
            database.AddHistory(
                "AirTest",
                $"Qualität: {result.AirQuality} %, CO2: {result.Co2Level} ppm, Feinstaub: {result.FineDust} µg/m³, Luftfeuchte: {result.Humidity} %",
                result.GetQualityStatus());

            return result;
        }

        public List<Tutorial> GetTutorials(string? category = null)
        {
            return database.GetTutorials(category);
        }

        public List<string> GetCategories()
        {
            return database.GetCategories();
        }

        public List<TestHistoryEntry> GetHistory()
        {
            return database.TestHistory;
        }


        // Hier werden noch die Koordinaten geholt
        public async Task<(double lat, double lon)?> GetCoordinates(string city)
        {
            using HttpClient client = new HttpClient();

            // Setzt einen User-Agent Header
            //  Wichtig damit die Nominatim API (OpenStreetMap) Requests nicht blocken kann
            client.DefaultRequestHeaders.Add("User-Agent", "WildApp");

            // EscapeDataString sorgt dafür das Sonderzeichen korrekt enkodiert werden.
            string url = $"https://nominatim.openstreetmap.org/search?format=json&q={Uri.EscapeDataString(city)}";

            var response = await client.GetStringAsync(url);

            var results = JsonSerializer.Deserialize<List<GeoResult>>(response);

            if (results == null || results.Count == 0)
                return null;


            // InvariantCulture sorgt dafür, dass der Punkt sich als Kommatrennung verhaltet.
            return (
                double.Parse(results[0].lat, CultureInfo.InvariantCulture),
                double.Parse(results[0].lon, CultureInfo.InvariantCulture)
            );
        }
    }
}
