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
	public class NavTest
	{
		public string PathToAPK { get; set; }
		private AndroidApp _app;

		static readonly Func<AppQuery, AppQuery> SearchButton = c => c.Marked("NoResourceEntry-0").Text("Search");
		static readonly Func<AppQuery, AppQuery> CalcButton = c => c.Marked("NoResourceEntry-0").Text("Calculate");
		static readonly Func<AppQuery, AppQuery> SymbInput = c => c.Marked("SymbolInput");
		static readonly Func<AppQuery, AppQuery> QuoteButton = c => c.Marked("QuoteButton");
		static readonly Func<AppQuery, AppQuery> CompName = c => c.Marked("CompName");
		static readonly Func<AppQuery, AppQuery> BadInput = c => c.Marked("CompName").Text("Please enter in a valid symbol, like MSFT.");




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
		public void getQuoteTest ()
		{

			_app.Tap (SearchButton);
			//Checks to see if the input is null
			_app.WaitForElement (SymbInput);
			//AppResult[] result = _app.Query(SymbInput);
			//Assert.IsTrue (result.Any(), "The input should be false");

			//enters input
			_app.Tap (SymbInput);
			_app.EnterText ("MSFT");
			_app.Tap (QuoteButton);

			//Checks to see if data on MSFT is displayed
			_app.WaitForElement (CompName);
			AppResult[] result = _app.Query(BadInput);
			Assert.IsFalse(result.Any(), "Microsoft Stock info should be displayed, but isn't");
			//_app.Repl ();
		}
	}
}

