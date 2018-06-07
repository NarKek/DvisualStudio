using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvisualStudio.Core.Model
{
    public class Place
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Categories { get; set; }//
        public double Rating { get; set; }//
        public string Location { get; set; }
        public string Address { get; set; }
        public string Icon { get; set; }
        public string OpenNow { get; set; }//
        public string PriceLevel { get; set; }//
    }
}
