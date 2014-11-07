using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

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
        public StockInfoPage()
        {
            Title = "Stock Quote"; 
            createToolbarSearch();
        }
        ToolbarItem search;
        ToolbarItem calculate;

        /// <summary>
        /// Creates 2 tool bar items in the navigation
        /// </summary>
        private void createToolbarSearch()
        {
            if (search != null)
            {
                return;
            }
            //string iconName = Device.OnPlatform(null, "ic_action_search.png", null);
            search = new ToolbarItem("Search", null, async () =>
            {
                await Navigation.PushModalAsync(new StockSearchPage());
            });
            calculate = new ToolbarItem("Calculate", null, async () =>
            {
                await Navigation.PushModalAsync(new StockSearchPage());
            });
            
            

        }
        protected override void OnAppearing()
        {
            ToolbarItems.Add(calculate);
            ToolbarItems.Add(search);
            
        }
    }

    

}
