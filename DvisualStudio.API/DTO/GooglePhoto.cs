using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.DTO
{
    public class GooglePhoto
    {
        [JsonProperty("photo_reference")]
        public string PhotoReference { get; set; }
    }
}
