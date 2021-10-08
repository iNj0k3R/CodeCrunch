using CodeCrunch.Contracts.CoinPaprika;

namespace CodeCrunch.Services.CoinPaprika
{
    public class CoinPaprikaService : ICoinPaprikaService
    {
        private readonly IHttpClientFactory _clientFactory;
        public CoinPaprikaService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public Task<CoinDetails[]> GetAllCoins()
        {
            return _clientFactory.CreateClient().GetFromJsonAsync<CoinDetails[]>("https://api.coinpaprika.com/v1/coins");
        }

        public Task<CoinTickerDetails[]> GetTickerDetails()
        {
            return _clientFactory.CreateClient().GetFromJsonAsync<CoinTickerDetails[]>($"https://api.coinpaprika.com/v1/tickers");
        }
        public Task<CoinDetails> GetCoinDetails(string coinId)
        {
            return _clientFactory.CreateClient().GetFromJsonAsync<CoinDetails>($"https://api.coinpaprika.com/v1/coins/{coinId}");
        }

        public Task<PersonDetails> GetPersonDetails(string personId)
        {
            return _clientFactory.CreateClient().GetFromJsonAsync<PersonDetails>($"https://api.coinpaprika.com/v1/people/{personId}");
        }
    }
}
