using System;
using System.Threading.Tasks;
using WildApp.Data;

namespace WildApp.Domain
{
    public class FakeAPI
    {
        public async Task<WaterTest> GetFakeWaterData()
        {
            await Task.Delay(300);

            return new WaterTest
            {
                WaterQuality = 23.5,
                Temperature = 41.2,
                Conductivity = 9999,
                OxygenLevel = 0.8,
                PhValue = 2.1
            };
        }

        public async Task<WaterTest> GetRandomWaterData()
        {
            await Task.Delay(300);

            Random random = new Random();

            return new WaterTest
            {
                WaterQuality = random.Next(0, 101),
                Temperature = Math.Round(random.NextDouble() * 35, 2),
                Conductivity = random.Next(100, 10000),
                OxygenLevel = Math.Round(random.NextDouble() * 15, 2),
                PhValue = Math.Round(random.NextDouble() * 14, 2)
            };
        }

        public async Task<AirTest> GetRandomAirData()
        {
            await Task.Delay(300);

            Random random = new Random();

            return new AirTest
            {
                AirDensity = Math.Round(1.0 + random.NextDouble() * 0.4, 3),
                AirQuality = random.Next(0, 101),
                Co2Level = random.Next(400, 3000),
                FineDust = Math.Round(random.NextDouble() * 90, 2),
                Humidity = Math.Round(20 + random.NextDouble() * 75, 2)
            };
        }
    }
}
