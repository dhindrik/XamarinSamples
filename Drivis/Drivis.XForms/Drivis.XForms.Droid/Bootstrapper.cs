using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Autofac;
using Drivis.Core.ViewModels;
using Drivis.XForms.Views;
using Drivis.Core.Networking;
using Drivis.Core.ServiceAgents;
using Drivis.Core.IoC;

namespace Drivis.XForms.Droid
{
    public class Bootstrapper
    {
        public static void Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<WeatherItemModel>();

            builder.RegisterType<MainView>();

            builder.RegisterType<RestClient>().As<IRestClient>();

            builder.RegisterType<WeatherServiceAgent>().As<IWeatherServiceAgent>();

            var container = builder.Build();
            Resolver.SetResolver(new AutofacResolver(container));
        }
    }
}