using Newtonsoft.Json;

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
