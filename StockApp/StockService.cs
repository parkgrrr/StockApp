using System;
using RestSharp;
namespace StockApp
{
/// <summary>
/// This class is the service access layer, connecting to markitondemand's stock quote api.
/// </summary>

	public class StockService
	{
		public StockService ()
		{
            qSymbol = "AMD"; //The constructor sets the quote symbol property 
            
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

        private string qSymbol;
        
		
		



		
	}
}

