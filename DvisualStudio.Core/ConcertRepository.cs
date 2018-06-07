using DvisualStudio.API.DTO.ConcertInfo;
using DvisualStudio.Core.Helpers;
using DvisualStudio.Core.Helpers.Transformers;
using DvisualStudio.Core.Interfaces;
using DvisualStudio.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.Core
{
    public class ConcertRepository : IRepository
    {
        public IEnumerable<Concert> Concerts { get; }

        public ConcertRepository()
        {
            JSONReader jsr = new JSONReader();
            List<Concert> buffer = new List<Concert>();
            EventToConcertTransformer ETCTransform = new EventToConcertTransformer();
            IEnumerable<Event> events = jsr.RestoreList<Event>("Data\\concerts.json");
            foreach (var e in events)
            {
                buffer.Add(ETCTransform.Transfrom(e));
            }
            Concerts = buffer;
        }
    }
}
