using Newtonsoft.Json;

namespace DvisualStudio.API.DTO.GooglePlaceInfoAPI
{
    public class DetailedGooglePlaceInfoResponse
    {
        [JsonProperty("result")]
        public DetailedGooglePlace Result { get; set; }
    }
}
