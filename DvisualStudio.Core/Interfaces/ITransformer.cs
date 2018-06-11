using DvisualStudio.API.DTO;
using DvisualStudio.API.DTO.ConcertInfo;
using DvisualStudio.API.DTO.GooglePlaceInfoAPI;
using DvisualStudio.API.DTO.GooglePlacesTextSearchAPI;
using DvisualStudio.Core.Model;

namespace DvisualStudio.Core.Interfaces
{
    public interface ITransformer
    {
       Concert TransfromJsonEventToConcert(Event e);
       Place TransformTextPlaceToPlace(GoogleTextSearchPlace gtp);

       Place TransformAPINerabyPlaceToPlace(GooglePlace gp);

       DetailedPlace TransformDetailedPlaceToPlace(DetailedGooglePlace dgp, Place place);
    }
}
