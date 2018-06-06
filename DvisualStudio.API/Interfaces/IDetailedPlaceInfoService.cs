using DvisualStudio.API.DTO.GooglePlaceInfoAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.Interfaces
{
    public interface IDetailedPlaceInfoService
    {
       DetailedGooglePlace GetInfromaationAboutSelectedPlace(string place_id);
    }
}
