using System.Collections.Generic;
using KooliProjekt.Data;
using KooliProjekt.Data.Repositories;
using KooliProjekt.Services;
using System.Net.Http.Json;

namespace KooliProjekt.Services
{
    public class WeatherService
    {
        private readonly IWeatherClient _weatherClient;
        public WeatherService(IWeatherClient weatherClient)
        {
            _weatherClient = weatherClient;
        }
        private readonly string APIKEY = "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m";
        public async Task<decimal?> GetCurrentTemperature()
        {
            try
            {
                var data = await _weatherClient.GetData();

                if (data == null)
                {
                    return null;
                }

                if (data.Current == null)
                {
                    return null;
                }

                if (data.Current.temperature_2m >= 60 || data.Current.temperature_2m <= -70)
                {
                    return null;
                }
                return data.Current.temperature_2m;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
    public class OpenMeteoClient : IWeatherClient
    {
        public async Task<WeatherForecast> GetData()
        {
            var client = new HttpClient();
            var data = await client.GetFromJsonAsync<WeatherForecast>("https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&current=temperature_2m,wind_speed_10m&hourly=temperature_2m,relative_humidity_2m,wind_speed_10m");

            return data;
        }
    }
}
