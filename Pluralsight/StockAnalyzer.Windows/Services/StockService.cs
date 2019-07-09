﻿using Newtonsoft.Json;
using StockAnalyzer.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace StockAnalyzer.Windows.Services
{
    public interface IStockService
    {
        Task<IEnumerable<StockPrice>> GetStockPricesFor(string ticker,
            CancellationToken cancellationToken);
    }

    public class StockService
    {
        public async Task<IEnumerable<StockPrice>> GetStockPricesFor(string ticker
            , CancellationToken cancellationToken)
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync($"http://localhost:61363/api/stocks/{ticker}"
                            , cancellationToken);

                result.EnsureSuccessStatusCode();

                var content = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<IEnumerable<StockPrice>>(content);
            }
        }
    }

    public class MockStockService : IStockService
    {
        public Task<IEnumerable<StockPrice>> GetStockPricesFor(string ticker,
            CancellationToken cancellationToken)
        {
            var stocks = new List<StockPrice> {
                new StockPrice { Ticker = "MSFT", Change = 0.5m, ChangePercent = 0.75m },
                new StockPrice { Ticker = "MSFT", Change = 0.2m, ChangePercent = 0.15m },
                new StockPrice { Ticker = "GOOGL", Change = 0.3m, ChangePercent = 0.25m },
                new StockPrice { Ticker = "GOOGL", Change = 0.5m, ChangePercent = 0.65m }
            };

            return Task.FromResult(stocks.Where(stock => stock.Ticker == ticker));
        }
    }
}
