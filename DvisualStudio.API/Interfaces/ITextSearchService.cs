using DvisualStudio.API.DTO.GooglePlacesTextSearchAPI;
using System.Collections.Generic;

namespace DvisualStudio.API.Interfaces
{
    public interface ITextSearchService
    {
        List<GoogleTextSearchPlace> FindPlacesByTextInput(string input);
    }
}
