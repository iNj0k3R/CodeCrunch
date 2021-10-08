using CodeCrunch.Contracts.OpenWeather;

namespace CodeCrunch.Services.OpenWeather
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IHttpClientFactory _clientFactory;

        public readonly string API_KEY;

        public OpenWeatherService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            API_KEY = configuration["OpenWeather:API_KEY"];
        }
        
        public Task<CurrentWeatherData> GetCurrentWeatherAsync(string city)
        {
            return _clientFactory.CreateClient().GetFromJsonAsync<CurrentWeatherData>($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={API_KEY}&units=metric");
        }
        public Task<CurrentWeatherData> GetCurrentWeatherByLocationAsync(string latitude, string longitude, string pincode)
        {
            if(latitude  == "" && longitude == "")
            {
                return _clientFactory.CreateClient().GetFromJsonAsync<CurrentWeatherData>($"https://api.openweathermap.org/data/2.5/weather?zip={pincode},IN&appid={API_KEY}&units=metric");
            }
            else
            {
                return _clientFactory.CreateClient().GetFromJsonAsync<CurrentWeatherData>($"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={API_KEY}&units=metric");
            }
        }
    }
}
