using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;
using System.Threading.Tasks;

namespace Drivis.Droid.UITests
{
	[TestFixture]
	public class Tests
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest ()
		{
			// TODO: If the Android app being tested is included in the solution then open
			// the Unit Tests window, right click Test Apps, select Add App Project
			// and select the app projects that should be tested.
			app = ConfigureApp
				.Android
			// TODO: Update this path to point to your Android app and uncomment the
			// code if the app is not included in the solution.
			//.ApkFile ("../../../Android/bin/Debug/UITestsAndroid.apk")
				.StartApp ();
		}

		

        [Test]
        public async void LoadWeatherData()
        {
            app.Device.SetLocation(60.38300, 14.69475);

            app.Screenshot("First screen.");

            app.WaitForElement(x => x.Button());
            app.Tap(x => x.Button());

            await Task.Delay(3000);

            app.Screenshot("List of weather");
        }
	}
}

