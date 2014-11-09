using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using StockApp.Data;

namespace StockApp.ViewModel
{
    class stockQuoteViewModel : INotifyPropertyChanged
    {
        private stockQuote _stockQuote;
        public event PropertyChangedEventHandler PropertyChanged;

        public stockQuoteViewModel(stockQuote stockQuote)
        {
            _stockQuote = stockQuote;
        }

        public decimal PurchasePrice
        {
            get { return _stockQuote != null ? _stockQuote.PurchasePrice : 0; }
            set
            {
                if (_stockQuote != null)
                {
                    _stockQuote.PurchasePrice = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("PurchasePrice"));
                    }
                }
            }
        }

        public interface INotifyPropertyChanged
        {
            event PropertyChangedEventHandler PropertyChanged;
        }
    }
}
