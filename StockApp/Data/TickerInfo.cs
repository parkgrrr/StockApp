using System;
using System.Collections.Generic;
using System.Text;

namespace StockApp.Data
{
    /// <summary>
    /// This class may possibly hold fields for a stock search, may not get implemented.
    /// </summary>
    class TickerInfo
    {
        string tickerSymbol;

        public string TickerSymbol
        {
            get { return tickerSymbol; }
            set { tickerSymbol = value; }
        }
    }
}
