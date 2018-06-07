using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
