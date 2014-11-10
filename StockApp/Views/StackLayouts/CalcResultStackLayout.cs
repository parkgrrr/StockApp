using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using StockApp.Data;

namespace StockApp.Views
{
    /// <summary>
    /// Generates the layout for calculator results
    /// </summary>
    public static class CalcResultStackLayout
    {
        /// <summary>
        /// Generates labels for the page
        /// </summary>
        /// <param name="sService"></param>
        /// <returns></returns>
        public static StackLayout createStack(StockService sService)
        {
            var quoteObj = sService.getQuote();
            sService.calcQuote(quoteObj.LastPrice);
            var changeColor = Color.Green;
            if (sService.ProfitDollar < 0) { changeColor = Color.Red; }

            var labelCText = new Label
            {
                Text = "Dollar Change",
                Font = Font.SystemFontOfSize(50)

            };
            var labelChange = new Label
            {
                Text = "$"+sService.ProfitDollar.ToString("0.##"),
                TextColor = changeColor,
                Font = Font.SystemFontOfSize(30)

            };

            var labelPText = new Label
            {
                Text = "Percent Change",
                Font = Font.SystemFontOfSize(50)

            };
            var labelPercent = new Label
            {
                Text = sService.ProfitPercent.ToString("0.##")+"%",
                TextColor = changeColor,
                Font = Font.SystemFontOfSize(30)

            };

            var Content = new StackLayout
            {
                Spacing = 10,
                VerticalOptions = LayoutOptions.Center,
                Children = { labelCText, labelChange, labelPText, labelPercent }
            };
            sService.ShareAmount = 0;
            return Content;
        }
    }
}
