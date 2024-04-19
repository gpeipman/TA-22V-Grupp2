using KooliProjekt.Data;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public interface IWeatherClient
    {
        Task<WeatherForecast> GetData();
    }
}
