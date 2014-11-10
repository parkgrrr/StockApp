using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using StockApp.Data;

namespace StockApp.Views.StackLayouts
{
    public static class QuoteResultStackLayout
    {
         public static StackLayout createStack(StockService sService)
        {
            
            var quoteObj = sService.getQuote();
            if (quoteObj.Name == null || quoteObj.Name == "") { quoteObj.Name = "Please make sure to enter in a valid stock quote, such as MSFT."; }
            var labelName = new Label
            {
                Text = quoteObj.Name + " (" + sService.qSymbol + ")",              

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
                Text = quoteObj.ChangePercent.ToString() + "amount of shares " + sService.ShareAmount.ToString() + "purchase price" + sService.PurchasePrice.ToString(),

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
            var Content = new StackLayout
            {
                //Spacing = 10,
                VerticalOptions = LayoutOptions.Center,
                Children = { labelName, labelLastPrice, labelChange, labelPercent }
            };
            return Content;
        }
    }
}
