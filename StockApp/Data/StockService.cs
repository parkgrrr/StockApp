using System;
using RestSharp;
namespace StockApp.Data
{
/// <summary>
/// This class is the service access layer, connecting to markitondemand's stock quote api.
/// </summary>

	public class StockService
	{
		public StockService ()//string tickerInput)
		{
            //qSymbol = tickerInput; //The constructor sets the quote symbol property 
            
		}
        /// <summary>
        /// This method connects to the web service and retrieves xml or possibly json in the future.
        /// </summary>
        /// <returns>currently the raw xml response as a string, but will change.</returns>
        public stockQuote getQuote()
        {
			var clientQuote = new RestClient("http://dev.markitondemand.com/Api/v2/");
			var requestQuote = new RestRequest("Quote/json", Method.GET);
			requestQuote.AddParameter("symbol", qSymbol);
            var responseQuote = clientQuote.Execute(requestQuote);
            var jsonQuote = responseQuote.Content;
            var quoteObj = new stockQuote(jsonQuote);
            return quoteObj;

        }

        public void calcQuote(decimal lastPrice)
        {
            //var Calc = new calcResult();
            var PurchaseTotal = ((PurchasePrice * ShareAmount) + (PurchaseFees + SellingFees));
            var SellingTotal = (lastPrice * ShareAmount);
            ProfitDollar = SellingTotal - PurchaseTotal;
            ProfitPercent = (ProfitDollar / PurchaseTotal) * 100;
            calcSet = true;
            

        }

        public string qSymbol { get; set; }
        public decimal PurchasePrice { get; set; }
        public int ShareAmount { get; set; }
        public decimal PurchaseFees { get; set; }
        public decimal SellingFees { get; set; }
        public decimal ProfitDollar { get; set; }
        public decimal ProfitPercent { get; set; }
        public bool calcSet { get; set; }
        
		
		



		
	}
}

