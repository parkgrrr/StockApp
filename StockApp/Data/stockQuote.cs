using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace StockApp.Data
{
    /// <summary>
    /// This class deserializes the web service response and populates a stock quote object with relecant financial info.  
    /// Backing fields provide the possibility of alerting the object of changes through an observer style pattern.
    /// </summary>
    public class stockQuote
    {
        /// <summary>
        /// The constructor deserializes the response from the web service.
        /// </summary>
        /// <param name="rawJson">This is a raw json string that gets passed from the constructor to another method</param>
        public stockQuote(string rawJson)
        {
            deserializeQuote(rawJson);
        }

        /// <summary>
        /// This method uses the json.net library to parse the raw string in to properties in the object
        /// </summary>
        /// <param name="rawJson">This method accepts a json string passed in through the constructor</param>
        private void deserializeQuote(string rawJson)
        {
            try
            {
                var jParsed = JObject.Parse(rawJson);
                name = jParsed["Name"].Value<string>();
                lastPrice = jParsed["LastPrice"].Value<decimal>();
                change = jParsed["Change"].Value<decimal>();
                changePercent = jParsed["ChangePercent"].Value<decimal>();
                timeStamp = jParsed["Timestamp"].Value<string>();
                mSDATE = jParsed["MSDate"].Value<decimal>();
                marketCap = jParsed["MarketCap"].Value<decimal>();
                volume = jParsed["Volume"].Value<double>();
                changeYTD = jParsed["ChangeYTD"].Value<decimal>();
                changePercentYTD = jParsed["ChangePercentYTD"].Value<decimal>();
                high = jParsed["High"].Value<decimal>();
                low = jParsed["Low"].Value<decimal>();
                open = jParsed["Open"].Value<decimal>();
            }
            catch
            {
                return;
            }
            
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private decimal lastPrice;

        public decimal LastPrice
        {
            get { return lastPrice; }
            set { lastPrice = value; }
        }
        private decimal change;

        public decimal Change
        {
            get { return change; }
            set { change = value; }
        }
        private decimal changePercent;

        public decimal ChangePercent
        {
            get { return changePercent; }
            set { changePercent = value; }
        }
        private string timeStamp;

        public string TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }

        private decimal mSDATE;

        public decimal MSDATE
        {
            get { return mSDATE; }
            set { mSDATE = value; }
        }

        private decimal marketCap;

        public decimal MarketCap
        {
            get { return marketCap; }
            set { marketCap = value; }
        }
        private double volume;

        public double Volume
        {
            get { return volume; }
            set { volume = value; }
        }
        private decimal changeYTD;

        public decimal ChangeYTD
        {
            get { return changeYTD; }
            set { changeYTD = value; }
        }
        private decimal changePercentYTD;

        public decimal ChangePercentYTD
        {
            get { return changePercentYTD; }
            set { changePercentYTD = value; }
        }
        private decimal high;

        public decimal High
        {
            get { return high; }
            set { high = value; }
        }
        private decimal low;

        public decimal Low
        {
            get { return low; }
            set { low = value; }
        }
        private decimal open;

        public decimal Open
        {
            get { return open; }
            set { open = value; }
        }

       

        public void calculateProfit()
        {

        }



        



    }

    
}
