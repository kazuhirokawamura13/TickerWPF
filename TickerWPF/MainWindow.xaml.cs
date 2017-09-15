using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using MahApps.Metro.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TickerWPF.Models;
using TickerWPF.Converter;

namespace TickerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public TickerConfiguration _config;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Equity> _equity;
        public ObservableCollection<Equity> Equity
        {
            get { return _equity; }
            set
            {
                if (_equity == value)
                {
                    return;
                }
                _equity = value;
                OnPropertyChanged(nameof(Equity));
            }
        }



        public MainWindow()
        {
            _equity = new ObservableCollection<Equity>();

            _equity.Add(new Equity
            {
                Name = "Test",
                Exchange = "TestExchange",
                Price = new Price
                {
                    Last = 100.00M,
                    Open = 90.00M
                },
                Title = "Ticker App"
            });

            _config = new TickerConfiguration();

            InitializeComponent();
            DataContext = this;
            Initialize();
        }

        private void Initialize()
        {
            var dueTime = TimeSpan.FromSeconds(1);
            var interval = TimeSpan.FromSeconds(_config.TickerInterval);

            Task task = RunPeriodicAsync(OnTick, dueTime, interval, CancellationToken.None);
        }

        private async Task RunPeriodicAsync(Action onTick, TimeSpan dueTime, TimeSpan interval,
            CancellationToken token)
        {
            if (dueTime > TimeSpan.Zero)
            {
                await Task.Delay(dueTime, token);
            }

            while (!token.IsCancellationRequested)
            {
                onTick?.Invoke();

                if (interval > TimeSpan.Zero)
                {
                    await Task.Delay(interval, token);
                }
            }
        }

        private async void OnTick()
        {
            var tickerString = await DownloadTask("https://api.coindesk.com/v1/bpi/currentprice/USD.json");
            var tickerJson = JsonConvert.DeserializeObject<BpiJson>(tickerString);

            var closeString = await DownloadTask("https://api.coindesk.com/v1/bpi/historical/close.json");
            var closeJson = JsonConvert.DeserializeObject<BpiCloseJson>(closeString);

            var equity = new Equity
            {
                Name = "BTC/USD",
                Exchange = "BPI",
                Price = new Price
                {
                    Last = tickerJson.bpi.USD.rate_float
                }
            };

            JObject obj = (JObject) closeJson.bpi;

            foreach (var closePrice in obj)
            {
                if (closePrice.Key == DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"))
                {
                    equity.Price.Open = Convert.ToDecimal(closePrice.Value);
                    equity.Price.PercentChange = CalculatePercentChange(equity.Price.Last, equity.Price.Open);
                }
            }

            equity.Title = $"{equity.Name}| LAST: {equity.Price.Last}";

            _equity.Clear();
            _equity.Add(equity);
        }

        private string CalculatePercentChange(decimal last, decimal open)
        {
            var difference = last - open;

            var percentChange = (difference / open) * 100;

            return $"{percentChange.ToString("0.##")}";
        }

        private async Task<string> DownloadTask(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    return await client.GetStringAsync(url);
                }
            }
            catch (WebException ex)
            {
                throw new WebException(ex.Message);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
