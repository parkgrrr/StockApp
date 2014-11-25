using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using StockApp.Data;
using StockApp.ViewModel;

namespace StockApp.Views
{
    /// <summary>
    /// This page calculates Profits or losses
    /// </summary>
    class StockCalcPage : ContentPage
    {

        /// <summary>
        /// This Constructor builds the page
        /// </summary>
        /// <param name="stockServiceViewModel"></param>
        public StockCalcPage(StockServiceViewModel stockServiceViewModel)
        {
            this.BindingContext = stockServiceViewModel;
            Title = "Calculate Profits/Losses"; 
            //var tickerLabel = new Label { Text = "Calculate your profits"};

			var sharePrice = new Label { Text = "Enter Price Per Share", };
			var priceInput = new Entry { Placeholder = "Enter Price Per Share", StyleId = "priceInput"};
            priceInput.SetBinding(Entry.TextProperty, "PurchasePrice");
			priceInput.Keyboard = Keyboard.Numeric;
            var shareLabel = new Label { Text = "Enter Amount of Shares Purchased" };
			var shareInput = new Entry { Placeholder = "Enter Amount of Shares", StyleId = "shareInput"};
            shareInput.SetBinding(Entry.TextProperty, "ShareAmount");
			shareInput.Keyboard = Keyboard.Numeric;
            var purchaseLabel = new Label { Text = "Enter Purchasing Fees" };
			var purchaseInput = new Entry { Placeholder = "Enter Purchasing Fees", StyleId = "purchaseInput"};
			purchaseInput.SetBinding(Entry.TextProperty, "PurchaseFees");
			purchaseInput.Keyboard = Keyboard.Numeric;
            var sellLabel = new Label { Text = "Enter Selling Fees" };
			var sellInput = new Entry { Placeholder = "Enter Selling Fees", StyleId = "sellInput"};
            sellInput.SetBinding(Entry.TextProperty, "SellingFees");
			//sellInput.Keyboard = Keyboard.Numeric;
            var btnSubmit = new Button
            {
                Text = "Calculate",
                BorderRadius = 10,
                TextColor = Color.White,
				StyleId = "calcSub"
                
            };

            btnSubmit.Clicked += SetCalc;

            Content = new StackLayout
            {
                //Spacing = 10,
                VerticalOptions = LayoutOptions.Center,
                Children = { sharePrice, priceInput, shareLabel, shareInput, purchaseLabel, purchaseInput, sellLabel, sellInput, btnSubmit }
            };

        }



        async void SetCalc(object sender, EventArgs eventArgs)
        {
            
            await Navigation.PopAsync();

        }




    }
}
