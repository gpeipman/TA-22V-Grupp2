using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IWeatherClient
    {
        Task<WeatherForecast> GetData();
    }
}
