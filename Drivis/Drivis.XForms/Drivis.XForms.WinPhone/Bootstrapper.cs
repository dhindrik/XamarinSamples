using Autofac;
using Drivis.Core.IoC;
using Drivis.Core.Networking;
using Drivis.Core.ServiceAgents;
using Drivis.Core.ViewModels;
using Drivis.XForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivis.XForms.WinPhone
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
