using DvisualStudio.API.DTO;
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
    public static class GetLocationByIpService
    {
        public static string GetLocation() 
        {
            string url = $"http://ipinfo.io/?token=60845147772721/geo";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var strResult = client.GetStringAsync(url).Result;
                    var result = JsonConvert.DeserializeObject<GetLocationAPI>(strResult);
                    var answer = result.Location;
                    return answer;
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
