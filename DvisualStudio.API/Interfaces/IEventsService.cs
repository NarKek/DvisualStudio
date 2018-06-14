using DvisualStudio.API.DTO.ConcertInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.Interfaces
{
    public interface IEventsService
    {
        IEnumerable<Event> GetEvents();
    }
}
