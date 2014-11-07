using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StockApp.Views
{
    class StockSearchPage : ContentPage
    {
        /// <summary>
        /// This is a modal page where the user can enter in the ticker symbol for a specific stock
        /// </summary>
        public StockSearchPage()
        {
            //Title = "Stock Search";
            //Padding = new Thickness(20);
            var ticker = new Entry { Placeholder = "Type Stock Symbol" };

            Content = new StackLayout
            {
                //Spacing = 10,
                VerticalOptions = LayoutOptions.Center,
                Children = { ticker }
            };

        }
        
    }
}
