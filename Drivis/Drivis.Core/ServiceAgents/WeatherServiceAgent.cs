using Drivis.Core.Entities;
using Drivis.Core.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivis.Core.ServiceAgents
{
    public class WeatherServiceAgent : IWeatherServiceAgent
    {
        private IRestClient _restClient;

        public WeatherServiceAgent(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<List<WeatherData>> GetWeather(double lat, double lon)
        {


            var url = "http://opendata-download-metfcst.smhi.se/api/category/pmp1.5g/version/1/geopoint/lat/" + lat.ToString("0.0000") + "/lon/" + lon.ToString("0.0000") + "/data.json";

            var result = await _restClient.GetAsync<WeatherForecast>(url);

            return result.WeatherData;
        }
    }
}
