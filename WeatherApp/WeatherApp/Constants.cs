using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WeatherApp
{
    public class Constants
    {
        public const string OpenWeatherMapEndpoint = "https://api.openweathermap.org/data/2.5/weather";
        public static string OpenWeatherMapAPIKey = "Put your API Key";// API Key stored and read in from key/value pair when productionalized. Add in your own API key to test
    }
}
