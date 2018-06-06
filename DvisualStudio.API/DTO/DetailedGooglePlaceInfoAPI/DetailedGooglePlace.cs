using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.DTO.GooglePlaceInfoAPI
{
    public class DetailedGooglePlace
    {
        [JsonProperty("place_id")]
        public string Id { get; set; }
        [JsonProperty("formatted_addres")]
        public string Address { get; set; }
        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("rating")]
        public double Rating { get; set; }
        [JsonProperty("types")]
        public List<string> Categories { get; set; }
        [JsonProperty("opening_hours")]
        public OpeningHours OpenHours { get; set; }

        [JsonProperty("website")]
        public string WebSite { get; set; }
        [JsonProperty("reviews")]
        public List<Review> Reviews { get; set; }
        [JsonProperty("formatted_phone_number")]
        public string PhoneNumber { get; set; }
    }
}
