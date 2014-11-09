using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using StockApp.Data;

namespace StockApp.ViewModel
{
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

        public interface INotifyPropertyChanged
        {
            event PropertyChangedEventHandler PropertyChanged;
        }
    }
}
