using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms.PlatformConfiguration;

namespace WeatherApp
{
    public class WeatherData
    {
        [JsonProperty("name")]
        public string Title { get; set; }

        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        public string Temp => $"{Math.Round(Main.Temperature, 1)}\u00b0F | {Main.TempC()}\u00b0C";

        public string Breeziness => $"{Wind.Speed} mph";

        public string perceivedTemp => $"Feels like {Main.WindChillTemp}\u00b0F";

        private string src => $"https://openweathermap.org/img/w/"+ Weather[0].WeatherIcon +".png";
        public System.Uri icon => new System.Uri(src);

        public string Summary => $"{perceivedTemp}. {char.ToUpper(Weather[0].WeatherDescription[0])+ Weather[0].WeatherDescription.Substring(1)}.";
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("feels_like")]
        public long WindChillTemp { get; set; }

        public double TempC() {return convertFtoC(Temperature);}

        private double convertFtoC(double temp)
        {
            return Math.Round(((temp - 32) * ((double)5 / 9)), 1);
        }
    }

    public class Weather
    {
        [JsonProperty("main")]
        public string Visibility { get; set; }

        [JsonProperty("description")]
        public string WeatherDescription { get; set; }

        [JsonProperty("icon")]
        public string WeatherIcon { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        public string BeaufortScale()
        {
            //source: https://www.weather.gov/bgm/forecast_terms
            string descriptor;

            //speed in mph
            if (Speed == 0) { descriptor = "No Breeze"; }
            else if (Speed <= 7) { descriptor = "Light Breeze"; }
            else if (Speed <= 12) { descriptor = "Gentle Breeze"; }
            else if (Speed <= 18) { descriptor = "Moderate Breeze"; }
            else if (Speed <= 31) { descriptor = "Windy"; }
            else if (Speed > 73) { descriptor = "Hurricane Force Winds";}
            else { descriptor = $"{Speed}mph Winds"; }

            return descriptor;
        }
    }

    public class Message
    {
        private Main m = new Main();
        public string TempMsg => m.Temperature + "\u00b0F";
    }   
}