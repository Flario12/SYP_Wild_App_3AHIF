using System;
using System.Text.Json;

namespace WildApp.Data
{
    public class WaterTest : TestBasis
    {
        public double WaterQuality { get; set; }
        public double Temperature { get; set; }
        public double Conductivity { get; set; }
        public double OxygenLevel { get; set; }
        public double PhValue { get; set; }

        public override void DeserializeJSON(string json)
        {
            // TODO: Implementieren
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
            if (WaterQuality >= 80)
                return "Gut";

            if (WaterQuality >= 50)
                return "Mittel";

            return "Schlecht";
        }
    }
}