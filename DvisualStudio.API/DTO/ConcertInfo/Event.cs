using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.DTO.ConcertInfo
{
    public class Event
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }
        [JsonProperty("club")]
        public Club Club { get; set; }
        [JsonProperty("images")]
        public Images Images { get; set; }
        [JsonProperty("genres")]
        public Genres Genres { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
