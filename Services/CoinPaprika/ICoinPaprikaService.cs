using CodeCrunch.Contracts.CoinPaprika;

namespace CodeCrunch.Services.CoinPaprika
{
    public interface ICoinPaprikaService
    {
        Task<CoinDetails> GetCoinDetails(string coinId);
        Task<CoinDetails[]> GetAllCoins();
        Task<CoinTickerDetails[]> GetTickerDetails();
        Task<PersonDetails> GetPersonDetails(string personId);
    }
}
