using DvisualStudio.API.DTO;
using DvisualStudio.API.DTO.GooglePlacesTextSearchAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.Interfaces
{
    public interface ITextSearchService
    {
        List<GoogleTextSearchPlace> FindPlacesByTextInput(string input);
    }
}
