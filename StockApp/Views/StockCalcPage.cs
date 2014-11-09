using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using StockApp.Data;
using StockApp.ViewModel;

namespace StockApp.Views
{
    class StockCalcPage : ContentPage
    {

        /// <summary>
        /// This is a modal page where the user can enter in the ticker symbol for a specific stock
        /// </summary>
        public StockCalcPage(StockServiceViewModel stockServiceViewModel)
        {
            //InitializeComponent();

            this.BindingContext = stockServiceViewModel;
            //Title = "Stock Search";
            //Padding = new Thickness(20);
            var tickerInput = new Entry { Placeholder = "Enter Purchase Price" };
            tickerInput.SetBinding(Entry.TextProperty, "PurchasePrice");



            var btnSubmit = new Button
            {
                Text = "Calculate",
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
