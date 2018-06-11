using Newtonsoft.Json;

namespace DvisualStudio.API.DTO
{
    public class Geometry 
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }
}
