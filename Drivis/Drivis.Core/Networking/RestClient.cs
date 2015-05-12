using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Drivis.Core.Networking
{
    public class RestClient : IRestClient
    {
        public async Task<T> GetAsync<T>(string uri)
        {
            var client = new HttpClient();

            var json = await client.GetStringAsync(uri);

            var result = JsonConvert.DeserializeObject<T>(json);

            return result;
        }
    }
}
