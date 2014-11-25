using NUnit.Framework;
using System;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;
using System.IO;
using System.Reflection;
using System.Linq;

namespace StockApp.Tests
{
	[TestFixture]
	public class TestCases
	{
		public string PathToAPK { get; set; }
		private AndroidApp _app;

		static readonly Func<AppQuery, AppQuery> SearchButton = c => c.Marked("NoResourceEntry-0").Text("Search");
		static readonly Func<AppQuery, AppQuery> CalcButton = c => c.Marked("NoResourceEntry-0").Text("Calculate");
		static readonly Func<AppQuery, AppQuery> homeButton = c => c.Marked("home");
		static readonly Func<AppQuery, AppQuery> Instruct = c => c.Marked("Instructions");

		static readonly Func<AppQuery, AppQuery> SymbInput = c => c.Marked("SymbolInput");
		static readonly Func<AppQuery, AppQuery> QuoteButton = c => c.Marked("QuoteButton");
		static readonly Func<AppQuery, AppQuery> CompName = c => c.Marked("CompName");
		static readonly Func<AppQuery, AppQuery> BadInput = c => c.Marked("CompName").Text("Please enter in a valid symbol, like MSFT.");
		//Calc page
		static readonly Func<AppQuery, AppQuery> PriceInput = c => c.Marked("priceInput");
		static readonly Func<AppQuery, AppQuery> ShareInput = c => c.Marked("shareInput");
		static readonly Func<AppQuery, AppQuery> PurchaseInput = c => c.Marked ("purchaseInput");
		static readonly Func<AppQuery, AppQuery> SellInput = c => c.Marked ("sellInput");
		static readonly Func<AppQuery, AppQuery> CalcSub = c => c.Marked ("calcSub").Text("Calculate");
		static readonly Func<AppQuery, AppQuery> DollarChange = c => c.Marked("dollarChange");



		[TestFixtureSetUp]
		public void TestFixtureSetup()
		{
			string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
			FileInfo fi = new FileInfo(currentFile);
			string dir = fi.Directory.Parent.Parent.Parent.FullName;
			PathToAPK = Path.Combine(dir, "Android", "bin", "Debug", "StockApp.Android.apk");
		}

		[SetUp]
		public void SetUp()
		{
			// an API key is required to publish on Xamarin Test Cloud for remote, multi-device testing
			// this works fine for local simulator testing though
			_app = ConfigureApp.Android.ApkFile(PathToAPK).ApiKey("YOUR_API_KEY_HERE").StartApp();
		}

		[Test]
		/// <summary>
		/// This test does a basic navigation between the pages.
		/// </summary>
		public void NavigationTest()
		{
			_app.WaitForElement (SearchButton, "Timed Out");
			_app.Tap (SearchButton);

			_app.WaitForElement (SymbInput, "Timed out");


			//navigates through pages
			_app.Tap (homeButton);

			_app.Tap (CalcButton);

			_app.Tap (homeButton);

			//Checks to see if the app navigated through the pages properly
			_app.WaitForElement (Instruct, "Timed out");
			AppResult[] result = _app.Query(Instruct);
			Assert.IsTrue(result.Any(), "The App was unable to navigate properly");
			//_app.Repl ();
		}

		[Test]
		/// <summary>
		/// This test gets a quote for AMD and displayes it
		/// </summary>
		public void getQuoteTest ()
		{
			_app.WaitForElement (SearchButton, "Timed Out");
			_app.Tap (SearchButton);
			//Checks to see if the input is null
			_app.WaitForElement (SymbInput, "Timed out");
			//AppResult[] result = _app.Query(SymbInput);
			//Assert.IsTrue (result.Any(), "The input should be false");

			//enters input
			_app.Tap (SymbInput);
			_app.EnterText ("AMD");
			_app.Tap (QuoteButton);

			//Checks to see if data on MSFT is displayed
			_app.WaitForElement (CompName, "Timed out");
			AppResult[] result = _app.Query(BadInput);
			Assert.IsFalse(result.Any(), "Microsoft Stock info should be displayed, but isn't");
			//_app.Repl ();
		}

		[Test]
		/// <summary>
		/// This test trys to search for a quote using bad input
		/// </summary>
		public void badQuoteTest ()
		{
			_app.WaitForElement (SearchButton, "Timed Out");
			_app.Tap (SearchButton);
			//Checks to see if the input is null
			_app.WaitForElement (SymbInput, "Timed out");
			//AppResult[] result = _app.Query(SymbInput);
			//Assert.IsTrue (result.Any(), "The input should be false");

			//enters input
			_app.Tap (SymbInput);
			_app.EnterText ("78sdfs");
			_app.Tap (QuoteButton);

			//Checks to see if data on MSFT is displayed
			_app.WaitForElement (CompName, "Timed out");
			AppResult[] result = _app.Query(BadInput);
			Assert.IsTrue(result.Any(), "No Stock Info Should Be Displayed");
			//_app.Repl ();
		}

		[Test]
		/// <summary>
		/// This test trys to search for a quote using bad input with special characters
		/// </summary>
		public void specialCharQuoteTest ()
		{
			_app.WaitForElement (SearchButton, "Timed Out");
			_app.Tap (SearchButton);
			//Checks to see if the input is null
			_app.WaitForElement (SymbInput, "Timed out");
			//AppResult[] result = _app.Query(SymbInput);
			//Assert.IsTrue (result.Any(), "The input should be false");

			//enters input
			_app.Tap (SymbInput);
			_app.EnterText ("!@#$%^&*()");
			_app.Tap (QuoteButton);

			//Checks to see if data on MSFT is displayed
			_app.WaitForElement (CompName, "Timed out");
			AppResult[] result = _app.Query(BadInput);
			Assert.IsTrue(result.Any(), "No Quote Data Should Be Shown.");

		}

		[Test]
		/// <summary>
		/// This test gets a quote for MSFT and calculates a ROI using whole numbers
		/// </summary>
		public void calcQuoteTest ()
		{
			_app.WaitForElement (SearchButton, "Timed Out");
			_app.Tap (SearchButton);
			//Checks to see if the input is null
			_app.WaitForElement (SymbInput, "Timed out");
			//AppResult[] result = _app.Query(SymbInput);
			//Assert.IsTrue (result.Any(), "The input should be false");

			//enters input
			_app.Tap (SymbInput);
			_app.EnterText ("MSFT");
			_app.Tap (QuoteButton);

			//Calculates the quote

			_app.Tap (CalcButton);
			_app.WaitForElement (PriceInput); //purchase price


			_app.WaitForElement (SellInput);
			_app.Tap (SellInput);
			_app.ClearText(SellInput);
			_app.EnterText ("7");

			_app.Tap (PurchaseInput);
			_app.ClearText(PurchaseInput);
			_app.EnterText ("7");


			_app.Tap (PriceInput);
			_app.ClearText(PriceInput);
			_app.EnterText ("45");

			_app.Tap (ShareInput);
			_app.ClearText(ShareInput);
			_app.EnterText ("100");

			_app.WaitForElement (CalcSub);
			_app.Tap (CalcSub);

			_app.WaitForElement (DollarChange, "The Change info did not appear");

			AppResult[] result2 = _app.Query(DollarChange);
			Assert.IsTrue(result2.Any(), "A Return on investment should be displayed, but is not");

		}

		[Test]
		/// <summary>
		/// This test is underdevelopment and is not currently accurate.
		/// This test pulls down a quote from AAPL, and then calculates a return using decimals.
		/// It should currently fails as the android SPELLCHECKER parses the data on an input attempt.
		/// </summary>
		public void calcQuoteDecTest ()
		{
			_app.WaitForElement (SearchButton, "Timed Out");
			_app.Tap (SearchButton);
			//Checks to see if the input is null
			_app.WaitForElement (SymbInput, "Timed out");
			//AppResult[] result = _app.Query(SymbInput);
			//Assert.IsTrue (result.Any(), "The input should be false");

			//enters input
			_app.Tap (SymbInput);
			_app.EnterText ("AAPL");
			_app.Tap (QuoteButton);

			//Calculates the quote

			_app.Tap (CalcButton);
			_app.WaitForElement (PriceInput); //purchase price


			_app.WaitForElement (SellInput);
			_app.Tap (SellInput);
			_app.ClearText(SellInput);
			_app.EnterText ("7.50");

			_app.Tap (PurchaseInput);
			_app.ClearText(PurchaseInput);
			_app.EnterText ("7.50");


			_app.Tap (PriceInput);
			_app.ClearText(PriceInput);
			_app.EnterText ("112.92");

			_app.Tap (ShareInput);
			_app.ClearText(ShareInput);
			_app.EnterText ("60");

			_app.WaitForElement (CalcSub);
			_app.Tap (CalcSub);

			_app.WaitForElement (DollarChange, "The Change info did not appear");

			AppResult[] result2 = _app.Query(DollarChange);
			//int change = Convert.ToInt32(result2[0]);

			//Assert.IsTrue(result2.Any(), "Accurate info should be displayed");
			//Assert.Less(result2[0], 100000, "The info displayed is too high, the test failed.");
			Assert.IsTrue (Convert.ToInt32(result2[1]) > 0, "The info displayed is too low, the test failed");


		}

		[Test]
		/// <summary>
		/// This should fail to calculate, as invalid characters are used to calcuate a ROI
		/// </summary>
		public void calcSpecCharTest ()
		{
			_app.WaitForElement (SearchButton, "Timed Out");
			_app.Tap (SearchButton);
			//Checks to see if the input is null
			_app.WaitForElement (SymbInput, "Timed out");
			//AppResult[] result = _app.Query(SymbInput);
			//Assert.IsTrue (result.Any(), "The input should be false");

			//enters input
			_app.Tap (SymbInput);
			_app.EnterText ("INTC");
			_app.Tap (QuoteButton);

			//Calculates the quote

			_app.Tap (CalcButton);
			_app.WaitForElement (PriceInput); //purchase price


			_app.WaitForElement (SellInput);
			_app.Tap (SellInput);
			_app.ClearText(SellInput);
			_app.EnterText ("&!%");

			_app.Tap (PurchaseInput);
			_app.ClearText(PurchaseInput);
			_app.EnterText ("&$&");


			_app.Tap (PriceInput);
			_app.ClearText(PriceInput);
			_app.EnterText ("#*^");

			_app.Tap (ShareInput);
			_app.ClearText(ShareInput);
			_app.EnterText ("+^)%");

			_app.WaitForElement (CalcSub);
			_app.Tap (CalcSub);

			//_app.WaitForElement (DollarChange, "The Change info did not appear");

			AppResult[] result2 = _app.Query(DollarChange);
			Assert.IsFalse(result2.Any(), "A Calculated Result Should Not Be Displayed");

		}
	}
}

