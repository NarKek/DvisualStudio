using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.DTO.GooglePlaceInfoAPI
{
    public class DetailedGooglePlaceInfoResponse
    {
        [JsonProperty("result")]
        public DetailedGooglePlace Result { get; set; }
    }
}
