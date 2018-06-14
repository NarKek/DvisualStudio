using DvisualStudio.API.DTO.GooglePlacesTextSearchAPI;
using DvisualStudio.API.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;

namespace DvisualStudio.API.Services
{
    public class GoogleTextSearchService : Service, ITextSearchService
    {
        private const string BaseUrl = "https://maps.googleapis.com/maps/api/place/textsearch/json";

        public List<GoogleTextSearchPlace> FindPlacesByTextInput(string input)
        {
            if (!input.ToLower().Contains("moscow"))
                input = input + " in Moscow";
            input = input.Replace(' ', '+');

            string Url = BuildUrl(BaseUrl, new Dictionary<string, string>()
            {
                {"key",APIKey},
                {"query",input}
            });

            try
            {
                string strResult=string.Empty;
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        strResult = client.GetStringAsync(Url).Result;

                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("Connection Error, check you internet connection and try again later");
                        return new List<GoogleTextSearchPlace>();
                    }

                    var result = JsonConvert.DeserializeObject<GoogleTextSearchResponse>(strResult);
                    return result.Results;
                }

            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Connection Error, check you internet connection and try again later");
                return null;
            }
        }
    }
}
