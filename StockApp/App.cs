using System;

using Xamarin.Forms;
using StockApp.Data;
using StockApp.Views;
using StockApp.ViewModel;

namespace StockApp
{
	public class App
	{
		public static Page GetMainPage ()
		{
            sService = new StockService();
            var ssvm = new StockServiceViewModel(sService);
            
            NavigationPage mainNav = new NavigationPage(new StockInfoPage(sService, ssvm));

            return mainNav;
		}

        public static string qsymbol;
        public static StockService sService;

        
	}
}

