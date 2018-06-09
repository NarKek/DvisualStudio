using DvisualStudio.API.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Controls;

namespace DvisualStudio.API.Services
{
    public class GooglePhotosService : Service, IPhotosService
    {
        private const string MainUrl = "https://maps.googleapis.com/maps/api/place/photo";
        public string GetImageByReference(string photoReference,string maxHeight,string maxWidth)
        {
            string Url = BuildUrl(MainUrl, new Dictionary<string, string>()
            {
                { "key",APIKey },
                { "photoreference", photoReference},
                { "maxheight", maxHeight},
                { "maxwidth",maxWidth}
            });
            return Url;
        }
    }
}
