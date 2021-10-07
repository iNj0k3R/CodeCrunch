using CodeCrunch.Contracts.NASA;
using System.Globalization;

namespace CodeCrunch.Services.NASA
{
    public class NASAService : INASAService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string API_KEY;
        public NASAService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            API_KEY = configuration["NASA:API_KEY"];
        }
        
        public Task<APOD> GetAPOD(string date)
        {
            return _clientFactory.CreateClient().GetFromJsonAsync<APOD>($"https://api.nasa.gov/planetary/apod?date={date}&api_key={API_KEY}");
        }

        public Task<APOD[]> GetAPODOfMonth(string year, string month)
        {
            DateTime date = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture);
            var firstDayOfMonth = new DateTime(Int32.Parse(year),date.Month,1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            string sDate = year + "-" + date.Month + "-" + firstDayOfMonth.Day;
            string lDate = year + "-" + date.Month + "-" + lastDayOfMonth.Day;
            return _clientFactory.CreateClient().GetFromJsonAsync<APOD[]>($"https://api.nasa.gov/planetary/apod?start_date={sDate}&end_date={lDate}&api_key={API_KEY}");
        }

        public Task<EPIC[]> GetEPIC(string date)
        {
            return _clientFactory.CreateClient().GetFromJsonAsync<EPIC[]>($"https://api.nasa.gov/EPIC/api/natural/date/{date}?api_key={API_KEY}");
        }
    }
}
