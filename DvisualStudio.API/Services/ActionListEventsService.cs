using DvisualStudio.API.DTO.ConcertInfo;
using DvisualStudio.API.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.API.Services
{
    public class ActionListEventsService : IEventsService
    {
        private List<T> RestoreList<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<List<T>>(jsonReader);
                }
            }
        }

        public IEnumerable<Event> GetEvents()
        {
            return RestoreList<Event>("Data\\concerts.json");
        }
    }
}
