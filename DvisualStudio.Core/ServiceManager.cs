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

        public async Task<IEnumerable<Place>> SearchWithParameters(int? priceLevel, string category, int? rating, bool? openNow)
        {
            if (category == null)
                category = "";
            if (priceLevel == null)
                priceLevel = 5;
            if (rating == null)
                rating = 0;
            if (openNow == null)
                openNow = false;
            var result = await Task.Factory.StartNew(() => GetPlacesByCategory(category));
            var query = result.Result.Where(p => p.Rating >= rating && p.PriceLevel != "" && int.Parse(p.PriceLevel) <= priceLevel && Convert.ToInt32(p.OpenNow) >= Convert.ToInt32(openNow));
            return query;
        }

        //public async Task<IEnumerable<Place>> TextSearch(string text)
        //{
        //    ITextSearchService textSearch = new GoogleTextSearchService();
        //    IEnumerable<GoogleTextSearchPlace> result = await Task.Factory.StartNew(() => textSearch.FindPlacesByTextInput(text));
        //
        //}
    }
}
