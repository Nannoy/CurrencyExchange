using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CurrencyExchangeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeRateController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ExchangeRateController> _logger;

        public ExchangeRateController(HttpClient httpClient, ILogger<ExchangeRateController> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        [HttpGet("rates/{baseCurrency}")]
        public async Task<IActionResult> GetExchangeRates(string baseCurrency)
        {
            try
            {
                var mockRates = new Dictionary<string, decimal>
                {
                    { "USD", 1.0m },
                    { "EUR", 0.85m },
                    { "GBP", 0.75m },
                    { "JPY", 110.0m },
                    { "CAD", 1.25m }
                };

                if (!mockRates.ContainsKey(baseCurrency.ToUpper()))
                {
                    return BadRequest($"Currency {baseCurrency} not supported");
                }

                var result = new
                {
                    BaseCurrency = baseCurrency.ToUpper(),
                    Rates = mockRates.Where(r => r.Key != baseCurrency.ToUpper())
                                   .ToDictionary(r => r.Key, r => r.Value),
                    LastUpdated = DateTime.UtcNow
                };

                _logger.LogInformation($"Exchange rates retrieved for {baseCurrency}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving exchange rates");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("convert")]
        public IActionResult ConvertCurrency([FromBody] ConversionRequest request)
        {
            try
            {
                if (request.Amount <= 0)
                    return BadRequest("Amount must be greater than 0");

                // Mock conversion rates
                var rates = new Dictionary<string, decimal>
                {
                    { "USD", 1.0m },
                    { "EUR", 0.85m },
                    { "GBP", 0.75m }
                };

                if (!rates.ContainsKey(request.FromCurrency) || !rates.ContainsKey(request.ToCurrency))
                    return BadRequest("Currency not supported");

                var fromRate = rates[request.FromCurrency];
                var toRate = rates[request.ToCurrency];
                var convertedAmount = (request.Amount / fromRate) * toRate;

                var result = new
                {
                    OriginalAmount = request.Amount,
                    FromCurrency = request.FromCurrency,
                    ToCurrency = request.ToCurrency,
                    ConvertedAmount = Math.Round(convertedAmount, 2),
                    ExchangeRate = Math.Round(toRate / fromRate, 4),
                    ConversionDate = DateTime.UtcNow
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error converting currency");
                return StatusCode(500, "Internal server error");
            }
        }
    }

    public class ConversionRequest
    {
        public decimal Amount { get; set; }
        public string FromCurrency { get; set; } = string.Empty;
        public string ToCurrency { get; set; } = string.Empty;
    }
}