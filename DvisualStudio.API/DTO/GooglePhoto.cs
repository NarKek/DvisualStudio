using Newtonsoft.Json;

namespace DvisualStudio.API.DTO
{
    public class GooglePhoto
    {
        [JsonProperty("photo_reference")]
        public string PhotoReference { get; set; }
    }
}
