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
    class Poststeds
    {
        readonly HttpClient _httpClient = new HttpClient();
        static readonly Uri poststesBaseUri = new Uri("http://localhost:59952/api/Poststeds");

        public async Task<Poststed[]> GetPoststedsAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(poststesBaseUri);
            string json = await result.Content.ReadAsStringAsync();
            Poststed[] poststeds = JsonConvert.DeserializeObject<Poststed[]>(json);

            return poststeds;
        }
    }
}
