using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Drivis.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {

            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android.StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

