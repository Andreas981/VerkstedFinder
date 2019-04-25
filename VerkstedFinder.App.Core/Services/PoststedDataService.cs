using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using VerkstedFinder.App.Core.Models;

namespace VerkstedFinder.App.Core.Services
{
    // This class holds sample data used by some generated pages to show how they can be used.
    // TODO WTS: Delete this file once your app is using real data.
    public static class PoststedDataService
    {
        public static Uri poststeds = new Uri("http://localhost:44356/api/Poststeds");
        public static HttpClient _httpClient = new HttpClient();
        public static ObservableCollection<Poststed> Poststeds { get; } = new ObservableCollection<Poststed>();

        public static async Task<ObservableCollection<Poststed>> AllOrdersAsync()
        {
            // The following is order summary data
            var result = await _httpClient.GetAsync(poststeds);
            var json = await result.Content.ReadAsStringAsync();
            var poststed = JsonConvert.DeserializeObject<Poststed[]>(json);
            for (int i = 0; i < poststed.Length; i++)
            {
                Poststeds.Add(poststed[i]);
            }
            return Poststeds;

        }

        // TODO WTS: Remove this once your grid page is displaying real data
        public static ObservableCollection<Poststed> GetGridSampleData()
        {
            return Poststeds;
        }
    }
}
