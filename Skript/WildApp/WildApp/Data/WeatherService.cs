using System;
using System.Collections.Generic;
using System.Text;

namespace WildApp.Data
{
    class WeatherService
    {
        private double temperature = 0;
        private double wind = 0;

        public void LoadFromAPI()
        {
            // TODO: Implementierens
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
