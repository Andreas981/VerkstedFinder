using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VerkstedFinder.App.DataAccess
{
    class Coordinates
    {

        readonly HttpClient _httpClient = new HttpClient();
        static readonly String coordsBaseUriStart = "https://api.opencagedata.com/geocode/v1/json?q=";
        static readonly String coordsBaseUriEnd = "&key=fc90830d3c42438f9c36cd79dac3afbf&language=nb&pretty=1&no_annotations=1";
        public async Task<String> GetCoordinatesAsync(String address)
        {
            String uriAddress = address.Replace(" ", "%20");
            Uri baseUri = new Uri(coordsBaseUriStart + uriAddress + coordsBaseUriEnd);

            HttpResponseMessage result = await _httpClient.GetAsync(baseUri);
            string json = await result.Content.ReadAsStringAsync();
            JObject jResponse = JObject.Parse(json);
            JArray array = (JArray)jResponse["results"];
            JObject resultObject = (JObject)array[0];
            JObject geometry = (JObject)resultObject["geometry"];

            String lat = Convert.ToString((JObject)geometry["lat"].ToString());
            String lng = Convert.ToString((JObject)geometry["lng"].ToString());

            String latLong = lat + "," + lng;

            return latLong;
        }
    }
}
