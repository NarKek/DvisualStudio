using DvisualStudio.API.Interfaces;
using System.Collections.Generic;

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
