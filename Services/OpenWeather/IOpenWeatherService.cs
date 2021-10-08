using CodeCrunch.Contracts.OpenWeather;

namespace CodeCrunch.Services.OpenWeather
{
    public interface IOpenWeatherService
    {
        Task<CurrentWeatherData> GetCurrentWeatherAsync(string city);
        Task<CurrentWeatherData> GetCurrentWeatherByLocationAsync(string latitude, string longitude, string pincode);
    }
}
