using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace StockApp.Views
{
    public static class InstructionsStackLayout
    {
        public static StackLayout createStack()
        {
            var labelTest = new Label
            {
                Text = "Click on the Search button to get the ticker price of a stock.  Then, click on the calculator button to determine your profit or loss."//sService.qSymbol

            };
            var Content = new StackLayout
            {
                //Spacing = 10,
                VerticalOptions = LayoutOptions.Center,
                Children = { labelTest }
            };
            return Content;

        }
    }
}
