using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using StockApp.Data;

namespace StockApp.ViewModel
{
    /// <summary>
    /// This View Model has properties that bind to the StockService model, and are set through the search and calculate pages
    /// </summary>
    class StockServiceViewModel : INotifyPropertyChanged
    {
        private StockService _stockService;
        public event PropertyChangedEventHandler PropertyChanged;

        public StockServiceViewModel (StockService stockService)
        {
            _stockService = stockService;
        }

        public string qSymbol 
        {
        get { return _stockService != null ? _stockService.qSymbol : null; }
        set {
            if ( _stockService != null ) {
                _stockService.qSymbol = value;
 
                if ( PropertyChanged != null ) {
                    PropertyChanged( this, new PropertyChangedEventArgs( "qSymbol" ) );
                }
              }
            }
        }

        public decimal PurchasePrice
        {
            get { return _stockService != null ? _stockService.PurchasePrice : 0.00m; }
            set
            {
                if (_stockService != null)
                {
                    _stockService.PurchasePrice = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("PurchasePrice"));
                    }
                }
            }
        }

        public int ShareAmount
        {
            get { return _stockService != null ? _stockService.ShareAmount : 0; }
            set
            {
                if (_stockService != null)
                {
                    _stockService.ShareAmount = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ShareAmount"));
                    }
                }
            }
        }

        public decimal PurchaseFees
        {
			get { return _stockService != null ? _stockService.PurchaseFees : 0.00m; }
            set
            {
                if (_stockService != null)
                {
                    _stockService.PurchaseFees = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("PurchaseFees"));
                    }
                }
            }
        }

        public decimal SellingFees
        {
			get { return _stockService != null ? _stockService.SellingFees : 0.00m; }
            set
            {
                if (_stockService != null)
                {
                    _stockService.SellingFees = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("SellingFees"));
                    }
                }
            }
        }

        public decimal ProfitDollar
        {
			get { return _stockService != null ? _stockService.ProfitDollar : 0.00m; }
            set
            {
                if (_stockService != null)
                {
                    _stockService.ProfitDollar = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ProfitDollar"));
                    }
                }
            }
        }


        public decimal ProfitPercent
        {
            get { return _stockService != null ? _stockService.ProfitPercent : 0; }
            set
            {
                if (_stockService != null)
                {
                    _stockService.ProfitPercent = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ProfitPercent"));
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
