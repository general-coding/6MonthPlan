using Newtonsoft.Json;
using StockAnalyzer.Core.Domain;
using StockAnalyzer.Windows.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace StockAnalyzer.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region using web to load data

        //private async void Search_Click(object sender, RoutedEventArgs e)
        //{
        //    #region Before loading stock data
        //    var watch = new Stopwatch();
        //    watch.Start();
        //    StockProgress.Visibility = Visibility.Visible;
        //    StockProgress.IsIndeterminate = true;
        //    #endregion

        //    #region using web to load data

        //    //using (HttpClient client = new HttpClient())
        //    //{
        //    //    HttpResponseMessage response = await client.GetAsync($"http://localhost:61363/api/stocks/{Ticker.Text}");

        //    //    try
        //    //    {
        //    //        await GetStocks();
        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        Notes.Text += ex.Message;
        //    //    }
        //    //}

        //    #endregion

        //    #region After stock data is loaded
        //    StocksStatus.Text = $"Loaded stocks for {Ticker.Text} in {watch.ElapsedMilliseconds}ms";
        //    StockProgress.Visibility = Visibility.Hidden;
        //    #endregion
        //}

        #endregion

        #region using file system to load data - data loaded on UI thread - not good idea

        //private async void Search_Click(object sender, RoutedEventArgs e)
        //{
        //    #region Before loading stock data
        //    var watch = new Stopwatch();
        //    watch.Start();
        //    StockProgress.Visibility = Visibility.Visible;
        //    StockProgress.IsIndeterminate = true;
        //    #endregion

        //    #region using file system to load data - data loaded on UI thread - not good idea

        //    //Using file system
        //    //Task.Run() will queue the data immediately.
        //    //#region After stock data is loaded is running immediately after Task.Run
        //    //There will be issues with the displaying the time taken to load
        //    //Adding the await, queues the data fetch.
        //    //This method will wait for the data fetch to complete. After that it will
        //    //execute #region After stock data is loaded
        //    //await Task.Run(() =>
        //    //{
        //    //    string[] lines = File.ReadAllLines(@"C:\Code\StockData\StockPrices_Small.csv");

        //    //    List<StockPrice> data = new List<StockPrice>();

        //    //    foreach (string line in lines.Skip(1))
        //    //    {
        //    //        string[] segments = line.Split(',');

        //    //        for (int i = 0; i < segments.Length; i++) segments[i] = segments[i].Trim('\'', '"');
        //    //        var price = new StockPrice
        //    //        {
        //    //            Ticker = segments[0],
        //    //            TradeDate = DateTime.ParseExact(segments[1], "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
        //    //            Volume = Convert.ToInt32(segments[6]),
        //    //            Change = Convert.ToDecimal(segments[7]),
        //    //            ChangePercent = Convert.ToDecimal(segments[8]),
        //    //        };
        //    //        data.Add(price);
        //    //    }

        //    //    //Move the execution to the UI thread
        //    //    Dispatcher.Invoke(() =>
        //    //    {
        //    //        Stocks.ItemsSource = data.Where(price => price.Ticker == Ticker.Text);
        //    //    });
        //    //});

        //    #endregion

        //    #region After stock data is loaded
        //    StocksStatus.Text = $"Loaded stocks for {Ticker.Text} in {watch.ElapsedMilliseconds}ms";
        //    StockProgress.Visibility = Visibility.Hidden;
        //    #endregion
        //}

        #endregion

        #region using file system to load data, without async, but with Task and ContinueWith to make it async

        //private void Search_Click(object sender, RoutedEventArgs e)
        //{
        //    #region Before loading stock data
        //    var watch = new Stopwatch();
        //    watch.Start();
        //    StockProgress.Visibility = Visibility.Visible;
        //    StockProgress.IsIndeterminate = true;
        //    #endregion

        //    #region using file system to load data - data loaded on UI thread - not good idea

        //    Task<string[]> loadLinesTask = Task.Run(() =>
        //    {
        //        string[] lines = File.ReadAllLines(@"C:\Code\StockData\StockPrices_Small.csv");

        //        return lines;
        //    });

        //    //Waits for the loadLinesTask to complete execution
        //    //Then it loads data
        //    Task processStocksTask = loadLinesTask.ContinueWith(t =>
        //    {
        //        string[] lines = t.Result;

        //        List<StockPrice> data = new List<StockPrice>();

        //        foreach (string line in lines.Skip(1))
        //        {
        //            string[] segments = line.Split(',');

        //            for (int i = 0; i < segments.Length; i++) segments[i] = segments[i].Trim('\'', '"');
        //            var price = new StockPrice
        //            {
        //                Ticker = segments[0],
        //                TradeDate = DateTime.ParseExact(segments[1], "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
        //                Volume = Convert.ToInt32(segments[6]),
        //                Change = Convert.ToDecimal(segments[7]),
        //                ChangePercent = Convert.ToDecimal(segments[8]),
        //            };
        //            data.Add(price);
        //        }

        //        //Once the data is loaded, transfer control to UI thread to display
        //        Dispatcher.Invoke(() =>
        //        {
        //            Stocks.ItemsSource = data.Where(price => price.Ticker == Ticker.Text);
        //        });
        //    }
        //        , TaskContinuationOptions.OnlyOnRanToCompletion);

        //    //Executes and shows exception to user when processStocksTask fails
        //    loadLinesTask.ContinueWith(t =>
        //    {
        //        Dispatcher.Invoke(() =>
        //        {
        //            Notes.Text = t.Exception.InnerException.Message;
        //        });
        //    }
        //        , TaskContinuationOptions.OnlyOnFaulted);

        //    //Notify user of time taken only after data is completely loaded
        //    processStocksTask.ContinueWith(_ =>
        //    {
        //        Dispatcher.Invoke(() =>
        //        {
        //            #region After stock data is loaded
        //            StocksStatus.Text = $"Loaded stocks for {Ticker.Text} in {watch.ElapsedMilliseconds}ms";
        //            StockProgress.Visibility = Visibility.Hidden;
        //            #endregion
        //        });
        //    });

        //    #endregion
        //}

        #endregion

        #region using cancellation on failure

        //CancellationTokenSource cancellationTokenSource = null;

        //private void Search_Click(object sender, RoutedEventArgs e)
        //{
        //    #region Before loading stock data
        //    var watch = new Stopwatch();
        //    watch.Start();
        //    StockProgress.Visibility = Visibility.Visible;
        //    StockProgress.IsIndeterminate = true;
        //    #endregion

        //    #region cancellations

        //    if (cancellationTokenSource != null)
        //    {
        //        cancellationTokenSource.Cancel();
        //        cancellationTokenSource = null;
        //        return;
        //    }

        //    cancellationTokenSource = new CancellationTokenSource();

        //    cancellationTokenSource.Token.Register(() =>
        //    {
        //        Notes.Text = "Cancellation requested.";
        //    });

        //    var loadLinesTask = SearchForStocks(cancellationTokenSource.Token);

        //    //Waits for the loadLinesTask to complete execution with success and not cancelled
        //    //Then it loads data
        //    Task processStocksTask = loadLinesTask.ContinueWith(t =>
        //    {
        //        List<string> lines = t.Result;

        //        List<StockPrice> data = new List<StockPrice>();

        //        foreach (string line in lines.Skip(1))
        //        {
        //            string[] segments = line.Split(',');

        //            for (int i = 0; i < segments.Length; i++) segments[i] = segments[i].Trim('\'', '"');
        //            var price = new StockPrice
        //            {
        //                Ticker = segments[0],
        //                TradeDate = DateTime.ParseExact(segments[1], "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
        //                Volume = Convert.ToInt32(segments[6]),
        //                Change = Convert.ToDecimal(segments[7]),
        //                ChangePercent = Convert.ToDecimal(segments[8]),
        //            };
        //            data.Add(price);
        //        }

        //        //Once the data is loaded, transfer control to UI thread to display
        //        Dispatcher.Invoke(() =>
        //        {
        //            Stocks.ItemsSource = data.Where(price => price.Ticker == Ticker.Text);
        //        });
        //    }
        //        , cancellationTokenSource.Token
        //        , TaskContinuationOptions.OnlyOnRanToCompletion
        //        , TaskScheduler.Current);

        //    //Executes and shows exception to user when processStocksTask fails
        //    loadLinesTask.ContinueWith(t =>
        //    {
        //        Dispatcher.Invoke(() =>
        //        {
        //            Notes.Text = t.Exception.InnerException.Message;
        //        });
        //    }
        //        , TaskContinuationOptions.OnlyOnFaulted);

        //    //Notify user of time taken only after data is completely loaded
        //    processStocksTask.ContinueWith(_ =>
        //    {
        //        Dispatcher.Invoke(() =>
        //        {
        //            #region After stock data is loaded
        //            StocksStatus.Text = $"Loaded stocks for {Ticker.Text} in {watch.ElapsedMilliseconds}ms";
        //            StockProgress.Visibility = Visibility.Hidden;
        //            #endregion
        //        });
        //    });

        //    #endregion
        //}

        #endregion

        #region using web api and cancellation

        CancellationTokenSource cancellationTokenSource = null;

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            #region Before loading stock data
            var watch = new Stopwatch();
            watch.Start();
            StockProgress.Visibility = Visibility.Visible;
            StockProgress.IsIndeterminate = true;

            Search.Content = "Cancel";
            #endregion

            #region cancellations

            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.Token.Register(() =>
            {
                Notes.Text = "Cancellation requested.";
            });

            #endregion

            try
            {
                string[] tickers = Ticker.Text.Split(',', ' ');

                StockService stockService = new StockService();

                List<Task<IEnumerable<StockPrice>>> tickerLoadingTasks = new List<Task<IEnumerable<StockPrice>>>();

                foreach (string ticker in tickers)
                {
                    Task<IEnumerable<StockPrice>> loadTask = stockService.GetStockPricesFor(ticker
                                                        , cancellationTokenSource.Token);
                    tickerLoadingTasks.Add(loadTask);
                }

                //Wait for all the stock prices to be listed
                IEnumerable<StockPrice>[] allStocks = await Task.WhenAll(tickerLoadingTasks);

                Stocks.ItemsSource = allStocks.SelectMany(stocks => stocks);
            }
            catch (Exception ex)
            {
                Notes.Text = ex.Message;
            }

            #region After stock data is loaded
            StocksStatus.Text = $"Loaded stocks for {Ticker.Text} in {watch.ElapsedMilliseconds}ms";
            StockProgress.Visibility = Visibility.Hidden;
            #endregion
        }

        #endregion

        private Task<List<string>> SearchForStocks(CancellationToken cancellationToken)
        {
            Task<List<string>> loadLinesTask = Task.Run(async () =>
            {
                List<string> lines = new List<string>();

                using (StreamReader stream = new StreamReader(File.OpenRead(@"C:\Code\StockData\StockPrices_Small.csv")))
                {
                    string line;

                    while ((line = await stream.ReadLineAsync()) != null)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            lines.Add(line);
                        }
                    }
                }

                return lines;
            }
                , cancellationToken);

            return loadLinesTask;
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));

            e.Handled = true;
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public async Task GetStocks()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"http://localhost:61363/api/stocks/{Ticker.Text}");

                try
                {
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<IEnumerable<StockPrice>>(content);

                    Stocks.ItemsSource = data;
                }
                catch (Exception ex)
                {
                    Notes.Text += ex.Message;
                }
            }
        }
    }
}
