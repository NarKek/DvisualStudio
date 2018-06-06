using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
