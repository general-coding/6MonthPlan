﻿using Newtonsoft.Json;
using StockAnalyzer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
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

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            #region Before loading stock data
            var watch = new Stopwatch();
            watch.Start();
            StockProgress.Visibility = Visibility.Visible;
            StockProgress.IsIndeterminate = true;
            #endregion

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"http://localhost:61363/api/stocks/{Ticker.Text}");

                try
                {
                    await GetStocks();
                }
                catch (Exception ex)
                {
                    Notes.Text += ex.Message;
                }
            }

            #region After stock data is loaded
            StocksStatus.Text = $"Loaded stocks for {Ticker.Text} in {watch.ElapsedMilliseconds}ms";
            StockProgress.Visibility = Visibility.Hidden;
            #endregion
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