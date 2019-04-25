using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VerkstedFinder.App.Core.Models;

namespace VerkstedFinder.App.DataAccess
{
    class Workshops
    {
        readonly HttpClient _httpClient = new HttpClient();
        static readonly Uri poststesBaseUri = new Uri("http://localhost:59952/api/Workshops");

        public async Task<Workshop[]> GetWorkshopsAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(poststesBaseUri);
            string json = await result.Content.ReadAsStringAsync();
            Workshop[] workshops = JsonConvert.DeserializeObject<Workshop[]>(json);

            return workshops;
        }
       
    }
}
