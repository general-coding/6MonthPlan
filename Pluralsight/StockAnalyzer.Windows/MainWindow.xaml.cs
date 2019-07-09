﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
                StockProgress.IsIndeterminate = false;
                StockProgress.Value = 0;
                StockProgress.Maximum = Ticker.Text.Split(',', ' ').Count();

                Progress<IEnumerable<StockPrice>> progress = new Progress<IEnumerable<StockPrice>>();
                progress.ProgressChanged += (_, stocks) =>
                {
                    StockProgress.Value += 1;
                    Notes.Text += $"Loaded {stocks.Count()} for {stocks.First().Ticker}" +
                                    $"{Environment.NewLine}";
                };

                await LoadStocks(progress);
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

        private async Task LoadStocks(IProgress<IEnumerable<StockPrice>> progress = null)
        {
            string[] tickers = Ticker.Text.Split(',', ' ');

            StockService service = new StockService();

            List<Task<IEnumerable<StockPrice>>> tickerLoadingTasks = new List<Task<IEnumerable<StockPrice>>>();

            foreach (string ticker in tickers)
            {
                Task<IEnumerable<StockPrice>> loadTask = service.GetStockPricesFor(ticker, cancellationTokenSource.Token);

                loadTask = loadTask.ContinueWith(stockTask =>
                {
                    progress?.Report(stockTask.Result);

                    return stockTask.Result;
                });

                tickerLoadingTasks.Add(loadTask);
            }
            Task timeoutTask = Task.Delay(2000);

            Task<IEnumerable<StockPrice>[]> allStocksLoadingTask = Task.WhenAll(tickerLoadingTasks);

            Task completedTask = await Task.WhenAny(timeoutTask, allStocksLoadingTask);

            Stocks.ItemsSource = allStocksLoadingTask.Result.SelectMany(stocks => stocks);
        }


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
