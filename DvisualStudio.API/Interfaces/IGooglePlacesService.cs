using DvisualStudio.API.DTO;
using DvisualStudio.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.Interfaces
{
    public interface IGooglePlacesService
    {
        List<Place> FindNearestPlacesByCategory(string category); 
    }
}
