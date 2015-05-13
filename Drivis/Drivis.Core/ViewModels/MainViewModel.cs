using Drivis.Core.Entities;
using Drivis.Core.IoC;
using Drivis.Core.ServiceAgents;
using Geolocator.Plugin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivis.Core.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private IWeatherServiceAgent _weatherServiceAgent;

        public MainViewModel(IWeatherServiceAgent weatherServiceAgent)
        {
            _weatherServiceAgent = weatherServiceAgent;
            WeatherData = new ObservableCollection<WeatherItemModel>();
        }

        public async Task Initialize()
        {
            if(CrossGeolocator.Current.IsGeolocationEnabled)
            {
                var position = await CrossGeolocator.Current.GetPositionAsync(10000);

                var weatherData = await _weatherServiceAgent.GetWeather(position.Latitude, position.Longitude);

                foreach(var item in weatherData.Take(24))
                {
                    var data = Resolver.Resolve<WeatherItemModel>();
                    data.Temperature = item.Temperature;
                    data.Time = item.Time;

                    WeatherData.Add(data);
                }
            }
        }

        public ObservableCollection<WeatherItemModel> WeatherData { get; set; }
    }
}
