using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.DTO.GooglePlacesTextSearchAPI
{
    public class GoogleTextSearchPlace
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
        [JsonProperty("formatted_address")]
        public string Address { get; set; }
        [JsonProperty("opening_hours")]
        public OpeningHours OpenHours { get; set; }
        [JsonProperty("photos")]
        public List<GooglePhoto> GooglePhotos { get; set; }
    }
}
