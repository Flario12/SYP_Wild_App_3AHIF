using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Globalization;

namespace WildApp.Data
{
    class WeatherService
    {
        private double temperature = 0;
        private double wind = 0;

        public async Task LoadFromAPI(double latitude, double longitude)
        {
            // TODO: Implementierens
            using var client = new HttpClient();

            // CultureInfo
            string url =
                $"https://api.open-meteo.com/v1/forecast" +
                $"?latitude={latitude.ToString(CultureInfo.InvariantCulture)}" +
                $"&longitude={longitude.ToString(CultureInfo.InvariantCulture)}" +
                $"&current=temperature_2m,wind_speed_10m";

            // Antwort von der API holen und in JSON umwandeln
            string response = await client.GetStringAsync(url);
            using JsonDocument doc = JsonDocument.Parse(response);


            JsonElement current = doc.RootElement.GetProperty("current"); // Ist ein Dict (Root vom Dict)
            temperature = current.GetProperty("temperature_2m").GetDouble(); // Inhalt des Dicts bzw. Roots
            wind = current.GetProperty("wind_speed_10m").GetDouble(); // ...
        }

        public double GetTemperature()
        {
            return temperature;
        }

        public double GetWind()
        {
            return wind;
        }
    }
}
