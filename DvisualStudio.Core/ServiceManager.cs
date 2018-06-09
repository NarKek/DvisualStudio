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
        //public IEnumerable<Place> GetPlaces(string category)
        //{
        //    IPlacesService service = new GooglePlacesService();
        //    //IEnumerable<> service.FindNearestPlacesByCategory(category);
        //}

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

        public event Action ConcertsLoaded;
    }
}
