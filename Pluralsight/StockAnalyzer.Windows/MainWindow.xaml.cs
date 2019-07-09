using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Newtonsoft.Json;
using StockAnalyzer.Core.Domain;
using StockAnalyzer.Windows.Services;

namespace StockAnalyzer.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public async Task Run()
        {
            await RunInternal(async () =>
            {
                await Task.Delay(200);
            });
        }

        public async Task RunInternal(Action action)
        {
            await Task.Delay(100).ContinueWith(_ => action());
        }

        CancellationTokenSource cancellationTokenSource = null;

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            #region Before loading stock data
            Stopwatch watch = new Stopwatch();
            watch.Start();
            StockProgress.Visibility = Visibility.Visible;

            Search.Content = "Cancel";
            #endregion

            #region Cancellation
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                cancellationTokenSource = null;
                return;
            }

            cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.Token.Register(() =>
            {
                Notes.Text += "Cancellation requested" + Environment.NewLine;
            });
            #endregion

            try
            {
                await WorkInNotepad();

                Notes.Text += "Notepad closed, continuation!";
            }
            catch (Exception ex)
            {
                Notes.Text += ex.Message + Environment.NewLine;
            }
            finally
            {
                cancellationTokenSource = null;
            }

            #region After stock data is loaded
            StocksStatus.Text = $"Loaded stocks for {Ticker.Text} in {watch.ElapsedMilliseconds}ms";
            StockProgress.Visibility = Visibility.Hidden;
            Search.Content = "Search";
            #endregion
        }

        private Task<IEnumerable<StockPrice>> GetStocksFor(string ticker)
        {
            TaskCompletionSource<IEnumerable<StockPrice>> source = new TaskCompletionSource<IEnumerable<StockPrice>>();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    List<StockPrice> prices = new List<StockPrice>();

                    string[] lines = File.ReadAllLines(@"C:\Code\StockData\StockPrices_Small.csv");

                    foreach (string line in lines.Skip(1))
                    {
                        string[] segments = line.Split(',');

                        for (int i = 0; i < segments.Length; i++)
                        {
                            segments[i] = segments[i].Trim('\'', '"');
                            StockPrice price = new StockPrice
                            {
                                Ticker = segments[0],
                                TradeDate = DateTime.ParseExact(segments[1], "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                Volume = Convert.ToInt32(segments[6]),
                                Change = Convert.ToDecimal(segments[7]),
                                ChangePercent = Convert.ToDecimal(segments[8]),
                            };
                            prices.Add(price);
                        }
                    }

                    source.SetResult(prices.Where(price => price.Ticker == ticker));
                }
                catch (Exception ex)
                {
                    source.SetException(ex);
                }
            });

            return source.Task;
        }

        public Task WorkInNotepad()
        {
            TaskCompletionSource<object> source = new TaskCompletionSource<object>();
            Process process = new Process
            {
                EnableRaisingEvents = true,
                StartInfo = new ProcessStartInfo("Notepad.exe")
                {
                    RedirectStandardError = true,
                    UseShellExecute = false
                }
            };

            process.Exited += (sender, e) =>
            {
                source.SetResult(null);
            };

            process.Start();
            return source.Task;
        }

        Random random = new Random();

        private decimal CalculateExpensiveComputation(IEnumerable<StockPrice> stocks)
        {
            Thread.Yield();

            decimal computedValue = 0m;

            foreach (StockPrice stock in stocks)
            {
                for (int i = 0; i < stocks.Count() - 2; i++)
                {
                    for (int a = 0; a < random.Next(50, 60); a++)
                    {
                        computedValue += stocks.ElementAt(i).Change + stocks.ElementAt(i + 1).Change;
                    }
                }
            }

            return computedValue;
        }

        #region Progress Reporting

        //private async void Search_Click(object sender, RoutedEventArgs e)
        //{
        //    #region Before loading stock data
        //    Stopwatch watch = new Stopwatch();
        //    watch.Start();
        //    StockProgress.Visibility = Visibility.Visible;

        //    Search.Content = "Cancel";
        //    #endregion

        //    #region Cancellation
        //    if (cancellationTokenSource != null)
        //    {
        //        cancellationTokenSource.Cancel();
        //        cancellationTokenSource = null;
        //        return;
        //    }

        //    cancellationTokenSource = new CancellationTokenSource();
        //    cancellationTokenSource.Token.Register(() =>
        //    {
        //        Notes.Text += "Cancellation requested" + Environment.NewLine;
        //    });
        //    #endregion

        //    try
        //    {
        //        StockProgress.IsIndeterminate = false;
        //        StockProgress.Value = 0;
        //        StockProgress.Maximum = Ticker.Text.Split(',', ' ').Count();

        //        Progress<IEnumerable<StockPrice>> progress = new Progress<IEnumerable<StockPrice>>();
        //        progress.ProgressChanged += (_, stocks) =>
        //        {
        //            StockProgress.Value += 1;
        //            Notes.Text += $"Loaded {stocks.Count()} for {stocks.First().Ticker} " +
        //            $"{Environment.NewLine}";
        //        };

        //        await LoadStocks(progress);
        //    }
        //    catch (Exception ex)
        //    {
        //        Notes.Text += ex.Message + Environment.NewLine;
        //    }
        //    finally
        //    {
        //        cancellationTokenSource = null;
        //    }

        //    #region After stock data is loaded
        //    StocksStatus.Text = $"Loaded stocks for {Ticker.Text} in {watch.ElapsedMilliseconds}ms";
        //    StockProgress.Visibility = Visibility.Hidden;
        //    Search.Content = "Search";
        //    #endregion
        //}

        //private async Task LoadStocks(IProgress<IEnumerable<StockPrice>> progress = null)
        //{
        //    string[] tickers = Ticker.Text.Split(',', ' ');

        //    StockService service = new StockService();

        //    List<Task<IEnumerable<StockPrice>>> tickerLoadingTasks = new List<Task<IEnumerable<StockPrice>>>();

        //    foreach (string ticker in tickers)
        //    {
        //        Task<IEnumerable<StockPrice>> loadTask = service.GetStockPricesFor(ticker, cancellationTokenSource.Token);

        //        loadTask = loadTask.ContinueWith(stockTask =>
        //        {
        //            progress?.Report(stockTask.Result);
        //            return stockTask.Result;
        //        });

        //        tickerLoadingTasks.Add(loadTask);
        //    }

        //    IEnumerable<StockPrice>[] allStocks = await Task.WhenAll(tickerLoadingTasks);

        //    Stocks.ItemsSource = allStocks.SelectMany(stocks => stocks);
        //}

        #endregion

        #region Deadlock hack

        //private async void Search_Click(object sender, RoutedEventArgs e)
        //{
        //    #region Before loading stock data
        //    Stopwatch watch = new Stopwatch();
        //    watch.Start();
        //    StockProgress.Visibility = Visibility.Visible;

        //    Search.Content = "Cancel";
        //    #endregion

        //    #region Cancellation
        //    if (cancellationTokenSource != null)
        //    {
        //        cancellationTokenSource.Cancel();
        //        cancellationTokenSource = null;
        //        return;
        //    }

        //    cancellationTokenSource = new CancellationTokenSource();
        //    cancellationTokenSource.Token.Register(() =>
        //    {
        //        Notes.Text += "Cancellation requested" + Environment.NewLine;
        //    });
        //    #endregion

        //    try
        //    {
        //        Task.Run(() => LoadStocks()).Wait();
        //    }
        //    catch (Exception ex)
        //    {
        //        Notes.Text += ex.Message + Environment.NewLine;
        //    }
        //    finally
        //    {
        //        cancellationTokenSource = null;
        //    }

        //    #region After stock data is loaded
        //    StocksStatus.Text = $"Loaded stocks for {Ticker.Text} in {watch.ElapsedMilliseconds}ms";
        //    StockProgress.Visibility = Visibility.Hidden;
        //    Search.Content = "Search";
        //    #endregion

        //}

        //private async Task LoadStocks()
        //{
        //    string[] tickers = Ticker.Text.Split(',', ' ');

        //    StockService service = new StockService();

        //    List<Task<IEnumerable<StockPrice>>> tickerLoadingTasks = new List<Task<IEnumerable<StockPrice>>>();

        //    foreach (string ticker in tickers)
        //    {
        //        Task<IEnumerable<StockPrice>> loadTask = service.GetStockPricesFor(ticker, cancellationTokenSource.Token);

        //        tickerLoadingTasks.Add(loadTask);
        //    }

        //    IEnumerable<StockPrice>[] allStocks = await Task.WhenAll(tickerLoadingTasks);

        //    Stocks.ItemsSource = allStocks.SelectMany(stocks => stocks);
        //}

        #endregion

        private Task<List<string>> SearchForStocks(CancellationToken cancellationToken)
        {
            Task<List<string>> loadLinesTask = Task.Run(async () =>
            {
                List<string> lines = new List<string>();

                using (StreamReader stream = new StreamReader(File.OpenRead(@"C:\Code\StockData\StockPrices_small.csv")))
                {
                    string line;
                    while ((line = await stream.ReadLineAsync()) != null)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            return lines;
                        }
                        lines.Add(line);
                    }
                }

                return lines;
            }, cancellationToken);

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
    }
}
