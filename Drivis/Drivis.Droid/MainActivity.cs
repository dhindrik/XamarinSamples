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
using System.Linq;

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

            _loadDataButton.Click += LoadClicked;
            

            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        async void LoadClicked(object sender, EventArgs e)
        {
            await ViewModel.LoadData();

            _adapter = new WeatherListAdapter(ViewModel.WeatherData.ToList());
            _weatherList.Adapter = _adapter;
        }

       

        void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "DataIsLoaded")
            {
                if (ViewModel.DataIsLoaded)
                {
                    _loadDataButton.Visibility = ViewStates.Gone;
                    _weatherList.Visibility = ViewStates.Visible;
                }
                else
                {
                    _loadDataButton.Visibility = ViewStates.Visible;
                }
            }
        }
    }
}

