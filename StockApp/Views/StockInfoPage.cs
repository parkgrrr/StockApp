using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using StockApp.Data;
using StockApp.ViewModel;

namespace StockApp.Views
{
    /// <summary>
    /// This page is the main page, and displays financial information about a certain stock.
    /// </summary>
    class StockInfoPage : ContentPage
    {
        /// <summary>
        /// Constructor sets the title page and creates the toolbar with a search and calculate icon
        /// </summary>
        public StockInfoPage(StockService sService, StockServiceViewModel ssvm)
        {
            Title = "Stock Quotr"; 
            createToolbars(ssvm);
            ToolbarItems.Add(calculate);
            ToolbarItems.Add(search);
            
        }
        
        ToolbarItem search;
        ToolbarItem calculate;
        //public StockService servResponse;

        /// <summary>
        /// Creates 2 tool bar items in the navigation
        /// </summary>
        private void createToolbars(StockServiceViewModel ssvm)
        {
            if (search != null)
            {
                return;
            }
            
            //string iconName = Device.OnPlatform(null, "ic_action_search.png", null);
            search = new ToolbarItem("Search", null, async () =>
            {
                await Navigation.PushAsync(new StockSearchPage(ssvm));
            });
            calculate = new ToolbarItem("Calculate", null, async () =>
            {
                await Navigation.PushAsync(new StockCalcPage(ssvm));
            });

            
                

                                        
                       

        }

        private void createLayout(StockService sService)
        {
            if (sService.qSymbol != null)
            {
                if (sService.ShareAmount != 0)
              {
                var quoteObj = sService.getQuote();
                sService.calcQuote(quoteObj.LastPrice);
                var labelName = new Label
                {
                    //Text = quoteObj.Name+" ("+sService.qSymbol+")",
                    Text = "Profit Dollar: " + sService.ProfitDollar.ToString("0.###") + ", Profit Percent: " + sService.ProfitPercent.ToString("0.##"),

                };
                Content = new StackLayout
                {
                    //Spacing = 10,
                    VerticalOptions = LayoutOptions.Center,
                    Children = { labelName, }
                };
                sService.ShareAmount = 0;
              }
                else
                {
                    var quoteObj = sService.getQuote();
                    //var calcObj = sService.calcQuote();
                    var labelName = new Label
                    {
                        Text = quoteObj.Name + " (" + sService.qSymbol + ")",
                        //Text = "Profit Dollar: " + sService.ProfitDollar.ToString() + ", Profit Percent: " + sService.ProfitPercent.ToString(),

                    };

                    var labelLastPrice = new Label
                    {
                        Text = quoteObj.LastPrice.ToString(),

                    };
                    var labelChange = new Label
                    {
                        Text = quoteObj.Change.ToString(),

                    };
                    var labelPercent = new Label
                    {
                        Text = quoteObj.ChangePercent.ToString()+"amount of shares "+ sService.ShareAmount.ToString()+"purchase price"+ sService.PurchasePrice.ToString(),

                    };
                    var labelTime = new Label
                    {
                        Text = quoteObj.TimeStamp,

                    };
                    var labelMarket = new Label
                    {
                        Text = quoteObj.MarketCap.ToString(),

                    };
                    var labelVolume = new Label
                    {
                        Text = quoteObj.Volume.ToString(),

                    };
                    Content = new StackLayout
                    {
                        //Spacing = 10,
                        VerticalOptions = LayoutOptions.Center,
                        Children = { labelName, labelLastPrice, labelChange, labelPercent }
                    };
                }
                
            }
            
            else
            {
                var labelTest = new Label
                {
                    Text = "Click on the Search button to get the ticker price of a stock.  Then, click on the calculator button to determine your profit or loss."//sService.qSymbol

                };
                Content = new StackLayout
                {
                    //Spacing = 10,
                    VerticalOptions = LayoutOptions.Center,
                    Children = { labelTest }
                };
            }
        }  

        protected override void OnAppearing()
        {
            
            createLayout(App.sService);

           // var servResponse = new StockService("amd");
            

            
            
        }
    }

    

}
