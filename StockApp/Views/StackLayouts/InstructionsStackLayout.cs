using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StockApp.Views
{
    /// <summary>
    /// Creates the initial page with user instructions.
    /// </summary>
    public static class InstructionsStackLayout
    {
        /// <summary>
        /// Generates the layout
        /// </summary>
        /// <returns></returns>
        public static StackLayout createStack()
        {
            var labelTest = new Label
            {
                Text = "Click on the Search button to get the ticker price of a stock.  Then click on the calculator button to determine your profit or loss.",
                Font = Font.SystemFontOfSize (25),
				StyleId = "Instructions"
            };
            var Content = new StackLayout
            {
                Spacing = 10,
                VerticalOptions = LayoutOptions.Center,
                Children = { labelTest },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //BackgroundColor = Color.Silver
            };
            return Content;

        }
    }
}
