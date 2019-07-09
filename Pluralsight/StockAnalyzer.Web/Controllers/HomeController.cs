using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using StockAnalyzer.Core;
using StockAnalyzer.Core.Domain;

namespace StockAnalyzer.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [Route("Stock/{ticker}")]
        public async Task<ActionResult> Stock(string ticker)
        {
            DataStore store = new DataStore();

            Dictionary<string, IEnumerable<StockPrice>> data = await store.LoadStocks().ConfigureAwait(false);

            return !data.ContainsKey(ticker) ? null : View(data[ticker]);
        }
    }
}
