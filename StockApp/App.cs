using System;

using Xamarin.Forms;

namespace StockApp
{
	public class App
	{
		public static Page GetMainPage ()
		{	
            StockService quote = new StockService();
			return new ContentPage { 
				Content = new Label {
					Text = quote.getQuote(), //returns the quote to the main page
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
				},
			};
		}
	}
}

