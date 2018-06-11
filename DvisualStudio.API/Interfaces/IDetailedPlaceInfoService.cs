using DvisualStudio.API.DTO.GooglePlaceInfoAPI;

namespace DvisualStudio.API.Interfaces
{
    public interface IDetailedPlaceInfoService
    {
       DetailedGooglePlace GetInformationAboutSelectedPlace(string place_id);
    }
}
