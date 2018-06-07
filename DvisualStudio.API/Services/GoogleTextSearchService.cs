using DvisualStudio.API.DTO;
using DvisualStudio.API.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DvisualStudio.API.Services
{
    public class GoogleTextSearchService : Service , ITextSearchService
    {
        private const string BaseUrl = "https://maps.googleapis.com/maps/api/place/textsearch/json";

        public List<GooglePlace> FindPlacesByTextInput(string input)
        {
            if (!input.ToLower().Contains("moscow"))
                input = input + " in Moscow";
            input = input.Replace(' ','+');

            string Url = BuildUrl(BaseUrl, new Dictionary<string, string>()
            {
                {"key",APIKey},
                {"query",input}
            });

            try
            {

            }
            catch (Exception)
            {
                MessageBox.show("sd");
            }
            using (HttpClient client = new HttpClient())
            {
                var strResult = client.GetStringAsync(Url).Result;

                var result = JsonConvert.DeserializeObject<GooglePlacesAPIRespone>(strResult);

                return result.Results;
            }
        }
    }
}
