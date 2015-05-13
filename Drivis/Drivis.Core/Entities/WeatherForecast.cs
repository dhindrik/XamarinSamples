using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivis.Core.Entities
{
    public class WeatherForecast
    {
        [JsonProperty("timeseries")]
        public List<WeatherData> WeatherData { get; set; }
    }
}
