using DvisualStudio.API.DTO.GooglePlaceInfoAPI;
using DvisualStudio.API.Interfaces;
using DvisualStudio.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.Services
{
    public class DetailedGooglePlaceService : Service, IDetailedPlaceInfoService
    {
        protected const string BaseUrl = "https://maps.googleapis.com/maps/api/place/details/json";

        public DetailedGooglePlace GetInfromaationAboutSelectedPlace(string place_id)
        {

            string Url = BuildUrl(BaseUrl, new Dictionary<string, string>()
            {
                {"key",APIKey},
                {"placeid",place_id}
            });

            using (HttpClient client = new HttpClient())
            {
                var strResult = client.GetStringAsync(Url).Result;

                var result = JsonConvert.DeserializeObject<DetailedGooglePlaceInfoResponse>(strResult).Result;
                return result;
            }
            
        }
    }
}