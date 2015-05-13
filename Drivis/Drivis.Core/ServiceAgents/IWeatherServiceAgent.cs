using Drivis.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivis.Core.ServiceAgents
{
    public interface IWeatherServiceAgent
    {
        Task<List<WeatherData>> GetWeather(double lat, double lon);
    }
}
