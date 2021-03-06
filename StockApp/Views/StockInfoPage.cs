﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using StockApp.Data;
using StockApp.ViewModel;
using StockApp.Views.StackLayouts;

namespace StockApp.Views
{
    /// <summary>
    /// This page is the main page, and contains logic to display different stack layouts.
    /// </summary>
    class StockInfoPage : ContentPage
    {
        /// <summary>
        /// Constructor sets the title page and creates the toolbar with a search and calculate tab
        /// </summary>
        public StockInfoPage(StockService sService, StockServiceViewModel ssvm)
        {
            Title = "Stock Quotr"; 
            createToolbars(ssvm);
			StyleId = "StockMain";
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
					this.StyleId = "SearchButton";
				});
			//search.StyleId = "SearchButton";
            calculate = new ToolbarItem("Calculate", null, async () =>
            {

					await Navigation.PushAsync(new StockCalcPage(ssvm));
					this.StyleId = "CalcButton";
            });
			//calculate.StyleId = "CalculateButton";

        }

        /// <summary>
        /// This method determines the stack layout that will be displayed on the main page.
        /// The layout returned varies by the user input.
        /// </summary>
        /// <param name="sService">This is the main service passed from the App page</param>
        private void createLayout(StockService sService)
        {
            if (sService.qSymbol != null && sService.qSymbol != "")
            {
                if (sService.ShareAmount != 0)
                {
                  Content = CalcResultStackLayout.createStack(sService);
                }
                else
                {
                    Content = QuoteResultStackLayout.createStack(sService);
                }                
            }
            
            else
            {
                Content = InstructionsStackLayout.createStack();
            }
        }  

        protected override void OnAppearing()
        {
            
            createLayout(App.sService);

           // var servResponse = new StockService("amd");
            

            
            
        }
    }

    

}
