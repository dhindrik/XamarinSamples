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
using Drivis.Core.Entities;

namespace Drivis.Droid.Adapters
{
    public class WeatherListAdapter : BaseAdapter
    {
        private List<WeatherData> _weatherData;
        
        public WeatherListAdapter()
        {
            _weatherData = new List<WeatherData>();
        }

        public void Add(WeatherData item)
        {
            _weatherData.Add(item);
        }
        public void Add(List<WeatherData> items)
        {
            _weatherData.AddRange(items);
        }

        public void Remove(WeatherData item)
        {
            _weatherData.Remove(item);
        }


        public override int Count
        {
            get { return _weatherData.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            throw new NotImplementedException();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var inflater = (LayoutInflater)Application.Context.GetSystemService(Service.LayoutInflaterService);
            var view = inflater.Inflate(Resource.Layout.WeatherRow, null);

            var time = view.FindViewById<TextView>(Resource.Id.Time);
            var temperature = view.FindViewById<TextView>(Resource.Id.Temperature);

            var item = _weatherData[position];

            time.Text = item.Time.ToString();
            temperature.Text = string.Format("{0}° C");

            return view;
        }
    }
}