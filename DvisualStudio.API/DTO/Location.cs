using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.DTO
{
    public class Location
    {
        [JsonProperty("lat")] 
        public double Latitude { get; set; }
        [JsonProperty("lng")]
        public double Longitude { get; set; } 
    }
}
