using DvisualStudio.API.DTO;
using DvisualStudio.API.Interfaces;
using DvisualStudio.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.Services
{
    public class GooglePlacesService :Service,IGooglePlacesService
    {
        protected const string APIKey = "AIzaSyBxHX8WQ8KSknfNj-P_qZdF_EnYn2zkjlg";
        protected const string BaseUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json";
        public List<Place> FindNearestPlacesByCategory(string category)
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

            using (HttpClient client = new HttpClient())
            {
                var strResult = client.GetStringAsync(Url).Result;

                var result = JsonConvert.DeserializeObject<GooglePlacesAPIRespone>(strResult);
                return result.Results.Select(response => new Place
                {
                    Id = response.Id,
                    Name = response.Name,
                    Categories = response.Types,
                    Rating = response.Rating,
                    Address = response.Address,
                    Icon = response.Icon,
                    Location = response.Geometry.Location.Latitude.ToString()
                                + response.Geometry.Location.Longitude.ToString(),
                    OpenNow = response.OpenHours.OpenNow.ToString()
                }).ToList();
            }
        }
        public List<Place> DetailedSearchForNearestPlaces(string category, string rating,
                                                        string maxPriceLevel, string radius,string openNow)
        {
            Dictionary<string, string> addToMainUrl = new Dictionary<string, string>()
            {
                {"key",APIKey},
                {"category",category},
                {"rating",rating},
                {"maxprice",maxPriceLevel},
                {"location",GetLocationByIpService.GetLocation()},
                {"radius",radius},
                {"opennow",openNow}
            };

            string Url = BuildUrl(BaseUrl, addToMainUrl);

            using (HttpClient client = new HttpClient())
            {
                var strResult = client.GetStringAsync(Url).Result;
                var result = JsonConvert.DeserializeObject<GooglePlacesAPIRespone>(strResult);
                return result.Results.Select(response => new Place
                {
                    Id = response.Id,
                    Name = response.Name,
                    Categories = response.Types,
                    Rating = response.Rating,
                    Address = response.Address,
                    Icon = response.Icon,
                    Location = response.Geometry.Location.Latitude.ToString()
                                + response.Geometry.Location.Longitude.ToString(),
                    OpenNow = response.OpenHours.OpenNow.ToString()
                }).ToList();
            }
        }
    }
}
