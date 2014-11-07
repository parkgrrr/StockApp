using System;

using Xamarin.Forms;
using StockApp.Data;
using StockApp.Views;

namespace StockApp
{
	public class App
	{
		public static Page GetMainPage ()
		{	
           // var servResponse = new StockService();
           // stockQuote quote = servResponse.getQuote();
            
            NavigationPage mainNav = new NavigationPage(new StockInfoPage());

            return mainNav;
		}
	}
}

