using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DvisualStudio.Core.Helpers
{
    public class JSONReader
    {
        public List<T> RestoreList<T>(string fileName)
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
    }
}
