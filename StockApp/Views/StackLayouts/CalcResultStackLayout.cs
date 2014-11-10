using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using StockApp.Data;

namespace StockApp.Views
{
    public static class CalcResultStackLayout
    {
        public static StackLayout createStack(StockService sService)
        {
            var quoteObj = sService.getQuote();
            sService.calcQuote(quoteObj.LastPrice);
            var labelName = new Label
            {
                //Text = quoteObj.Name+" ("+sService.qSymbol+")",
                Text = "Profit Dollar: " + sService.ProfitDollar.ToString("0.##") + ", Profit Percent: " + sService.ProfitPercent.ToString("0.##"),

            };
            var Content = new StackLayout
            {
                //Spacing = 10,
                VerticalOptions = LayoutOptions.Center,
                Children = { labelName, }
            };
            sService.ShareAmount = 0;
            return Content;
        }
    }
}
