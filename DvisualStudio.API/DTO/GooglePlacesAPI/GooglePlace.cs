using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.DTO
{
    public class GooglePlace
    {
        [JsonProperty("place_id")]
        public string Id { get; set; }
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; } 
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("rating")]
        public double Rating { get; set; }
        [JsonProperty("types")]
        public List<string> Types { get; set; }
        [JsonProperty("vicinity")]
        public string Address { get; set; }
        [JsonProperty("opening_hours")]
        public OpeningHours OpenHours { get; set; }
        [JsonProperty("price_level")]
        public int? PriceLevel { get; set; }
    }
}
