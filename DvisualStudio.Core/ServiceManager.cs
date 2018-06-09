using DvisualStudio.API.Interfaces;
using DvisualStudio.API.Services;
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

        public event Action ConcertsLoaded;
    }
}
