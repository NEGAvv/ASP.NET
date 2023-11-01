﻿using MyAppMVC.Models;

namespace MyAppMVC.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherAsync(double latitude, double longitude);
    }
}
