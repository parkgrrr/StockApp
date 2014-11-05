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
        public string getQuote()
        {
            var clientQuote = new RestClient("http://dev.markitondemand.com/Api/v2/");
            var requestQuote = new RestRequest("Quote/", Method.POST);
            requestQuote.AddParameter("Symbol", qSymbol);
            //requestQuote.RequestFormat = DataFormat.Json; //This isn't working, could change to GET and add jsonp? to url manually
            var responseQuote = clientQuote.Execute(requestQuote);
            var content = responseQuote.Content;
            return content;

        }

        private string qSymbol;
        
		
		



		
	}
}

