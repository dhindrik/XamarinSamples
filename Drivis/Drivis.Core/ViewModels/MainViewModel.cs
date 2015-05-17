using Drivis.Core.Entities;
using Drivis.Core.IoC;
using Drivis.Core.Mvvm;
using Drivis.Core.ServiceAgents;
using Geolocator.Plugin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

       

        public ICommand LoadWeatherData
        {
            get
            {
                return new Command(async () =>
                {
                    await LoadData();
                });
            }
        }

        public async Task LoadData()
        {
            if (CrossGeolocator.Current.IsGeolocationEnabled)
            {
                var position = await CrossGeolocator.Current.GetPositionAsync(10000);

                var weatherData = await _weatherServiceAgent.GetWeather(position.Latitude, position.Longitude);

                foreach (var item in weatherData.Take(24))
                {
                    var data = Resolver.Resolve<WeatherItemModel>();
                    data.Temperature = item.Temperature;
                    data.Time = item.Time;

                    WeatherData.Add(data);
                }

                DataIsLoaded = true;
            }
        }
        public ObservableCollection<WeatherItemModel> WeatherData { get; set; }

        private bool _dataIsLoaded;
        public bool DataIsLoaded
        {
            get { return _dataIsLoaded; }
            set
            {
                _dataIsLoaded = value;
                NotifyPropertyChanged("DataIsLoaded");
                NotifyPropertyChanged("DataIsNotLoaded");
            }
        }

        public bool DataIsNotLoaded
        {
            get { return !_dataIsLoaded; }
        }
    }
}
