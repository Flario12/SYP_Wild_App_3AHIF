using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using WildApp.Data;

namespace WildApp.Domain
{
    class Controllers
    {
        public string databasePath { get; } = "";

        public void ManageApp()
        {

        }

        public void Save(string database)
        {

        }
        
        public void Load(string database)
        {

        }

        public async Task<(double temp, double wind)> UpdateWeather(double lat, double lon)
        {
            WeatherService service = new WeatherService();
            await service.LoadFromAPI(lat, lon);

            return (service.GetTemperature(), service.GetWind());
        }
    }
}
