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
    class Users
    {
        readonly HttpClient _httpClient = new HttpClient();
        static readonly Uri poststesBaseUri = new Uri("http://localhost:59952/api/Users");

        public async Task<User[]> GetUsersAsync()
        {
            HttpResponseMessage result = await _httpClient.GetAsync(poststesBaseUri);
            string json = await result.Content.ReadAsStringAsync();
            User[] users = JsonConvert.DeserializeObject<User[]>(json);

            return users;
        }

    }
}
