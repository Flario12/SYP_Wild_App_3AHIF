using System;
using System.Text.Json;

namespace WildApp.Data
{
    public class AirTest : TestBasis
    {
        public double AirDensity { get; set; }
        public int AirQuality { get; set; }
        public double Co2Level { get; set; }
        public double FineDust { get; set; }
        public double Humidity { get; set; }

        public override void DeserializeJSON(string json)
        {
            AirTest? data = JsonSerializer.Deserialize<AirTest>(json);

            if (data == null)
            {
                throw new Exception("JSON konnte nicht gelesen werden.");
            }

            AirDensity = data.AirDensity;
            AirQuality = data.AirQuality;
            Co2Level = data.Co2Level;
            FineDust = data.FineDust;
            Humidity = data.Humidity;
        }

        public override string SerializeJSON(string jsonfile)
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }

        public string GetQualityStatus()
        {
            if (AirQuality >= 80 && Co2Level <= 1000 && FineDust <= 25)
                return "Gut";

            if (AirQuality >= 50 && Co2Level <= 2000 && FineDust <= 50)
                return "Mittel";

            return "Schlecht";
        }
    }
}
