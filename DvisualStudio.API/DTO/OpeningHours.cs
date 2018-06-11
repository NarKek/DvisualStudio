using Newtonsoft.Json;

namespace DvisualStudio.API.DTO
{
    public class OpeningHours
    {
        [JsonProperty("open_now")]
        public bool OpenNow { get; set; }
    } 
}
