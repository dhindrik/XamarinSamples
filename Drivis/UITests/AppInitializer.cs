using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                var path = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                var info = new FileInfo(path);
                var directory = info.Directory.Parent.Parent.Parent.FullName;

                var pathToAPK = Path.Combine(directory, "Drivis.XForms\\Drivis.XForms.Droid", "bin", "Debug", "Drivis.XForms.Droid.apk");

                return ConfigureApp
                    .Android.ApkFile(pathToAPK)
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

