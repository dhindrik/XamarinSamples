using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Drivis.Core.ViewModels
{
    public class WeatherItemModel : ViewModel
    {
        private DateTime _time;
        public DateTime Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                NotifyPropertyChanged("Time");
            }
        }

        private double _temperature;
        public double Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                _temperature = value;
                NotifyPropertyChanged("Temperature");
            }
        }      
    }
}
