using DvisualStudio.API.DTO.ConcertInfo;
using DvisualStudio.Core.Helpers;
using DvisualStudio.Core.Helpers.Transformers;
using DvisualStudio.Core.Interfaces;
using DvisualStudio.Core.Model;
using System.Collections.Generic;

namespace DvisualStudio.Core
{
    public class JSONConcertRepository : IConcertRepository
    {
        public IEnumerable<Concert> Concerts { get; }

        public JSONConcertRepository()
        {
            ITransformer transformer = new GoogleTransformer(); 

            JSONReader jsr = new JSONReader();
            List<Concert> buffer = new List<Concert>();

            IEnumerable<Event> events = jsr.RestoreList<Event>("Data\\concerts.json");

            foreach (var e in events)
            {
                buffer.Add(transformer.TransfromJsonEventToConcert(e));
            }
            Concerts = buffer;
        }
    }
}
