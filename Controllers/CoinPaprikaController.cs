using CodeCrunch.Services.CoinPaprika;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCrunch.Controllers
{
    [Route("crypto")]
    [ApiController]
    public class CoinPaprikaController : ControllerBase
    {
        private readonly ICoinPaprikaService _coinPaprikaService;

        public CoinPaprikaController(ICoinPaprikaService coinPaprikaService)
        {
            _coinPaprikaService = coinPaprikaService;
        }
        [HttpGet("coins")]
        public async Task<IActionResult> GetAllCoins()
       {
            try
            {
                var coins = await _coinPaprikaService.GetAllCoins();
                var response = coins.Select(coin => new
                {
                    id = coin.id,
                    name = coin.name,
                    symbol = coin.symbol,
                    type = coin.type
                });
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "coin/token not found"
                });
            }
            
        }
        [HttpGet("tokens")]
        public async Task<IActionResult> GetAllTokenType()
        {
            try
            {
                var coins = await _coinPaprikaService.GetAllCoins();
                var response = coins.Where(coin => coin.type is "token").Select(coin => new
                {
                    id = coin.id,
                    name = coin.name,
                    symbol = coin.symbol,
                    type = coin.type
                });
                return Ok(response);
            }
            catch (Exception)
            {

                return NotFound(new
                {
                    status = 404,
                    message = "coin/token not found"
                });
            }
            
        }
        [HttpGet("quote/{name}")]
        public async Task<IActionResult> GetCoinTickerPrice(string name)
        {
            try
            {
                var tickers = await _coinPaprikaService.GetTickerDetails();
                var tickerByName = tickers.Where(ticker => ticker.name == name).FirstOrDefault();
                var response = new
                {
                    id = tickerByName.id,
                    name = tickerByName.name,
                    symbol = tickerByName.symbol,
                    rank = tickerByName.rank,
                    circulating_supply = tickerByName.circulating_supply,
                    total_supply = tickerByName.total_supply,
                    max_supply = tickerByName.max_supply,
                    USD_price = tickerByName.quotes.USD.price
                };
                return Ok(response);
            }
            catch (Exception)
            {
                return NotFound(new
                {
                    status = 404,
                    message = "coin/token not found"
                });
            }
            
        }
        [HttpGet("team/{name}")]
        public async Task<IActionResult> GetFounderAndTeam(string name)
        {          
            return Ok();
        }
    }
}
