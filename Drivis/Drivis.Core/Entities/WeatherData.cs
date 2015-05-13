using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivis.Core.Entities
{
    public class WeatherData
    {
        [JsonProperty("validTime")]
        public DateTime Time { get; set; }

        [JsonProperty("t")]
        public double Temperature { get; set; }
    }
}
