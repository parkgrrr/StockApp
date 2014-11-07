using System;

using Xamarin.Forms;

namespace StockApp
{
	public class App
	{
		public static Page GetMainPage ()
		{	
            var servResponse = new StockService();
            stockQuote quote = servResponse.getQuote();
            
            
			return new ContentPage { 
				Content = new Label {
					Text = "The name for that ticker is: "+ quote.Name, //returns the quote to the main page
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
				},
			};
		}
	}
}

