using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using TickerWPF.Annotations;

namespace TickerWPF.Models
{
    public class Equity : INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get => _name;
            set {
                if (value == _name)
                {
                    return;
                }
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private Price _price;

        public Price Price
        {
            get => _price;
            set {
                if (value == _price)
                {
                    return;
                }
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private string _exchange;

        public string Exchange
        {
            get => _exchange;
            set {
                if (value == _exchange)
                {
                    return;
                }
                _exchange = value;
                OnPropertyChanged(nameof(Exchange));
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set {
                if (value == _title)
                {
                    return;
                }
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Price : INotifyPropertyChanged
    {
        private decimal _open;

        public decimal Open
        {
            get { return decimal.Round(_open, 2); }
            set
            {
                if (value == _open)
                {
                    return;
                }
                _open = value;
                OnPropertyChanged(nameof(Open));
            }
        }

        private decimal _last;

        public decimal Last
        {
            get { return decimal.Round(_last, 2); }
            set
            {
                if (value == _last)
                {
                    return;
                }
                _last = value;
                OnPropertyChanged(nameof(Last));
            }
        }

        private string _percentChange;

        public string PercentChange
        {
            get { return $"{_percentChange}%"; }
            set
            {
                if (value == _percentChange)
                {
                    return;
                }
                _percentChange = value;
                OnPropertyChanged(nameof(PercentChange));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
