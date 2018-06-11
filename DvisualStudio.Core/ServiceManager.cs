using DvisualStudio.API.DTO.GooglePlacesTextSearchAPI;
using DvisualStudio.API.Interfaces;
using DvisualStudio.API.Services;
using DvisualStudio.Core.Helpers.Transformers;
using DvisualStudio.Core.Interfaces;
using DvisualStudio.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.Core
{
    public class ServiceManager
    {
        private Dictionary<string, int> _priceLevels = new Dictionary<string, int>
        {
            { "free", 0 },
            { "cheap", 1 },
            { "moderate", 2 },
            { "expensive", 3 },
            { "very expensive", 4 },
            { "unknown", 5 }
        };

        private Dictionary<string, string> _categories = new Dictionary<string, string>
        {
            { "restaurants", "restaurant" },
            { "bars", "bar" },
            { "cinemas", "movie_theater" },
            { "parks", "park" }
        };

        public async Task<IEnumerable<Concert>> GetConcerts()
        {
            IConcertRepository repo = await Task.Factory.StartNew(() => Factory.Instance.GetRepository());
            return repo.Concerts;
        }

        public async Task<IEnumerable<Place>> GetPlacesByCategory(string category)
        {
            IPlacesService placesService = new GooglePlacesService();
            var result = await Task.Factory.StartNew(() => placesService.FindNearestPlacesByCategory(category));
            List<Place> places = new List<Place>();
            foreach (var r in result)
            {
                places.Add(Transformer.TransformGooglePlaceToPlace(r));
            }
            return places;
        }

        public async Task<DetailedPlace> GetDetailedPlace(Place place)
        {
            IDetailedPlaceInfoService dps = new DetailedGooglePlaceService();
            var result = await Task.Factory.StartNew(() => dps.GetInformationAboutSelectedPlace(place.Id));
            return Transformer.TransformGoogleDetailedPlaceToPlace(result, place);
        }

        public async Task<IEnumerable<Place>> SearchWithParameters(string priceLevel, string category, int? rating, string openNow)
        {
            int price;
            bool open = true;
            string cat;
            if (category == null)
                cat = "";
            else
                cat = _categories[category];
            if (priceLevel == null)
                price = 5;
            else
                price = _priceLevels[priceLevel];
            if (rating == null)
                rating = 0;
            if (openNow == null)
                open = false;
            var result = await Task.Factory.StartNew(() => GetPlacesByCategory(cat));
            var query = result.Result.Where(p => p.Rating >= rating && int.Parse(p.PriceLevel) <= price && Convert.ToInt32(p.OpenNow) >= Convert.ToInt32(open));
            return query;
        }

        //public async Task<IEnumerable<Place>> TextSearch(string text)
        //{
        //    ITextSearchService textSearch = new GoogleTextSearchService();
        //    IEnumerable<GoogleTextSearchPlace> result = await Task.Factory.StartNew(() => textSearch.FindPlacesByTextInput(text));
        //    List<Place> places = new List<Place>();
        //    foreach (var gtp in result)
        //    {
        //        places.Add(Transformer.TransformTextPlaceToPlace(gtp));
        //    }
        //    return places;
        //}
    }
}
