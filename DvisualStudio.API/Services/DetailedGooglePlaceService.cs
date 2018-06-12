using DvisualStudio.API.DTO.GooglePlaceInfoAPI;
using DvisualStudio.API.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;

namespace DvisualStudio.API.Services
{
    public class DetailedGooglePlaceService : Service, IDetailedPlaceInfoService
    {
        private const string BaseUrl = "https://maps.googleapis.com/maps/api/place/details/json";

        public DetailedGooglePlace GetInformationAboutSelectedPlace(string place_id)
        {

            string Url = BuildUrl(BaseUrl, new Dictionary<string, string>()
            {
                {"key",APIKey},
                {"placeid",place_id}
            });

            try
            {
                string strResult = string.Empty;
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        strResult = client.GetStringAsync(Url).Result;
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("Connection Error, check you internet connection and try again later");
                        return null;
                    }

                    var result = JsonConvert.DeserializeObject<DetailedGooglePlaceInfoResponse>(strResult).Result;
                    return result;
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