using Newtonsoft.Json;

namespace DvisualStudio.API.DTO.GooglePlaceInfoAPI
{
    public class Review
    {
        [JsonProperty("author_name")]
        public string ReviewAuthor { get; set; }
        [JsonProperty("text")]
        public string ReviewText { get; set; }
    }
}
