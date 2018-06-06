using DvisualStudio.API.DTO;
using DvisualStudio.API.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DvisualStudio.API.Services
{
    public class GooglePlacesService : Service, IPlacesService
    {
        private const string BaseUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";
        public List<GooglePlace> FindNearestPlacesByCategory(string category)
        {
            string radius = "1000";
            string location = GetLocationByIpService.GetLocation();


            string Url = BuildUrl(BaseUrl, new Dictionary<string, string>()
            {
                {"key",APIKey},
                {"type",category},
                {"location",location},
                {"radius",radius},
                {"opennow","true"}
            });

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var strResult = client.GetStringAsync(Url).Result;

                    var result = JsonConvert.DeserializeObject<GooglePlacesAPIRespone>(strResult);
                    return result.Results;
                }

            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Connection Error, check you internet connection and try again later");
                return null;
            }

        }
        public List<GooglePlace> DetailedSearchForNearestPlaces(Dictionary<string, string> addToMainUrl)
        {
            addToMainUrl.Add("key", APIKey);
            addToMainUrl.Add("location", GetLocationByIpService.GetLocation());
            addToMainUrl.Add("radius", "1000");

            string Url = BuildUrl(BaseUrl, addToMainUrl);

            using (HttpClient client = new HttpClient())
            {
                var strResult = client.GetStringAsync(Url).Result;
                var result = JsonConvert.DeserializeObject<GooglePlacesAPIRespone>(strResult);
                return result.Results;
            }
        }
    }
}
