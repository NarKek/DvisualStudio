using DvisualStudio.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.Interfaces
{
    public interface IPlacesService
    {
        List<GooglePlace> FindNearestPlacesByCategory(string category);
        List<GooglePlace> DetailedSearchForNearestPlaces(Dictionary<string,string> addToMainUrl);
    }
}
