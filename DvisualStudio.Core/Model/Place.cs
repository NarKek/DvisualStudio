using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.Core.Model
{
    public class Place
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Categories { get; set; }
        public double Rating { get; set; } 
        public string Location { get; set; }
        public string Address { get; set; }
        public string Icon { get; set; }

        //private async Location GetUserLocation()
        //{
        //    string UserIp = "46.242.9.169";
        //    LocationAPI location;
        //    using (HttpClient client = new HttpClient())
        //    {
        //        string result = await client.GetStringAsync($"http://ipinfo.io/{UserIp}/geo");
        //        location = JsonConvert.DeserializeObject<LocationAPI>(result);
        //    }
        //}

        //private class LocationAPI
        //{
        //    [JsonProperty("loc")]
        //    public string Coordinates { get; set; }
        //}

    }
}
