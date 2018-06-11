using Newtonsoft.Json;

namespace DvisualStudio.API.DTO.ConcertInfo
{
    public class Club
    {
        [JsonProperty("club_name")]
        public string Name { get; set; }
        [JsonProperty("club_adress")]
        public string Adress { get; set; }
        [JsonProperty("club_geo")]
        public string Location { get; set; }
        [JsonProperty("club_phone")]
        public string Telephone { get; set; }
    }
}
