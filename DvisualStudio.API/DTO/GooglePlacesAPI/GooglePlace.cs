using Newtonsoft.Json;
using System.Collections.Generic;

namespace DvisualStudio.API.DTO
{
    public class GooglePlace
    {
        [JsonProperty("place_id")]
        public string PlaceId { get; set; }
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("rating")]
        public double Rating { get; set; }
        [JsonProperty("types")]
        public List<string> Categories { get; set; }
        [JsonProperty("vicinity")]
        public string Address { get; set; }
        [JsonProperty("opening_hours")]
        public OpeningHours OpenHours { get; set; }
        [JsonProperty("price_level")]
        public int? PriceLevel { get; set; }
        [JsonProperty("photos")]
        public List<GooglePhoto> GooglePhotos { get; set; }
    }
}
