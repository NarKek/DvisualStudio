using Newtonsoft.Json;
using System.Collections.Generic;

namespace DvisualStudio.API.DTO
{
    public class GooglePlacesAPIRespone
    {
        [JsonProperty("results")] 
        public List<GooglePlace> Results { get; set; }
    }
}
