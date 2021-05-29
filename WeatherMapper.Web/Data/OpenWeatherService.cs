using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WeatherMapper.Web.Data
{
    public class OpenWeatherService : IWeatherService
    {
        private readonly IConfiguration Configuration;

        HttpClient HttpClient;
        string ApiKey;
        public OpenWeatherService(IConfiguration configuration)
        {
            Configuration = configuration;
            ApiKey = Configuration["OpenWeatherApiKey"];
            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri($"https://api.openweathermap.org/data/2.5/weather?units=metric")
            };
        }
        public async Task<WeatherItem> GetWeatherItemAsync(double lat, double lng)
        {
            // https://api.openweathermap.org/data/2.5/weather?units=metric&lat={lat}&lon={lon}&appid={apiKey}")
            var result = await HttpClient.GetFromJsonAsync<WeatherItem>(HttpClient.BaseAddress + $"&lat={lat}&lon={lng}&appid={ApiKey}");
            return result;
        }
    }
}
