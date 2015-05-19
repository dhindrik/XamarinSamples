using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Drivis.Core.ViewModels;
using Drivis.Core.IoC;
using Drivis.Droid.Adapters;
using Drivis.Core.Entities;

namespace Drivis.Droid
{
    [Activity(Label = "Drivis.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        private MainViewModel ViewModel { get; set; }

        private Button _loadDataButton;
        private ListView _weatherList;

        private WeatherListAdapter _adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
 
            Bootstrapper.Initialize();

            ViewModel = Resolver.Resolve<MainViewModel>();

            SetContentView(Resource.Layout.Main);

           
            _loadDataButton = FindViewById<Button>(Resource.Id.LoadData);
            _weatherList = FindViewById<ListView>(Resource.Id.WeatherList);

            _adapter = new WeatherListAdapter();
            _weatherList.Adapter = _adapter;

            _loadDataButton.Click += LoadClicked;
            

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            ViewModel.WeatherData.CollectionChanged += WeatherData_CollectionChanged;
        }

        async void LoadClicked(object sender, EventArgs e)
        {
            await ViewModel.LoadData();
        }

        void WeatherData_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach(WeatherData item in e.NewItems)
                {
                    _adapter.Add(item);
                }
            }
            else if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (WeatherData item in e.OldItems)
                {
                    _adapter.Remove(item);
                }
            }

            _adapter.NotifyDataSetChanged();
        }

        void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "DataIsLoaded")
            {
                if (ViewModel.DataIsLoaded)
                {
                    _loadDataButton.Visibility = ViewStates.Gone;
                }
                else
                {
                    _loadDataButton.Visibility = ViewStates.Visible;
                }
            }
        }
    }
}

