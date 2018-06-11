using DvisualStudio.API.DTO;
using System;
using System.Collections.Generic;

namespace DvisualStudio.Core.Model
{
    public class Concert
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ClubName { get; set; }
        public string Address { get; set; }
        public Location ClubLocation { get; set; }
        public string ClubTelephone { get; set; }
        public string Icon { get; set; }
        public string SmallAfisha { get; set; }
        public double Rating { get; set; }

        public Concert()
        {
            Rating = -1;
        }
    }
}
