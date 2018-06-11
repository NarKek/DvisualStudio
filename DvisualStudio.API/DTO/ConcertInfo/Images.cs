using Newtonsoft.Json;

namespace DvisualStudio.API.DTO.ConcertInfo
{
    public class Images
    {
        [JsonProperty("afisha")]
        public string Afisha { get; set; }
        [JsonProperty("afisha_small")]
        public string SmallAfisha { get; set; }
    }
}
