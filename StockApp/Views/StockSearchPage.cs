using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using StockApp.Data;
using StockApp.ViewModel;

namespace StockApp.Views
{
    class StockSearchPage : ContentPage
    {
        
        /// <summary>
        /// This is a modal page where the user can enter in the ticker symbol for a specific stock
        /// </summary>
        public StockSearchPage(StockServiceViewModel stockServiceViewModel)
        {
            //InitializeComponent();
 
            this.BindingContext = stockServiceViewModel;
            Title = "Ticker Symbol Search";
            //Padding = new Thickness(20);
            var tickerInput = new Entry { Placeholder = "Enter Stock Symbol" };
            tickerInput.SetBinding(Entry.TextProperty, "qSymbol");
            //var shareInput = new Entry { Placeholder = "Enter Amount of Shares" };
            //shareInput.SetBinding(Entry.TextProperty, "ShareAmount");
            
            
            
            var btnSubmit = new Button
            {
                Text = "Set Quote",
                BorderRadius = 5,
                TextColor = Color.White,
                //BackgroundColor = Colours.BackgroundGrey
            };
            
            btnSubmit.Clicked += SetStock;

            Content = new StackLayout
            {
                //Spacing = 10,
                VerticalOptions = LayoutOptions.Center,
                Children = { tickerInput, btnSubmit }
            };

        }

        
        
        async void SetStock(object sender, EventArgs eventArgs)
        {
           
            await Navigation.PopAsync();

        }

        
        
        
    }
}
