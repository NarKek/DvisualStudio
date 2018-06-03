using DvisualStudio.API.DTO;
using DvisualStudio.Core.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.Services
{
    public class GetLocationByIpService : Service
    {
        public string GetLocation() 
        {
            string userIp = "46.242.9.169"; //GetUserIp.GetIp();
            string url = $"http://ipinfo.io/{userIp}/geo";
            using (HttpClient client = new HttpClient())
            {
                var strResult = client.GetStringAsync(url).Result;
                var result = JsonConvert.DeserializeObject<GetLocationAPI>(strResult);
                var answer = result.Location;
                return answer;
            }
        }
    }
}
