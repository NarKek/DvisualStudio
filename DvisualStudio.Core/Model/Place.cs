using System.Collections.Generic;


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
        public bool? OpenNow { get; set; }//
        public string PriceLevel { get; set; }//
        public string PriceString { get; set; }
        public string Photo { get; set; }
        public string PhotoReference { get; set; }
    }
}
