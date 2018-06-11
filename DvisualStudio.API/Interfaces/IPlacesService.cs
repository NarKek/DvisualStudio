using DvisualStudio.API.DTO;
using System.Collections.Generic;

namespace DvisualStudio.API.Interfaces
{
    public interface IPlacesService
    {
        List<GooglePlace> FindNearestPlacesByCategory(string category);
        List<GooglePlace> DetailedSearchForNearestPlaces(Dictionary<string,string> addToMainUrl);
    }
}
