using System.Diagnostics;
using KooliProjekt.Controllers;
using KooliProjekt.Data;
using KooliProjekt.Models;
using KooliProjekt.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Moq;
using Xunit;

namespace KooliProjekt.UnitTests.ServiceTests
{
    public class WeatherServiceTests
    {
        private readonly Mock<IWeatherClient> _weatherClient;
        private readonly WeatherService _weatherService;

        public WeatherServiceTests()
        {
            _weatherClient = new Mock<IWeatherClient>();
            _weatherService = new WeatherService(_weatherClient.Object
                                );
        }

        [Fact]
        public async Task GetCurrentTemperature_should_return_null_if_HttpRequestException_occurs()
        {
            // Arrange
            _weatherClient.Setup(r => r.GetData())
                    .ThrowsAsync(new HttpRequestException());

            // Act
            var result = await _weatherService.GetCurrentTemperature();

            // Asserts
            Assert.Null(result);

        }
        [Fact]
        public async Task GetCurrentTemperature_should_return_null_if_data_is_null()
        {
            // Arrange
            WeatherForecast data = null;
            _weatherClient.Setup(r => r.GetData())
                    .ReturnsAsync(data);

            // Act
            var result = await _weatherService.GetCurrentTemperature();

            // Assert
            Assert.Null(result);

        }
        [Fact]
        public async Task GetCurrentTemperature_should_return_null_if_Current_data_is_null()
        {
            // Arrange
            WeatherForecast data = new WeatherForecast();
            data.Current = null;
            _weatherClient.Setup(r => r.GetData())
                    .ReturnsAsync(data);

            // Act
            var result = await _weatherService.GetCurrentTemperature();

            // Assert
            Assert.Null(result);

        }
        [Fact]
        public async Task GetCurrentTemperature_should_return_null_if_data_is_too_small()
        {
            // Arrange
            WeatherForecast data = new WeatherForecast();

            _weatherClient.Setup(r => r.GetData())
                    .ReturnsAsync(data);
            data.Current = new WeatherForecast.WeatherX { temperature_2m = -71 };
            // Act
            var result = await _weatherService.GetCurrentTemperature();

            // Assert
            Assert.Null(result);

        }
        [Fact]
        public async Task GetCurrentTemperature_should_return_null_if_data_is_too_big()
        {
            // Arrange
            WeatherForecast data = new WeatherForecast();

            _weatherClient.Setup(r => r.GetData())
                    .ReturnsAsync(data);
            data.Current = new WeatherForecast.WeatherX { temperature_2m = 60 };
            // Act
            var result = await _weatherService.GetCurrentTemperature();

            // Assert
            Assert.Null(result);

        }
        [Fact]
        public async Task GetCurrentTemperature_should_return_temperature_if_data_is_too_small()
        {
            // Arrange
            WeatherForecast data = new WeatherForecast();

            _weatherClient.Setup(r => r.GetData())
                    .ReturnsAsync(data);
            data.Current = new WeatherForecast.WeatherX { temperature_2m = 10 };
            // Act
            var result = await _weatherService.GetCurrentTemperature();

            // Assert
            Assert.Equal(data.Current.temperature_2m, result.Value);

        }
    }
}
