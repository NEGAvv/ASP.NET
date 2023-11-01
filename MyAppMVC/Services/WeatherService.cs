using Microsoft.Extensions.Configuration;
using MyAppMVC.Models;

namespace MyAppMVC.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;

        public WeatherService (HttpClient httpClient,IConfiguration configuration )
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<WeatherData> GetWeatherAsync(double latitude, double longitude)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={_configuration.GetSection("ApiKey").Value}");
                await Console.Out.WriteLineAsync($"data : {response}");
                if (response.IsSuccessStatusCode)
                {
                    var weatherData = await response.Content.ReadFromJsonAsync<WeatherData>();
                    return weatherData;
                }
                throw new HttpRequestException();
            }
            catch (HttpRequestException)
            {
                throw new HttpRequestException();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
    }

