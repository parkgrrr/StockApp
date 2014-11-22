using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using StockApp.Data;

namespace StockApp.Views.StackLayouts
{
    /// <summary>
    /// The layout for stock quote results
    /// </summary>
    public static class QuoteResultStackLayout
    {
        /// <summary>
        /// The constructor creates the labels
        /// </summary>
        /// <param name="sService"></param>
        /// <returns></returns>
         public static StackLayout createStack(StockService sService)
        {
            
            var quoteObj = sService.getQuote();
            if (quoteObj.Name == null || quoteObj.Name == "") { quoteObj.Name = "Please enter in a valid symbol, like MSFT."; }
            var changeColor = Color.Green;
            if (quoteObj.Change < 0) { changeColor = Color.Red; }

            var labelName = new Label
            {
                Text = quoteObj.Name,
                Font = Font.SystemFontOfSize(50, FontAttributes.Bold),
				StyleId = "CompName"

            };
            var labelSymbol = new Label
            {
                Text = " (" + sService.qSymbol.ToUpper() + ")",
                Font = Font.SystemFontOfSize(30, FontAttributes.Bold)

            };
            var labelLPText = new Label
            {
                Text = "Last Price",
                Font = Font.SystemFontOfSize(30)

            };
            var labelLastPrice = new Label
            {
                Text = "$"+quoteObj.LastPrice.ToString(),
                TextColor = changeColor

            };
            var labelCText = new Label
            {
                Text = "Dollar Change",
                Font = Font.SystemFontOfSize(30)

            };
            var labelChange = new Label
            {
                Text = "$"+quoteObj.Change.ToString("0.###"),
                TextColor = changeColor
                
            };
            var labelPText = new Label
            {
                Text = "Percent Change",
                Font = Font.SystemFontOfSize(30)

            };
            var labelPercent = new Label
            {
                Text = quoteObj.ChangePercent.ToString("0.###")+"%",
                TextColor = changeColor

            };
            var labelOText = new Label
           {
               Text = "Opening Price",
               Font = Font.SystemFontOfSize(30)
           };
            var labelOpen = new Label
            {
                Text = "$"+quoteObj.Open.ToString("0.###"),

            };
            var labelMarket = new Label
            {
                Text = quoteObj.MarketCap.ToString(),

            };
            var labelVolume = new Label
            {
                Text = quoteObj.Volume.ToString(),

            };
            var Content = new StackLayout
            {
                Spacing = 10,
                VerticalOptions = LayoutOptions.Center,
                Children = { labelName, labelSymbol, labelLPText, labelLastPrice, labelCText, labelChange, labelPText, labelPercent, labelOText, labelOpen }
            };
            return Content;
        }
    }
}
